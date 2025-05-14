using Infra.Entities;
using Infra.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AddAsync(Cliente cliente)
        {
            if (!UtilService.Util.CpfValido(cliente.CPF))
                throw new ArgumentException("CPF inválido.");

            if (!UtilService.Util.EmailValido(cliente.Email))
                throw new ArgumentException("E-mail inválido.");

            await _clienteRepository.AddAsync(cliente);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }
    }
}
