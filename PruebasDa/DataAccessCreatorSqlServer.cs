using DllsUAC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDatos
{
    public class DataAccessCreatorSqlServer : DataAccessCreator
    {
        public override DataAccess FactoryMethod(string user, string password)
        {
            return new DataAccessSqlServer(user, password);
        }
        public override DataAccess FactoryMethod(String nombreConexion)
        {
            return new DataAccessSqlServer(nombreConexion);
        }

        public override DataAccess FactoryMethod()
        {
            return new DataAccessSqlServer();
        }
    }
}
