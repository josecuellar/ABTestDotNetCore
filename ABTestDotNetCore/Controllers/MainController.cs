using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ABTestDotNetCore.Main.Services;
using ABTestDotNetCore.Main;

namespace ABTestDotNetCore.Controllers
{
    public class MainController : Controller
    {

        private readonly IExperimentService ExperimentService;

        public MainController(IExperimentService experimentService)
        {
            ExperimentService = experimentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
