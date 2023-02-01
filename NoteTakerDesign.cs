using System.Data;

namespace NoteTaker
{
    public partial class Form1 : Form
    {
        DataTable dataTable;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Messages", typeof(string));

            dataGridView2.DataSource = dataTable;

        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Add(txtTitle.Text, txtMessage.Text);

            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void bttRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;

            if (index > -1)
            {
                txtTitle.Text = dataTable.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = dataTable.Rows[index].ItemArray[1].ToString();
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;

            dataTable.Rows[index].Delete();
        }

    }
}