using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace analizadorLexico
{

    public partial class Form1 : Form
    {
        int suma1 = 0, suma2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo_fuente;
            string ruta_archivo;



            openFileDialog1.Filter = "Codigo fuente | *.c";
            openFileDialog1.Title = "compilador - Abrir codigo fuente";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ruta_archivo = openFileDialog1.FileName;
                System.IO.StreamReader Fp = new System.IO.StreamReader(ruta_archivo, System.Text.Encoding.Default);
                codigo_fuente = Fp.ReadToEnd();
                Fp.Close();
                richTextBox1.Text = codigo_fuente;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            String entrada = richTextBox1.Text;
            int f = 0;
            analizadorLexico lex = new analizadorLexico();
            LinkedList<token> LTokens = lex.Escanear(entrada);

            f = lex.cont(f);
            int i = 0;
            foreach (token item in LTokens)
            {
                dataGridView1.Rows.Insert(i, Convert.ToString(i + 1), Convert.ToString(item.GetValueToken()), Convert.ToString(item.GetTipoToken()));
                i++;
            }
            suma1 += i;
            suma1 = suma1 - f;
            label1.Text = "Total de tokens = " + suma1;
            tabControl1.SelectedIndex = 1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string codigo_fuente;
            string ruta_archivo;

            openFileDialog2.Filter = "Codigo fuente | *.c";
            openFileDialog2.Title = "compilador - Abrir codigo fuente";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                ruta_archivo = openFileDialog2.FileName;
                System.IO.StreamReader Fp = new System.IO.StreamReader(ruta_archivo, System.Text.Encoding.Default);
                codigo_fuente = Fp.ReadToEnd();
                Fp.Close();
                richTextBox2.Text = codigo_fuente;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int x = 0;
            String entrada = richTextBox2.Text;
            analizadorLexico lex = new analizadorLexico();
            LinkedList<token> LTokens2 = lex.Escanear(entrada);
            x = lex.cont(x);
            int i = 0;
            foreach (token item in LTokens2)
            {
                dataGridView2.Rows.Insert(i, Convert.ToString(i + 1), Convert.ToString(item.GetValueToken()), Convert.ToString(item.GetTipoToken()));
                i++;
            }
            suma2 += i;
            suma2 = suma2 - x;
            label2.Text = "Total de tokens 2 = " + suma2;
            tabControl1.SelectedIndex = 1;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int distaciaLevenshtein = 0, mayor = 0;
            float porcentajeSimilitud;

            if (suma1 == suma2)
            {

                label3.Text = "La similitud es de 100%";
                tabControl1.SelectedIndex = 1;

            }
            else if (suma1 > suma2)
            {
                mayor = suma1;
                distaciaLevenshtein = (suma1 - suma2);

            }
            else if (suma1 < suma2)
            {
                mayor = suma2;
                distaciaLevenshtein = (suma1 - suma2) * (-1);

            }
            if (suma1 != suma2)
            {
                porcentajeSimilitud = 100f - (distaciaLevenshtein * 100f / mayor);
                label3.Text = "La similitud es de " + porcentajeSimilitud.ToString("F2") + " %";
                tabControl1.SelectedIndex = 1;

            }


        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}