using ASPWebApp.Models;
using ASPWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASPWebApp.ViewComponents
{
    public class TechnologyViewComponent : ViewComponent
    {
        private readonly ITechnologyService _techService;

        public TechnologyViewComponent(ITechnologyService techService)
        {
            _techService = techService;
        }

        public IViewComponentResult Invoke()
        {
            List<Technology> techs = _techService.GetAllWithMedia();
            return View("~/Views/Home/Components/_Technology.cshtml", techs);
        }
    }
}