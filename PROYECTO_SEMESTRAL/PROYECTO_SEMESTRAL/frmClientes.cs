using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
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
            if (txtCodCliente.Text != "")
            {
                if (txtDomicilio.Text != "")
                {
                    if (txtRazonSocial.Text != "")
                    {
                        if (txtTelefono.Text != "")
                        {


                        }
                    }
                }
            }
        }

        private void Validar()
        {
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
