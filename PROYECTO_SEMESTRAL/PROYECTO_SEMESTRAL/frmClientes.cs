using System;
using System.Diagnostics.Eventing.Reader;
using Dominio;
using Funcionalidad_Formularios;
using BibliotecaDeClases;
using System.Windows.Forms;

namespace PROYECTO_SEMESTRAL
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            if (txtCodCliente.Text != "")
            {
                cliente.Codigo = txtCodCliente.Text;

                if (txtDomicilio.Text != "")
                {
                    cliente.Domicilio = txtDomicilio.Text;

                    if (txtRazonSocial.Text != "")
                    {
                        cliente.Razon = txtRazonSocial.Text;

                        if (txtTelefono.Text != "")
                        {
                            cliente.Telefono = txtTelefono.Text;

                            ModeloDUsuario obj = new ModeloDUsuario();

                            if (obj.InsertarCliente(cliente))
                                MessageBox.Show("Insercion Exitosa");
                            else
                                MessageBox.Show("No se pudo realizar la insercion");
                        }
                        else
                            MessageBox.Show("El campo Telefono no puede ir vacio");
                    }
                    else
                        MessageBox.Show("El campo Razon Social no puede ir vacio");
                }
                else
                    MessageBox.Show("El campo Domicilio no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void ActualizarData()
        {
            ModeloDUsuario obj = new ModeloDUsuario();
            dataGridView1.DataSource = obj.MostarClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            if (txtCodCliente.Text != "")
            {
                cliente.Codigo = txtCodCliente.Text;

                if (txtDomicilio.Text != "")
                {
                    cliente.Domicilio = txtDomicilio.Text;

                    if (txtRazonSocial.Text != "")
                    {
                        cliente.Razon = txtRazonSocial.Text;

                        if (txtTelefono.Text != "")
                        {
                            cliente.Telefono = txtTelefono.Text;

                            ModeloDUsuario obj = new ModeloDUsuario();

                            if (obj.ActualizarCliente(cliente))
                                MessageBox.Show("Se han realizado los cambios exitosamente");
                            else
                                MessageBox.Show("No se pudo realizar ningun cambio");
                        }
                        else
                            MessageBox.Show("El campo Telefono no puede ir vacio");
                    }
                    else
                        MessageBox.Show("El campo Razon Social no puede ir vacio");
                }
                else
                    MessageBox.Show("El campo Domicilio no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo no puede ir vacio");

            Vaciar();
            ActualizarData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            if (txtCodCliente.Text != "")
            {
                cliente.Codigo = txtCodCliente.Text;

                ModeloDUsuario obj = new ModeloDUsuario();

                if (obj.EliminarCliente(cliente))
                    MessageBox.Show("Se han eliminado al cliente correctamente");
                else
                    MessageBox.Show("No se pudo realizar ningun cambio");
            }
            else
                MessageBox.Show("El campo Codigo no puede ir vacio");

            Vaciar();
            ActualizarData();
        }


        private void Vaciar()
        {
            txtCodCliente.Text = "";
            txtDomicilio.Text = "";
            txtRazonSocial.Text = "";
            txtTelefono.Text = "";
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            ActualizarData();
        }
    }
}
