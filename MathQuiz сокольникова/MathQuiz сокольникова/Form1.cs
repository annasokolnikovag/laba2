using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz_сокольникова
{
    public partial class Form1 : Form
    {
        // Создаем Random object called randomizer 
        // генерирующий рандомные числа. 
        Random randomizer = new Random();

        // Эти целочисленные переменные будут хранить числа 
        // для сложения 
        int addend1;
        int addend2;

        // для вычитания
        int minuend;
        int subtrahend;

        // для умножения
        int multiplicand;
        int multiplier;

        // для деления 
        int dividend;
        int divisor;


        // отвечает за оставшееся время
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }
        public void StartTheQuiz()
        {
            // создаем задачу сложения используя 'addend1' и 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // преобразование в строки
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // для добавления чего то к sumб он должен быть равен 0
            sum.Value = 0;

            // вычитание
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // умножение
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // деление
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // начало для таймера
            timeLeft = 30;
            timeLabel.Text = "30 секунд";
            timer1.Start();
        }

        // Проверяет ответы: true - если ответы верные
        // иначе false
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // если CheckTheAnswer() выводит true при верном  
                // ответе остановить таймер  
                // и показать MessageBox.
                timer1.Stop();
                MessageBox.Show("Все ваши ответы верны!",
                                "Поздравляем!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // если выводит false, продолжать счет,
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " секунд";
                //если осталось 5 сек и меньше, окно красное
                if (timeLeft <= 5 && timeLeft >= 0) {
                    timeLabel.BackColor = Color.Red;
                }
               
            
        }
            else
            {
                // при окончании времени выводится окно о конце
                timer1.Stop();
                timeLabel.Text = "Время вышло!";
                MessageBox.Show("Ваше время закончилось.", "Простите!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void начатьНовыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
