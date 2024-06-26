using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pioneers.BLL.Interfaces;
using Pioneers.BLL.Repositories;
using Pioneers.DAL.Entities;
using StoreDashboard.Helpers;
using StoreDashboard.Models;

namespace StoreDashboard.Controllers
{
    public class MarketsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MarketsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model = mapper.Map<IEnumerable<Market>, IEnumerable<MarketViewModel>>(await unitOfWork.MarketRepository.GetAll());
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MarketViewModel model)
        {
            if (model == null)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                    }

                }
                Console.WriteLine("SaveCreateMarket action isnot executing...");
                return View("Create", model);
            }
            //the error that when you click on submit the upload input cleared you goes to teacherviewmodel.cs and make property of imagename nullable
            model.ImageName = DocumentSetting.UploadFile(model.Image, "Imgs");
            var mapmodel = mapper.Map<MarketViewModel, Market>(model);
            await unitOfWork.MarketRepository.Add(mapmodel);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id,string ViewName="Details")
        {
            if(id==null)
                return BadRequest();
            
            var mapmodel = mapper.Map<Market, MarketViewModel>(await unitOfWork.MarketRepository.Get(id));
            return View(ViewName, mapmodel);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id,MarketViewModel model)
        {
            if (model.Id != id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                    }

                }
                Console.WriteLine("SaveEditMarket action isnot executing...");
                return View("Edit", model);
            }
            var mapmodel=mapper.Map<MarketViewModel,Market>(model);
            DocumentSetting.DeleteFile(mapmodel.ImageName, "Imgs");

            // Update the file name with the new image
            mapmodel.ImageName = DocumentSetting.UploadFile(model.Image, "Imgs");
            await unitOfWork.MarketRepository.Update(mapmodel);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult>Delete(int id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int id,MarketViewModel model)
        {
            if (model.Id != id)
                return BadRequest();
            
            var mapmodel=mapper.Map<MarketViewModel, Market>(model);
            await unitOfWork.MarketRepository.Delete(mapmodel);
            return RedirectToAction(nameof(Index));

        }

    }
}
