using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using PruebaNegocios;
namespace webservice
{
    /// <summary>
    /// Descripción breve de WSbuscarUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSbuscarUsuario : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        /// <summary>
        /// NUEVO DE CONEXION
        /// </summary>
        /// <returns></returns>
        private PruebaNegocios.Usuario usuario = new PruebaNegocios.Usuario();

        SqlDataReader leer;
        DataTable dt = new DataTable();
        DataSet table = new DataSet();
     


        [WebMethod]
        public DataSet WSlistadoUsuarios()
        {

         try
            {

                dt = usuario.mostrarUsuarios();
                table.Tables.Add(dt);

              
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public DataSet WSlistadoUsuarioNombre(String user)
        {

            try
            {
              

                dt = usuario.mostrarUsusarioNombre(user);
                table.Tables.Add(dt);

                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
