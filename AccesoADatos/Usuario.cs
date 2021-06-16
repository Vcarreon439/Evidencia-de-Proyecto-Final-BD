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

        #region Colaborador
        public bool ActualizarColaborador(Colaborador colaborador)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();


                    string comando = "Update COLABORADORES Set BANCO = @banco, DOMICILIO = @domicilio, NUMERO_CUENTA = @cuenta, NOMBRE = @nom, TELEFONO = @tel  Where ID_COLABORADOR = @cod";
                    SqlCommand cmd = new SqlCommand(comando, conexion);

                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters.Add("@banco", SqlDbType.VarChar);
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar);
                    cmd.Parameters.Add("@cuenta", SqlDbType.VarChar);
                    cmd.Parameters.Add("@nom", SqlDbType.VarChar);
                    cmd.Parameters.Add("@tel", SqlDbType.VarChar);

                    cmd.Parameters["@cod"].Value = colaborador.ID;
                    cmd.Parameters["@banco"].Value = colaborador.Banco;
                    cmd.Parameters["@domicilio"].Value = colaborador.Domicilio;
                    cmd.Parameters["@cuenta"].Value = colaborador.NumCuenta;
                    cmd.Parameters["@nom"].Value = colaborador.Nombre;
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

        #endregion

        #region Pagos
        public bool ActualizarPagos(Pagos pago)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    string comando = "Update PAGOS Set ID_COLABORADOR = @numColab, CONCEPTO = @Concepto, FECHA = @fecha, CANTIDAD = @Cantidad  Where NUM_DE_PAGO = @cod";
                    SqlCommand cmd = new SqlCommand(comando, conexion);

                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters.Add("@numColab", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Concepto", SqlDbType.VarChar);
                    cmd.Parameters.Add("@fecha", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Money);

                    cmd.Parameters["@cod"].Value = pago.NumPago;
                    cmd.Parameters["@numColab"].Value = pago.ID_Colaborador;
                    cmd.Parameters["@Concepto"].Value = pago.Concepto;
                    cmd.Parameters["@fecha"].Value = pago.Fecha;
                    cmd.Parameters["@Cantidad"].Value = Convert.ToDouble(pago.Cantidad);

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public bool EliminarPagos(Pagos pago)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string comando = "Delete From PAGOS Where NUM_DE_PAGO = @cod";
                    SqlCommand cmd = new SqlCommand(comando, conexion);

                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters["@cod"].Value = pago.NumPago;

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        public bool InsertarPagos(Pagos pago)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string comando = "Insert into PAGOS Values (@cod, @numColab, @Concepto, @fecha, @Cantidad)";
                    SqlCommand cmd = new SqlCommand(comando, conexion);

                    cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                    cmd.Parameters.Add("@numColab", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Concepto", SqlDbType.VarChar);
                    cmd.Parameters.Add("@fecha", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Money);

                    cmd.Parameters["@cod"].Value = pago.NumPago;
                    cmd.Parameters["@numColab"].Value = pago.ID_Colaborador;
                    cmd.Parameters["@Concepto"].Value = pago.Concepto;
                    cmd.Parameters["@fecha"].Value = pago.Fecha;
                    cmd.Parameters["@Cantidad"].Value = pago.Cantidad;

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable MostrarPagos()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlDataAdapter adaptador = new SqlDataAdapter("Select * From PAGOS", conexion))
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

        #region PagosTipo

            public bool ActualizarPagoTipo(TipoPago tipo)
            {
                try
                {
                    using (SqlConnection conexion = ObtenerConexion())
                    {
                        conexion.Open();

                        string comando = "Update TIPO Set Descripcion = @decripcion Where CODIGO_TIPO = @cod";
                        SqlCommand cmd = new SqlCommand(comando, conexion);

                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar);

                        cmd.Parameters["@cod"].Value = tipo.codigo;
                        cmd.Parameters["@numColab"].Value = tipo.descripcion;

                        return cmd.ExecuteNonQuery() != 0;
                    }
                }
                catch (SqlException error)
                {
                    MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            public bool EliminarTipoPago(TipoPago tipo)
            {
                try
                {
                    using (SqlConnection conexion = ObtenerConexion())
                    {
                        conexion.Open();
                        string comando = "Delete From TIPO Where CODIGO_TIPO = @cod";
                        SqlCommand cmd = new SqlCommand(comando, conexion);

                        cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                        cmd.Parameters["@cod"].Value = tipo.codigo;

                        return cmd.ExecuteNonQuery() != 0;
                    }
                }
                catch (SqlException error)
                {
                    MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            public bool InsertarTipo(TipoPago tipo)
            {
                try
                {
                    using (SqlConnection conexion = ObtenerConexion())
                    {
                        conexion.Open();
                        string comando = "Insert into TIPO Values (@cod, @decripcion)";
                        SqlCommand cmd = new SqlCommand(comando, conexion);

                        cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                        cmd.Parameters.Add("@decripcion", SqlDbType.VarChar);

                        cmd.Parameters["@cod"].Value = tipo.codigo;
                        cmd.Parameters["@decripcion"].Value = tipo.descripcion;

                        return cmd.ExecuteNonQuery() != 0;
                    }
                }
                catch (SqlException error)
                {
                    MessageBox.Show($"Error: { error.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            public DataTable MostrarTIPO()
            {
                try
                {
                    using (SqlConnection conexion = ObtenerConexion())
                    {
                        conexion.Open();

                        using (SqlDataAdapter adaptador = new SqlDataAdapter("Select * From Tipo", conexion))
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

    }
}
