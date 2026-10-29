using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.DAL
{
    public interface ISanPhamDAL
    {
        List<SanPhamDTO> LayDanhSachSanPham();
    }
}
