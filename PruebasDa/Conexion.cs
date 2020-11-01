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

namespace PruebaDatos
{

   public class Conexion
    {

        private SqlConnection cone = new SqlConnection("Server=DESKTOP-D6PE8JT\\SQLEXPRESS;DataBase= PruebaNet;Integrated Security=true");
      

        public SqlConnection CerrarBaseDatos()
        {
            if (cone.State == ConnectionState.Open)
                cone.Close();
            return cone;
        }

        public SqlConnection AbrirConexion()
        {

            if (cone.State == ConnectionState.Closed)
                cone.Open();
            return cone;
        }

    }
}


