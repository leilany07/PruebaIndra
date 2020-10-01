using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaDatos
{
   public class Conexion
    {
        

        public static DataAccess ObtenerConexionOracle()
        {
            DataAccessCreator dac = new DataAccessCreatorOracle();
            return dac.FactoryMethod();
        }


        //public static DataAccess ObtenerConexionSql()
        //{
        //    DataAccessCreator dac = new DataAccessCreatorSqlServer();
        //    return dac.FactoryMethod();
        //}

        //public static DataAccess ObtenerConexionSql(string login, string password)
        //{
        //    DataAccessCreator dac = new DataAccessCreatorSqlServer();
        //    return dac.FactoryMethod();
        //}

        //public static DataAccess ObtenerConexion(string login, string password)
        //{
        //    try
        //    {
        //        DataAccessCreator dac = new DataAccessCreatorDB2AS400();
        //        return dac.FactoryMethod(login, password);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private static string LeerArchivo()
        //{

        //    string s;
        //    System.IO.FileStream fs = new System.IO.FileStream("data.uac", System.IO.FileMode.Open, System.IO.FileAccess.Read);
        //    System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
        //    s = br.ReadString();
        //    br.Close();
        //    br.Dispose();
        //    fs.Close();
        //    fs.Dispose();
        //    return Cryptus.CifrarAES.DescifrarTextoAES(s);
        //}

        //private static void CrearArchivo(string login, string password)
        //{
        //    if (System.IO.File.Exists("data.uac")) System.IO.File.Delete("data.uac");
        //    System.IO.FileStream fs = new System.IO.FileStream("data.uac", System.IO.FileMode.CreateNew, System.IO.FileAccess.Write, System.IO.FileShare.Write);
        //    System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
        //    bw.Write(Cryptus.CifrarAES.CifrarTextoAES(login + "|" + password));
        //    bw.Close();
        //    bw.Dispose();
        //    fs.Close();
        //    fs.Dispose();
        //}

        //private static string LeerCache(string sessionId)
        //{
        //    System.Runtime.Caching.ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;
        //    DataTable dt = (System.Data.DataTable)(cache["data"]);
        //    dt = dt.Select("SessionId = " + sessionId).CopyToDataTable();
        //    return dt.Rows[0]["SessionId"].ToString() + "|" + dt.Rows[0]["User"].ToString() + "|" + dt.Rows[0]["User"].ToString();
        //}

        //private static void CrearCache(string sessionId, string login, string password)
        //{

        //    System.Data.DataTable dtSessions = new System.Data.DataTable("Session");
        //    dtSessions.Columns.Add(new System.Data.DataColumn("SessionId", typeof(String)));
        //    dtSessions.Columns["SessionId"].AllowDBNull = false;
        //    dtSessions.Columns["SessionId"].Unique = true;
        //    dtSessions.Columns.Add(new System.Data.DataColumn("User", typeof(String)));
        //    dtSessions.Columns["User"].AllowDBNull = false;
        //    dtSessions.Columns.Add(new System.Data.DataColumn("Psw", typeof(String)));
        //    dtSessions.Columns["Psw"].AllowDBNull = false;

        //    dtSessions.Rows.Add(new Object[] { Cryptus.CifrarAES.CifrarTextoAES(sessionId), Cryptus.CifrarAES.CifrarTextoAES(login), Cryptus.CifrarAES.CifrarTextoAES(password) });

        //    System.Runtime.Caching.ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;
        //    cache["data"] = dtSessions;
        //}


    }
}
