using Infra.Entities;
using Infra.Interface;
using Moq;
using Service;
using Service.Service;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ClienteScore.Tests
{
    public class ClienteServiceTests
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly ClienteService _clienteService;

        public ClienteServiceTests()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _clienteService = new ClienteService(_clienteRepositoryMock.Object);
        }

        [Fact]
        public async Task AddAsync_DeveLancarErro_QuandoCpfInvalido()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Teste",
                DataNascimento = new DateTime(1990, 1, 1),
                CPF = "12345678900", 
                Email = "teste@email.com",
                Estado = "MG",
                DDD = "31",
                Telefone = "999999999",
                RendimentoAnual = 10000
            };

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() =>
                _clienteService.AddAsync(cliente));

            Assert.Equal("CPF inválido.", ex.Message);
        }

        [Fact]
        public async Task AddAsync_DeveLancarErro_QuandoEmailInvalido()
        {
            var cliente = new Cliente
            {
                Nome = "Gabriel",
                CPF = "12769862626", 
                Email = "email-invalido",
                Estado = "MG",
                DDD = "31",
                Telefone = "999999999",
                DataNascimento = new DateTime(1995, 1, 1),
                RendimentoAnual = 80000
            };

            var ex = await Assert.ThrowsAsync<ArgumentException>(() =>
                _clienteService.AddAsync(cliente));

            Assert.Equal("E-mail inválido.", ex.Message);
        }

        [Fact]
        public async Task AddAsync_DeveSalvarCliente_QuandoValido()
        {
            var cliente = new Cliente
            {
                Nome = "Gabriel",
                CPF = "12769862626", 
                Email = "gabriel@email.com",
                Estado = "MG",
                DDD = "31",
                Telefone = "999999999",
                DataNascimento = new DateTime(1995, 1, 1),
                RendimentoAnual = 80000
            };

            await _clienteService.AddAsync(cliente);

            _clienteRepositoryMock.Verify(r => r.AddAsync(cliente), Times.Once);
        }
    }
}
