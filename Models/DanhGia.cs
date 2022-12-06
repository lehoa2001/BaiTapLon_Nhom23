using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLon_Nhom23.Models
{
    public class DanhGia
    {
        [Key]
        public string? IDSp {get; set;}
        public string? TenSp {get; set;}
        public string? GopY {get; set;}
        public int? DiemDanhGia {get; set;}

    }
}