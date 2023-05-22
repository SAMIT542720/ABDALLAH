using ABDALLAH.Models;

namespace ABDALLAH.Data.ViewModels
{
    public class NewProductVMdropdown
    {
        public NewProductVMdropdown()
        {
            users = new List<User>();
            
        }
        public List<User> users { get; set; }
    }
}
