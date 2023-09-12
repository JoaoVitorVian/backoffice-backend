using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Domain.Entity;
using Infra.Interfaces;

namespace Department.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartmentService(IMapper mapper, IDepartamentoRepository departamentoRepository)
        {
            _mapper = mapper;
            _departamentoRepository = departamentoRepository;
        }

        public async Task<DepartamentoViewModel> RegistroDepartamento(DepartamentoViewModel departamentoDTO)
        {
            var depExists = await _departamentoRepository.GetByName(departamentoDTO.NomeDepartamento);
            if (depExists != null)
            {
                throw new DomainExceptions("Já existe um departamento com este nome.");
            }

            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            departamento.Validate();

            var departamentoCreated = await _departamentoRepository.Create(departamento);

            return _mapper.Map<DepartamentoViewModel>(departamentoCreated);
        }

        public async Task<DepartamentoViewModel> UpdateDepartamento(DepartamentoViewModel departamentoDTO)
        {
            var departamento = _mapper.Map<Departamento>(departamentoDTO);
            departamento.Validate();

            var departamentoCreated = await _departamentoRepository.Update(departamento);

            return _mapper.Map<DepartamentoViewModel>(departamentoCreated);
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