using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;


namespace TiendaWS
{
    public class Procedures
    {
        public Procedures()
        {

        }

        public string insert_producto_only(
            OracleConnection conn,
            string nombreprod, 
            string descrip, 
            string marca,
            double precio, 
            int stock,
            double descu, 
            string fechaIngreso,
            int idCategoria)
        {
            //Insert
            OracleParameter p_nombreprod = new OracleParameter();
            p_nombreprod.OracleDbType = OracleDbType.Varchar2;
            p_nombreprod.Value = nombreprod;

            OracleParameter p_descrip = new OracleParameter();
            p_descrip.OracleDbType = OracleDbType.Varchar2;
            p_descrip.Value = descrip;

            OracleParameter p_marca = new OracleParameter();
            p_marca.OracleDbType = OracleDbType.Varchar2;
            p_marca.Value = marca;

            OracleParameter p_precio = new OracleParameter();
            p_precio.OracleDbType = OracleDbType.Double;
            p_precio.Value = precio;

            OracleParameter p_stock = new OracleParameter();
            p_stock.OracleDbType = OracleDbType.Double;
            p_stock.Value = stock;

            OracleParameter p_descu = new OracleParameter();
            p_descu.OracleDbType = OracleDbType.Varchar2;
            p_descu.Value = descu;


            OracleParameter p_fechaIngreso = new OracleParameter();
            p_fechaIngreso.OracleDbType = OracleDbType.Varchar2;
            p_fechaIngreso.Value = fechaIngreso;

            OracleParameter p_idCategoria = new OracleParameter();
            p_idCategoria.OracleDbType = OracleDbType.Varchar2;
            p_idCategoria.Value = idCategoria;

            OracleCommand cmd = new OracleCommand("insert_producto_only", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_nombreprod);
            cmd.Parameters.Add(p_descrip);
            cmd.Parameters.Add(p_marca);
            cmd.Parameters.Add(p_precio);
            cmd.Parameters.Add(p_stock);
            cmd.Parameters.Add(p_descu);
            cmd.Parameters.Add(p_fechaIngreso);
            cmd.Parameters.Add(p_idCategoria);

            //return cmd.Parameters. .ToString();

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Producto insertado";
            }
            catch
            {
                return "Error al insertar el nuevo producto";
            }

        }

        public string read_producto_only(OracleConnection conn, int idprod)//Select
        {
            OracleParameter p_id = new OracleParameter();
            p_id.OracleDbType = OracleDbType.Int16;
            p_id.Value = idprod;

            OracleCommand cmd = new OracleCommand("read_producto_only", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(p_id);
            cmd.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            try
            {
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);

                conn.Dispose();

                return JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return "ERROR al obtener el producto" + ex.Message;
            }

            //dataGridView.DataSource = data;


        }

        
        public string read_producto_all(OracleConnection conn)
        {
            OracleCommand cmd = new OracleCommand("read_producto_all", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            try
            {

                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);

                conn.Dispose();

                return JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return "ERROR al obtener el producto" + ex.Message;
            }

            //dataGridView.DataSource = data;


        }


        public string update_producto_only(OracleConnection conn, int id_producto, string nombreprod, string descrip, string marca, double precio, int stock, double descu, string fechaIngreso, int idCategoria)
        {
            OracleParameter p_id_producto = new OracleParameter();
            p_id_producto.OracleDbType = OracleDbType.Int16;
            p_id_producto.Value = id_producto;

            OracleParameter p_nombreprod = new OracleParameter();
            p_nombreprod.OracleDbType = OracleDbType.Varchar2;
            p_nombreprod.Value = nombreprod;

            OracleParameter p_descrip = new OracleParameter();
            p_descrip.OracleDbType = OracleDbType.Varchar2;
            p_descrip.Value = descrip;

            OracleParameter p_marca = new OracleParameter();
            p_marca.OracleDbType = OracleDbType.Varchar2;
            p_marca.Value = marca;

            OracleParameter p_precio = new OracleParameter();
            p_precio.OracleDbType = OracleDbType.Double;
            p_precio.Value = precio;

            OracleParameter p_stock = new OracleParameter();
            p_stock.OracleDbType = OracleDbType.Int16;
            p_stock.Value = stock;

            OracleParameter p_descu = new OracleParameter();
            p_descu.OracleDbType = OracleDbType.Double;
            p_descu.Value = descu;


            OracleParameter p_fechaIngreso = new OracleParameter();
            p_fechaIngreso.OracleDbType = OracleDbType.Varchar2;
            p_fechaIngreso.Value = fechaIngreso;

            OracleParameter p_idCategoria = new OracleParameter();
            p_idCategoria.OracleDbType = OracleDbType.Int16;
            p_idCategoria.Value = idCategoria;

            OracleCommand cmd = new OracleCommand("update_producto_only", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_id_producto);
            cmd.Parameters.Add(p_nombreprod);
            cmd.Parameters.Add(p_descrip);
            cmd.Parameters.Add(p_marca);
            cmd.Parameters.Add(p_precio);
            cmd.Parameters.Add(p_stock);
            cmd.Parameters.Add(p_descu);
            cmd.Parameters.Add(p_fechaIngreso);
            cmd.Parameters.Add(p_idCategoria);


            //return cmd.Parameters. .ToString();

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Producto actualizado";
            }
            catch
            {
                return "Error al actualizar el producto";
            }
        }



        public string delete_producto(OracleConnection conn, int id)
        {
            OracleParameter p_id = new OracleParameter();
            p_id.OracleDbType = OracleDbType.Varchar2;
            p_id.Value = id;

            OracleCommand cmd = new OracleCommand("delete_producto", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_id);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Producto eliminado";
            }
            catch
            {
                return "Error al eliminar el producto";
            }
        }






    }
}