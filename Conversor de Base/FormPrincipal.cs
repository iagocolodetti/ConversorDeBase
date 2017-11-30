using System;
using System.Windows.Forms;

namespace Conversor_de_Base
{
    public partial class FormPrincipal : Form
    {
        bool Travar;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Travar = false;
            comboBox1.Items.Clear();
            for (int i = 2; i <= 32; i++) comboBox1.Items.Add(i.ToString());
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void BtConverter_Click(object sender, EventArgs e)
        {
            try
            {
                if (Travar == false)
                {
                    Travar = true;
                    BaseFuncoes BF = new BaseFuncoes();
                    TextBox[] textBox = { textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16,
                            textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32 };
                    int Base = int.Parse(comboBox1.Text);
                    for (int i = 0; i <= 32 - 2; i++)
                    {
                        if ((i + 2) == Base) { textBox[i].BackColor = textBox[i].BackColor; textBox[i].ForeColor = System.Drawing.Color.Red; }
                        else { textBox[i].BackColor = textBox[i].BackColor; textBox[i].ForeColor = System.Drawing.SystemColors.WindowText; }
                        textBox[i].Text = BF.ConverterAlgarismo(textBox1.Text, Base, i + 2);
                    }
                }
                else MessageBox.Show("Aguarde o termino da conversão atual.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Não foi possível realizar a conversão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Travar = false;
            }
        }
    }
}
