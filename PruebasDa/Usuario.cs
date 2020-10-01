using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace PruebaDatos
{
   public class Usuario
    {

        private Conexion cone = new Conexion();

        SqlDataReader leer;
        DataTable dt = new DataTable();
        SqlCommand comando = new SqlCommand();


        public  DataTable mostrarUsuarios()
        {

          
            // cadena de conexion
            try
            {
               

                comando.Connection = cone.AbrirConexion();
                comando.CommandText = "MostrarUsuarios";
                comando.CommandType = CommandType.StoredProcedure;              
                leer = comando.ExecuteReader();
                dt.Load(leer);         
                cone.CerrarBaseDatos();
            
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public  DataTable mostrarUsusarioNombre(string user)
        {

        
            // cadena de conexion
            try
            {
                

                comando.Connection = cone.AbrirConexion();
                comando.CommandText = "MostrarUsuarioNombre";             
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@user", user);
                leer = comando.ExecuteReader();
                dt.Load(leer);
                comando.Parameters.Clear();
                cone.CerrarBaseDatos();
                
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
     
    }
}
