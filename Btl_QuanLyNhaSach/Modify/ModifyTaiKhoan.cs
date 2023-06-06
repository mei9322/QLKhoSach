using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Management;
using System.Data;
using Btl_QuanLyNhaSach.Object;
using System.Data.Common;

namespace Btl_QuanLyNhaSach
{
    class ModifyTaiKhoan
    {
        public ModifyTaiKhoan()
        {
        }

        SqlCommand sqlCommand; // Dùng để truy vấn các lệnh insert, update,..
        SqlDataReader dataReader;
        SqlDataAdapter dataAdapter;

        // Tạo 1 list tài khoản
        public List<TaiKhoan> TaiKhoans(string query) // Check tài khoản đăng nhập
        {
            List<TaiKhoan> taiKhoans= new List<TaiKhoan>();

            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while ( dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }

                sqlConnection.Close();
            } 

            return taiKhoans;
        }

        public void Command(string query) // Dùng để đăng kí tài khoản
        {
            // Mở đường kết nối
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery(); // Thực hiện truy vấn
                sqlConnection.Close();
            }    
        }

        // Tạo dataTable để đổ dữ liệu vào datagridview
        public DataTable Table(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

    }
}
