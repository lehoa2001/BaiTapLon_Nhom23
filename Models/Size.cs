using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class Size
    {
        [Key]
        public string? MaSize {get; set;}
        public string? TenSize {get; set;}
    }
}