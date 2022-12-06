using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class HoaDon
    {
        [Key]
        public string? IDKhachHang {get; set;}
        public string? TenKhachHang {get; set;}
        public string? DiaChi {get; set;}
        public int? SĐT {get; set;}
        public string? IDSp {get; set;}
        public string? TenSp {get; set;}
        public int? TongTien {get; set;}
        public int? PhuongThucTT {get; set;}

    }
}