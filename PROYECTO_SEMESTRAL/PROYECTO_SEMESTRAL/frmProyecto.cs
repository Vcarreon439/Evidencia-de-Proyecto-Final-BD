using System;
using System.Windows.Forms;
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

        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {

        }
    }
}
