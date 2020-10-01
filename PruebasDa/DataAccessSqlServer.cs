using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
using System.Configuration;
using PruebaDatos;

namespace DllsUAC.AccesoDatos
{
    public class DataAccessSqlServer
    {

        private SqlConnection Conexion = new SqlConnection("Server=SISTEMAS14\\SQLEXPRESS;DataBase= Practica;Integrated Security=true");


        private SqlConnection cnx;
        private SqlCommand cmd;
        private SqlTransaction trn;
        private int tiempoDeEsperaConsulta = 10000;

       
       

        public SqlConnection CerrarBaseDatos()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

        public SqlConnection AbrirConexion()
        {

            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }


        

        //public override void AgregarParametros(string paramName, DbType spType, int spSize)
        //{
        //    cmd.Parameters.Add(paramName, ConvertirTipo(spType), spSize);
        //    cmd.Parameters[paramName].Direction = ParameterDirection.Output;
        //}

        //public override void AgregarParametroDeRetorno(string paramName, DbType spType, int spSize, ParameterDirection tipoRetorno)
        //{
        //    cmd.Parameters.Add(paramName, ConvertirTipo(spType), spSize);
        //    cmd.Parameters[paramName].Direction = tipoRetorno;
        //}

        //public override string ValorParametro(string paramName)
        //{
        //    return cmd.Parameters[paramName].Value.ToString();
        //}

        //public override void VaciarParametros()
        //{
        //    cmd.Parameters.Clear();
        //}

        //public override DataTable Datos(string qrString)
        //{
        //    DataTable dt = new DataTable();
        //    cmd.CommandText = qrString;
        //    cmd.Connection = cnx;
        //    cmd.CommandTimeout = tiempoDeEsperaConsulta;
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        adp.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return dt;
        //}

        //public override void Valor(string qrString)
        //{
        //    DataTable dt = new DataTable();
        //    cmd.CommandText = qrString;
        //    cmd.Connection = cnx;
        //    cmd.CommandTimeout = tiempoDeEsperaConsulta;
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

      //  }

        //public override void Ejecutar(string exString)
        //{
        //    cmd.Connection = cnx;
        //    cmd.Transaction = trn;
        //    cmd.CommandTimeout = tiempoDeEsperaConsulta;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = exString;
        //    cmd.ExecuteNonQuery();
        //}

        //public override void CorrerScript(string qrString)
        //{
        //}

        //public override void TiempoEsperaConsulta(int tiempo)
        //{
        //    tiempoDeEsperaConsulta = tiempo;
        //}

        //private SqlDbType ConvertirTipo(DbType tipo)
        //{
        //    SqlDbType _tipo = SqlDbType.VarChar;
        //    if (tipo == DbType.String)
        //    {
        //        _tipo = SqlDbType.VarChar;
        //    }
        //    else if (tipo == DbType.DateTime)
        //    {
        //        _tipo = SqlDbType.DateTime;
        //    }
        //    else if (tipo == DbType.Boolean)
        //    {
        //        _tipo = SqlDbType.Bit;
        //    }
        //    else if (tipo == DbType.Int16)
        //    {
        //        _tipo = SqlDbType.SmallInt;
        //    }
        //    else if (tipo == DbType.Int32)
        //    {
        //        _tipo = SqlDbType.Int;
        //    }
        //    else if (tipo == DbType.Int64)
        //    {
        //        _tipo = SqlDbType.BigInt;
        //    }
        //    else if (tipo == DbType.Single)
        //    {
        //        _tipo = SqlDbType.Float;
        //    }
        //    else if (tipo == DbType.Double)
        //    {
        //        _tipo = SqlDbType.Decimal;
        //    }
        //    return _tipo;
        //}


   }
}
