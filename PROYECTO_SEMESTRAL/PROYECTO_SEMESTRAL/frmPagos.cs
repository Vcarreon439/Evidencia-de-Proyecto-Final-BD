using System;
using System.Windows.Forms;
using BibliotecaDeClases;
using Dominio;

namespace PROYECTO_SEMESTRAL
{
    public partial class frmPagos : Form
    {
        public frmPagos()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtNumeroPago.Text = dataGridView1.SelectedCells[0].Value.ToString();
                txtIdColaborador.Text = dataGridView1.SelectedCells[1].Value.ToString();
                txtConcepto.Text = dataGridView1.SelectedCells[2].Value.ToString();
                dtmFecha.Value = DateTime.Parse(dataGridView1.SelectedCells[3].Value.ToString());
                txtCantidad.Text = dataGridView1.SelectedCells[4].Value.ToString();

                txtNumeroPago.Enabled = false;
                txtIdColaborador.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Pagos Pago = new Pagos();

            if (txtNumeroPago.Text != "")
            {
                Pago.NumPago = txtNumeroPago.Text;

                if (txtIdColaborador.Text != "")
                {
                    Pago.ID_Colaborador = txtIdColaborador.Text;

                    if (txtConcepto.Text != "")
                    {
                        Pago.Concepto = txtConcepto.Text;

                        if (txtCantidad.Text != "")
                        {
                            Pago.Cantidad = Convert.ToDouble(txtCantidad.Text);
                            Pago.Fecha = $"{dtmFecha.Value.Month}-{dtmFecha.Value.Day}-{dtmFecha.Value.Year}";


                            ModeloDUsuario objDUsuario = new ModeloDUsuario();

                            if (objDUsuario.InsertarPagos(Pago))
                                MessageBox.Show("Insercion Exitosa");
                            else
                                MessageBox.Show("No se pudo realizar la insercion");

                        }
                        else
                            MessageBox.Show("El campo CANTIDAD no puede ir vacio");
                    }
                    else
                        MessageBox.Show("El campo CONCEPTO no puede ir vacio");
                }
                else
                    MessageBox.Show("El campo ID_COLABORADOR no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Numero de Pago no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void ActualizarData()
        {
            ModeloDUsuario obj = new ModeloDUsuario();
            dataGridView1.DataSource = obj.MostarPagos();
        }

        private void Vaciar()
        {
            txtNumeroPago.Text = "";
            txtIdColaborador.Text = "";
            txtConcepto.Text = "";
            txtCantidad.Text = "";
            dtmFecha.Value = DateTime.Today;
            txtNumeroPago.Enabled = true;
            txtIdColaborador.Enabled = true;
        }

        private void frmPagos_Load(object sender, EventArgs e)
        {
            ActualizarData();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Pagos Pago = new Pagos();

            if (txtNumeroPago.Text != "")
            {
                Pago.NumPago = txtNumeroPago.Text;

                if (txtIdColaborador.Text != "")
                {
                    Pago.ID_Colaborador = txtIdColaborador.Text;

                    if (txtConcepto.Text != "")
                    {
                        Pago.Concepto = txtConcepto.Text;

                        if (txtCantidad.Text != "")
                        {
                            Pago.Cantidad = Convert.ToDouble(txtCantidad.Text);
                            Pago.Fecha = $"{dtmFecha.Value.Month}-{dtmFecha.Value.Day}-{dtmFecha.Value.Year}";

                            ModeloDUsuario objDUsuario = new ModeloDUsuario();

                            if (objDUsuario.ActualizarPagos(Pago))
                                MessageBox.Show("Se han realizado los cambios exitosamente");
                            else
                                MessageBox.Show("No se pudo realizar ningun cambio");

                        }
                        else
                            MessageBox.Show("El campo CANTIDAD no puede ir vacio");
                    }
                    else
                        MessageBox.Show("El campo CONCEPTO no puede ir vacio");
                }
                else
                    MessageBox.Show("El campo ID_COLABORADOR no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Numero de Pago no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Pagos pagos = new Pagos();

            if (txtNumeroPago.Text != "")
            {
                pagos.NumPago = txtNumeroPago.Text;

                ModeloDUsuario obj = new ModeloDUsuario();

                if (obj.EliminarPagos(pagos))
                    MessageBox.Show("Se han eliminado el pago correctamente");
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
