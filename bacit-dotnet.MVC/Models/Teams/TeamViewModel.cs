using System.ComponentModel.DataAnnotations;

namespace bacit_dotnet.MVC.Models.Teams
{
    public class TeamViewModel
    {
        [Required]
        [MinLength (5, ErrorMessage = "Skriv et ordentlig teamnavn!")]
        public string teamName { get; set; }
        public int teamId { get; set; }
    }

}