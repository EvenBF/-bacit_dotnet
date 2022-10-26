using bacit_dotnet.MVC.Entities;
using bacit_dotnet.MVC.Models.Suggestions;
using System.Data;

namespace bacit_dotnet.MVC.DataAccess
{
    public interface ISqlConnector
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Suggestion> FetchSug();
        void SetSuggestionsParam(SuggestionViewModel model);
        IEnumerable<Suggestion> FetSpeSug(int id);

        void UpdateValueSetSug(SuggestionViewModel model, int id);

        void DeleteValueSetSug(SuggestionViewModel model, int id);

        IDbConnection GetDbConnection();

    }
}