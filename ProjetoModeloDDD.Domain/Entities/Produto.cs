using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }

        public int ClienteID { get; set; }

        // ForeignKey não é necessário aqui, pois o EF Core já mapeia isso automaticamente
        public virtual Cliente Cliente { get; set; }
    }
}
