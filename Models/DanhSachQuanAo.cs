using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class DanhSachQuanAo
    {
        [Key]
        public string? IDSp {get; set;}
        public string? TenSp {get; set;}
        public string? ThuongHieu {get; set;}
        public string? GiaTien {get; set;}
        public string? MaSize {get; set;}
        public string? MauSac {get; set;}
    }
}