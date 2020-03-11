using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class Conexion
    {
        
        public SqlConnection cnn;
        public Boolean Conectar(string bd)
        {
            try
            {
                cnn = new SqlConnection(@"Server=" + R.SERVERS.SERVER_ETIQUETAS +
                    ";Database=" + bd + ";User Id=" + R.USERS.UserMaster +
                    ";Password="+ R.USERS.KeyMaster + ";");
                cnn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(R.ERROR_MESSAGES.ERROR_SQL.ERROR_MESSAGE_SQLCONNECT + ex);
                return false;
            }
        }

        public Boolean Desconectar()
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(R.ERROR_MESSAGES.ERROR_SQL.ERROR_MESSAGE_SQLDISCONNECT + ex);
                return false;
            }
        }
    }
}
