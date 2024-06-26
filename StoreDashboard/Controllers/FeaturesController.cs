using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pioneers.BLL.Interfaces;
using Pioneers.DAL.Entities;
using StoreDashboard.Models;

namespace StoreDashboard.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public FeaturesController(IMapper mapper , IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            
            var mapmodel = mapper.Map<IEnumerable<Feature>, IEnumerable<FeatureViewModel>>(await unitOfWork.FeatureRepository.GetAll());
            return View(mapmodel);
        }
        public async Task<IActionResult>Details(int id,string ViewName = "Details")
        {
            if (id == null)
                return BadRequest();
            var mapmodel = mapper.Map<Feature, FeatureViewModel>(await unitOfWork.FeatureRepository.Get(id));

            return View(ViewName, mapmodel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FeatureViewModel model)
        {
            if(model== null)
                return BadRequest();
            if(ModelState.IsValid)
            {
                var mapmodel=mapper.Map<FeatureViewModel,Feature>(model);
                await unitOfWork.FeatureRepository.Add(mapmodel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                    }

                }
                Console.WriteLine("Save Create Feature action isnot executing...");
                return View("Create", model);
            }
            
        }
        public async Task<IActionResult>Edit(int id)
        {
            if(id==null)
                return BadRequest();
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id,FeatureViewModel model)
        {
            if(model.Id != id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                var mapmodel=mapper.Map<FeatureViewModel,Feature>(model);
                await unitOfWork.FeatureRepository.Update(mapmodel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                    }

                }
                Console.WriteLine("Save Edit Feature action isnot executing...");
                return View("Edit", model);
            }
        }
        public async Task<IActionResult>Delete(int id)
        {
            if (id == null)
                return BadRequest();
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute]int id,FeatureViewModel model)
        {
            if(model.Id!=id)
                return BadRequest();
            if(ModelState.IsValid)
            {
                var mapmodel=mapper.Map<FeatureViewModel, Feature>(model);
                await unitOfWork.FeatureRepository.Delete(mapmodel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach(var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                    }
                    
                }
                Console.WriteLine("Save Delete Feature action isnot executing...");
                return View("Delete", model);
            }
        }

    }
}
