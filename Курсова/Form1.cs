using System;
using System.Windows.Forms;


namespace Курсова
{
    public partial class Form1 : Form
    {
        private int page = 0, point = 0, attempt = 0;
        public Form1()
        {
            InitializeComponent();
            FirstPage();
        }
        private void SetAnswer(int k)
        {
            switch (k)
            {
                case 1:
                    button1.Text = new DataHandler(page, MySelector.TRUE).Data;
                    break;
                case 2:
                    button2.Text = new DataHandler(page, MySelector.TRUE).Data;
                    break;
                case 3:
                    button3.Text = new DataHandler(page, MySelector.TRUE).Data;
                    break;
                case 4:
                    button4.Text = new DataHandler(page, MySelector.TRUE).Data;
                    break;
            }
        }
        private void ChangeNamesOfAllButtons()
        {
            UniqueNumbers uniqueNumbers = new UniqueNumbers(0, UserData.FCapacity, 4);

            button1.Text = new DataHandler(uniqueNumbers[0], MySelector.FALSE).Data;
            button2.Text = new DataHandler(uniqueNumbers[1], MySelector.FALSE).Data;
            button3.Text = new DataHandler(uniqueNumbers[2], MySelector.FALSE).Data;
            button4.Text = new DataHandler(uniqueNumbers[3], MySelector.FALSE).Data;

            SetAnswer(new Random().Next(1, 5));
        }
        private void FirstPage() // якщо без firstPage, то буде та форма, що по дефолту зроблена, а я хочу, щоб все було рандомно
        {
            ChangeNamesOfAllButtons();
            label3.Text = new DataHandler(new DataHandler(page, MySelector.TRUE).Data).Label;
            pictureBox1.Image = System.Drawing.Image.FromFile(new DataHandler(page++).Path);
        }
        private void RefreshPage(string text)
        {
            label3.Text = new DataHandler(new DataHandler(page, MySelector.TRUE).Data).Label;
            
            if (text == new DataHandler(page - 1, MySelector.TRUE).Data) ++point;
            
            if (page == UserData.TCapacity)
            {
                DialogResult result = MessageBox.Show(
                    $"Спроба[{++attempt}]\n" +
                    $"Кількість очків[{point}/{UserData.TCapacity}], які {UserData.Name} набрав(ла).\n\n" +
                    $"Retry - щоб пройти знову тест. " +
                    $"Cancel - щоб закінчити тест.", 
                    "Результат", MessageBoxButtons.RetryCancel);
                
                if (result == DialogResult.Retry)
                {
                    page = 0;
                    label2.Text = $"{page + 1}";
                    UserData.Answers = new Answers(UserData.TCapacity, UserData.FCapacity);
                    pictureBox1.Image = System.Drawing.Image.FromFile(new DataHandler(point = 0).Path);
                    FirstPage();
                }
                else Close();
            }
            else
            {
                ChangeNamesOfAllButtons();
                pictureBox1.Image = System.Drawing.Image.FromFile(new DataHandler(page).Path);
                label2.Text = $"{++page}";
            }
        }
        private void button1_Click(object sender, EventArgs e) => RefreshPage(button1.Text);
        private void button2_Click(object sender, EventArgs e) => RefreshPage(button2.Text);
        private void button3_Click(object sender, EventArgs e) => RefreshPage(button3.Text);
        private void button4_Click(object sender, EventArgs e) => RefreshPage(button4.Text);
    }
}
