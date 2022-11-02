using bacit_dotnet.MVC.Models.Suggestions;
using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;

namespace bacit_dotnet.MVC.Controllers
{
    public class SuggestionsController : Controller
    {
        private readonly ILogger<SuggestionsController> _logger;
        private readonly ISqlConnector sqlConnector;

        public SuggestionsController(ILogger<SuggestionsController> logger, ISqlConnector sqlConnector)
        {
            _logger = logger;
            this.sqlConnector = sqlConnector;
        }

        public IActionResult Index()
        {
            var data = sqlConnector.GetTeam();
            var model = new SuggestionModel();
            model.Teams = data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(SuggestionViewModel model) 
        {
            sqlConnector.SetSuggestionsParam(model);
            return View(model);
        }
        [HttpGet]
        public IActionResult ViewSug(int id)
        {

            var data = sqlConnector.FetchSug();
            var model = new SuggestionModel();
            model.Sug = data;

            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            dynamic mymodel = new SuggestionModel();
            mymodel.Sug = sqlConnector.FetSpeSug(id);
            dynamic mymodel2 = new TeamModel();
            mymodel2.team = sqlConnector.GetTeam();
            return View(mymodel, mymodel2);
        }

        [HttpPost]
        public IActionResult EditSave(SuggestionViewModel model, int id)
        {
            sqlConnector.UpdateValueSetSug(model, id);
            var data = sqlConnector.FetchSug();
            var model2 = new SuggestionModel();
            model2.Sug = data;
            
            return View("ViewSug",model2);
        }

        [HttpGet]
        public IActionResult Delete(SuggestionViewModel model, int id)
        {

            sqlConnector.DeleteValueSetSug(model, id);
            var data = sqlConnector.FetchSug();
            var model2 = new SuggestionModel();
            model2.Sug = data;
            
            return View("ViewSug", model2);
        }

         [HttpPost]
        public IActionResult Godkjenn(SuggestionViewModel model, int id)
        {

            sqlConnector.UpdateValueSetGodkjenn(model, id);
            var data = sqlConnector.FetchSug();
            var model2 = new SuggestionModel();
            model2.Sug = data;

            return View("ViewSug",model2);
        }
        [HttpGet]
        
        public IActionResult Login(SuggestionViewModel model) 
        {
            var model2 = new SuggestionModel();
           return View("Login",model2);
        }
}
}
