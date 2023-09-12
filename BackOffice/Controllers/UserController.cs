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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/v1/users/getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allUsers = await _userService.GetAll();

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

        [HttpGet]
        [Route("/api/v1/users/getById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var usersById = await _userService.Get(id);

                return Ok(new ResultViewModel
                {
                    Message = "Successfully",
                    Success = true,
                    Data = usersById
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
        [Route("/api/v1/users/create-users")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserViewModel>(userViewModel);
                var userCreated = await _userService.RegistroPessoas(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "User created successfully",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest("Mesmo Nome ou Documento.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }


        [HttpPut]
        [Route("/api/v1/users/update-users/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserUpdateViewModel>(userViewModel);
                userDTO.Id = id;

                var updatedUser = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "User updated successfully",
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
        [Route("/api/v1/users/remove-users/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);

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
