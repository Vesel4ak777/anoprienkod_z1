using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                maskedTextBox1.PasswordChar = '\0';
            else maskedTextBox1.PasswordChar = '*';
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || maskedTextBox1.Text=="")
            {
                MessageBox.Show("Заполните все поля!","Предупреждение",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            this.Hide();
            var f2 = new Form2();
            f2.label1.Text = textBox1.Text;
            f2.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar) != false) && (e.KeyChar < 'А' || e.KeyChar > 'я')) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
            MessageBox.Show("Логин только латиницей, только буквы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
            MessageBox.Show("Пароль только цифрами!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}
