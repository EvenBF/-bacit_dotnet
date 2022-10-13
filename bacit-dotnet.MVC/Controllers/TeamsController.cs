using bacit_dotnet.MVC.Models.Teams;
using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;

namespace bacit_dotnet.MVC.Controllers
{
    public class TeamsController : Controllers
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
    }
}