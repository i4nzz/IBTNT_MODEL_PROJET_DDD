using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome.")]
        [MaxLength(250, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0","9999999999")]
        [Required(ErrorMessage = "Preencha um valor.")]
        public decimal Valor { get; set; }

        [DisplayName("Disponivel?")]
        public bool Disponivel { get; set; }

        public int ClienteID { get; set; }

        // ForeignKey não é necessário aqui, pois o EF Core já mapeia isso automaticamente
        public virtual ClienteViewModel Cliente { get; set; }
    }
}
