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
    public partial class firstRun : Form
    {
        public firstRun()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            SQLiteConnection.CreateFile("data.db3");

            SQLiteConnection conn = new SQLiteConnection(@"Data Source = data.db3; version = 3");
            SQLiteCommand comm = new SQLiteCommand("CREATE TABLE clients (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, Name STRING NOT NULL DEFAULT some_client, tel STRING);", conn);
            conn.Open();
            comm.ExecuteNonQuery();
            comm.CommandText = "CREATE TABLE devices (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE DEFAULT (0), date STRING NOT NULL DEFAULT (1 / 1 / 2000), device STRING NOT NULL DEFAULT some_dev, owner INTEGER REFERENCES clients (id), issue BOOLEAN NOT NULL DEFAULT false, price INTEGER, paid BOOLEAN NOT NULL DEFAULT false, defect STRING DEFAULT some_defect, issue_date STRING);";
            comm.ExecuteNonQuery();
            comm.CommandText = "CREATE TABLE tasks (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, task STRING NOT NULL, priory INTEGER NOT NULL DEFAULT (0), complete BOOLEAN NOT NULL DEFAULT (0), date STRING NOT NULL, complete_to DATETIME, comment TEXT);";
            comm.ExecuteNonQuery();
            comm.CommandText = "CREATE TABLE orders (id INTEGER PRIMARY KEY UNIQUE NOT NULL, 'order' STRING NOT NULL, count INTEGER, client INTEGER REFERENCES clients (id) NOT NULL, complete BOOLEAN NOT NULL, date STRING, comment TEXT);";
            comm.ExecuteNonQuery();
            //CREATE TABLE orders (id INTEGER PRIMARY KEY UNIQUE NOT NULL, "order" STRING NOT NULL, client INTEGER REFERENCES clients (id) NOT NULL, complete BOOLEAN NOT NULL, date STRING, comment TEXT);
            conn.Close();
            conn.Dispose();
            comm.Dispose();
            Properties.Settings.Default.dbPath = Application.StartupPath + "\\data.db3";
            this.DialogResult = DialogResult.OK;
        }

        private void setBtn_Click(object sender, EventArgs e)
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
                    this.DialogResult = DialogResult.OK;
                    System.Console.WriteLine("База данных прошла проверку на соответствие");
                }
                catch
                {
                    MessageBox.Show("База данных не прошла проверку на соответствие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
