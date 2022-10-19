using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Suggestions;
using bacit_dotnet.MVC.Models.Teams;

namespace bacit_dotnet.MVC.DataAccess
{
    public interface ISqlConnector
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Suggestion> FetchSug();
        void SetSuggestionsParam(SuggestionViewModel model);
         IEnumerable<Suggestion> FetSpeSug(int id);
        void SetTeamParam(TeamViewModel model);
    }
}