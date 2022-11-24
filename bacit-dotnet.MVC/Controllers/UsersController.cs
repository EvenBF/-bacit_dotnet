using bacit_dotnet.MVC.Models.Users;

using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;

namespace bacit_dotnet.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ISqlConnector sqlConnector;

        public UsersController(ILogger<UsersController> logger, ISqlConnector sqlConnector)
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
        public IActionResult Save(UserViewModel model)
        {
            sqlConnector.SetUserParam(model);
            return View(model);
        }
    }
}
