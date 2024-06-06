using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Планирование_модельных_экспериментов
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //полный факторный план
        private void button1_Click(object sender, EventArgs e)
        {
          Form4 f4 = new Form4();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f4.Show();//<имя переменной>.Show() (открытие нужной формы)
            this.Hide();
            //this.Close(); //(закрытие текущей формы)
        }

        //план с измененением фактора по одному
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            this.Hide();
            //this.Close(); //(закрытие текущей формы)
            f3.Show();//<имя переменной>.Show() (открытие нужной формы)
            
        }
        //рандомизированный план
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f2.Show();//<имя переменной>.Show() (открытие нужной формы)
            this.Hide();
            //this.Close(); //(закрытие текущей формы)
        }
        //дробный факторный план
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f5.Show();//<имя переменной>.Show() (открытие нужной формы)
            this.Hide();
            //this.Close(); //(закрытие текущей формы)
        }

        //выход из программы
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Действительно выйти?" /* вопрос в окне */, "Выход из программы" /*заголовок окна*/,
                MessageBoxButtons.YesNo /*типы кнопок*/, MessageBoxIcon.Question /*иконка вопроса*/, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) Close();//закрытие программы, елси нажата кнопка Yes

        }

        //кнопки информации об экспериментах
        private void inform1(object sender, EventArgs e)
        {
            Form6 f = new Form6();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f.Show();//<имя переменной>.Show() (открытие нужной формы)
        }

        private void inform2(object sender, EventArgs e)
        {
            Form7 f = new Form7();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f.Show();//<имя переменной>.Show() (открытие нужной формы)
        }

        private void inform3(object sender, EventArgs e)
        {
            Form8 f = new Form8();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f.Show();//<имя переменной>.Show() (открытие нужной формы)
        }

        private void inform4(object sender, EventArgs e)
        {
            Form9 f = new Form9();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f.Show();//<имя переменной>.Show() (открытие нужной формы)
        }
    }
}
