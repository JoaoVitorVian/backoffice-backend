using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Domain.Entity;
using Infra.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly HttpClient _httpClient;

        public UserService(IMapper mapper, IUserRepository userRepository, HttpClient httpClient, IDepartamentoRepository departamentoRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _httpClient = httpClient;
            _departamentoRepository = departamentoRepository;
        }

        public async Task<UserViewModel> RegistroPessoas(UserViewModel userDTO)
        {
            var userExists = await _userRepository.GetByName(userDTO.Name);

            if (userExists != null)
            {
                throw new DomainExceptions("Já uma pessoa com esse nome");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserViewModel>(userCreated);
        }

        public async Task<DepartamentoViewModel> RegistroDepartamento(DepartamentoViewModel departamentoDTO)
        {
            var depExists = await _departamentoRepository.GetByName(departamentoDTO.NomeResponsavel);

            if (depExists != null)
            {
                throw new DomainExceptions("Já existe uma pessoa com esse departamento");
            }

            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            departamento.Validate();

            var userCreated = await _departamentoRepository.Create(departamento);

            return _mapper.Map<DepartamentoViewModel>(userCreated);
        }

        public async Task<UserUpdateViewModel> Update(UserUpdateViewModel userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            var user = _mapper.Map<User>(userDTO);

            var userCreated = await _userRepository.Update(user);

            return _mapper.Map<UserUpdateViewModel>(userCreated);
        }

        public async Task<DepartamentoViewModel> UpdateDepartamento(DepartamentoViewModel userDTO)
        {
            var userExists = await _departamentoRepository.Get(userDTO.Id);

            var user = _mapper.Map<Departamento>(userDTO);

            var userCreated = await _departamentoRepository.Update(user);

            return _mapper.Map<DepartamentoViewModel>(userCreated);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task RemoveDepartamento(long id)
        {
            await _departamentoRepository.Remove(id);
        }

        public async Task<UserViewModel> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var allUsers = await _userRepository.GetAll();

            return _mapper.Map<List<UserViewModel>>(allUsers);
        }

        public async Task<List<DepartamentoViewModel>> GetAllDepartamento()
        {
            var allUsers = await _departamentoRepository.GetAll();

            return _mapper.Map<List<DepartamentoViewModel>>(allUsers);
        }

        public async Task<List<UserViewModel>> SearchByName(string name)
        {
            var allUsers = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserViewModel>>(allUsers);
        }

        public async Task<UserViewModel> GetByName(string name)
        {
            var user = await _userRepository.GetByName(name);

            return _mapper.Map<UserViewModel>(user);
        }
    }
}