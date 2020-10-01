using System.Data;

namespace PruebaDatos
{
    public abstract class DataAccess
    {
        public abstract void IniciarTransaccion();
        public abstract void TerminarTransaccion();
        public abstract void InterrumpirTransaccion();
        public abstract void AbrirBaseDatos();
        public abstract void CerrarBaseDatos();
        public abstract void AgregarParametros(string paramName, DbType spType, int spSize, object spValue);
        public abstract void AgregarParametros(string paramName, DbType spType, int spSize);
        public abstract void AgregarParametroDeRetorno(string paramName, DbType spType, int spSize, ParameterDirection tipoRetorno);
        public abstract string ValorParametro(string paramName);
        public abstract void VaciarParametros();
        public abstract DataTable Datos(string qrString);
        public abstract void Valor(string qrString);
        public abstract void Ejecutar(string exString);
        public abstract void CorrerScript(string qrString);

        public abstract void TiempoEsperaConsulta(int tiempo);
    }
}
