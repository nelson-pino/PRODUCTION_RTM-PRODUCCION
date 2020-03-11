using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class ProductManager
    {
        readonly ClassConexion micomm = new ClassConexion();
        public DataSet ds = new DataSet();
        public DataTable dtproducto = new DataTable();
        readonly SqlDataAdapter daproducto = new SqlDataAdapter();
        readonly string db = "RITRAMA";
        readonly string STRING_SQL_COMMAND_LIST_PRODUCTS = "SELECT " +
        "Product_ID,Product_Name,Product_Descrip,Product_Ref,Codebar,Existencia," +
        "Category_ID,Tipo_MP,Tipo_PT,anulado,fisico,inventario_inicial,salidas" +
        ",existencia_final FROM producto";
        public Boolean ToList()
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = STRING_SQL_COMMAND_LIST_PRODUCTS
                };
                comando.ExecuteNonQuery();
                daproducto.SelectCommand = comando;
                daproducto.Fill(ds, "dtproducto");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar los datos de la tabla de productos. error code:" + ex);
                return false;
            }
        }
  
    }
}
