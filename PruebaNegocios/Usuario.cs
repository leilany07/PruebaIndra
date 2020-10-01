using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaDatos;
using System.Data;
namespace PruebaNegocios
{
   
    public class Usuario
    {
        private PruebaDatos.Usuario objetoPruebaDatos = new PruebaDatos.Usuario();

        #region Metodos #

        public DataTable mostrarUsuarios()
        {
            try
            {

                DataTable tabla = new DataTable();
                tabla =  objetoPruebaDatos.mostrarUsuarios();
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public  DataTable mostrarUsusarioNombre(string user)
        {
            try
            {
               
                
                DataTable tabla = new DataTable();
                tabla = objetoPruebaDatos.mostrarUsusarioNombre(user);
                
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
