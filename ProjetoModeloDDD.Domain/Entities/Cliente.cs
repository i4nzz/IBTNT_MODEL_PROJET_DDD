namespace ProjetoModeloDDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }

        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && (DateTime.Now.Year - cliente.DataCadastro.Year >= 5);
        }
    }
}
