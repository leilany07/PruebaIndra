using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaDatos;
using System.Data;

namespace PruebaNegocios
{
    public class Resultado
    {
        private PruebaDatos.Resultado objetoPruebaDatos = new PruebaDatos.Resultado();

        #region Metodos #

        public DataTable mostrarResultados()
        {
            try
            {

                DataTable tabla = new DataTable();
                tabla = objetoPruebaDatos.mostrarResultados();
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable mostrarResultadosFiltroUsu(string usuario)
        {
            try
            {

                DataTable tabla = new DataTable();
                tabla = objetoPruebaDatos.mostrarResultadosFiltroUsu(usuario);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable mostrarResultadosFiltroRespM(string usuario, int respuestaMin, int respuestaMax)
        {
            try
            {

                DataTable tabla = new DataTable();
                tabla = objetoPruebaDatos.mostrarResultadosFiltroRespM(usuario, respuestaMin, respuestaMax);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsetarResultado(string usuario, int resultado)
        {
            try
            {
                objetoPruebaDatos.InsetarResultado(usuario, resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void eliminar(int id)
        {

            try
            {
                objetoPruebaDatos.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
