using System;
using System.IO;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public abstract class ConexionSQL
    {
        private readonly string cadenaConexion;

        public ConexionSQL() 
        {
            cadenaConexion = $"Data Source=DESKTOP-185RN13\\SQLEXPRESS;Database = EMPRESA; Integrated Security = True";
        }

        protected SqlConnection ObtenerConexion()
        { 
            return new SqlConnection(cadenaConexion); 
        }

    }

}
