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
            IMediaService mediaService
        ) : base(userService)
        {
            _techService = techService;
            _mediaService = mediaService;
        }

        // LIST
        public IActionResult Index()
        {
            return ListItems(() => _techService.GetAllWithMedia());
        }

        // CREATE GET
        public IActionResult Create()
        {
            return CreateItemView();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(TechnologyViewModel model)
        {
            return CreateItemPost(() =>
            {
                Media? media = null;

                if (model.ImageFile != null)
                {
                    // Upload to Media table, no userId
                    media = _mediaService.UploadFile(model.ImageFile);
                }

                var tech = new Technology
                {
                    Name = model.Name,
                    Description = model.Description,
                    Category = model.Category,
                    Url = model.Url,
                    Media = media
                };

                _techService.Create(tech);

                return true;
            }, "Technology created successfully");
        }

        // EDIT GET
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
            var tech = _techService.GetByIdWithMedia(model.Id);

            if (tech == null)
                return NotFound();

            // Update fields
            tech.Name = model.Name;
            tech.Description = model.Description;
            tech.Category = model.Category;
            tech.Url = model.Url;

            // Upload new image if exists
            if (model.ImageFile != null)
            {
                var media = _mediaService.UploadFile(model.ImageFile);
                tech.Media = media;
            }

            _techService.Update(tech);

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            return DeleteItem((techId) =>
            {
                var tech = _techService.GetById(techId);

                if (tech == null)
                    return (false, "Not found");

                _techService.Delete(tech);
                return (true, "");

            }, id);
        }

        // USER PAGE
        public IActionResult UserTechnologies()
        {
            var techs = _techService.GetAll();
            return View(techs);
        }
    }
}