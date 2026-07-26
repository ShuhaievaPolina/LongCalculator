using System;
using System.IO;
using System.Windows.Forms;

namespace Kyrsova_2_sem
{
    public partial class Form1 : Form
    {

        private BigInt savedNumber = null;
        private string currentOperation = "";

        public Form1()
        {
            InitializeComponent();
            InputNumber.Text = "";
            InputNumber2.Text = "";
            Operation.Text = "";
            Result.Text = "";
        }

        private void PrepareOperation(string operation)
        {
            try
            {
                string inputText = TextLine.Text;
                ClearUI();
                savedNumber = new BigInt(inputText);
                InputNumber.Text = savedNumber.ToString();
                currentOperation = operation;
                Operation.Text = currentOperation;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void buttonPlusClick(object sender, EventArgs e)
        {
            PrepareOperation("+");
        }

        private void buttonMinusClick(object sender, EventArgs e)
        {
            PrepareOperation("-");
        }

        private void buttonMultiplicationClick(object sender, EventArgs e)
        {
            PrepareOperation("*");
        }

        private void buttonDivisionClick(object sender, EventArgs e)
        {
            PrepareOperation("/");
        }

        private void buttonPovClick(object sender, EventArgs e)
        {
            PrepareOperation("^");
        }

        private void buttonEqualsClick(object sender, EventArgs e)
        {
            try
            {
                if (savedNumber == null || currentOperation == "") return;

                BigInt secondNumber = new BigInt(TextLine.Text);
                BigInt result = null;
                BigInt remainder = null;
                bool divideFlag = false;

                InputNumber2.Text = secondNumber.ToString();

                switch (currentOperation)
                {
                    case "+":
                        OpCounter.Reset();
                        result = savedNumber + secondNumber;
                        break;
                    case "-":
                        OpCounter.Reset();
                        result = savedNumber - secondNumber;
                        break;
                    case "*":
                        OpCounter.Reset();
                        result = savedNumber * secondNumber;
                        break;
                    case "/":
                        if(secondNumber == new BigInt(0))
                        {
                            MessageBox.Show("Ділення на нуль не можливе", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            secondNumber = null;
                            return;
                        }

                        OpCounter.Reset();
                        result = BigInt.Divide(savedNumber, secondNumber, out remainder);
                        divideFlag = true;
                        break;
                    case "^":
                        if (!int.TryParse(InputNumber2.Text, out int x))
                        {
                            MessageBox.Show("Степінь занадто велика! Комп'ютеру не вистачить пам'яті.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int baseDigitsCount = InputNumber.Text.Length;
                        long resultLength = (long)baseDigitsCount * x;

                        if (resultLength > 60000)
                        {
                            MessageBox.Show($"Результат буде занадто величезним (приблизно {resultLength} цифр)! Максимальний ліміт для виводу: 60 000 цифр.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        OpCounter.Reset();
                        result = BigMath.BigPov(savedNumber, x);
                        break;
                }

                if (result != null)
                {
                    Result.Text = result.ToString() + (divideFlag ? "  Остача: " + remainder.ToString() : "");
                }

                LabelTime.Text = $"Кількість операцій: {OpCounter.Steps}";
                savedNumber = null;
                currentOperation = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void buttonFactorialClick(object sender, EventArgs e)
        {
            try
            {
                Operation.Text = "!";
                InputNumber2.Text = "";
                BigInt a = new BigInt(TextLine.Text);
                InputNumber.Text = a.ToString();

                BigInt limit = new BigInt("10000");

                if (a > limit)
                {
                    MessageBox.Show("Число занадто велике для обчислення факторіалу. Введіть число до 10 000.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OpCounter.Reset();
                BigInt result = BigMath.Factorial(a);

                Result.Text = result.ToString();
                LabelTime.Text = $"Кількість операцій: {OpCounter.Steps}";
                savedNumber = null;
                currentOperation = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            ClearUI();
        }

        private void ButtonSaveToFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Result.Text))
            {
                MessageBox.Show("Немає результату для збереження!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";
            saveFileDialog.Title = "Зберегти результат";
            saveFileDialog.FileName = "Result.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string textToSave = $"Число 1: {InputNumber.Text}\r\n";
                    textToSave += $"Операція: {Operation.Text}\r\n";
                    if (!string.IsNullOrEmpty(InputNumber2.Text))
                    {
                        textToSave += $"Число 2: {InputNumber2.Text}\r\n";
                    }
                    textToSave += $"\nРезультат: {Result.Text}\r\n";
                    textToSave += $"Кількість операцій: {OpCounter.Steps}\r\n";
                    File.WriteAllText(saveFileDialog.FileName, textToSave);

                    MessageBox.Show("Файл успішно збережено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні файлу: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == '-' && TextLine.Text.Length == 0)
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            e.Handled = true;
        }

        private void ClearUI()
        {
            InputNumber.Text = "";
            InputNumber2.Text = "";
            Operation.Text = "";
            Result.Text = "";
            TextLine.Text = "";
            LabelTime.Text = "";
            savedNumber = null;
            currentOperation = "";
        }
    }
}