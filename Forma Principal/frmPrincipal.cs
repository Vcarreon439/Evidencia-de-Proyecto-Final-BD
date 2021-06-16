using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Funcionalidad_Formularios;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forma_Principal
{
    public partial class frmPrincipal : Form
    {
        #region Load

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        #endregion

        private void SlideBtn()
        {
            if (pnlMenu.Size.Width == 60)
            {
                pnlMenu.Size = new Size(200, pnlMenu.Height);
                CambiarBotones();
                SlideAligment();
            }
        }


        #region ControlDePaneles

        private void btnGeneros_Click(object sender, EventArgs e)
        {
            SlideBtn();

            if (pnlSubMenu1.Visible == false)
                pnlSubMenu1.Visible = true;
            else
                pnlSubMenu1.Visible = false;

        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            SlideBtn();

            if (pnlSubMenu2.Visible == false)
                pnlSubMenu2.Visible = true;
            else
                pnlSubMenu2.Visible = false;
        }

        private void btnMiembros_Click(object sender, EventArgs e)
        {
            SlideBtn();

            if (pnlSubMenu3.Visible == false)
                pnlSubMenu3.Visible = true;
            else
                pnlSubMenu3.Visible = false;
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            SlideBtn();

            if (pnlSubMenu4.Visible == false)
                pnlSubMenu4.Visible = true;
            else
                pnlSubMenu4.Visible = false;
        }

        private void btnManagers_Click(object sender, EventArgs e)
        {
            SlideBtn();

            if (pnlSubMenu5.Visible == false)
                pnlSubMenu5.Visible = true;
            else
                pnlSubMenu5.Visible = false;
        }

        private void btnEditorial_Click(object sender, EventArgs e)
        {
            SlideBtn();

            if (pnlSubMenu6.Visible == false)
                pnlSubMenu6.Visible = true;
            else
                pnlSubMenu6.Visible = false;
        }

        #endregion

        #region MovimientoDeLaForma
        private void pnlContenedor_MouseMove(object sender, MouseEventArgs e)
        {
            Arrastre_Formularios.Llama_ReleaseCapture();
            Arrastre_Formularios.Llama_SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlEncabezadoMenu_MouseMove(object sender, MouseEventArgs e)
        {
            Arrastre_Formularios.Llama_ReleaseCapture();
            Arrastre_Formularios.Llama_SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlMenu_MouseMove(object sender, MouseEventArgs e)
        {
            Arrastre_Formularios.Llama_ReleaseCapture();
            Arrastre_Formularios.Llama_SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion


        private void btnGestionClientes_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private Form FormularioAbierto = null;

        private void CambiarBotones()
        {
            if (pnlMenu.Size.Width == 60)
            {
                btnClientes.Text = "";
                btnColaboradores.Text = "";
                btnPagos.Text = "";
                btnProycto.Text = "";
                btnCerrarSesion.Text = "";
                lblTitulo.Visible = false;
            }
            else
            {
                btnClientes.Text = "Clientes";
                btnColaboradores.Text = "Colaboradores";
                btnPagos.Text = "Pagos";
                btnProycto.Text = "Proyecto";
                btnCerrarSesion.Text = "Cerrar Sesion";
                lblTitulo.Visible = true;
            }
        }

        private void SlideAligment()
        {
            if (btnSlide.ImageAlign == ContentAlignment.MiddleLeft)
                btnSlide.ImageAlign = ContentAlignment.MiddleRight;
            else
                btnSlide.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void CambiarMenu()
        {
            pnlSubMenu1.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
            pnlSubMenu4.Visible = false;
            pnlSubMenu5.Visible = false;
            pnlSubMenu6.Visible = false;


            if (pnlMenu.Size.Width != 60)
            {
                pnlMenu.Size = new Size(60, pnlMenu.Height);
                CambiarBotones();
                SlideAligment();
            }
            else
            {
                pnlMenu.Size = new Size(200, pnlMenu.Height);
                CambiarBotones();
                SlideAligment();
            }
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            CambiarMenu();   
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            if (FormularioAbierto != null)
                FormularioAbierto.Close();

            FormularioAbierto = FormEnPanel.AbrirForm<PROYECTO_SEMESTRAL.frmClientes>(ref pnlContenedor);
            pnlSubMenu1.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
            pnlSubMenu4.Visible = false;
            pnlSubMenu5.Visible = false;
            pnlSubMenu6.Visible = false;
        }

        private void btnGestionColaboradores_Click(object sender, EventArgs e)
        {
            if (FormularioAbierto != null)
                FormularioAbierto.Close();

            FormularioAbierto = FormEnPanel.AbrirForm<PROYECTO_SEMESTRAL.frmColaboradores>(ref pnlContenedor);
            pnlSubMenu1.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
            pnlSubMenu4.Visible = false;
            pnlSubMenu5.Visible = false;
            pnlSubMenu6.Visible = false;
        }

        private void btnGestionPagos_Click(object sender, EventArgs e)
        {
            if (FormularioAbierto != null)
                FormularioAbierto.Close();

            FormularioAbierto = FormEnPanel.AbrirForm<PROYECTO_SEMESTRAL.frmPagos>(ref pnlContenedor);
            pnlSubMenu1.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
            pnlSubMenu4.Visible = false;
            pnlSubMenu5.Visible = false;
            pnlSubMenu6.Visible = false;
        }

        private void btnTipoPago_Click(object sender, EventArgs e)
        {
            if (FormularioAbierto != null)
                FormularioAbierto.Close();

            FormularioAbierto = FormEnPanel.AbrirForm<PROYECTO_SEMESTRAL.frmPagosTipo>(ref pnlContenedor);
            pnlSubMenu1.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
            pnlSubMenu4.Visible = false;
            pnlSubMenu5.Visible = false;
            pnlSubMenu6.Visible = false;
        }

        private void btnGestionProyectos_Click(object sender, EventArgs e)
        {
            if (FormularioAbierto != null)
                FormularioAbierto.Close();

            FormularioAbierto = FormEnPanel.AbrirForm<PROYECTO_SEMESTRAL.frmProyecto>(ref pnlContenedor);
            pnlSubMenu1.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
            pnlSubMenu4.Visible = false;
            pnlSubMenu5.Visible = false;
            pnlSubMenu6.Visible = false;
        }

        private void btnProyectosColab_Click(object sender, EventArgs e)
        {
            if (FormularioAbierto != null)
                FormularioAbierto.Close();

            FormularioAbierto = FormEnPanel.AbrirForm<PROYECTO_SEMESTRAL.frmProyectoColaboradoes>(ref pnlContenedor);
            pnlSubMenu1.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
            pnlSubMenu4.Visible = false;
            pnlSubMenu5.Visible = false;
            pnlSubMenu6.Visible = false;
        }

        private void btnTipoProyecto_Click(object sender, EventArgs e)
        {
            if (FormularioAbierto != null)
                FormularioAbierto.Close();

            FormularioAbierto = FormEnPanel.AbrirForm<PROYECTO_SEMESTRAL.frmTipo>(ref pnlContenedor);
            pnlSubMenu1.Visible = false;
            pnlSubMenu2.Visible = false;
            pnlSubMenu3.Visible = false;
            pnlSubMenu4.Visible = false;
            pnlSubMenu5.Visible = false;
            pnlSubMenu6.Visible = false;
        }
    }
}
