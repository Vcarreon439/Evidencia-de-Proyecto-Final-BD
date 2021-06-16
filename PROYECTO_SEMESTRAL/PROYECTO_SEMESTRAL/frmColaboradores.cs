using System.Windows.Forms;
using BibliotecaDeClases;

namespace PROYECTO_SEMESTRAL
{
    public partial class frmColaboradores : Form
    {
        public frmColaboradores()
        {
            InitializeComponent();
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
                                }

                            }

                            /*ModeloDUsuario obj = new ModeloDUsuario();

                            if (obj.InsertarCliente(cliente))
                                MessageBox.Show("Insercion Exitosa");
                            else
                                MessageBox.Show("No se pudo realizar la insercion");*/
                        }
                    }
                }
            }
            else
                MessageBox.Show("El campo ID COLABORADOR no puede ir vacio");

        }
    }
}
