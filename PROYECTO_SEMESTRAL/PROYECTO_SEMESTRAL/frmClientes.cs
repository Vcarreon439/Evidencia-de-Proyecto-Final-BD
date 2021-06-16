using System;
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
                        MessageBox.Show("El campo Telefono no puede ir vacio");
                    }
                    MessageBox.Show("El campo Razon Social no puede ir vacio");
                }
                MessageBox.Show("El campo Domicilio no puede ir vacio");
            }
            else
                MessageBox.Show("El campo Codigo no puede ir vacio");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
