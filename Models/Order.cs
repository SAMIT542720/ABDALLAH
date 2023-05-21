
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABDALLAH.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public string? Email { get; set; }
        public string? UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User? User { get; set; }
        public List<PRODUCT>? PRODUCTS { get; set; }
    }
}
