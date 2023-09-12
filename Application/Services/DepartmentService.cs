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
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly HttpClient _httpClient;

        public DepartmentService(IMapper mapper, HttpClient httpClient, IDepartamentoRepository departamentoRepository)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _departamentoRepository = departamentoRepository;
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

        public async Task<DepartamentoViewModel> UpdateDepartamento(DepartamentoViewModel userDTO)
        {
            var userExists = await _departamentoRepository.Get(userDTO.Id);

            var user = _mapper.Map<Departamento>(userDTO);

            var userCreated = await _departamentoRepository.Update(user);

            return _mapper.Map<DepartamentoViewModel>(userCreated);
        }

        public async Task RemoveDepartamento(long id)
        {
            await _departamentoRepository.Remove(id);
        }

        public async Task<List<DepartamentoViewModel>> GetAllDepartamento()
        {
            var allUsers = await _departamentoRepository.GetAll();

            return _mapper.Map<List<DepartamentoViewModel>>(allUsers);
        }
    }
}