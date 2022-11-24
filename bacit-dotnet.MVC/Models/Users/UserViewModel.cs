using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.Users
{
    public class UserViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email{ get; set; }
        public int phone { get; set; }
    }
}
