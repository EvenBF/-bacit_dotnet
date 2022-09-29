﻿using bacit_dotnet.MVC.Models.Suggestions;
using Microsoft.AspNetCore.Mvc;
using bacit_dotnet.MVC.DataAccess;

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
            return View();
        }

        [HttpPost]
        public IActionResult Save(SuggestionViewModel model) 
        {
            sqlConnector.SetSuggestionsParam(model);
            return View(model);
        }
    }
}
