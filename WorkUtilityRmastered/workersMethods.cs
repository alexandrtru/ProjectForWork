using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace WorkUtiliteRmastered
{
     partial class generalForm
    {
         private void edDev()
         {
             EditDevice ed = new EditDevice(data.Tables["devices"].Select("id = " + devicesDataView.CurrentRow.Cells[0].Value)[0]);
             if (ed.ShowDialog() == DialogResult.OK)
             {
                 clientsDataAdapter.Update(data.Tables["clients"]);
                 devicesDataAdapter.Update(data.Tables["devices"]);
                 refreshDevicesView();
             }
         }

         private void issueDev()
         {
             DataRow fastRow = data.Tables["devices"].Select("id = " + devicesDataView.CurrentRow.Cells[0].Value)[0];
             if (Boolean.Parse(fastRow["issue"].ToString()) == false)
             {
                 if (MessageBox.Show("Выдать оборудование?", "Вы уверены?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     fastRow["issue"] = true;
                     fastRow["issue_date"] = System.DateTime.Now.Date.ToString("dd.MM.yy");
                     devicesDataAdapter.Update(data, "devices");//обновляем источник (Базу данных)
                     devicesDataView.CurrentCell = null;
                     refreshDevicesView();
                 }
             }
             else if (Boolean.Parse(fastRow["issue"].ToString()) == true)
             {
                 if (MessageBox.Show("Вернуть оборудование в ремонт?", "Вы уверены?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     fastRow["issue"] = false;
                     fastRow["issue_date"] = "";
                     devicesDataView.CurrentCell = null;
                     devicesDataAdapter.Update(data, "devices");//обновляем источник (Базу данных)
                     refreshDevicesView();
                 }
             }
             fastRow = null;
         }

         private void editTask()
         {
             addTask at = new addTask(data.Tables["tasks"].Select("id =" + tasksDataView.SelectedCells[0].Value)[0]);
             if (at.ShowDialog() == DialogResult.OK)
             {
                 tasksDataAdapter.Update(data.Tables["tasks"]);
                 createTasksView();
             }
         }

         //отмечает дело как выполеннное
         private void completeTask()
         {
             if (MessageBox.Show("Дело выполнено?", "Отметить как выполенное", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 data.Tables["tasks"].Select("id =" + tasksDataView.SelectedCells[0].Value)[0]["complete"] = true;
                 tasksDataAdapter.Update(data.Tables["tasks"]);
                 createTasksView();
             }
         }

         private void editOrder(){ 
            orderForm of = new orderForm(data.Tables["orders"].Select("id =" + ordersDataView.SelectedRows[0].Cells[0].Value.ToString())[0]);
            if (of.ShowDialog() == DialogResult.OK)
            {
                clientsDataAdapter.Update(data.Tables["clients"]);
                ordersDataAdapter.Update(data.Tables["orders"]);
                createOrdersView();
            }
         }

         private void completeOrder() {
             if (MessageBox.Show("Заказ выполнен?", "Отметить как выполенное", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 data.Tables["orders"].Select("id =" + ordersDataView.SelectedCells[0].Value)[0]["complete"] = true;
                 ordersDataAdapter.Update(data.Tables["orders"]);
                 createOrdersView();
             }
         }

         static public void printClientTable() {
             foreach (DataRow r in data.Tables["clients"].AsEnumerable())
             {
                 System.Console.WriteLine(r["id"] + " " + r["name"] + " " + r["tel"]);
             }
         }


    }
}
