using System;
using System.Data;
using System.Configuration;
namespace PruebaDatos
{
    public class Persona
    {
        public static System.Data.DataTable crearPersona(string identificacion, string nombres , string apellidos,string genero)
        {

            // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

                // da.AbrirBaseDatos();

                String qry = "  INSERT INTO  PERSON (PERSONAID,IDENTIFICACION,NOMBRES,APELLIDOS,GENERO,REGISTROESTADOID)VALUES (PERSONID.nextval," + identificacion.Trim() + "," + nombres.Trim() + "," +  apellidos.Trim() + ",1);";

                // dt = da.Datos(qry);

                // da.CerrarBaseDatos();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //mostrar


        public static System.Data.DataTable mostrarPersona()
        {

            // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

                // da.AbrirBaseDatos();

                String qry = "SELECT * FROM  PERSON WHERE REGISTROESTADOID=1";

                // dt = da.Datos(qry);

                // da.CerrarBaseDatos();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static System.Data.DataTable mostrarPersonaUsusario(string documento)
        {

            // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

                // da.AbrirBaseDatos();

                String qry = "SELECT * FROM  PERSON WHERE REGISTROESTADOID=1 AND IDENTIFICACION='" + documento.Trim()+"'";

                // dt = da.Datos(qry);

                // da.CerrarBaseDatos();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ACTUALIZAR CURSO

        public static void persona_Actualizar(long personaid)
        {

            //  DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            try
            {
                System.Data.DataTable dt = null;

                //  da.AbrirBaseDatos();

                String qry = "UPDATE  PERSON WHERE PERSONAID= " + personaid + ";";

                //  dt = da.Datos(qry);

                // da.CerrarBaseDatos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void eliminarPersona(long personaid)
        {

            //  DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            try
            {
                System.Data.DataTable dt = null;

                //  da.AbrirBaseDatos();

                String qry = "DELETE FROM   PERSONA WHERE PERSONAID= " + personaid + ";";

                //  dt = da.Datos(qry);

                // da.CerrarBaseDatos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
