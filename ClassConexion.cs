using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace RitramaAPP
{
    public class ClassConexion
    {
        public string ServerEtiqueta = @"";
        public string LaptopVIT = @"DESKTOP-M2F5UC0\SQLEXPRESS;";
        public SqlConnection cnn;

        public Boolean Conectar(string bd)
        {
            try
            {
                cnn = new SqlConnection("Server=" + LaptopVIT +
                "initial catalog=" + bd + ";integrated security=true");
                cnn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error de conexion a la base de datos. error code:" + ex);
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
                MessageBox.Show("Error al desconectarse de la base de datos. error: " + ex);
                return false;
            }
        }
    }
}
