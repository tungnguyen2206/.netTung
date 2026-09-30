using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TvcLesson12.Models;

public class NMTMember
{
    [Key]
    [DisplayName("Mã thành viên")]
    public string NMTMemberId { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
    [StringLength(50)]
    [DisplayName("Tên đăng nhập")]
    public string NMTUserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    [StringLength(100)]
    [DisplayName("Mật khẩu")]
    public string NMTPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Họ và tên không được để trống")]
    [StringLength(200)]
    [DisplayName("Họ và tên")]
    public string NMTFullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [DisplayName("Email")]
    public string NMTEmail { get; set; } = string.Empty;
}
