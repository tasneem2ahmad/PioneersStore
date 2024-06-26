using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pioneers.BLL.Interfaces;
using Pioneers.DAL.Entities;
using StoreDashboard.Helpers;
using StoreDashboard.Models;

namespace StoreDashboard.Controllers
{
    public class ChildDepartmentsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ChildDepartmentsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model = mapper.Map<IEnumerable<ChildDepartment>, IEnumerable<ChildDepartmentViewModel>>(await unitOfWork.ChildDepartmentRepository.GetAll());
            return View(model);
        }
        public async Task<IActionResult> Details(int id, string ViewName = "Details")
        {
            if (id == null)
                return BadRequest();
            var department = await unitOfWork.ChildDepartmentRepository.Get(id);
            var mapdepartment = mapper.Map<ChildDepartment, ChildDepartmentViewModel>(department);
            return View(ViewName, mapdepartment);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ChildDepartmentViewModel model)
        {
            if (model == null)
                return BadRequest();
            ViewData["Department"] = await unitOfWork.ChildDepartmentRepository.GetAll();
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
                Console.WriteLine("SaveCreate child Department action isnot executing...");
                return View("Create", model);
            }
            //the error that when you click on submit the upload input cleared you goes to teacherviewmodel.cs and make property of imagename nullable
            model.ImageName = DocumentSetting.UploadFile(model.Image, "Imgs");
            var mapmodel = mapper.Map<ChildDepartmentViewModel, ChildDepartment>(model);
            await unitOfWork.ChildDepartmentRepository.Add(mapmodel);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
                return BadRequest();
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, ChildDepartmentViewModel model)
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
                Console.WriteLine("Save Edit child Department action isnot executing...");
                return View("Edit", model);
            }
            var depart = mapper.Map<ChildDepartmentViewModel, ChildDepartment>(model);
            if (model.Image != null)
            {
                // Delete the old image
                DocumentSetting.DeleteFile(depart.ImageName, "Imgs");

                // Update the file name with the new image
                depart.ImageName = DocumentSetting.UploadFile(model.Image, "Imgs");
            }
            await unitOfWork.ChildDepartmentRepository.Update(depart);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
                return BadRequest();
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, ChildDepartmentViewModel model)
        {
            if (model.Id != id)
                return BadRequest();
            ViewData["Department"] = await unitOfWork.DepartmentRepository.GetAll();

            var mapmodel = mapper.Map<ChildDepartmentViewModel, ChildDepartment>(model);
            await unitOfWork.ChildDepartmentRepository.Delete(mapmodel);
            return RedirectToAction(nameof(Index));
        }
    }
}
