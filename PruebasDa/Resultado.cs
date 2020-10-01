using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace PruebaDatos
{
   public  class Resultado
    {

        private Conexion cone = new Conexion();

        SqlDataReader leer;
        DataTable dt = new DataTable();
        SqlCommand comando = new SqlCommand();

        //mostrar
        public DataTable mostrarResultados()
        {
            // cadena de conexion
            try
            {
                
                comando.Connection = cone.AbrirConexion();
                comando.CommandText = "MostrarResultado";
                comando.CommandType = CommandType.Text;
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
        public DataTable mostrarResultadosFiltroRespM(string usuario, int respuestaMin,int respuestaMax)
        {
            // cadena de conexion
            try
            {

                comando.Connection = cone.AbrirConexion();
                comando.CommandText = "MostrarResultadoFiltro";
                comando.CommandType = CommandType.Text;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@respMin", respuestaMin);
                comando.Parameters.AddWithValue("@respMax", respuestaMax);
                comando.ExecuteNonQuery();
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
        public DataTable mostrarResultadosFiltroUsu(string usuario)
        {
            // cadena de conexion
            try
            {

                comando.Connection = cone.AbrirConexion();
                comando.CommandText = "MostrarResultadoFiltroUser";
                comando.CommandType = CommandType.Text;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@usuario", usuario);
           
                comando.ExecuteNonQuery();
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
        //insertar
        public void InsetarResultado(string usuario, int resultado)
        {
            comando.Connection = cone.AbrirConexion();
            comando.CommandText = "InsetarResultado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@respuesta", resultado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cone.CerrarBaseDatos();
        }

        public void Eliminar(int id)
        {
            comando.Connection = cone.AbrirConexion();
            comando.CommandText = "EliminarResultado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cone.CerrarBaseDatos();
        }
    }
}
