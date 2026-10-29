using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAL
{
    public static class DbConnectionTest
    {
        public static bool TestConnection(out string message)
        {
            try
            {
                using (SqlConnection connection =
                       DbConnectionFactory.CreateConnection())
                {
                    connection.Open();

                    message = "Kết nối SQL Server thành công!";
                    return true;
                }
            }
            catch (SqlException ex)
            {
                message = "Lỗi SQL Server: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                message = "Lỗi: " + ex.Message;
                return false;
            }
        }
    }
}
