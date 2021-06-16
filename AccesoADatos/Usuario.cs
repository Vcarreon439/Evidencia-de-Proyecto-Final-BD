using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BibliotecaDeClases;

namespace AccesoADatos
{
    public class Usuario : ConexionSQL
    {

        public bool InsertarCliente(Cliente cliente)
        {
            try
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string comando = "Insert into CLIENTES Values (@cod, @razon, @telefono, @domicilio)";
                    SqlCommand cmd = new SqlCommand(comando, conexion);
                    
                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters.Add("@razon", SqlDbType.VarChar);
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar);
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar);

                    cmd.Parameters["@cod"].Value = cliente.Codigo;
                    cmd.Parameters["@razon"].Value = cliente.Razon;
                    cmd.Parameters["@domicilio"].Value = cliente.Domicilio;
                    cmd.Parameters["@telefono"].Value = cliente.Telefono;

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show($"Error: { error.Message}","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
