using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        // uma view model nao pode ter comportamentos

        [Key]
        [ScaffoldColumn(false)]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome.")]
        [MaxLength(150 ,ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preencha o campo Sobrenome.")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Minimo {0} caracteres")]
        public string Sobrenome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preencha o campo Email.")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Insira um email valido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;


        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; } = new List<ProdutoViewModel>();

    }
}
