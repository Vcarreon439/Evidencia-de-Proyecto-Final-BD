using System;
using System.Windows.Forms;
using BibliotecaDeClases;
using Dominio;

namespace PROYECTO_SEMESTRAL
{
    public partial class frmTipo : Form
    {
        public frmTipo()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TipoProyecto tipo = new TipoProyecto();

            if (txtCodigoTipo.Text != "")
            {
                tipo.codigo = txtCodigoTipo.Text;

                if (txtDescripcion.Text != "")
                {
                    tipo.descripcion = txtDescripcion.Text;

                    ModeloDUsuario objDUsuario = new ModeloDUsuario();

                    if (objDUsuario.InsertarTipo(tipo))
                        MessageBox.Show("Insercion Exitosa");
                    else
                        MessageBox.Show("No se pudo realizar la insercion");

                }
                else
                    MessageBox.Show("El campo Descripcion no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo Tipo no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void ActualizarData()
        {
            ModeloDUsuario obj = new ModeloDUsuario();
            dataGridView1.DataSource = obj.MostrarTipo();
        }

        private void Vaciar()
        {
            txtCodigoTipo.Text = "";
            txtDescripcion.Text = "";
            txtCodigoTipo.Enabled = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            TipoProyecto tipo = new TipoProyecto();

            if (txtCodigoTipo.Text != "")
            {
                tipo.codigo = txtCodigoTipo.Text;

                if (txtDescripcion.Text != "")
                {
                    tipo.descripcion = txtDescripcion.Text;

                    ModeloDUsuario objDUsuario = new ModeloDUsuario();

                    if (objDUsuario.ActualizarTipo(tipo))
                        MessageBox.Show("Las cambios se han realizado exitosamente");
                    else
                        MessageBox.Show("No se pudieron realizar los cambios");

                }
                else
                    MessageBox.Show("El campo Descripcionno puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo Tipo no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TipoPago tipo = new TipoPago();

            if (txtCodigoTipo.Text != "")
            {
                tipo.CodigoTipo = txtCodigoTipo.Text;

                ModeloDUsuario obj = new ModeloDUsuario();

                if (obj.EliminarTipoPago(tipo))
                    MessageBox.Show("Se han eliminado el tipo correctamente");
                else
                    MessageBox.Show("No se pudo realizar ningun cambio");
            }
            else
                MessageBox.Show("El campo Codigo no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void frmTipo_Load(object sender, EventArgs e)
        {
            ActualizarData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtCodigoTipo.Text = dataGridView1.SelectedCells[0].Value.ToString();
                txtDescripcion.Text = dataGridView1.SelectedCells[1].Value.ToString();
                
                txtCodigoTipo.Enabled = false;
            }
        }
    }
}
