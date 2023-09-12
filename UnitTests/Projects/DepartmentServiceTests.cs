using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Department.Application.Services;
using Domain.Entity;
using FluentAssertions;
using Infra.Interfaces;

namespace Projects
{
    public class DepartmentServiceTests
    {
        private readonly IDepartmentService _sut;
        private readonly IMapper _mapper;
        private readonly Mock<IDepartamentoRepository> _departmentRepositoryMock;

        public DepartmentServiceTests()
        {
            _mapper = AutoMapperConfiguration.GetConfiguration();
            _departmentRepositoryMock = new Mock<IDepartamentoRepository>();

            var httpClient = new Mock<HttpClient>().Object;

            _sut = new DepartmentService(_mapper, _departmentRepositoryMock.Object);
        }

        [Fact(DisplayName = "Registro de Departamentos")]
        [Trait("Category", "Services")]
        public async Task RegistroPessoas_WhenUserDoesNotExist_ReturnsUserViewModel()
        {
            // Arrange
            var userDTO = new DepartamentoViewModel
            {
                NomeDepartamento = "Nome departamento",
                NomeResponsavel = "Nome responsavel"
            };

            _departmentRepositoryMock.Setup(x => x.GetByName(userDTO.NomeResponsavel))
                .ReturnsAsync(() => null);

            _departmentRepositoryMock.Setup(x => x.Create(It.IsAny<Departamento>()))
                .ReturnsAsync((Departamento departamento) => departamento);

            // Act
            var result = await _sut.RegistroDepartamento(userDTO);

            // Assert
            result.Should().NotBeNull();
            result.NomeResponsavel.Should().Be(userDTO.NomeResponsavel);
            result.NomeDepartamento.Should().Be(userDTO.NomeDepartamento);
        }

        [Fact(DisplayName = "Registro de Departamento quando já existe um responsavel")]
        [Trait("Category", "Services")]
        public async Task RegistroPessoas_WhenUserExists_ThrowsException()
        {
            // Arrange
            var userDTO = new DepartamentoViewModel
            {
                NomeResponsavel = "Nome Responsavel",
            };

            var existingUser = new Departamento
            {
                Id = 1,
                NomeResponsavel = "Nome Responsavel",
                NomeDepartamento = "Nome Departamento"
            };

            _departmentRepositoryMock.Setup(x => x.GetByName(userDTO.NomeDepartamento))
                .ReturnsAsync(() => existingUser);

            // Act & Assert
            await Assert.ThrowsAsync<DomainExceptions>(() => _sut.RegistroDepartamento(userDTO));
        }

        [Fact(DisplayName = "Atualização de departamento")]
        [Trait("Category", "Services")]
        public async Task AtualizacaoPessoas_WhenUserExists_ReturnsUpdatedUserViewModel()
        {
            // Arrange
            var userDTO = new DepartamentoViewModel
            {
                Id = 1,
                NomeDepartamento = "Nome departamneto",
                NomeResponsavel = "nome responsavel"
            };

            var existingUser = new Departamento
            {
                Id = 1,
                NomeDepartamento = "Nome departamneto",
                NomeResponsavel = "nome responsavel"
            };

            _departmentRepositoryMock.Setup(x => x.Get(userDTO.Id))
                .ReturnsAsync(existingUser);

            _departmentRepositoryMock.Setup(x => x.Update(It.IsAny<Departamento>()))
                .ReturnsAsync((Departamento departamento) => departamento);

            // Act
            var result = await _sut.UpdateDepartamento(userDTO);

            // Assert
            
            result.Should().NotBeNull();
            result.NomeDepartamento.Should().Be(userDTO.NomeDepartamento);
            result.NomeResponsavel.Should().Be(userDTO.NomeResponsavel);
        }

        [Fact(DisplayName = "Remoção de departamentos")]
        [Trait("Category", "Services")]
        public async Task RemocaoPessoas_WhenUserExists_RemovesUserSuccessfully()
        {
            // Arrange
            var userIdToRemove = 1;

            _departmentRepositoryMock.Setup(x => x.Get(userIdToRemove))
                .ReturnsAsync(new Departamento { Id = userIdToRemove });

            _departmentRepositoryMock.Setup(x => x.Remove(userIdToRemove))
                .Returns(Task.CompletedTask);

            // Act
            await _sut.RemoveDepartamento(userIdToRemove);

            // Assert
            _departmentRepositoryMock.Verify(x => x.Remove(userIdToRemove), Times.Once);
        }
    }
}
