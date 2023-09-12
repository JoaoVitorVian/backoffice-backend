using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> RegistroPessoas(UserViewModel userDTO);

        Task<UserUpdateViewModel> Update(UserUpdateViewModel userDTO);
        
        Task Remove(long id);

        Task<UserViewModel> Get(long id);

        Task<List<UserViewModel>> GetAll();

        Task<List<UserViewModel>> SearchByName(string name);

        Task<UserViewModel> GetByName(string email);
    }
}
