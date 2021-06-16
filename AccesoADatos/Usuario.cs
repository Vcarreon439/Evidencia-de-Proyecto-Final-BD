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
        #region Cliente

        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string comando = "Update CLIENTES Set RAZON_SOCIAL = @razon, TELEFONO = @telefono, DOMICILIO = @domicilio Where COD_CLIENTE = @cod";
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
                MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        } 
        
        public bool EliminarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string comando = "Delete From CLIENTES Where COD_CLIENTE = @cod";
                    SqlCommand cmd = new SqlCommand(comando, conexion);

                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters["@cod"].Value = cliente.Codigo;

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
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

        public DataTable MostrarClientes()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlDataAdapter adaptador = new SqlDataAdapter("Select * From CLIENTES", conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        #endregion

        public bool ActualizarColaborador(Colaborador colaborador)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();


                    string comando = "Update CLIENTES Set BANCO = @banco, DOMICILIO = @domicilio, NUMERO_CUENTA = @cuenta, NOMBRE = @nom, TELEFONO = @tel  Where ID_COLABORADOR = @cod";
                    SqlCommand cmd = new SqlCommand(comando, conexion);

                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters.Add("@banco", SqlDbType.VarChar);
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar);
                    cmd.Parameters.Add("@cuenta", SqlDbType.VarChar);
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                    cmd.Parameters.Add("@tel", SqlDbType.VarChar);

                    cmd.Parameters["@cod"].Value = colaborador.ID;
                    cmd.Parameters["@banco"].Value = colaborador.Banco;
                    cmd.Parameters["@domicilio"].Value = colaborador.Domicilio;
                    cmd.Parameters["@cuenta"].Value = colaborador.NumCuenta;
                    cmd.Parameters["@nombre"].Value = colaborador.Nombre;
                    cmd.Parameters["@tel"].Value = colaborador.Telefono;

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        } 
        
        public bool EliminarColaborador(Colaborador colaborador)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string comando = "Delete From COLABORADORES Where ID_COLABORADOR = @cod";
                    SqlCommand cmd = new SqlCommand(comando, conexion);

                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters["@cod"].Value = colaborador.ID;

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        public bool InsertarColaborador(Colaborador colaborador)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string comando = "Insert into COLABORADORES Values (@cod, @banco, @domicilio, @cuenta, @nombre, @tel)";
                    SqlCommand cmd = new SqlCommand(comando, conexion);
                    
                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters.Add("@banco", SqlDbType.VarChar);
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar);
                    cmd.Parameters.Add("@cuenta", SqlDbType.VarChar);
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                    cmd.Parameters.Add("@tel", SqlDbType.VarChar);

                    cmd.Parameters["@cod"].Value = colaborador.ID;
                    cmd.Parameters["@banco"].Value = colaborador.Banco;
                    cmd.Parameters["@domicilio"].Value = colaborador.Domicilio;
                    cmd.Parameters["@cuenta"].Value = colaborador.NumCuenta;
                    cmd.Parameters["@nombre"].Value = colaborador.Nombre;
                    cmd.Parameters["@tel"].Value = colaborador.Telefono;

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show($"Error: { error.Message}","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable MostrarColaborador()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlDataAdapter adaptador = new SqlDataAdapter("Select * From COLABORADORES", conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        return tabla;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        
    }
}
