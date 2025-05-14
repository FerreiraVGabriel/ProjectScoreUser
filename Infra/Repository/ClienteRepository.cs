using Infra.Data;
using System.Data;
using Microsoft.Data.SqlClient;
using Infra.Entities;
using Infra.Interface;

namespace Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public ClienteRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            var sql = "SELECT * FROM Clientes";
            var lista = new List<Cliente>();

            using var connection = (SqlConnection)_connectionFactory.CreateConnection();
            using var command = new SqlCommand(sql, (SqlConnection)connection);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(new Cliente
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString()!,
                    DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                    CPF = reader["CPF"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    RendimentoAnual = Convert.ToDecimal(reader["RendimentoAnual"]),
                    Estado = reader["Estado"].ToString()!,
                    DDD = reader["DDD"].ToString()!,
                    Telefone = reader["Telefone"].ToString()!
                });
            }

            return lista;
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Clientes WHERE Id = @Id";

            using var connection = (SqlConnection)_connectionFactory.CreateConnection();
            using var command = new SqlCommand(sql, (SqlConnection)connection);

            command.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Cliente
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = reader["Nome"].ToString()!,
                    DataNascimento = Convert.ToDateTime(reader["DataNascimento"]),
                    CPF = reader["CPF"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    RendimentoAnual = Convert.ToDecimal(reader["RendimentoAnual"]),
                    Estado = reader["Estado"].ToString()!,
                    DDD = reader["DDD"].ToString()!,
                    Telefone = reader["Telefone"].ToString()!
                };
            }

            return null;
        }
        public async Task AddAsync(Cliente cliente)
        {
            var sql = @"INSERT INTO Clientes 
                        (Nome, DataNascimento, CPF, Email, RendimentoAnual, Estado, DDD, Telefone)
                        VALUES 
                        (@Nome, @DataNascimento, @CPF, @Email, @RendimentoAnual, @Estado, @DDD, @Telefone)";

            using var connection = (SqlConnection)_connectionFactory.CreateConnection();
            using var command = new SqlCommand(sql, (SqlConnection)connection);

            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@RendimentoAnual", cliente.RendimentoAnual);
            command.Parameters.AddWithValue("@Estado", cliente.Estado);
            command.Parameters.AddWithValue("@DDD", cliente.DDD);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            var sql = @"UPDATE Clientes SET 
                        Nome = @Nome,
                        DataNascimento = @DataNascimento,
                        CPF = @CPF,
                        Email = @Email,
                        RendimentoAnual = @RendimentoAnual,
                        Estado = @Estado,
                        DDD = @DDD,
                        Telefone = @Telefone
                        WHERE Id = @Id";

            using var connection = (SqlConnection)_connectionFactory.CreateConnection();
            using var command = new SqlCommand(sql, (SqlConnection)connection);

            command.Parameters.AddWithValue("@Id", cliente.Id);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@RendimentoAnual", cliente.RendimentoAnual);
            command.Parameters.AddWithValue("@Estado", cliente.Estado);
            command.Parameters.AddWithValue("@DDD", cliente.DDD);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Clientes WHERE Id = @Id";

            using var connection = (SqlConnection)_connectionFactory.CreateConnection();
            using var command = new SqlCommand(sql, (SqlConnection)connection);

            command.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

    }
}
