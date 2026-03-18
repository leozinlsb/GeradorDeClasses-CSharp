using System;

namespace CadastroLivros.Model
{
    public class Livro
    {
        private string titulo;
        private string autor;
        private string isbn;
        private string anoPublicacao;
        private string editora;
        private string numeroPaginas;

        public Livro() { }

        public Livro(string titulo, string autor, string isbn,
                     string anoPublicacao, string editora, string numeroPaginas)
        {
            SetTitulo(titulo);
            SetAutor(autor);
            SetIsbn(isbn);
            SetAnoPublicacao(anoPublicacao);
            SetEditora(editora);
            SetNumeroPaginas(numeroPaginas);
        }

        // ── Titulo ───────────────────────────────────────────────────────────
        public string GetTitulo() { return titulo; }
        public void SetTitulo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Titulo nao pode ser vazio.");
            titulo = valor.Trim();
        }

        // ── Autor ────────────────────────────────────────────────────────────
        public string GetAutor() { return autor; }
        public void SetAutor(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Autor nao pode ser vazio.");
            autor = valor.Trim();
        }

        // ── ISBN ─────────────────────────────────────────────────────────────
        public string GetIsbn() { return isbn; }
        public void SetIsbn(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("ISBN nao pode ser vazio.");

            string digits = valor.Replace("-", "").Replace(" ", "");

            if (digits.Length != 10 && digits.Length != 13)
                throw new ArgumentException("ISBN deve ter 10 ou 13 digitos.");

            foreach (char c in digits)
                if (!char.IsDigit(c))
                    throw new ArgumentException("ISBN deve conter apenas numeros.");

            isbn = digits;
        }

        // ── Ano de Publicacao ────────────────────────────────────────────────
        public string GetAnoPublicacao() { return anoPublicacao; }
        public void SetAnoPublicacao(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Ano de publicacao nao pode ser vazio.");

            int ano;
            if (!int.TryParse(valor.Trim(), out ano))
                throw new ArgumentException("Ano de publicacao deve ser numerico.");

            if (ano < 1000 || ano > DateTime.Now.Year)
                throw new ArgumentException(
                    string.Format("Ano deve estar entre 1000 e {0}.", DateTime.Now.Year));

            anoPublicacao = valor.Trim();
        }

        // ── Editora ──────────────────────────────────────────────────────────
        public string GetEditora() { return editora; }
        public void SetEditora(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Editora nao pode ser vazia.");
            editora = valor.Trim();
        }

        // ── Numero de Paginas ────────────────────────────────────────────────
        public string GetNumeroPaginas() { return numeroPaginas; }
        public void SetNumeroPaginas(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Numero de paginas nao pode ser vazio.");

            int pag;
            if (!int.TryParse(valor.Trim(), out pag))
                throw new ArgumentException("Numero de paginas deve ser numerico.");

            if (pag <= 0)
                throw new ArgumentException("Numero de paginas deve ser maior que zero.");

            numeroPaginas = valor.Trim();
        }

        // ── ToString ─────────────────────────────────────────────────────────
        public override string ToString()
        {
            return string.Format(
                "Livro [ Titulo: {0}, Autor: {1}, ISBN: {2}, Ano: {3}, Editora: {4}, Paginas: {5} ]",
                titulo, autor, isbn, anoPublicacao, editora, numeroPaginas);
        }
    }
}
