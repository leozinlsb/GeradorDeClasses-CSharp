using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercicio01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ── Botão Limpar ─────────────────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();   // campo propriedade
            textBox2.Clear();   // campo nome da classe
            listBox1.Items.Clear();
        }

        // ── Botão => (adicionar propriedade à lista) ─────────────────────────
        private void button3_Click(object sender, EventArgs e)
        {
            string prop = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(prop))
            {
                MessageBox.Show("Digite o nome da propriedade antes de adicionar.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBox1.Items.Contains(prop.ToLower()))
            {
                MessageBox.Show("Essa propriedade já foi adicionada.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBox1.Items.Add(prop.ToLower());
            textBox1.Clear();
            textBox1.Focus();
        }

        // ── Botão Gerar Classe ───────────────────────────────────────────────
        private void button2_Click(object sender, EventArgs e)
        {
            // ── BLL: validações ──────────────────────────────────────────────
            string nomeClasse = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(nomeClasse))
            {
                MessageBox.Show("Informe o nome da classe.", "Validação",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (!char.IsLetter(nomeClasse[0]))
            {
                MessageBox.Show("O nome da classe deve começar com uma letra.", "Validação",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos uma propriedade à lista.", "Validação",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            // ── Gerar código ─────────────────────────────────────────────────
            var props = new List<string>();
            foreach (var item in listBox1.Items)
                props.Add(item.ToString());

            string codigo = GerarCodigo(nomeClasse, props);

            // Exibir em uma nova janela
            var frmResultado = new Form();
            frmResultado.Text = "Classe Gerada: " + nomeClasse;
            frmResultado.Size = new System.Drawing.Size(620, 550);
            frmResultado.StartPosition = FormStartPosition.CenterScreen;

            var txt = new RichTextBox();
            txt.Dock = DockStyle.Fill;
            txt.Font = new Font("Consolas", 10f);
            txt.BackColor = Color.FromArgb(30, 30, 30);
            txt.ForeColor = Color.FromArgb(220, 220, 220);
            txt.Text = codigo;
            txt.ReadOnly = true;
            txt.WordWrap = false;
            txt.ScrollBars = RichTextBoxScrollBars.Both;

            var btnCopiar = new Button();
            btnCopiar.Text = "Copiar Código";
            btnCopiar.Dock = DockStyle.Bottom;
            btnCopiar.Height = 40;
            btnCopiar.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
            btnCopiar.BackColor = Color.FromArgb(0, 122, 204);
            btnCopiar.ForeColor = Color.White;
            btnCopiar.FlatStyle = FlatStyle.Flat;
            btnCopiar.Click += (s, ev) =>
            {
                Clipboard.SetText(txt.Text);
                MessageBox.Show("Código copiado!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            frmResultado.Controls.Add(txt);
            frmResultado.Controls.Add(btnCopiar);
            frmResultado.ShowDialog();
        }

        // ── Geração do código C# ─────────────────────────────────────────────
        private string GerarCodigo(string nomeClasse, List<string> props)
        {
            string i1 = "    ";
            string i2 = "        ";
            var sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("public class " + nomeClasse);
            sb.AppendLine("{");

            // Campos privados
            foreach (var p in props)
                sb.AppendLine(i1 + "private string " + p + ";");

            sb.AppendLine();

            // Construtor padrão
            sb.AppendLine(i1 + "public " + nomeClasse + "()");
            sb.AppendLine(i1 + "{");
            foreach (var p in props)
                sb.AppendLine(i2 + p + " = string.Empty;");
            sb.AppendLine(i1 + "}");
            sb.AppendLine();

            // Construtor com parâmetros
            var paramList = string.Join(", ", props.Select(p => "string " + p));
            sb.AppendLine(i1 + "public " + nomeClasse + "(" + paramList + ")");
            sb.AppendLine(i1 + "{");
            foreach (var p in props)
                sb.AppendLine(i2 + "Set" + Cap(p) + "(" + p + ");");
            sb.AppendLine(i1 + "}");
            sb.AppendLine();

            // Getters e Setters
            foreach (var p in props)
            {
                // Get
                sb.AppendLine(i1 + "public string Get" + Cap(p) + "()");
                sb.AppendLine(i1 + "{");
                sb.AppendLine(i2 + "return " + p + ";");
                sb.AppendLine(i1 + "}");
                sb.AppendLine();

                // Set
                sb.AppendLine(i1 + "public void Set" + Cap(p) + "(string valor)");
                sb.AppendLine(i1 + "{");
                sb.AppendLine(i2 + "if (string.IsNullOrWhiteSpace(valor))");
                sb.AppendLine(i2 + "    throw new ArgumentException(\"" + Cap(p) + " nao pode ser vazio.\");");
                sb.AppendLine(i2 + p + " = valor.Trim();");
                sb.AppendLine(i1 + "}");
                sb.AppendLine();
            }

            // ToString
            var campos = string.Join(", ", props.Select(p => Cap(p) + ": {" + p + "}"));
            sb.AppendLine(i1 + "public override string ToString()");
            sb.AppendLine(i1 + "{");
            sb.AppendLine(i2 + "return $\"" + nomeClasse + " [ " + campos + " ]\";");
            sb.AppendLine(i1 + "}");

            sb.AppendLine("}");
            return sb.ToString();
        }

        // Primeira letra maiúscula
        private string Cap(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}

