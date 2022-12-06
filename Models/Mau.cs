using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class Mau
    {
        [Key]
        public string? MaMau {get; set;}
        public string? TenMau {get; set;}
    }
}