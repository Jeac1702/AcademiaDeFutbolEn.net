using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace AcademiaFutbol.Clases
{
    public class Conexion
    {
        public SqlConnection conectar()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-9JKKC2SP\SQLEXPRESS;Initial Catalog=AcademiaFutbol;Integrated Security=True");
            return con;
        }

        public DataTable queryAdapter(string query)
        {
            SqlConnection con = this.conectar();
            con.Open();        
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            con.Close();
            adapter.Dispose();
            return dt;
        }

        public void nonQueryAdapter(string query, out int registros)
        {
            SqlConnection con = this.conectar();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            registros = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();  
        }

        public void queryScalarAdapter(string table, string campo, string clausulas, out string result)
        {
            SqlConnection con = this.conectar();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT "+campo+" FROM "+table+" "+clausulas, con);
            SqlDataReader reader = cmd.ExecuteReader();
            result = "";
            while (reader.Read())
            {
                result = reader[campo].ToString();
            }
            reader.Close();
            con.Close();
            cmd.Dispose();
        }        
    }
}
