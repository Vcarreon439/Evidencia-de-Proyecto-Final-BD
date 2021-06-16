using System.Data;
using AccesoADatos;
using BibliotecaDeClases;

namespace Dominio
{
    public class ModeloDUsuario
    {
        Usuario usuario = new Usuario();

        #region Clientes

        public bool InsertarCliente(Cliente cliente)
        {
            return usuario.InsertarCliente(cliente);
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            return usuario.ActualizarCliente(cliente);
        }

        public bool EliminarCliente(Cliente cliente)
        {
            return usuario.EliminarCliente(cliente);
        }

        public DataTable MostarClientes()
        {
            return usuario.MostrarClientes();
        }

        #endregion

        #region Colaborador
        
        public bool InsertarColaborador(Colaborador colaborador)
        {
            return usuario.InsertarColaborador(colaborador);
        }

        public bool ActualizarColaborador(Colaborador colaborador)
        {
            return usuario.ActualizarColaborador(colaborador);
        }

        public bool EliminarColaborador(Colaborador colaborador)
        {
            return usuario.EliminarColaborador(colaborador);
        }

        public DataTable MostarColaborador()
        {
            return usuario.MostrarColaborador();
        }

        #endregion

        #region Pagos
            public bool InsertarPagos(Pagos pago)
            {
                return usuario.InsertarPagos(pago);
            }

            public bool ActualizarPagos(Pagos pago)
            {
                return usuario.ActualizarPagos(pago);
            }

            public bool EliminarPagos(Pagos Pago)
            {
                return usuario.EliminarPagos(Pago);
            }

            public DataTable MostarPagos()
            {
                return usuario.MostrarPagos();
            }
        #endregion

        #region Tipo

        public bool InsertarTipo(TipoProyecto tipo)
        {
            return usuario.InsertarTipoProyecto(tipo);
        }

        public bool ActualizarTipo(TipoProyecto tipo)
        {
            return usuario.ActualizarTipoProyecto(tipo);
        }

        public bool EliminarTipo(TipoProyecto tipo)
        {
            return usuario.EliminarTipoProyecto(tipo);
        }

        public DataTable MostrarTipo()
        {
            return usuario.MostrarTipoProyecto();
        }

        #endregion

        #region TipoPago

        public bool InsertarTipoPago(TipoPago tipo)
        {
            return usuario.InsertarTipoPago(tipo);
        }

        public bool ActualizarTipoPago(TipoPago tipo)
        {
            return usuario.ActualizarTipoPago(tipo);
        }

        public bool EliminarTipoPago(TipoPago tipo)
        {
            return usuario.EliminarTipoPago(tipo);
        }

        public DataTable MostrarTipoPago()
        {
            return usuario.MostrarTipoPago();
        }

        #endregion


    }

}
