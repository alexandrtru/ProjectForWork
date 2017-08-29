using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkUtiliteRmastered
{
    public partial class searchForm : Form
    {
        string startFilter;
        string Where = "";
        string What = "device LIKE";
        BindingSource bs;

        public searchForm(BindingSource inBs)
        {
            bs = inBs;
            startFilter = bs.Filter;
            InitializeComponent();
        }

        private void search_Load(object sender, EventArgs e)
        {
            issueRadioButton.Checked = true;
            deviceRadio.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (keyTextBox.Text.Trim() != "")
            {
                SearchRows(Where, What, keyTextBox.Text);
            }
            else {
                try
                {
                    bs.Filter = Where;
                }
                catch {
                    System.Console.WriteLine("Ошибка");
                }
            }
        }

        private void SearchRows(string whr, string wht, string k)
        {
            string query = String.Format("{0} {1} '{2}*'", whr, wht, k);
            System.Console.WriteLine(query);
            try
            {
                bs.Filter = query;
            }
            catch {
                System.Console.WriteLine("Запрос ничего не вернул");
            }

        }

        private void issueRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (issueRadioButton.Checked) Where = "";
            SearchRows(Where, What, keyTextBox.Text);
        }

        private void issueTrueRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (issueTrueRadioButton.Checked) Where = "issue = 1 and";
            SearchRows(Where, What, keyTextBox.Text);
        }

        private void issueFalseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (issueFalseRadioButton.Checked) Where = "issue = 0 and";
            SearchRows(Where, What, keyTextBox.Text);
        }

        private void ownerNameRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ownerNameRadio.Checked) What = "name LIKE";
            if (keyTextBox.Text.Trim() != "") SearchRows(Where, What, keyTextBox.Text);
        }

        private void deviceRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (deviceRadio.Checked) What = "device LIKE";
            if (keyTextBox.Text.Trim() != "") SearchRows(Where, What, keyTextBox.Text);
        }

        private void dateRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (dateRadio.Checked) What = "date LIKE";
            if (keyTextBox.Text.Trim() != "") SearchRows(Where, What, keyTextBox.Text);
        }

        private void issueDateRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (issueDateRadio.Checked) What = "issue_date LIKE";
            if(keyTextBox.Text.Trim() != "") SearchRows(Where, What, keyTextBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void search_FormClosing(object sender, FormClosingEventArgs e)
        {
            bs.Filter = startFilter;
        }
    }
}
