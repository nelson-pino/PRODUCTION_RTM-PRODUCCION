using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class CustomerManager
    {
        Conexion micomm = new Conexion();
        public DataSet ds = new DataSet();
        DataTable dtcustomer = new DataTable();
        SqlDataAdapter dacustomer = new SqlDataAdapter();
        string db = "RITRAMA";
        string sql1 = "SELECT Customer_ID,Customer_Name,Customer_Category,Customer_Dir,Customer_Email,Anulado,phone  FROM customer";
        string sql2 = "INSERT INTO customer (Customer_ID,Customer_Name,Customer_Category,Customer_Dir,Customer_Email,Anulado,phone) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
        string sql3 = "UPDATE customer SET Customer_Name=@p2,Customer_Category=@p3,Customer_Dir=@p4,Customer_Email=@p5,Anulado=@p6,phone=@p7 WHERE Customer_ID=@p1";
        string sql4 = "SELECT count(*) FROM customer WHERE customer_id=@p1";
        public Boolean ToList()
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql1

                };
                comando.ExecuteNonQuery();
                dacustomer.SelectCommand = comando;
                dacustomer.Fill(ds, "dtcustomer");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los clientes. error code:" + ex);
                return false;
            }
        }
        public Boolean Add(ClassCustomer customer)
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql2

                };
                SqlParameter p1 = new SqlParameter("@p1", customer.CustomerID);
                SqlParameter p2 = new SqlParameter("@p2", customer.CustomerName);
                SqlParameter p3 = new SqlParameter("@p3", customer.Category);
                SqlParameter p4 = new SqlParameter("@p4", customer.direcc);
                SqlParameter p5 = new SqlParameter("@p5", customer.email);
                SqlParameter p6 = new SqlParameter("@p6", customer.Anulado);
                SqlParameter p7 = new SqlParameter("@p7", customer.phone);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                MessageBox.Show("proceso realizado con exito...");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar nuevo registro de cliente...Error Code:" + ex);
                return false;
            }
        }
        public Boolean Update(ClassCustomer customer)
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql3

                };
                SqlParameter p1 = new SqlParameter("@p1", customer.CustomerID);
                SqlParameter p2 = new SqlParameter("@p2", customer.CustomerName);
                SqlParameter p3 = new SqlParameter("@p3", customer.Category);
                SqlParameter p4 = new SqlParameter("@p4", customer.direcc);
                SqlParameter p5 = new SqlParameter("@p5", customer.email);
                SqlParameter p6 = new SqlParameter("@p6", customer.Anulado);
                SqlParameter p7 = new SqlParameter("@p7", customer.phone);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                MessageBox.Show("Se actualizaron los datos con exito...");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar cliente...Error Code:" + ex);
                return false;
            }
        }
        public DataTable GetCustomersTableOnly()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql1

                };
                comando.ExecuteNonQuery();
                da.SelectCommand = comando;
                da.Fill(dt);
                comando.Dispose();
                micomm.Desconectar();
                return dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los clientes. error code:" + ex);
                return dt;
            }
        }
        public Boolean ClienteExiste(string codigo)
        {
            int result;
            micomm.Conectar(db);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = sql4,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
