using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Suggestions;
using bacit_dotnet.MVC.Models.Teams;

namespace bacit_dotnet.MVC.DataAccess
{
    public interface ISqlConnector
    {
        IEnumerable<User> GetUsers();
        IEnumerable<team> GetTeam();
        IEnumerable<Suggestion> FetchSug();
        void SetSuggestionsParam(SuggestionViewModel model);
        IEnumerable<Suggestion> FetSpeSug(int id);

        void UpdateValueSetSug(SuggestionViewModel model, int id);

        void DeleteValueSetSug(SuggestionViewModel model, int id);

        void UpdateValueSetGodkjenn(SuggestionViewModel model, int id);
        void SetTeamParam(TeamViewModel model);
    }
}