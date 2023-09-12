using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using BackOffice.ViewModels;
using BackOffice.ViewModels.User;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.Controllers
{
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/v1/departamento/getAll")]
        public async Task<IActionResult> GetAllDepartamento()
        {
            try
            {
                var allUsers = await _departmentService.GetAllDepartamento();

                return Ok(new ResultViewModel
                {
                    Message = "Successfully",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

        [HttpPost]
        [Route("/api/v1/departamento/create-departamento")]
        public async Task<IActionResult> CreateDepartamento([FromBody] CreateDepartamentoViewModel userViewModel)
        {
            try
            {
                var depDTO = _mapper.Map<DepartamentoViewModel>(userViewModel);
                var depCreated = await _departmentService.RegistroDepartamento(depDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Departamento created successfully",
                    Success = true,
                    Data = depCreated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest("Mesmo Nome Responsavel ou departamento.");
            }
            catch (Exception)
            {
                return StatusCode(500,"Erro");
            }
        }

        [HttpPut]
        [Route("/api/v1/departamento/update-departamento/{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, [FromBody] UpdateDepartamentoViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<DepartamentoViewModel>(userViewModel);
                userDTO.Id = id;

                var updatedUser = await _departmentService.UpdateDepartamento(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Departamento updated successfully",
                    Success = true,
                    Data = updatedUser
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

        [HttpDelete]
        [Route("/api/v1/departamento/remove-departamento/{id}")]
        public async Task<IActionResult> RemoveDepartamento(long id)
        {
            try
            {
                await _departmentService.RemoveDepartamento(id);

                return Ok(new ResultViewModel
                {
                    Message = "removed successfully",
                    Success = true
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }
    }
}
