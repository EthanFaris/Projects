namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string num1 = "";
        private string num2 = ""; 
        private char func;
        private int result = 0;
        private string userInput;
        private void button1_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "1";
            textbox.Text += userInput;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "2";
            textbox.Text += userInput;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "3";
            textbox.Text += userInput;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "4";
            textbox.Text += userInput;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "5";
            textbox.Text += userInput;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "6";
            textbox.Text += userInput;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "7";
            textbox.Text += userInput;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "8";
            textbox.Text += userInput;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textbox.Text = "";
            userInput += "9";
            textbox.Text += userInput;
        }

        private void button10_Click(object sender, EventArgs e) // Clear
        {
            func = ' ';
            num1 = "";
            num2 = "";
            userInput = "";
            result = 0;
            textbox.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e) // Add
        {
            func = '+';
            num1 = userInput;
            userInput = "";
        }

        private void button12_Click(object sender, EventArgs e) // Subtract
        {
            func = '-';
            num1 = userInput;
            userInput = "";
        }

        private void button13_Click(object sender, EventArgs e) // Multiply
        {
            func = '*';
            num1 = userInput;
            userInput = "";
        }

        private void button14_Click(object sender, EventArgs e) // Division
        {
            func = '/';
            num1 = userInput;
            userInput = "";
        }

        private void button15_Click(object sender, EventArgs e) // Submit
        {
            num2 = userInput;
            int first, second;
            first = Convert.ToInt32(num1);
            second = Convert.ToInt32(num2); 

            switch(func)
            {
                case '+':
                    result = first + second;
                    break;
                case '-':
                    result = first - second;
                    break;
                case '*':
                    result = first * second;
                    break;
                case '/':
                    if (second == 0) textbox.Text = "Error";
                    else result = first / second;
                    break;
            }

            textbox.Text = textbox.Text == "Error" ? "Error" : Convert.ToString(result);
            userInput = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Textbox
        {

        }

        private void button16_Click(object sender, EventArgs e) // 0
        {
            textbox.Text = "";
            userInput += "0";
            textbox.Text += userInput;
        }
    }
}