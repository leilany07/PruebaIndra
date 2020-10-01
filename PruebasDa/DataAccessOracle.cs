using System;
using System.Linq;
using System.Data;
using Oracle.DataAccess.Client;
using System.Configuration;
namespace PruebaDatos
{
    public class DataAccessOracle: DataAccess
    {
        private OracleConnection cnx;
        private OracleCommand cmd;
        private OracleTransaction trn;
        private int tiempoDeEsperaConsulta = 10000;

        public DataAccessOracle(string user, string password)
        {
            try
            {
                string strCnx = ConfigurationManager.ConnectionStrings["ICEBERG"].ToString();
                strCnx = strCnx.Replace("[USER]", user);
                strCnx = strCnx.Replace("[PASSWORD]", password);
                cnx = new OracleConnection(strCnx);
                cmd = new OracleCommand();
            }
            catch (Exception ex)
            {
                if (ex.GetType().ToString() == "System.Data.OracleClient.OracleException")
                {
                    OracleException err = (OracleException)ex;
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

        public DataAccessOracle(string nombreConexion)
        {
            cnx = new OracleConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ToString());
            cmd = new OracleCommand();
        }

        public DataAccessOracle()
        {
            cnx = new OracleConnection(ConfigurationManager.ConnectionStrings["ICEBERG"].ToString());
            cmd = new OracleCommand();
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
            cmd.Parameters[paramName].Value = spValue;
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
            cmd.CommandText = qrString;
            cmd.Connection = cnx;
            //cmd.Transaction = trn;
            cmd.CommandTimeout = tiempoDeEsperaConsulta;
            cmd.CommandType = System.Data.CommandType.Text;
            // cmd.ExecuteNonQuery();
            OracleDataReader reader = cmd.ExecuteReader();

            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            return dt;

        }

        public override void Valor(string qrString)
        {
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

        public override void CorrerScript(string exString)
        {
            cmd.Connection = cnx;
            cmd.Transaction = trn;
            cmd.CommandTimeout = tiempoDeEsperaConsulta;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = exString;
            cmd.ExecuteNonQuery();
        }

        public override void TiempoEsperaConsulta(int tiempo)
        {
            tiempoDeEsperaConsulta = tiempo;
        }

        private OracleDbType ConvertirTipo(DbType tipo)
        {
            OracleDbType _tipo = new OracleDbType();
            if (tipo == DbType.String)
            {
                _tipo = OracleDbType.Varchar2;
            }
            else if (tipo == DbType.DateTime)
            {
                _tipo = OracleDbType.TimeStamp;
            }
            else if (tipo == DbType.Boolean)
            {
                _tipo = OracleDbType.Int16;
            }
            else if (tipo == DbType.Int16)
            {
                _tipo = OracleDbType.Int16;
            }
            else if (tipo == DbType.Int32)
            {
                _tipo = OracleDbType.Int32;
            }
            else if (tipo == DbType.Int64)
            {
                _tipo = OracleDbType.Int64;
            }
            else if (tipo == DbType.Single)
            {
                _tipo = OracleDbType.Single;
            }
            else if (tipo == DbType.Double)
            {
                _tipo = OracleDbType.Double;
            }
            return _tipo;
        }

    }
}
