using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pioneers.BLL.Interfaces;
using Pioneers.BLL.Repositories;
using Pioneers.DAL.Entities;
using StoreDashboard.Helpers;
using StoreDashboard.Models;

namespace StoreDashboard.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentsController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Department"]=await unitOfWork.DepartmentRepository.GetAll();
            var model = mapper.Map<IEnumerable<Department>, IEnumerable< DepartmentViewModel>>(await unitOfWork.DepartmentRepository.GetAll());
            return View(model);
        }
        public async Task<IActionResult> Details(int id, string ViewName = "Details")
        {
            if(id == null) 
                return BadRequest();
            ViewData["Department"] = await unitOfWork.DepartmentRepository.GetAll();
            var department = await unitOfWork.DepartmentRepository.Get(id);
            var mapdepartment=mapper.Map<Department,DepartmentViewModel>(department);
            return View(ViewName, mapdepartment);
        }
        public async Task<IActionResult> Create()
        {
            ViewData["Department"] = await unitOfWork.DepartmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            if (model == null)
                return BadRequest();
            ViewData["Department"] = await unitOfWork.DepartmentRepository.GetAll();
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
                Console.WriteLine("SaveCreateDepartment action isnot executing...");
                return View("Create", model);
            }
            //the error that when you click on submit the upload input cleared you goes to teacherviewmodel.cs and make property of imagename nullable
            model.ImageName = DocumentSetting.UploadFile(model.Image, "Imgs");
            var mapmodel = mapper.Map<DepartmentViewModel, Department>(model);
            await unitOfWork.DepartmentRepository.Add(mapmodel);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Edit(int id)
        {
            if(id==null)
                return BadRequest();
            ViewData["Department"] = await unitOfWork.DepartmentRepository.GetAll();
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id,DepartmentViewModel model)
        {
            if(model.Id!=id)
                return BadRequest();
            ViewData["Department"] = await unitOfWork.DepartmentRepository.GetAll();

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
                Console.WriteLine("Save Edit Department action isnot executing...");
                return View("Edit", model);
            }
            var depart = mapper.Map<DepartmentViewModel, Department>(model);
            if (model.Image != null)
            {
                // Delete the old image
                DocumentSetting.DeleteFile(depart.ImageName, "Imgs");

                // Update the file name with the new image
                depart.ImageName = DocumentSetting.UploadFile(model.Image, "Imgs");
            }
            await unitOfWork.DepartmentRepository.Update(depart);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult>Delete(int id)
        {
            if(id==null)
                return BadRequest();
            ViewData["Department"] = await unitOfWork.DepartmentRepository.GetAll();
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,DepartmentViewModel model)
        {
            if (model.Id != id)
                return BadRequest();
            ViewData["Department"] = await unitOfWork.DepartmentRepository.GetAll();

            var mapmodel=mapper.Map<DepartmentViewModel, Department>(model);
            await unitOfWork.DepartmentRepository.Delete(mapmodel);
            return RedirectToAction(nameof(Index));
        }
    }
}
