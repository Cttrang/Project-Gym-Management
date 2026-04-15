using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp_GYM.DAL
{
        public class DataConnection
        {
            // Chuỗi kết nối: Bạn cần thay "TEN-MAY-TINH" bằng tên Server của bạn
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GYMMANAGEMENT;Integrated Security=True";

            public SqlConnection GetConnection()
            {
                return new SqlConnection(connString);
            }

        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = GetConnection()) // Hàm GetConnection bạn đã có
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }

        // --- BẮT ĐẦU PHẦN BỔ SUNG ---

        // 1. Hàm ExecuteQuery có tham số (Dùng cho ScheduleDAL.GetSchedules)
        public DataTable ExecuteQuery(string sql, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // 2. Hàm ExecuteNonQuery có tham số (Dùng cho Update, Insert, Delete)
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            int rows = 0;
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                rows = cmd.ExecuteNonQuery();
            }
            return rows;
        }


    }
    

}
