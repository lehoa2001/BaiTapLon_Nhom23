using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class ChucVu
    {
        [Key]
        public string? MaChuVu {get; set;}
        public string? TenChucVu {get; set;}
    }
}