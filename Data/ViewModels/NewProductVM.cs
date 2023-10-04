using ABDALLAH.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ABDALLAH.Data.ViewModels
{
    public class NewProductVM
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "CostumerFullName")]
        [Required(ErrorMessage = "الإسم مطلوب")]
        public string? CostumerFullName { get; set; }
        [Display(Name = "CotumerCity")]
        [Required(ErrorMessage = "مطلوب ادخال اسم المدينة")]
        public string? CotumerCity { get; set; }
        [Display(Name = "CostumerPhoneNumber")]
        [Required(ErrorMessage = "مطلوب رقم هاتف العميل")]
        public int? CostumerPhoneNumber { get; set; }
        [Display(Name = "PNumber")]
        [Required(ErrorMessage = "مطلوب كمية المنتج")]
        public int? PNumber { get; set; }
        [Display(Name = "NameFR")]
        [Required(ErrorMessage = "مطلوب الاسم بالأبجدية اللاتينية (الاسم المكتوب على المنتج)")]
        public string? NameFR { get; set; }
        [Display(Name = "NameAR")]
        [Required(ErrorMessage = "الاسم مطلوب في الحروف الهجائية العربية")]
        public string? NameAR { get; set; }
        public int? Benefit { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "السعر مطلوب")]
        public int? Price { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "الوصف مطلوب")]
        public string? Description { get; set; }
        [Display(Name = "Destination")]
        [Required(ErrorMessage = "الوجهة مطلوبة")]
        public string? Destination { get; set; }
        [Display(Name = "Date")]
        [Required(ErrorMessage = "يجب إدخال التاريخ")]
        public DateTime? Date { get; set; }
        public int? Payment { get; set; }
        [Display(Name = "ShippingPayment")]
        [Required(ErrorMessage = "مطلوب ادخال رسوم الشحن")]
        public int? ShippingPayment { get; set; }
        public int? PRODUCTID { get; set; }
        [ForeignKey("PRODUCTID")]
        [Display(Name = "UserIDS")]
        [Required(ErrorMessage = "يجب اختيار العميل إذا لم يكن مدرجًا في القائمة ، فاختر أي عميل ثم أنشئ حسابًا جديدًا للعميل المستهدف وقم بتحديث الطلب")]
        public List<int>? UserIDS { get; set; }
        public string? Statu { get; set; }
    }
}
