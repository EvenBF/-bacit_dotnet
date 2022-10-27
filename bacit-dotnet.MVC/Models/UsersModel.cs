using bacit_dotnet.MVC.Entities;

namespace bacit_dotnet.MVC.Models
{
    public class UsersModel
    {
        public IEnumerable<User> Users { get; set; }
    }

    public class SuggestionModel {

        public IEnumerable<Suggestion> Sug {
            get; set;
        }
    }

    public class TeamModel
    {
        public IEnumerable<Team> Team
        {
            get; set;
        }
    }
}

