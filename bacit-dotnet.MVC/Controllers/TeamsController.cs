using bacit_dotnet.MVC.Models.Teams;
using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;

namespace bacit_dotnet.MVC.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly ISqlConnector sqlConnector;

        public TeamsController(ILogger<TeamsController> logger, ISqlConnector sqlConnector)
        {
            _logger = logger;
            this.sqlConnector = sqlConnector;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(TeamViewModel model)
        {
            sqlConnector.SetTeamParam(model);
            return View(model);
        }
        [HttpGet]
        public IActionResult viewTeam()
        {

            var data = sqlConnector.GetTeam();
            var model = new TeamModel();
            model.team = data;
            return View(model);

        }
    }
}