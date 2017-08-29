using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WorkUtiliteRmastered
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        bool sWasChanged = false;

        private void setDbPathBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "sqliteDataBase| *.db3";
            op.Multiselect = false;
            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SQLiteConnection con = new SQLiteConnection("Data Source = " + op.FileName + "; version = 3");
                    DataSet ds = new DataSet();
                    //проверка наличия таблиц
                    SQLiteDataAdapter da = new SQLiteDataAdapter("select * from devices", con);
                    da.Fill(ds, "devices");
                    da.SelectCommand.CommandText = "select * from clients";
                    da.Fill(ds, "clients");
                    da.SelectCommand.CommandText = "select * from tasks";
                    da.Fill(ds, "tasks");
                    da.SelectCommand.CommandText = "select * from orders";
                    da.Fill(ds, "orders");
                    Properties.Settings.Default.dbPath = op.FileName;
                    ds.Dispose();
                    da.Dispose();
                    con.Dispose();
                    System.Console.WriteLine("База данных прошла проверку на соответствие");
                    sWasChanged = true;
                }
                catch
                {
                    MessageBox.Show("База данных не прошла проверку на соответствие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void companyNameTxtBx_TextChanged(object sender, EventArgs e)
        {
            sWasChanged = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (companyNameTxtBx.Text.Trim() != "")
            {
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show("Не все поля заполнены верно");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (!sWasChanged)
            {
                if (MessageBox.Show("Некоторые параметры были измененыю Выйти без сохранения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
