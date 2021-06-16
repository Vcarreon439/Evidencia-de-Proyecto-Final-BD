using System.Windows.Forms;
using BibliotecaDeClases;
using Dominio;

namespace PROYECTO_SEMESTRAL
{
    public partial class frmProyectoColaboradoes : Form
    {
        public frmProyectoColaboradoes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            ProyectoColaboradores colaborador = new ProyectoColaboradores();

            if (txtIdColaborador.Text != "")
            {
                colaborador.IdColaborador = txtIdColaborador.Text;

                if (txtCodigoProyecto.Text != "")
                {
                    colaborador.CodProyecto = txtCodigoProyecto.Text;
                    
                    ModeloDUsuario obj = new ModeloDUsuario();

                    if (obj.InsertarProyectoColaboradores(colaborador))
                        MessageBox.Show("Insercion Exitosa");
                    else
                        MessageBox.Show("No se pudo realizar la insercion");

                }
                else
                    MessageBox.Show("El campo BANCO no puede ir vacio");
            }
            else
                MessageBox.Show("El campo ID COLABORADOR no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void ActualizarData()
        {
            ModeloDUsuario obj = new ModeloDUsuario();
            dataGridView1.DataSource = obj.MostrarProyectoColaboradores();
        }

        private void Vaciar()
        {
            txtIdColaborador.Text = "";
            txtCodigoProyecto.Text = "";
            txtIdColaborador.Enabled = true;
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            ProyectoColaboradores colaborador = new ProyectoColaboradores();

            if (txtIdColaborador.Text != "")
            {
                colaborador.IdColaborador = txtIdColaborador.Text;

                if (txtCodigoProyecto.Text != "")
                {
                    colaborador.CodProyecto = txtCodigoProyecto.Text;

                    ModeloDUsuario obj = new ModeloDUsuario();

                    if (obj.ActualizarProyectoColaboradores(colaborador))
                        MessageBox.Show("Los cambios se han realizado de manera exitosa");
                    else
                        MessageBox.Show("No se pudo realizar ningun cambio");

                }
                else
                    MessageBox.Show("El campo Codigo Proyecto no puede ir vacio");
            }
            else
                MessageBox.Show("El campo ID COLABORADOR no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            ProyectoColaboradores colaborador = new ProyectoColaboradores();

            if (txtIdColaborador.Text != "")
            {
                colaborador.IdColaborador = txtIdColaborador.Text;

                if (txtCodigoProyecto.Text != "")
                {
                    colaborador.CodProyecto = txtCodigoProyecto.Text;

                    ModeloDUsuario obj = new ModeloDUsuario();

                    if (obj.EliminarProyectoColaboradores(colaborador))
                        MessageBox.Show("Se ha eliminado el registro de manera exitosa");
                    else
                        MessageBox.Show("No se pudo realizar ningun cambio");

                }
                else
                    MessageBox.Show("El campo Codigo Proyecto no puede ir vacio");
            }
            else
                MessageBox.Show("El campo ID COLABORADOR no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void frmProyectoColaboradoes_Load(object sender, System.EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ActualizarData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtIdColaborador.Text = dataGridView1.SelectedCells[0].Value.ToString();
                txtCodigoProyecto.Text = dataGridView1.SelectedCells[1].Value.ToString();
                txtIdColaborador.Enabled = false;
            }
        }
    }
}
