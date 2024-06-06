using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//РАНДОМИЗИРОВАННЫЙ ПЛАН
namespace Планирование_модельных_экспериментов
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //кнопка "Назад"
        private void mainMenu(object sender, EventArgs e)
        {
            Form mainMenu = Application.OpenForms[0]; //открываем главную форму
            mainMenu.Show(); //показываем главную форму
            this.Close();// работает, если это не главная форма

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                return; // завершение выполнения метода или функции
            }
            int x = int.Parse(textBox1.Text);//количество факторов
            dataGridView7.RowCount = x;//построение таблицы для заполнения значений
            if (x < 1)
            {
                MessageBox.Show("Неверное количество факторов" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                textBox7.Clear();
                return;
            }
            else if (x > 5)
            {
                MessageBox.Show("Количество факторов не больше 5" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                textBox7.Clear();
                return;
            }
            dataGridView7.ColumnCount = 2;
            dataGridView7.Columns[0].HeaderText = "min"; dataGridView7.Columns[1].HeaderText = "max";
            if (x >= 1) dataGridView7.Rows[0].HeaderCell.Value = "х1"; //заголовки строк
            if (x >= 2) dataGridView7.Rows[1].HeaderCell.Value = "х2";
            if (x >= 3) dataGridView7.Rows[2].HeaderCell.Value = "х3";
            if (x >= 4) dataGridView7.Rows[3].HeaderCell.Value = "х4";
            if (x == 5) dataGridView7.Rows[4].HeaderCell.Value = "х5";
        }

        //кнопка "Построить"
        private void calculate(object sender, EventArgs e)
        {
            //сообщения об ошибке 
            if (string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите количество факторов и уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                return; // завершение выполнения метода или функции
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите количество факторов" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                return; // завершение выполнения метода или функции
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Введите количество уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);

                return; // завершение выполнения метода или функции
            }
            int x = int.Parse(textBox1.Text);
            int count = int.Parse(textBox7.Text);//количество опытов
            if (count < 1)
            {
                MessageBox.Show("Неверное количество опытов" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                textBox7.Clear();
                return;
            }
            double[,] znach = new double[x, 2];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < 2; j++)
                {
                    // Получаем значение из определенной ячейки в столбце 
                    object cellValue = dataGridView7.Rows[i].Cells[j].Value;
                    // Проверяем, что значение не равно null
                    if (cellValue != null)
                    {
                        // Преобразуем значение в double и добавляем его в массив
                        if (double.TryParse(cellValue.ToString(), out double parsedValue)) znach[i, j] = parsedValue;
                        else
                        {
                            // Обработка ошибки преобразования, например, что-то записываем в массив
                            znach[i, j] = 0.0;
                        }
                    }
                    else
                    {
                        // Обработка случая, если значение равно null, например, что-то записываем в массив
                        znach[i, j] = 0.0;
                    }
                }
            dataGridView1.RowCount = count;//построение таблицы плана эксперимента 
            dataGridView1.ColumnCount = x;
            if (x >= 1) dataGridView1.Columns[0].HeaderText = "x1";//заголовки строк
            if (x >= 2) dataGridView1.Columns[1].HeaderText = "x2";
            if (x >= 3) dataGridView1.Columns[2].HeaderText = "x3";
            if (x >= 4) dataGridView1.Columns[3].HeaderText = "x4";
            if (x == 5) dataGridView1.Columns[4].HeaderText = "x5";
            Random rnd = new Random();
            for (int n=0; n<count; n+=0)
            {
                for (int i = 0; i < x; i++)
                    dataGridView1.Rows[n].Cells[i].Value = Math.Round(rnd.NextDouble()*(znach[i, 1]-znach[i, 0])+ znach[i, 0], 2);//генерация случайного значения в диапазоне
                dataGridView1.Rows[n].HeaderCell.Value = Convert.ToString(++n);
            }
                
        }
        //Кнопка "Сброс"
        private void clear(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox7.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView7.Rows.Clear();
            dataGridView7.Columns.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Действительно выйти?" /* вопрос в окне */, "Выход из программы" /*заголовок окна*/,
                MessageBoxButtons.YesNo /*типы кнопок*/, MessageBoxIcon.Question /*иконка вопроса*/, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) Close();//закрытие программы, елси нажата кнопка Yes

        }

        private void оПланеЭкспериментаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f.Show();//<имя переменной>.Show() (открытие нужной формы)
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.KeyChar = (char)0;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.KeyChar = (char)0;
        }
    }
}
