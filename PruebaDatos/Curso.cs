using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaDatos
{
   public class Curso
    {


        // CREAR CURSO

        public static System.Data.DataTable crearCurso(string codigo, string nombre, string observaciones)
        {

            // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

                // da.AbrirBaseDatos();

                String qry = "INSERT INTO  CURSO(CURSOID,CODIGO,NOMBRE,OBSERVACIONES,REGISTROESTADOID)VALUES (cursoid.nextval," +nombre.Trim() + "," + observaciones.Trim()+ ",1);";

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


        public static System.Data.DataTable mostrarCurso()
        {

           // DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            // cadena de conexion
            try
            {
                System.Data.DataTable dt = null;

               // da.AbrirBaseDatos();

                String qry = "SELECT * FROM  CURSO WHERE REGISTROESTADOID=1";

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

        public static void curso_Actualizar(long cursoid)
        {

          //  DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            try
            {
                System.Data.DataTable dt = null;

              //  da.AbrirBaseDatos();

                String qry = "UPDATE  CURSO WHERE CURSOID= "+ cursoid + ";";

              //  dt = da.Datos(qry);

               // da.CerrarBaseDatos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void eliminarCurso(long cursoid)
        {

            //  DllsUAC.AccesoDatos.DataAccess da = DllsUAC.AccesoDatos.Conexion.ObtenerConexionOracle();
            try
            {
                System.Data.DataTable dt = null;

                //  da.AbrirBaseDatos();

                String qry = "DELETE FROM   CURSO WHERE CURSOID= " + cursoid + ";";

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
