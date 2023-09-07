using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using AutoMapper;
using Bogus;
using Core.Exceptions;
using Domain.Entity;
using FluentAssertions;
using Infra.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnitTests.AutoMapper;
using Xunit;

namespace Projects
{
    public class UserServiceTests
    {
        private readonly IUserService _sut;
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IDepartamentoRepository> _departamentoRepositoryMock;

        public UserServiceTests()
        {
            _mapper = AutoMapperConfiguration.GetConfiguration();
            _userRepositoryMock = new Mock<IUserRepository>();
            _departamentoRepositoryMock = new Mock<IDepartamentoRepository>();

            var httpClient = new Mock<HttpClient>().Object;

            _sut = new UserService(_mapper, _userRepositoryMock.Object, httpClient, _departamentoRepositoryMock.Object);
        }


        [Fact(DisplayName = "Registro de Pessoas")]
        [Trait("Category", "Services")]
        public async Task RegistroPessoas_WhenUserDoesNotExist_ReturnsUserViewModel()
        {
            // Arrange
            var userDTO = new UserViewModel
            {
                Name = "Nome do Usuário",
                Apelido = "Apelido do Usuário",
                Documento = "120330123210",
                TipoDePessoa = "fisica",
                Cep = "61622020",
                Bairro = "Bairro do usuario",
                Qualificacoes = "algo",
                Localidade = "Caucaia" 
            };

            _userRepositoryMock.Setup(x => x.GetByName(userDTO.Name))
                .ReturnsAsync(() => null);

            _userRepositoryMock.Setup(x => x.Create(It.IsAny<User>()))
                .ReturnsAsync((User user) => user);

            // Act
            var result = await _sut.RegistroPessoas(userDTO);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(userDTO.Name);
            result.Apelido.Should().Be(userDTO.Apelido);
            result.TipoDePessoa.Should().Be(userDTO.TipoDePessoa);
            result.Cep.Should().Be(userDTO.Cep);
            result.Bairro.Should().Be(userDTO.Bairro);
            result.Qualificacoes.Should().Be(userDTO.Qualificacoes);
            result.Localidade.Should().Be(userDTO.Localidade);
            result.Documento.Should().Be(userDTO.Documento);
        }

        [Fact(DisplayName = "Registro de Pessoas Quando o Usuário Já Existe")]
        [Trait("Category", "Services")]
        public async Task RegistroPessoas_WhenUserExists_ThrowsException()
        {
            // Arrange
            var userDTO = new UserViewModel
            {
                Name = "Nome do Usuário Existente",
            };

            var existingUser = new User
            {
                Name = userDTO.Name,
                Apelido = userDTO.Apelido,
                Documento = userDTO.Documento,
                TipoDePessoa = userDTO.TipoDePessoa,
                Cep = userDTO.Cep,
                Localidade = userDTO.Localidade,
                Bairro = userDTO.Bairro,
                Qualificacoes = userDTO.Qualificacoes
            };

            _userRepositoryMock.Setup(x => x.GetByName(userDTO.Name))
                .ReturnsAsync(() => existingUser);

            // Act & Assert
            await Assert.ThrowsAsync<DomainExceptions>(() => _sut.RegistroPessoas(userDTO));
        }
    }
}
