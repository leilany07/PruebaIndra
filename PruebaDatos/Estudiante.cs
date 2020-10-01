using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaDatos
{
    public class Estudiante
    {


        public static System.Data.DataTable crearEstudiante(long personaid, long cursoid)
        {

            // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

                // da.AbrirBaseDatos();

                String qry = "INSERT INTO  ESTUDIANTES(ESTUDIANTEID,PERSONAID,CURSOID,REGISTROESTADOID)VALUES (ESTUID.nextval," + personaid + "," + cursoid + ",1);";

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


        public static System.Data.DataTable mostrarEstudiante()
        {

            // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

                // da.AbrirBaseDatos();

                String qry = "SELECT A1.ESTUDIANTEID, A2.PERSONAID,  A2.NOMBRES,  A2.IDENTIFICACION,  A2.APELLIDOS,  A3.CODIGO,  A3.NOMBRE CURSONOMBRE  FROM  ESTUDIANTES A1  INNER JOIN PERSON A2 ON  A1.PERSONAID = A2.PERSONAID   INNER JOIN CURSOS A3  ON A3.CURSOID = A1.CURSOID";

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

        public static void estudiante_Actualizar(long estudianteid)
        {

            //  DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            try
            {
                System.Data.DataTable dt = null;

                //  da.AbrirBaseDatos();

                String qry = "UPDATE  ESTUDIANTE WHERE ESTUDIANTEID= " + estudianteid + ";";

                //  dt = da.Datos(qry);

                // da.CerrarBaseDatos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void eliminarEstudiante(long estudianteid)
        {

            //  DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            try
            {
                System.Data.DataTable dt = null;

                //  da.AbrirBaseDatos();

                String qry = "DELETE FROM   ESTUDIANTE WHERE ESTUDIANTEID= " + estudianteid + ";";

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
