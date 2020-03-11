using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class ConfigManager
    {
        readonly Conexion Micomm = new Conexion();
        readonly string db = "RITRAMA";
        readonly string sql1 = "SELECT par1 FROM control WHERE filter=@p1";
        readonly string sql2 = "UPDATE control SET par1=@p1 WHERE filter=@p2";
        public string GetParameterControl(string filter)
        {
            string cant_value;
            Micomm.Conectar(db);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = sql1,
                Connection = Micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", filter);
            comando.Parameters.Add(p1);
            try
            {
                cant_value = comando.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los parametros de la tabla control...error code:" + ex);
                cant_value = "";
            }
            Micomm.Desconectar();
            comando.Dispose();
            return cant_value;
        }
        public Boolean SetParametersControl(string value, string filter)
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = sql2,
                    Connection = Micomm.cnn
                };
                SqlParameter p1 = new SqlParameter("@p1", value);
                SqlParameter p2 = new SqlParameter("@p2", filter);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.ExecuteScalar();
                Micomm.Desconectar();
                comando.Dispose();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al tratar de salvar el consecutivo de la orden de corte. error code:" + ex);
                return false;
            }
        }
    }
}
