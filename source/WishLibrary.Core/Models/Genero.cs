namespace WishLibrary.Core.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }

        public Genero(string nome)
        {
            Nome = nome;
        }
    }
}
