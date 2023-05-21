using System.ComponentModel.DataAnnotations;

namespace ABDALLAH.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "الاسم الكامل مطلوب")]
        public string? FullName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "عنوان البريد الإلكتروني مطلوب")]
        public string? EmialAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمة المرور غير مطابقة")]
        public string? ConfirmPassword { get; set; }
    }
}
