using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Suggestions;
using bacit_dotnet.MVC.Models.Teams;
using bacit_dotnet.MVC.Models.Users;

namespace bacit_dotnet.MVC.DataAccess
{
    public interface ISqlConnector
    {
        IEnumerable<User> GetUsers();
        IEnumerable<team> GetTeam();
        IEnumerable<status>GetStatus();
        IEnumerable<Suggestion> FetchSug();
        void SetSuggestionsParam(SuggestionViewModel model);
        IEnumerable<Suggestion> FetSpeSug(int id);

        void UpdateValueSetSug(SuggestionViewModel model, int id);

        void DeleteValueSetSug(SuggestionViewModel model, int id);

        void UpdateValueSetGodkjenn(SuggestionViewModel model, int id);
        void SetTeamParam(TeamViewModel model);

        public void SetUserParam(UserViewModel model);
        public  IEnumerable<team> FetSpeAns(int id);
    }
}