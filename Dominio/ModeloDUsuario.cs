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
    }

}
