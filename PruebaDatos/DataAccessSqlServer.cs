using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
using System.Configuration;

namespace DllsUAC.AccesoDatos
{
    public class DataAccessSqlServer : DataAccess
    {
        private SqlConnection cnx;
        private SqlCommand cmd;
        private SqlTransaction trn;
        private int tiempoDeEsperaConsulta = 10000;

        public DataAccessSqlServer(string user, string password)
        {
            try
            {
                string strCnx = ConfigurationManager.ConnectionStrings["DB2AS400Generico"].ToString();
                strCnx = strCnx.Replace("[USER]", user);
                strCnx = strCnx.Replace("[PASSWORD]", password);
                cnx = new SqlConnection(strCnx);
                cmd = new SqlCommand();
            }
            catch (Exception ex)
            {
                if (ex.GetType().ToString() == "System.Data.SqlClient.SqlError")
                {
                    SqlException err = (SqlException)ex;
                    if (err.ErrorCode == 8001)
                        throw new Exception("8001 - Por favor rectifique el Usuario");
                    else if (err.ErrorCode == 8002)
                        throw new Exception("8002 - Por favor rectifique la Contraseña");
                    else
                        throw ex;
                }
                else
                    if (ex.Message == "La conexión no se puede abrir porque ha pasado el tiempo de espera de la conexión.")
                        throw new Exception("0001 - No ha sido posible conectarse a la Base de Datos. Verifique que está conectado a la red de la Universidad.");
                    else
                        throw ex;
            }
        }

        public DataAccessSqlServer(string nombreConexion)
        {
            cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ToString());
            cmd = new SqlCommand();
        }

        public DataAccessSqlServer()
        {
            cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ToString());
            cmd = new SqlCommand();
        }

        public override void IniciarTransaccion()
        {
            trn = cnx.BeginTransaction();
        }

        public override void TerminarTransaccion()
        {
            trn.Commit();
        }

        public override void InterrumpirTransaccion()
        {
            trn.Rollback();
        }

        public override void AbrirBaseDatos()
        {
            cnx.Open();
        }

        public override void CerrarBaseDatos()
        {
            cnx.Close();
        }

        public override void AgregarParametros(string paramName, DbType spType, int spSize, object spValue)
        {
            cmd.Parameters.Add(paramName, ConvertirTipo(spType), spSize);
            if (spValue == null)
            {
                cmd.Parameters[paramName].IsNullable = true;
                cmd.Parameters[paramName].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters[paramName].Value = spValue;
            }                     
            cmd.Parameters[paramName].Direction = ParameterDirection.Input;
        }

        public override void AgregarParametros(string paramName, DbType spType, int spSize)
        {
            cmd.Parameters.Add(paramName, ConvertirTipo(spType), spSize);
            cmd.Parameters[paramName].Direction = ParameterDirection.Output;
        }

        public override void AgregarParametroDeRetorno(string paramName, DbType spType, int spSize, ParameterDirection tipoRetorno)
        {
            cmd.Parameters.Add(paramName, ConvertirTipo(spType), spSize);
            cmd.Parameters[paramName].Direction = tipoRetorno;
        }

        public override string ValorParametro(string paramName)
        {
            return cmd.Parameters[paramName].Value.ToString();
        }

        public override void VaciarParametros()
        {
            cmd.Parameters.Clear();
        }

        public override DataTable Datos(string qrString)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = qrString;
            cmd.Connection = cnx;
            cmd.CommandTimeout = tiempoDeEsperaConsulta;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public override void Valor(string qrString)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = qrString;
            cmd.Connection = cnx;
            cmd.CommandTimeout = tiempoDeEsperaConsulta;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override void Ejecutar(string exString)
        {
            cmd.Connection = cnx;
            cmd.Transaction = trn;
            cmd.CommandTimeout = tiempoDeEsperaConsulta;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = exString;
            cmd.ExecuteNonQuery();
        }

        public override void CorrerScript(string qrString)
        {
        }

        public override void TiempoEsperaConsulta(int tiempo)
        {
            tiempoDeEsperaConsulta = tiempo;
        }

        private SqlDbType ConvertirTipo(DbType tipo)
        {
            SqlDbType _tipo = SqlDbType.VarChar;
            if (tipo == DbType.String)
            {
                _tipo = SqlDbType.VarChar;
            }
            else if (tipo == DbType.DateTime)
            {
                _tipo = SqlDbType.DateTime;
            }
            else if (tipo == DbType.Boolean)
            {
                _tipo = SqlDbType.Bit;
            }
            else if (tipo == DbType.Int16)
            {
                _tipo = SqlDbType.SmallInt;
            }
            else if (tipo == DbType.Int32)
            {
                _tipo = SqlDbType.Int;
            }
            else if (tipo == DbType.Int64)
            {
                _tipo = SqlDbType.BigInt;
            }
            else if (tipo == DbType.Single)
            {
                _tipo = SqlDbType.Float;
            }
            else if (tipo == DbType.Double)
            {
                _tipo = SqlDbType.Decimal;
            }
            return _tipo;
        }


    }
}
