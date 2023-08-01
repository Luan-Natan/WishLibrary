namespace WishLibrary.Core.Models
{
    public class Livro
    {
        public Livro(string nome, DateTime dataLancamento, int generoId)
        {
            Nome = nome;
            DataLancamento = dataLancamento;
            GeneroId = generoId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }

        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
