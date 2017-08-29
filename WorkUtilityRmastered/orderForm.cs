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
    public partial class orderForm : Form
    {
        DataRow workingRow;
        bool edit = false; // по умолчанию создаем новую запись
        int clientId = 0;
        clientFinder cl = new clientFinder();

        public orderForm(DataRow innerRow)
        {
            InitializeComponent();
            if (innerRow != null)//если при инцициализации получена строка, то запоминаем её
            {
                workingRow = innerRow;
                clientId = int.Parse(innerRow["client"].ToString());
                MessageBox.Show("Client id" + clientId);
                edit = true;
                System.Console.WriteLine(workingRow["order"] + " " + innerRow["id"]);
                fillField();
            }
            else
            {
                workingRow = generalForm.data.Tables["orders"].NewRow();
            }
        }

        private void clientTextBox_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(clientSearcher.searchClient(sender as TextBox, clientTelTextBox, generalForm.data.Tables["clients"]));
            
            /*System.Console.WriteLine("clientId from textBox = " + clientId);
                string notSelectStrinrg = clientTextBox.Text.Substring(0, clientTextBox.SelectionStart).Trim();
                cl.getCondidatId(notSelectStrinrg);//отправляем не выделенный текст

                string possibleName = cl.getCondidatName();
                string attachmentPart = "";
                if (possibleName != "") attachmentPart = possibleName.Substring(notSelectStrinrg.Length);


                clientTextBox.Text += attachmentPart;
                clientTextBox.Select(notSelectStrinrg.Length, attachmentPart.Length);

                if (cl.equalClient(notSelectStrinrg))
                {
                    clientId = cl.possibleClientId;
                    clientTelTextBox.Text = cl.getPhone();
                }
                else
                {
                    clientId = 0;
                    clientTelTextBox.Text = "";
                }*/
        }

        private void clientTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && clientTextBox.SelectedText != "" && clientTextBox.SelectionLength != clientTextBox.Text.Length)
            {
                --clientTextBox.SelectionStart;
                clientTextBox.SelectionLength++;
            }

            if (e.KeyCode == Keys.Right)
            {
                try
                {
                    clientTelTextBox.Text = generalForm.data.Tables["clients"].Select("name = '" + clientTextBox.Text + "'")[0]["tel"].ToString();
                    clientId = int.Parse(generalForm.data.Tables["clients"].Select("name = '" + clientTextBox.Text + "'")[0]["id"].ToString());
                    System.Console.WriteLine("client id from dataset = " + clientId);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                clientTextBox.Text.Remove(clientTextBox.SelectionStart);
            }
        }

        private void fillField() {
            clientId = int.Parse(workingRow["id"].ToString());
            orderTextBox.Text = workingRow["order"].ToString();
            orderCount.Value = int.Parse(workingRow["count"].ToString());
            DataRow cl = generalForm.data.Tables["clients"].Select("id = " + clientId)[0];
            clientTextBox.Text = cl["name"].ToString();
            clientTelTextBox.Text = cl["tel"].ToString();
            completeCheckBox.Checked = bool.Parse(workingRow["complete"].ToString());
            commentTextBox.Text = workingRow["comment"].ToString();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (orderTextBox.Text != "" && clientTextBox.Text != "")
            {
                if (clientId == 0)
                {
                    generalForm.data.Tables["clients"].Rows.Add(null, clientTextBox.Text, clientTelTextBox.Text);
                    clientId = int.Parse(generalForm.data.Tables["clients"].Rows[generalForm.data.Tables["clients"].Rows.Count - 1]["id"].ToString());
                    System.Console.WriteLine("client id from dataset = " + clientId);
                    MessageBox.Show("Клиент был добвален");
                }
                else {
                    MessageBox.Show("Номер телефона клиента был обновлен");
                    generalForm.data.Tables["clients"].Select("id = " + clientId)[0]["tel"] = clientTelTextBox.Text;
                }

                if (edit)
                { 
                   System.Console.WriteLine("Ветка с редактированием");
                   workingRow["order"] = orderTextBox.Text;
                   workingRow["client"] = clientId;
                   workingRow["count"] = orderCount.Value;
                   workingRow["complete"] = completeCheckBox.Checked;
                   workingRow["comment"] = commentTextBox.Text;
                   MessageBox.Show("Client id" + clientId);
               }
               else {
                   System.Console.WriteLine("Ветка с новым");
                   workingRow["date"] = System.DateTime.Now.Date.ToString("dd.MM.yy");
                   workingRow["order"] = orderTextBox.Text;
                   workingRow["client"] = clientId;
                   workingRow["count"] = orderCount.Value;
                   workingRow["complete"] = completeCheckBox.Checked;
                   workingRow["comment"] = commentTextBox.Text;

                   generalForm.data.Tables["orders"].Rows.Add(workingRow);

               }
                
              // this.DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show("Необходимые поля отмеченны звездочкой");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
