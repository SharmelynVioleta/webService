using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;


namespace TiendaWS
{
    public class Oracle_conection
    {
        OracleConnection oc;
        string oradb = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=TIENDAONLINNE;PASSWORD=adminn";

        public void OpenCon()
        {
            oc = new OracleConnection(oradb);
            oc.Open();
        }

        public OracleConnection GetCon()
        {
            return oc;
        }

        public OracleConnection Conn
        {
            get { return oc; }
        }

    }
}