using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ПЛАН С ИЗМЕНЕНИЕМ ФАКТОРОВ ПО ОДНОМУ
namespace Планирование_модельных_экспериментов
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //поля для ввода уровней
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {

                return; // завершение выполнения метода или функции
            }
            int l = int.Parse(textBox2.Text);//количество уровней факторов            
            if (l < 1)
            {
                MessageBox.Show("Неверное количество уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                textBox2.Clear();
                return;
            }
            else if (l > 5)
            {
                MessageBox.Show("Количество уровней не больше 5" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                textBox2.Clear();
                return;
            }
            dataGridView2.ColumnCount = l;
            
        }
        private void textBox7_Leave(object sender, EventArgs e)
            {
            if (string.IsNullOrEmpty(textBox7.Text))
            {

                return; // завершение выполнения метода или функции
            }
            int x = int.Parse(textBox7.Text);//количество уровней факторов
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
            dataGridView2.RowCount = x;
            if (x >= 1) dataGridView2.Rows[0].HeaderCell.Value = "х1"; //заголовки строк
            if (x >= 2) dataGridView2.Rows[1].HeaderCell.Value = "х2";
            if (x >= 3) dataGridView2.Rows[2].HeaderCell.Value = "х3";
            if (x >= 4) dataGridView2.Rows[3].HeaderCell.Value = "х4";
            if (x == 5) dataGridView2.Rows[4].HeaderCell.Value = "х5";
        }

        //кнопка "Назад"
        private void mainMenu(object sender, EventArgs e)
        {
            Form mainMenu = Application.OpenForms[0]; //открываем главную форму
            mainMenu.Show(); //показываем главную форму
            this.Close();// работает, если это не главная форма
        }

        
            //кнопка "Построить"
            private void button3_Click(object sender, EventArgs e)
        {
            //сообщения об ошибке 
            if (string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Введите количество факторов и уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                return; // завершение выполнения метода или функции
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Введите количество факторов" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                return; // завершение выполнения метода или функции
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Введите количество уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);

                return; // завершение выполнения метода или функции
            }
            int x = int.Parse(textBox7.Text);
            int l = int.Parse(textBox2.Text);//количество уровней факторов
            //if (x < 1 && l < 1)
            //{
            //    MessageBox.Show("Неверное количество факторов и уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
            //    MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
            //    return;
            //}
            //else if (x < 1)
            //{
            //    MessageBox.Show("Неверное количество факторов" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
            //    MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
            //    return;
            //}
            //else if (l < 1)
            //{
            //    MessageBox.Show("Неверное количество уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
            //    MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
            //    return;
            //}
            dataGridView2.ColumnCount = l;
            
            double[,] znach = new double[x, l + 1];
            for (int i = 0; i < x; i++)
            {
                double sum = 0;
                for (int j = 0; j < l; j++)
                {

                    // Получаем значение из определенной ячейки в столбце 
                    object cellValue = dataGridView2.Rows[i].Cells[j].Value;
                    // Проверяем, что значение не равно null
                    if (cellValue != null)
                    {
                        // Преобразуем значение в double и добавляем его в массив
                        if (double.TryParse(cellValue.ToString(), out double parsedValue)) { znach[i, j] = parsedValue; sum += znach[i, j]; }
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
                    znach[i, l] = Math.Round(sum / l, 2);
                }
            }
            dataGridView1.RowCount = x*l;//построение таблицы плана эксперимента 
            dataGridView1.ColumnCount = x;
            if (x >= 1) dataGridView1.Columns[0].HeaderText = "х1"; //заголовки строк
            if (x >= 2) dataGridView1.Columns[1].HeaderText = "х2";
            if (x >= 3) dataGridView1.Columns[2].HeaderText = "х3";
            if (x >= 4) dataGridView1.Columns[3].HeaderText = "х4";
            if (x == 5) dataGridView1.Columns[4].HeaderText = "х5";
            int n = 0;
            //заполнение плана эксперимента
            for (int i = 0; i < x; i++)
            {
                for (int k = 0; k < l; k++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        if (i == j) dataGridView1.Rows[n].Cells[j].Value = znach[i, k];//вывод значения факторов 
                        else dataGridView1.Rows[n].Cells[j].Value = znach[j, l];//вывод среднего
                    }
                    dataGridView1.Rows[n].HeaderCell.Value = Convert.ToString(++n);
                    //номер эксперимента

                }
            }
        }
        //Кнопка "Сброс"
        private void clear(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox7.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Действительно выйти?" /* вопрос в окне */, "Выход из программы" /*заголовок окна*/,
                MessageBoxButtons.YesNo /*типы кнопок*/, MessageBoxIcon.Question /*иконка вопроса*/, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) Close();//закрытие программы, елси нажата кнопка Yes

        }

        private void оПланеЭкспериментаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
            f.Show();//<имя переменной>.Show() (открытие нужной формы)
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.KeyChar = (char)0;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.KeyChar = (char)0;
        }
    }
}
