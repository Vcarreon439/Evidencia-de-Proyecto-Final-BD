using System;
using System.Windows.Forms;
using BibliotecaDeClases;
using Dominio;

namespace PROYECTO_SEMESTRAL
{
    public partial class frmProyecto : Form
    {
        public frmProyecto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            Proyecto proyecto = new Proyecto();

            if (txtCodigoCliente.Text != "")
            {
                proyecto.codCliente = txtCodigoCliente.Text;

                if (txtCodigoProyecto.Text != "")
                {
                    proyecto.codProyecto= txtCodigoProyecto.Text;

                    if (txtCosto.Text != "")
                    {
                        proyecto.Costo = Convert.ToDouble(txtCosto.Text);

                        if (txtDescripcion.Text != "")
                        {
                            proyecto.Descripcion = txtDescripcion.Text;
                            proyecto.inicio = $"{dtpInicio.Value.Month}-{dtpInicio.Value.Day}-{dtpInicio.Value.Year}";
                            proyecto.fin = $"{dtpFin.Value.Month}-{dtpFin.Value.Day}-{dtpFin.Value.Year}";

                            ModeloDUsuario objDUsuario = new ModeloDUsuario();

                            if (objDUsuario.InsertarProyecto(proyecto))
                                MessageBox.Show("Insercion Exitosa");
                            else
                                MessageBox.Show("No se pudo realizar la insercion");

                        }
                        else
                            MessageBox.Show("El campo Descripcion no puede ir vacio");
                    }
                    else
                        MessageBox.Show("El campo Costo no puede ir vacio");
                }
                else
                    MessageBox.Show("El campo Codigo del proyecto no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo Cliente no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void frmProyecto_Load(object sender, System.EventArgs e)
        {
            ActualizarData();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Vaciar()
        {
            txtCodigoCliente.Text = "";
            txtCodigoProyecto.Text = "";
            txtDescripcion.Text = "";
            txtCosto.Text = "";
            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today;

            txtCodigoCliente.Enabled = true;
            txtCodigoProyecto.Enabled = true;
        }

        private void ActualizarData()
        {
            ModeloDUsuario Obj = new ModeloDUsuario();
            dataGridView1.DataSource = Obj.MostrarProyecto();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            Proyecto proyecto = new Proyecto();

            if (txtCodigoCliente.Text != "")
            {
                proyecto.codCliente = txtCodigoCliente.Text;

                if (txtCodigoProyecto.Text != "")
                {
                    proyecto.codProyecto = txtCodigoProyecto.Text;

                    if (txtCosto.Text != "")
                    {
                        proyecto.Costo = Convert.ToDouble(txtCosto.Text);

                        if (txtDescripcion.Text != "")
                        {
                            proyecto.Descripcion = txtDescripcion.Text;
                            proyecto.inicio = $"{dtpInicio.Value.Month}-{dtpInicio.Value.Day}-{dtpInicio.Value.Year}";
                            proyecto.fin = $"{dtpFin.Value.Month}-{dtpFin.Value.Day}-{dtpFin.Value.Year}";

                            ModeloDUsuario objDUsuario = new ModeloDUsuario();

                            if (objDUsuario.ActualizarProyecto(proyecto))
                                MessageBox.Show("Los cambios han sido realizados exitosamente");
                            else
                                MessageBox.Show("No se pudo realizar ningun cambio");

                        }
                        else
                            MessageBox.Show("El campo Descripcion no puede ir vacio");
                    }
                    else
                        MessageBox.Show("El campo Costo no puede ir vacio");
                }
                else
                    MessageBox.Show("El campo Codigo del proyecto no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo Cliente no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            Proyecto proyecto = new Proyecto();

            if (txtCodigoProyecto.Text != "")
            {
                proyecto.codProyecto = txtCodigoProyecto.Text;

                ModeloDUsuario objDUsuario = new ModeloDUsuario();

                if (objDUsuario.EliminarProyecto(proyecto))
                    MessageBox.Show("Se ha eliminado el registro exitosamente");
                else
                    MessageBox.Show("No se pudo realizar ningun cambio");
            }
            else
                MessageBox.Show("El campo Codigo Proyecto no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtCodigoProyecto.Text = dataGridView1.SelectedCells[0].Value.ToString();
                dtpInicio.Value = DateTime.Parse(dataGridView1.SelectedCells[1].Value.ToString());
                dtpFin.Value = DateTime.Parse(dataGridView1.SelectedCells[2].Value.ToString());
                txtDescripcion.Text = dataGridView1.SelectedCells[3].Value.ToString();
                txtCosto.Text = dataGridView1.SelectedCells[4].Value.ToString();
                txtCodigoCliente.Text = dataGridView1.SelectedCells[5].Value.ToString();

                txtCodigoProyecto.Enabled = false;
                txtCodigoCliente.Enabled = false;
            }
        }
    }
}
