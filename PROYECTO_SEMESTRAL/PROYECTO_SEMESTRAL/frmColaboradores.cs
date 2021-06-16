using System.Windows.Forms;
using BibliotecaDeClases;
using Dominio;

namespace PROYECTO_SEMESTRAL
{
    public partial class frmColaboradores : Form
    {
        public frmColaboradores()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            Colaborador colaborador = new Colaborador();

            if (txtIdColaborador.Text != "")
            {
                colaborador.ID = txtIdColaborador.Text;

                if (txtBanco.Text != "")
                {
                    colaborador.Banco = txtBanco.Text;

                    if (txtDomicilio.Text != "")
                    {
                        colaborador.Domicilio = txtDomicilio.Text;

                        if (txtNumeroDeCueta.Text != "")
                        {
                            colaborador.NumCuenta = txtNumeroDeCueta.Text;

                            if (txtNombre.Text!="")
                            {
                                colaborador.Nombre = txtNombre.Text;

                                if (txtTelefono.Text!="")
                                {
                                    colaborador.Telefono = txtTelefono.Text;

                                    ModeloDUsuario obj = new ModeloDUsuario();

                                    if (obj.InsertarColaborador(colaborador))
                                        MessageBox.Show("Insercion Exitosa");
                                    else
                                        MessageBox.Show("No se pudo realizar la insercion");

                                }
                                else
                                    MessageBox.Show("El campo TELEFONO no puede ir vacio");
                            }
                            else
                                MessageBox.Show("El campo NOMBRE no puede ir vacio");
                        }
                        else
                            MessageBox.Show("El campo NUMERO DE CUENTA no puede ir vacio");
                    }
                    else
                        MessageBox.Show("El campo DOMICILIO no puede ir vacio");
                }
                else
                    MessageBox.Show("El campo BANCO no puede ir vacio");
            }
            else
                MessageBox.Show("El campo ID COLABORADOR no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            Colaborador colaborador = new Colaborador();

            if (txtIdColaborador.Text != "")
            {
                colaborador.ID = txtIdColaborador.Text;

                if (txtBanco.Text != "")
                {
                    colaborador.Banco = txtBanco.Text;

                    if (txtDomicilio.Text != "")
                    {
                        colaborador.Domicilio = txtDomicilio.Text;

                        if (txtNumeroDeCueta.Text != "")
                        {
                            colaborador.NumCuenta = txtNumeroDeCueta.Text;

                            if (txtNombre.Text != "")
                            {
                                colaborador.Nombre = txtNombre.Text;

                                if (txtTelefono.Text != "")
                                {
                                    colaborador.Telefono = txtTelefono.Text;

                                    ModeloDUsuario obj = new ModeloDUsuario();

                                    if (obj.ActualizarColaborador(colaborador))
                                        MessageBox.Show("Los cambios se han guardado exitosamente");
                                    else
                                        MessageBox.Show("No se pudo realizar ningun cambio");

                                }
                                else
                                    MessageBox.Show("El campo TELEFONO no puede ir vacio");
                            }
                            else
                                MessageBox.Show("El campo NOMBRE no puede ir vacio");
                        }
                        else
                            MessageBox.Show("El campo NUMERO DE CUENTA no puede ir vacio");
                    }
                    else
                        MessageBox.Show("El campo DOMICILIO no puede ir vacio");
                }
                else
                    MessageBox.Show("El campo BANCO no puede ir vacio");
            }
            else
                MessageBox.Show("El campo ID COLABORADOR no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void Vaciar()
        {
            txtIdColaborador.Text = "";
            txtBanco.Text = "";
            txtDomicilio.Text = "";
            txtNumeroDeCueta.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtIdColaborador.Enabled = true;
        }

        private void ActualizarData()
        {
            ModeloDUsuario obj = new ModeloDUsuario();
            dataGridView1.DataSource = obj.MostarColaborador();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtIdColaborador.Text = dataGridView1.SelectedCells[0].Value.ToString();
                txtBanco.Text = dataGridView1.SelectedCells[1].Value.ToString();
                txtDomicilio.Text = dataGridView1.SelectedCells[2].Value.ToString();
                txtNumeroDeCueta.Text = dataGridView1.SelectedCells[3].Value.ToString();
                txtNombre.Text = dataGridView1.SelectedCells[4].Value.ToString();
                txtTelefono.Text = dataGridView1.SelectedCells[5].Value.ToString();

                txtIdColaborador.Enabled = false;
            }
        }

        private void frmColaboradores_Load(object sender, System.EventArgs e)
        {
            ActualizarData();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            Colaborador colaborador = new Colaborador();

            if (txtIdColaborador.Text != "")
            {
                colaborador.ID = txtIdColaborador.Text;

                ModeloDUsuario obj = new ModeloDUsuario();

                if (obj.EliminarColaborador(colaborador))
                    MessageBox.Show("Se han eliminado al colaborador correctamente");
                else
                    MessageBox.Show("No se pudo realizar ningun cambio");
            }
            else
                MessageBox.Show("El campo Codigo no puede ir vacio");

            Vaciar();
            ActualizarData();
        }
    }
}
