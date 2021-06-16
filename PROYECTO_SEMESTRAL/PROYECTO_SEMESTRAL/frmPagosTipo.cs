using System.Windows.Forms;
using BibliotecaDeClases;
using Dominio;

namespace PROYECTO_SEMESTRAL
{
    public partial class frmPagosTipo : Form
    {
        public frmPagosTipo()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            TipoPago tipo = new TipoPago();

            if (txtCodigoTipos.Text != "")
            {
                tipo.CodigoTipo = txtCodigoTipos.Text;

                if (txtNumeroPagos.Text != "")
                {
                    tipo.NumPago = txtNumeroPagos.Text;

                    ModeloDUsuario objDUsuario = new ModeloDUsuario();

                    if (objDUsuario.InsertarTipoPago(tipo))
                        MessageBox.Show("Insercion Exitosa");
                    else
                        MessageBox.Show("No se pudo realizar la insercion");
                }
                else
                    MessageBox.Show("El campo Numero de Pago no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo no pueden ir vacios");

            ActualizarData();
            Vaciar();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            TipoPago tipo = new TipoPago();

            if (txtCodigoTipos.Text != "")
            {
                tipo.CodigoTipo = txtCodigoTipos.Text;

                if (txtNumeroPagos.Text != "")
                {
                    tipo.NumPago = txtNumeroPagos.Text;

                    ModeloDUsuario objDUsuario = new ModeloDUsuario();

                    if (objDUsuario.ActualizarTipoPago(tipo))
                        MessageBox.Show("Los cambios se han realizado exitosamente");
                    else
                        MessageBox.Show("No se pudo realizar ningun cambio");
                }
                else
                    MessageBox.Show("El campo Numero de Pago no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo no pueden ir vacios");

            ActualizarData();
            Vaciar();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            TipoPago tipo = new TipoPago();

            if (txtCodigoTipos.Text != "")
            {
                tipo.CodigoTipo = txtCodigoTipos.Text;

                ModeloDUsuario objDUsuario = new ModeloDUsuario();

                if (objDUsuario.EliminarTipoPago(tipo))
                    MessageBox.Show("Se ha eliminado el registro correctamente");
                else
                    MessageBox.Show("No se pudo realizar ningun cambio");
            }
            else
                MessageBox.Show("El campo Codigo no pueden ir vacios");

            ActualizarData();
            Vaciar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtCodigoTipos.Text = dataGridView1.SelectedCells[0].Value.ToString();
                txtNumeroPagos.Text = dataGridView1.SelectedCells[1].Value.ToString();

                txtNumeroPagos.Enabled = false;
            }
        }

        private void ActualizarData()
        {
            ModeloDUsuario obj = new ModeloDUsuario();
            dataGridView1.DataSource = obj.MostrarTipoPago();
        }

        private void Vaciar()
        {
            txtCodigoTipos.Text = "";
            txtNumeroPagos.Text = "";
            txtNumeroPagos.Enabled = true;
        }

        private void frmPagosTipo_Load(object sender, System.EventArgs e)
        {
            ActualizarData();
        }
    }
}
