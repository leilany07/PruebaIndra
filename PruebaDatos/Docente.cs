using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaDatos
{
    public class Docente
    {


        public static System.Data.DataTable crearDocente(long personaid, long cursoid)
        {

            // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

                // da.AbrirBaseDatos();

                String qry = "INSERT INTO  DOCENTES(DOCENTEID,PERSONAID,CURSOID,REGISTROESTADOID)VALUES (DOCENID.nextval," + personaid+ "," + cursoid + ",1);";

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


        public static System.Data.DataTable mostrarDocentes()
        {

            // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

                // da.AbrirBaseDatos();

                String qry = "SELECT A1.DOCENTEID, A2.PERSONAID,  A2.NOMBRES,  A2.IDENTIFICACION,  A2.APELLIDOS,  A3.CODIGO,  A3.NOMBRE CURSONOMBRE  FROM  DOCENTES A1  INNER JOIN PERSON A2 ON  A1.PERSONAID = A2.PERSONAID   INNER JOIN CURSOS A3  ON A3.CURSOID = A1.CURSOID";

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

        public static void docente_Actualizar(long docenteid)
        {

            //  DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            try
            {
                System.Data.DataTable dt = null;

                //  da.AbrirBaseDatos();

                String qry = "UPDATE  DOCENTES WHERE DOCENTEID= " + docenteid + ";";

                //  dt = da.Datos(qry);

                // da.CerrarBaseDatos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void eliminarDocente(long docenteid)
        {

            //  DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            try
            {
                System.Data.DataTable dt = null;

                //  da.AbrirBaseDatos();

                String qry = "DELETE FROM   DOCENTE WHERE DOCENTEID= " + docenteid + ";";

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
