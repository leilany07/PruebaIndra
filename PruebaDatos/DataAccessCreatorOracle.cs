using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DllsUAC.AccesoDatos
{
    public class DataAccessCreatorOracle : DataAccessCreator
    {
        public override DataAccess FactoryMethod(string user, string password)
        {
            return new DataAccessOracle(user, password);
        }
        public override DataAccess FactoryMethod(string nombreConexion)
        {
            return new DataAccessOracle(nombreConexion);
        }

        public override DataAccess FactoryMethod()
        {
            return new DataAccessOracle();
        }
    }
}
