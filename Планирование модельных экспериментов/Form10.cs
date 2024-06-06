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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        //private void textBox2_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(textBox2.Text))
        //    {

        //        return; // завершение выполнения метода или функции
        //    }
        //    int l = int.Parse(textBox2.Text);//количество уровней факторов
        //    if (l < 1)
        //    {
        //        MessageBox.Show("Неверное количество уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
        //        MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
        //        textBox2.Clear();
        //        return;
        //    }
        //    else if (l > 5)
        //    {
        //        MessageBox.Show("Количество уровней не больше 5" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
        //        MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
        //        textBox2.Clear();
        //        return;
        //    }
        //    dataGridView2.ColumnCount = l;

        //}
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
            if (x >= 1){ dataGridView3.Rows[0].HeaderCell.Value = "х1"; dataGridView2.Rows[0].HeaderCell.Value = "х1";} //заголовки строк
            if (x >= 2) { dataGridView2.Rows[1].HeaderCell.Value = "х2"; dataGridView3.Rows[1].HeaderCell.Value = "х2"; }
            if (x >= 3) { dataGridView2.Rows[2].HeaderCell.Value = "х3"; dataGridView3.Rows[2].HeaderCell.Value = "х3"; }
            if (x >= 4) { dataGridView2.Rows[3].HeaderCell.Value = "х4"; dataGridView3.Rows[3].HeaderCell.Value = "х4"; }
            if (x == 5) { dataGridView2.Rows[4].HeaderCell.Value = "х5"; dataGridView3.Rows[4].HeaderCell.Value = "х5"; }
        }

        //кнопка "Назад"
        private void mainMenu(object sender, EventArgs e)
        {
            Form mainMenu = Application.OpenForms[0]; //открываем главную форму
            mainMenu.Show(); //показываем главную форму
            this.Close();// работает, если это не главная форма
        }
        //кнопка Построить
        private void calculate(object sender, EventArgs e)
        {
            //сообщения об ошибке 
            //if (string.IsNullOrEmpty(textBox7.Text) && string.IsNullOrEmpty(textBox2.Text))
            //{
            //    MessageBox.Show("Введите количество факторов и уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
            //    MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
            //    return; // завершение выполнения метода или функции
            //}

            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Введите количество факторов" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
                MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);
                return; // завершение выполнения метода или функции
            }
            //if (string.IsNullOrEmpty(textBox2.Text))
            //{
            //    MessageBox.Show("Введите количество уровней" /* вопрос в окне */, "Ошибка построения" /*заголовок окна*/,
            //    MessageBoxButtons.OK /*типы кнопок*/, MessageBoxIcon.Error /*иконка вопроса*/);

            //    return; // завершение выполнения метода или функции
            //}

            int x = int.Parse(textBox7.Text);
            //int l = int.Parse(textBox2.Text);//количество уровней факторов
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
            double lev = Math.Pow(l, x);
            int s = Convert.ToInt32(lev);
            dataGridView1.RowCount = s;//построение таблицы плана эксперимента 
            dataGridView1.ColumnCount = x;
            int n = 0;
            if (x >= 1) dataGridView1.Columns[0].HeaderText = "х1"; //заголовки строк
            if (x >= 2) dataGridView1.Columns[1].HeaderText = "х2";
            if (x >= 3) dataGridView1.Columns[2].HeaderText = "х3";
            if (x >= 4) dataGridView1.Columns[3].HeaderText = "х4";
            if (x == 5) dataGridView1.Columns[4].HeaderText = "х5";
            if (x == 1)
                for (int i = 0; i < l; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = znach[0, i];
                    dataGridView1.Rows[n].HeaderCell.Value = Convert.ToString(++n);

                }
            if (x == 2)
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l; j++)
                    {
                        dataGridView1.Rows[n].Cells[0].Value = znach[0, i]; dataGridView1.Rows[n].Cells[1].Value = znach[1, j];
                        dataGridView1.Rows[n].HeaderCell.Value = Convert.ToString(++n);
                    }
                }

            if (x == 3)
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l; j++)
                    {
                        for (int k = 0; k < l; k++)
                        {
                            dataGridView1.Rows[n].Cells[0].Value = znach[0, i]; dataGridView1.Rows[n].Cells[1].Value = znach[1, j]; dataGridView1.Rows[n].Cells[2].Value = znach[2, k];
                            dataGridView1.Rows[n].HeaderCell.Value = Convert.ToString(++n);
                        }

                    }
                }
            if (x == 4)
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l; j++)
                    {
                        for (int k = 0; k < l; k++)
                        {
                            for (int m = 0; m < l; m++)
                            {
                                dataGridView1.Rows[n].Cells[0].Value = znach[0, i]; dataGridView1.Rows[n].Cells[1].Value = znach[1, j]; dataGridView1.Rows[n].Cells[2].Value = znach[2, k]; dataGridView1.Rows[n].Cells[3].Value = znach[3, m];
                                dataGridView1.Rows[n].HeaderCell.Value = Convert.ToString(++n);
                            }

                        }

                    }
                }
            if (x == 5)
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l; j++)
                        for (int k = 0; k < l; k++)
                            for (int m = 0; m < l; m++)
                                for (int p = 0; p < l; p++)
                                {
                                    dataGridView1.Rows[n].Cells[0].Value = znach[0, i]; dataGridView1.Rows[n].Cells[1].Value = znach[1, j]; dataGridView1.Rows[n].Cells[2].Value = znach[2, k]; dataGridView1.Rows[n].Cells[3].Value = znach[3, m]; dataGridView1.Rows[n].Cells[4].Value = znach[4, p];
                                    dataGridView1.Rows[n].HeaderCell.Value = Convert.ToString(++n);
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

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПланеЭкспериментаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();//имя нужной формы <имя любая переменная> = new имя нужной формы() (объявляем форму как переменную)
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
