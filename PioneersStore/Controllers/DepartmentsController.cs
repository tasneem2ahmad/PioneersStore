using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pioneers.BLL.Interfaces;
using Pioneers.DAL.Entities;
using System.Runtime.InteropServices;

namespace PioneersStore.Controllers
{
    [Route("Departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartmentsController(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            unitOfWork = UnitOfWork;
            this.mapper = mapper;
        }
        [Route("AllDepartments")]
        [HttpPost]
       
        public async Task<ActionResult<Department>> indexAsync()
        {
            var result=await unitOfWork.DepartmentRepository.GetAll();
            if (result == null || !result.Any())
            {
                return Content("No Departments yet");
            }
            return Ok(result);
        }
    }
}
