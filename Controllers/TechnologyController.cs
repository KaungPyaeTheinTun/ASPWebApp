using ASPWebApp.Models;
using ASPWebApp.Services.Interfaces;
using ASPWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApp.Controllers
{
    public class TechnologyController : BaseController<Technology>
    {
        private readonly ITechnologyService _techService;
        private readonly IMediaService _mediaService;

        public TechnologyController(
            IUserService userService,
            ITechnologyService techService,
            IMediaService mediaService)
            : base(userService, techService)
        {
            _techService = techService;
            _mediaService = mediaService;
        }

        public IActionResult Index()
        {
            return View(_techService.GetAllWithMedia());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TechnologyViewModel model)
        {
            Media? media = null;

            if (model.ImageFile != null)
                media = _mediaService.UploadFile(model.ImageFile);

            var tech = new Technology
            {
                Name = model.Name,
                Description = model.Description,
                Category = model.Category,
                Url = model.Url,
                Media = media
            };

            return CreateItem(tech);
        }

        public IActionResult Edit(int id)
        {
            var tech = _techService.GetByIdWithMedia(id);

            if (tech == null)
                return NotFound();

            var model = new TechnologyViewModel
            {
                Id = tech.Id,
                Name = tech.Name,
                Description = tech.Description,
                Category = tech.Category,
                Url = tech.Url,
                ExistingImagePath = tech.Media?.FilePath
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TechnologyViewModel model)
        {
            var tech = _techService.GetById(model.Id);

            if (tech == null)
                return NotFound();

            tech.Name = model.Name;
            tech.Description = model.Description;
            tech.Category = model.Category;
            tech.Url = model.Url;

            if (model.ImageFile != null)
                tech.Media = _mediaService.UploadFile(model.ImageFile);

            return EditItem(tech);
        }

        public IActionResult Delete(int id)
        {
            return DeleteItem(id);
        }
    }
}