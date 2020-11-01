using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PruebaDatos
{
  public  class Articulos
    {

        private Conexion cone = new Conexion();

        SqlDataReader leer;
        DataTable dt = new DataTable();
        SqlCommand comando = new SqlCommand();

        //mostrar
        public DataTable mostrarTodos()
        {
            // cadena de conexion
            try
            {

                comando.Connection = cone.AbrirConexion();
                comando.CommandText = "MostrarArticulos";
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
        public DataTable mostrarFiltro(string nombre, string marca)
        {
            // cadena de conexion
            try
            {

                comando.Connection = cone.AbrirConexion();
                comando.CommandText = "MostrarArticulosFiltro";
                comando.CommandType = CommandType.Text;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@marca", marca);
              
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
        public void Insetar(string nombre, string marca)
        {
            comando.Connection = cone.AbrirConexion();
            comando.CommandText = "InsertarArticulo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cone.CerrarBaseDatos();
        }

        public void Eliminar(int id)
        {
            comando.Connection = cone.AbrirConexion();
            comando.CommandText = "EliminarArticulo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            cone.CerrarBaseDatos();
        }
    }
}

