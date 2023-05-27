using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TiendaWS
{
    /// <summary>
    /// Descripción breve de ProductorTienda
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductorTienda : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }


        [WebMethod]
        public string insert_producto_only( 
            string nombreprod,
            string descrip, string marca,
            double precio, 
            int stock,
            double descu, 
            string fechaIngreso,
            int idCategoria)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.insert_producto_only(conn.Conn, nombreprod, descrip, marca, precio, stock, descu, fechaIngreso, idCategoria);
        }


        [WebMethod]
        public string read_producto_only(int id_producto)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.read_producto_only(conn.Conn, id_producto);
        }


        [WebMethod]
        public string read_producto_all()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.read_producto_all(conn.Conn);
        }



        [WebMethod]
        public string update_producto_only(
            int id_producto,
            string nombreprod, 
            string descrip,
            string marca, 
            double precio,
            int stock, 
            double descu,
            string fechaIngreso,
            int idCategoria)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.update_producto_only(conn.Conn, id_producto, nombreprod, descrip, marca, precio, stock, descu, fechaIngreso, idCategoria);
        }


        [WebMethod]
        public string delete_producto(int id)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.OpenCon();

            Procedures pc = new Procedures();
            return pc.delete_producto(conn.Conn, id);
        }


        //METODO PARA VERIFICAR LA CONECCION A LA BASE DE DATOS ORACLE
        [WebMethod]
        public bool conect()
        {
            try
            {
                Oracle_conection conn = new Oracle_conection();
                conn.OpenCon();
                return true;
            }
            catch
            {
                return false;
            }
        
        }      

    }
}
