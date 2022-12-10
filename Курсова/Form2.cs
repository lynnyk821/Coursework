using System;
using System.Windows.Forms;

namespace Курсова
{
    public partial class Form2 : Form
    {
        public Form2() => InitializeComponent();
        private void button5_Click(object sender, EventArgs e)
        {
            UserData.Name = textBox1.Text == "" ? "noname" : textBox1.Text;
            UserData.Answers = new Answers(UserData.TCapacity, UserData.FCapacity);
            Close();
        }
    }
}
