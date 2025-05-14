using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class Cliente
    {
        public int Id { get; set; } 
        public string Nome { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal RendimentoAnual { get; set; }

        public string Estado { get; set; } = null!;
        public string DDD { get; set; } = null!;
        public string Telefone { get; set; } = null!;
    }
}
