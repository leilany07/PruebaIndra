
namespace PruebaDatos { 

    public abstract class DataAccessCreator
    {
        public abstract DataAccess FactoryMethod(string user, string password);
        public abstract DataAccess FactoryMethod();
        public abstract DataAccess FactoryMethod(string nombreConexion);
    }
}
