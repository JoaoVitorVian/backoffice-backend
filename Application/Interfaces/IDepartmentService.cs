using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartamentoViewModel> RegistroDepartamento(DepartamentoViewModel depDto);

        Task<DepartamentoViewModel> UpdateDepartamento(DepartamentoViewModel userDTO);

        Task RemoveDepartamento(long id);

        Task<List<DepartamentoViewModel>> GetAllDepartamento();
    }
}
