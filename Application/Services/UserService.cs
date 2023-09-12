using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Domain.Entity;
using Infra.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository, HttpClient httpClient)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> RegistroPessoas(UserViewModel userDTO)
        {
            var userExists = await _userRepository.GetByName(userDTO.Name);
            var documentExists = await _userRepository.GetByDocument(userDTO.Documento);

            if (userExists != null || documentExists != null)
            {
                throw new DomainExceptions("Documento ou Nome já existem.");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserViewModel>(userCreated);
        }

        public async Task<UserUpdateViewModel> Update(UserUpdateViewModel userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Update(user);

            return _mapper.Map<UserUpdateViewModel>(userCreated);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
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