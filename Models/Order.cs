using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samit_For__Trading.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public List<PRODUCT>? PRODUCTS { get; set; }
    }
}
