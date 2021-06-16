using Autenticacion;
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

        #region Autenticacion

        public bool Login(string usuario, string contra)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "select * from Managers where Nombre=@usuario and Contraseña=@pass";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@pass", contra);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

        public TipoUsuario.TypeUser Autenticacion(string usuario, string contraseña)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "select Rol from Managers where Nombre=@usuario and Contraseña=@pass";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@pass", contraseña);
                    cmd.CommandType = CommandType.Text;

                    switch ((string) cmd.ExecuteScalar())
                    {
                        case "ADMIN":
                            return TipoUsuario.TypeUser.Admin;

                        case "USER":
                            return TipoUsuario.TypeUser.Usuario;

                        case "MANAGER":
                            return TipoUsuario.TypeUser.Maganer;

                        case "GUEST":
                            return TipoUsuario.TypeUser.Invitado;

                        default:
                            return TipoUsuario.TypeUser.Ninguno;
                    }
                }
            }
        }

        #endregion

        #region Eliminar

        public bool EliminarTema(string codigo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("EliminarTema", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codTema", codigo);

                    if (cmd.ExecuteNonQuery() != 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        #endregion

        #region Mostrar

        public DataTable MostrarLibrosCant(int cantidad)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarLibrosCant", conexion))
                    {
                        adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adaptador.SelectCommand.Parameters.AddWithValue("@cant", cantidad);
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

        public DataTable MostrarLibros()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarLibros", conexion))
                    {
                        adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public object AutorCant(int cant)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("AutorCant", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.SelectCommand.Parameters.AddWithValue("@cant", cant);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }

        public List<string> TemaCombo()
        {
            List<string> elementos = new List<string>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("TemaCombo", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            elementos.Add(reader.GetString(0));
                    }

                    return elementos;
                }
            }
        }

        public DataTable MostrarGeneros()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarTemas", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }

        public DataTable MostrarAutores()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarAutores", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }

        public DataTable MostrarUsuarios()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarUsuarios", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }

        public DataTable MostrarGenerosCant(int cantidad)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("TemaCant", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.SelectCommand.Parameters.AddWithValue("@cant", cantidad);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }

        /// <summary>
        /// Metodo de acceso a procedimiento almacenado MostrarAutores_5 de la base de datos
        /// </summary>
        /// <param name="elementos">Codigo, nombre, apellidos, pais, ciudad</param>
        /// <returns>Retorna una tabla de los datos (Codigo, nombre, apellidos, pais, ciudad) del autor)</returns>
        public DataTable MostrarAutores_5(List<string> elementos)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarAutores_5", conexion))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@cod", elementos[0]);
                    adaptador.SelectCommand.Parameters.AddWithValue("@nombre", elementos[1]);
                    adaptador.SelectCommand.Parameters.AddWithValue("@apellidos", elementos[2]);
                    adaptador.SelectCommand.Parameters.AddWithValue("@pais", elementos[3]);
                    adaptador.SelectCommand.Parameters.AddWithValue("@ciudad", elementos[4]);


                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    return tabla;
                }
            }
        }

        public DataTable UsuariosCant(int cantidad)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("UsuariosCant", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.SelectCommand.Parameters.AddWithValue("@cant", cantidad);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }

        public DataTable MostrarManagers()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarManagers", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }


        public List<string> EditorialesCombo()
        {
            List<string> elementos = new List<string>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("EditorialesCombo", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            elementos.Add(reader.GetString(0));
                    }

                    return elementos;
                }
            }
        }

        public DataTable MostrarEditoriales()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarEditoriales", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }

        public DataTable MostrarEditorial(string cod, string nombre)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlDataAdapter adaptador = new SqlDataAdapter("MostrarEditorial", conexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.SelectCommand.Parameters.Add("@cod", cod);
                    adaptador.SelectCommand.Parameters.Add("@nombre", nombre);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }

        #endregion

        #region Actualizar


        public bool ActualizarGenero(string cod, string descripcion)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("ActualizarGenero1", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@cod", cod));
                        cmd.Parameters.Add(new SqlParameter("@cambio", descripcion));

                        int valor = cmd.ExecuteNonQuery();

                        if (valor != 0)
                            return true;
                    }
                }
                catch (SqlException error)
                {
                    Console.WriteLine(error.Number);
                    return false;
                }

                return false;

            }
        }


        #region Insertar

        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string comando = "Insert into Cliente Values (@cod, @razon, @domicilio, @telefono)";
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

    public bool InsertarGenero(string codigo, string definicion)
        {
            try
            {

                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("Insercion_Genero", conexion))
                    {
                        cmd.Connection = conexion;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@cod", codigo));
                        cmd.Parameters.Add(new SqlParameter("@tipo", definicion));

                        if (cmd.ExecuteNonQuery() != 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (SqlException error)
            {
                if (error.Number == 2627)
                    MessageBox.Show("Este registro ya existe en la base de datos", $"Error {error.Number}", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
        }

        public bool InsertarManager(string nombre, string contra, string rol)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarManager", conexion))
                {
                    cmd.Connection = conexion;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@contra", contra);
                    cmd.Parameters.AddWithValue("@rol", rol);

                    if (cmd.ExecuteNonQuery() != 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        #endregion

        
    }
}
#endregion