using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CadastroLivros.Model;
using CadastroLivros.BLL;

namespace CadastroLivros.Tests
{
    [TestClass]
    public class LivroTests
    {
        // ════════════════════════════════════════════════════════════════════
        //  TITULO
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void SetTitulo_ValorValido_DeveSalvar()
        {
            Livro livro = new Livro();
            livro.SetTitulo("Dom Casmurro");
            Assert.AreEqual("Dom Casmurro", livro.GetTitulo());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetTitulo_Vazio_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetTitulo("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetTitulo_SoEspacos_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetTitulo("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetTitulo_Nulo_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetTitulo(null);
        }

        [TestMethod]
        public void SetTitulo_DeveAparar_EspacosExtras()
        {
            Livro livro = new Livro();
            livro.SetTitulo("  Clean Code  ");
            Assert.AreEqual("Clean Code", livro.GetTitulo());
        }

        // ════════════════════════════════════════════════════════════════════
        //  AUTOR
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void SetAutor_ValorValido_DeveSalvar()
        {
            Livro livro = new Livro();
            livro.SetAutor("Machado de Assis");
            Assert.AreEqual("Machado de Assis", livro.GetAutor());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetAutor_Vazio_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetAutor("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetAutor_Nulo_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetAutor(null);
        }

        // ════════════════════════════════════════════════════════════════════
        //  ISBN
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void SetIsbn_10Digitos_DeveSalvar()
        {
            Livro livro = new Livro();
            livro.SetIsbn("0306406152");
            Assert.AreEqual("0306406152", livro.GetIsbn());
        }

        [TestMethod]
        public void SetIsbn_13Digitos_DeveSalvar()
        {
            Livro livro = new Livro();
            livro.SetIsbn("9780306406157");
            Assert.AreEqual("9780306406157", livro.GetIsbn());
        }

        [TestMethod]
        public void SetIsbn_ComTracos_DeveNormalizar()
        {
            Livro livro = new Livro();
            livro.SetIsbn("978-03-064-0615-7");
            Assert.AreEqual("9780306406157", livro.GetIsbn());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetIsbn_MenosDe10_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetIsbn("12345");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetIsbn_11Digitos_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetIsbn("12345678901");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetIsbn_ComLetras_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetIsbn("97803064ABC57");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetIsbn_Vazio_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetIsbn("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetIsbn_Nulo_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetIsbn(null);
        }

        // ════════════════════════════════════════════════════════════════════
        //  ANO DE PUBLICACAO
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void SetAnoPublicacao_AnoValido_DeveSalvar()
        {
            Livro livro = new Livro();
            livro.SetAnoPublicacao("2020");
            Assert.AreEqual("2020", livro.GetAnoPublicacao());
        }

        [TestMethod]
        public void SetAnoPublicacao_AnoAtual_DevePermitir()
        {
            Livro livro = new Livro();
            string anoAtual = DateTime.Now.Year.ToString();
            livro.SetAnoPublicacao(anoAtual);
            Assert.AreEqual(anoAtual, livro.GetAnoPublicacao());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetAnoPublicacao_Vazio_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetAnoPublicacao("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetAnoPublicacao_ComLetras_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetAnoPublicacao("ABC");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetAnoPublicacao_AbaixoDe1000_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetAnoPublicacao("500");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetAnoPublicacao_AnoFuturo_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetAnoPublicacao((DateTime.Now.Year + 1).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetAnoPublicacao_Nulo_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetAnoPublicacao(null);
        }

        // ════════════════════════════════════════════════════════════════════
        //  EDITORA
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void SetEditora_ValorValido_DeveSalvar()
        {
            Livro livro = new Livro();
            livro.SetEditora("Saraiva");
            Assert.AreEqual("Saraiva", livro.GetEditora());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetEditora_Vazio_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetEditora("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetEditora_Nulo_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetEditora(null);
        }

        // ════════════════════════════════════════════════════════════════════
        //  NUMERO DE PAGINAS
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void SetNumeroPaginas_ValorValido_DeveSalvar()
        {
            Livro livro = new Livro();
            livro.SetNumeroPaginas("350");
            Assert.AreEqual("350", livro.GetNumeroPaginas());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNumeroPaginas_Vazio_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetNumeroPaginas("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNumeroPaginas_ComLetras_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetNumeroPaginas("trezentas");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNumeroPaginas_Zero_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetNumeroPaginas("0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNumeroPaginas_Negativo_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetNumeroPaginas("-10");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNumeroPaginas_Nulo_DeveGerarExcecao()
        {
            Livro livro = new Livro();
            livro.SetNumeroPaginas(null);
        }

        // ════════════════════════════════════════════════════════════════════
        //  CONSTRUTOR COMPLETO
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void ConstrutorCompleto_DadosValidos_DeveCriarObjeto()
        {
            Livro livro = new Livro("Clean Code", "Robert C. Martin",
                                    "9780132350884", "2008", "Prentice Hall", "431");

            Assert.AreEqual("Clean Code", livro.GetTitulo());
            Assert.AreEqual("Robert C. Martin", livro.GetAutor());
            Assert.AreEqual("9780132350884", livro.GetIsbn());
            Assert.AreEqual("2008", livro.GetAnoPublicacao());
            Assert.AreEqual("Prentice Hall", livro.GetEditora());
            Assert.AreEqual("431", livro.GetNumeroPaginas());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstrutorCompleto_TituloVazio_DeveGerarExcecao()
        {
            new Livro("", "Autor", "9780132350884", "2008", "Editora", "100");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstrutorCompleto_IsbnInvalido_DeveGerarExcecao()
        {
            new Livro("Titulo", "Autor", "123", "2008", "Editora", "100");
        }

        // ════════════════════════════════════════════════════════════════════
        //  BLL
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void Cadastrar_LivroValido_DeveSalvarNaLista()
        {
            LivroBLL bll = new LivroBLL();
            Livro livro = new Livro("Livro A", "Autor A", "9780132350884", "2010", "Ed A", "200");
            bll.Cadastrar(livro);
            Assert.AreEqual(1, bll.ListarTodos().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cadastrar_LivroNulo_DeveGerarExcecao()
        {
            LivroBLL bll = new LivroBLL();
            bll.Cadastrar(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cadastrar_IsbnDuplicado_DeveGerarExcecao()
        {
            LivroBLL bll = new LivroBLL();
            bll.Cadastrar(new Livro("Livro A", "Autor A", "9780132350884", "2010", "Ed A", "100"));
            bll.Cadastrar(new Livro("Livro B", "Autor B", "9780132350884", "2015", "Ed B", "200"));
        }

        [TestMethod]
        public void BuscarPorIsbn_Existente_DeveRetornarLivro()
        {
            LivroBLL bll = new LivroBLL();
            bll.Cadastrar(new Livro("Livro C", "Autor C", "9780132350884", "2012", "Ed C", "150"));
            Livro encontrado = bll.BuscarPorIsbn("9780132350884");
            Assert.IsNotNull(encontrado);
            Assert.AreEqual("Livro C", encontrado.GetTitulo());
        }

        [TestMethod]
        public void BuscarPorIsbn_Inexistente_DeveRetornarNulo()
        {
            LivroBLL bll = new LivroBLL();
            Livro resultado = bll.BuscarPorIsbn("0000000000000");
            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void Remover_IsbnExistente_DeveRetornarTrue()
        {
            LivroBLL bll = new LivroBLL();
            bll.Cadastrar(new Livro("Livro D", "Autor D", "9780132350884", "2018", "Ed D", "300"));
            bool removeu = bll.Remover("9780132350884");
            Assert.IsTrue(removeu);
            Assert.AreEqual(0, bll.ListarTodos().Count);
        }

        [TestMethod]
        public void Remover_IsbnInexistente_DeveRetornarFalse()
        {
            LivroBLL bll = new LivroBLL();
            bool removeu = bll.Remover("9999999999999");
            Assert.IsFalse(removeu);
        }

        [TestMethod]
        public void ListarTodos_SemLivros_DeveRetornarListaVazia()
        {
            LivroBLL bll = new LivroBLL();
            Assert.AreEqual(0, bll.ListarTodos().Count);
        }

        [TestMethod]
        public void ListarTodos_ComDoisLivros_DeveRetornarDois()
        {
            LivroBLL bll = new LivroBLL();
            bll.Cadastrar(new Livro("L1", "A1", "9780132350884", "2000", "E1", "100"));
            bll.Cadastrar(new Livro("L2", "A2", "9780306406157", "2005", "E2", "200"));
            Assert.AreEqual(2, bll.ListarTodos().Count);
        }

        // ════════════════════════════════════════════════════════════════════
        //  TOSTRING
        // ════════════════════════════════════════════════════════════════════

        [TestMethod]
        public void ToString_DeveConterTodosOsDados()
        {
            Livro livro = new Livro("Refactoring", "Martin Fowler",
                                    "9780201485677", "1999", "Addison Wesley", "448");
            string str = livro.ToString();
            StringAssert.Contains(str, "Refactoring");
            StringAssert.Contains(str, "Martin Fowler");
            StringAssert.Contains(str, "9780201485677");
            StringAssert.Contains(str, "1999");
        }
    }
}
