using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class QuanAo
    {
        [Key]
        public string? IDSp {get; set;}
        public string? TenSp {get; set;}
        public string? ThuongHieu {get; set;}
        public string? GiaTien {get; set;}
        public int? SoLuong {get; set;}
        public string? MaSize {get; set;}
        [ForeignKey("MaSize")]
        public Size? Size{get; set;}
        public string? MaMau {get; set;}
        [ForeignKey("MaMau")]
        public Mau? Mau {get; set;}

    }
}