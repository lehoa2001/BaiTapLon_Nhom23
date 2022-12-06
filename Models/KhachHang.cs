using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class KhachHang
    {
        [Key]
        public string? IDKhachHang {get; set;}
        public string? TenKhachHang {get; set;}
        public string? DiaChi {get; set;}
        public int? SĐT {get; set;}

    }
}