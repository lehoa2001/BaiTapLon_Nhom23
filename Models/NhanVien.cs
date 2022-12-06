using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class NhanVien
    {
        [Key]
        public string? MaID {get; set;}
        public string? Ten {get; set;}
        public string? NgaySinh {get; set;}
        public string? QueQuan {get; set;}
        public int? SĐT {get; set;}
        public string? MaChucVu {get; set;}
        [ForeignKey("MaChucVu")]
       public ChucVu? ChucVu{get; set;}

    }
}