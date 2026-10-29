using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.BLL
{
    public static class ConnectionService
    {
        public static bool TestConnection(out string message)
        {
            return DbConnectionTest.TestConnection(out message);
        }
    }
}
