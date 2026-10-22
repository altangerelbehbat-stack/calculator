using System;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();

            // Товчлууруудыг код дотроос автоматаар холбож байна (Properties руу орох шаардлагагүй)
            // Тоонууд болон цэг
            button5.Click += button_Click;   // 7
            button9.Click += button_Click;   // 8
            button13.Click += button_Click;  // 9
            button6.Click += button_Click;   // 4
            button10.Click += button_Click;  // 5
            button14.Click += button_Click;  // 6
            button7.Click += button_Click;   // 1
            button11.Click += button_Click;  // 2
            button15.Click += button_Click;  // 3
            button8.Click += button_Click;   // 0
            button16.Click += button_Click;  // .

            // Үйлдлүүд (+, -, *, /)
            button20.Click += operator_Click; // +
            button19.Click += operator_Click; // -
            button18.Click += operator_Click; // *
            button17.Click += operator_Click; // /

            // Тусгай товчлуурууд
            button24.Click += btnEqual_Click;       // =
            btnC.Click += btnC_Click;               // C
            btnCE.Click += btnCE_Click;             // CE
            btnBackspace.Click += btnBackspace_Click; // Backspace
            button12.Click += btnPlusMinus_Click;   // +/-
            button21.Click += btnSqrt_Click;        // sqr
            button23.Click += btnReciprocal_Click;  // 1/x
        }

        // 1. Тоон товчлуурууд болон цэг (.) дархад ажиллах хэсэг
        private void button_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + ".";
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + button.Text;
            }
        }

        // 2. Арифметик үйлдэл (+, -, *, /) дархад ажиллах хэсэг
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnEqual_Click(sender, e);
                operationPerformed = button.Text;
                resultValue = double.Parse(txtDisplay.Text);
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(txtDisplay.Text);
                isOperationPerformed = true;
            }
        }

        // 3. Бүх утгыг цэвэрлэх (C товч)
        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // 4. Дэлгэцийг цэвэрлэх (CE товч)
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        // 5. Нэг нэгээр нь устгах (Backspace)
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if (txtDisplay.Text == "" || txtDisplay.Text == "-")
            {
                txtDisplay.Text = "0";
            }
        }

        // 6. Тэнцүү (=) товч дарж үр дүн гаргах
        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    if (double.Parse(txtDisplay.Text) != 0)
                    {
                        txtDisplay.Text = (resultValue / double.Parse(txtDisplay.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("0-д хувааж болохгүй!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(txtDisplay.Text);
            operationPerformed = "";
        }

        // 7. Нэмэлт функцууд
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double val = double.Parse(txtDisplay.Text);
            if (val >= 0)
                txtDisplay.Text = Math.Sqrt(val).ToString();
            else
                MessageBox.Show("Сөрөг тооноос язгуур гарахгүй!");
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            double val = double.Parse(txtDisplay.Text);
            if (val != 0)
                txtDisplay.Text = (1 / val).ToString();
            else
                MessageBox.Show("0-д хувааж болохгүй!");
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            double val = double.Parse(txtDisplay.Text);
            txtDisplay.Text = (-val).ToString();
        }
    }
}