using System;
using System.Collections.Generic;
using CadastroLivros.Model;

namespace CadastroLivros.BLL
{
    public class LivroBLL
    {
        private List<Livro> livros = new List<Livro>();

        public void Cadastrar(Livro livro)
        {
            if (livro == null)
                throw new ArgumentNullException("livro", "Livro nao pode ser nulo.");

            foreach (Livro l in livros)
            {
                if (l.GetIsbn() == livro.GetIsbn())
                    throw new InvalidOperationException(
                        string.Format("ISBN {0} ja cadastrado.", livro.GetIsbn()));
            }

            livros.Add(livro);
        }

        public List<Livro> ListarTodos()
        {
            return new List<Livro>(livros);
        }

        public Livro BuscarPorIsbn(string isbn)
        {
            foreach (Livro l in livros)
                if (l.GetIsbn() == isbn)
                    return l;
            return null;
        }

        public bool Remover(string isbn)
        {
            Livro livro = BuscarPorIsbn(isbn);
            if (livro == null) return false;
            livros.Remove(livro);
            return true;
        }
    }
}
