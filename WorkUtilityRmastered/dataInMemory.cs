using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WorkUtiliteRmastered
{
    partial class generalForm
    {
        public static DataSet data = new DataSet(); // набор данных 
        DataTable showingTableDevices = new DataTable();//таблица отображения устройств
        DataTable showingTableOrders = new DataTable();//таблица отображения заказов

        private void createViewDevicesTable()
        {
            using (DataTable table = showingTableDevices)
            {
                table.Columns.Add("id", typeof(Int16));
                table.Columns.Add("date", typeof(string));
                table.Columns.Add("device", typeof(string));
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("tel", typeof(string));
                table.Columns.Add("price", typeof(string));
                table.Columns.Add("paid", typeof(Boolean));
                table.Columns.Add("defect", typeof(string));
                table.Columns.Add("issue", typeof(Boolean));
                table.Columns.Add("issue_date", typeof(string));
            }
        }

        private void createViewOrdersTable()
        {
            using (DataTable table = showingTableOrders)
            {           
                table.Columns.Add("id", typeof(Int16));
                table.Columns.Add("order", typeof(string));
                table.Columns.Add("count", typeof(Int16));
                table.Columns.Add("client", typeof(string));
                table.Columns.Add("tel", typeof(string));
                table.Columns.Add("complete", typeof(Boolean));
                table.Columns.Add("date", typeof(string));
                table.Columns.Add("comment", typeof(string));
            }
        }


        private static void createDataSource()
        {
            using (DataSet data = generalForm.data)
            {
                data.Tables.Add(new DataTable("devices"));
                using (DataTable table = data.Tables["devices"])
                {
                    table.Columns.Add("id", typeof(Int16));
                    table.Columns.Add("date", typeof(string));
                    table.Columns.Add("device", typeof(string));
                    table.Columns.Add("owner", typeof(Int16));
                    table.Columns.Add("price", typeof(string));
                    table.Columns.Add("paid", typeof(Boolean));
                    table.Columns.Add("defect", typeof(string));
                    table.Columns.Add("issue", typeof(Boolean));
                    table.Columns.Add("issue_date", typeof(string));


                    table.Columns[0].AutoIncrement = true;
                    table.Columns[0].AutoIncrementSeed = 1;
                }

                data.Tables.Add(new DataTable("clients"));
                using (DataTable table = data.Tables["clients"])
                {
                    table.Columns.Add("id", typeof(Int16));
                    table.Columns.Add("name", typeof(string));
                    table.Columns.Add("tel", typeof(string));

                    table.Columns[0].AutoIncrement = true;
                    table.Columns[0].AutoIncrementSeed = 1;
                }

                data.Tables.Add(new DataTable("tasks"));
                using (DataTable table = data.Tables["tasks"])
                {
                    table.Columns.Add("id", typeof(Int16));
                    table.Columns.Add("task", typeof(string));
                    table.Columns.Add("priory", typeof(Int16));
                    table.Columns.Add("complete", typeof(Boolean));
                    table.Columns.Add("date", typeof(string));
                    table.Columns.Add("complete_to", typeof(DateTime));
                    table.Columns.Add("comment", typeof(string));

                    table.Columns[0].AutoIncrement = true;
                    table.Columns[0].AutoIncrementSeed = 1;
                }

                data.Tables.Add(new DataTable("orders"));
                using (DataTable table = data.Tables["orders"])
                {
                    table.Columns.Add("id", typeof(Int16));
                    table.Columns.Add("order", typeof(string));
                    table.Columns.Add("count", typeof(Int16));
                    table.Columns.Add("client", typeof(Int16));
                    table.Columns.Add("complete", typeof(Boolean));
                    table.Columns.Add("date", typeof(string));
                    table.Columns.Add("comment", typeof(string));

                    table.Columns[0].AutoIncrement = true;
                    table.Columns[0].AutoIncrementSeed = 1;
                }
                data.AcceptChanges();
            }
        }

        private void refreshDevicesView()
        {
            showingTableDevices.Clear();
            
            DataTable devices = data.Tables["devices"];
            DataTable clients = data.Tables["Clients"];
            if (devices.Rows.Count != 0)
            {
                //LINQ к таблицам чтобы выбрать всё и не заморачиваться со связями
                var query = from device in devices.AsEnumerable()
                            from client in clients.AsEnumerable()
                            where Convert.ToInt16(device["owner"]) == Convert.ToInt16(client["id"])
                            select (new
                            {
                                id = device["id"],
                                date = device["date"],
                                device = device["device"],
                                owner = client["name"],
                                tel = client["tel"],
                                price = device["price"],
                                paid = device["paid"],
                                defect = device["defect"],
                                issue = device["issue"],
                                issue_date = device["issue_date"],
                            });
                //перегружаем строки в таблицу (по возможности придумать более быстрое решение чем цикл)
                foreach (var row in query)
                {
                    showingTableDevices.Rows.Add(row.id, row.date, row.device, row.owner, row.tel, row.price, row.paid, row.defect, row.issue, row.issue_date);
                }

                BindingSource currSource = new BindingSource(showingTableDevices, "");
                devicesDataView.DataSource = currSource;

                //читабельный вид
                devicesDataView.AutoGenerateColumns = true;
                devicesDataView.Columns[0].HeaderCell.Value = "Номер";
                devicesDataView.Columns[1].HeaderCell.Value = "Дата";
                devicesDataView.Columns[2].HeaderCell.Value = "Устройство";
                devicesDataView.Columns[3].HeaderCell.Value = "Владелец";
                devicesDataView.Columns[4].HeaderCell.Value = "Номер телефона";
                devicesDataView.Columns[5].HeaderCell.Value = "Сумма";
                devicesDataView.Columns[6].HeaderCell.Value = "Оплачено";
                devicesDataView.Columns[7].HeaderCell.Value = "Неисправность";
                devicesDataView.Columns[8].HeaderCell.Value = "Выдано";
                devicesDataView.Columns[9].HeaderCell.Value = "Дата выдачи";
            }
        }
        //создание вида заданий
        private void createTasksView()
        {
            if (data.Tables["tasks"].Rows.Count != 0)
            {
                tasksDataView.DataSource = new BindingSource(data.Tables["tasks"], "");
                tasksDataView.AutoGenerateColumns = true;
                tasksDataView.Columns[0].HeaderCell.Value = "Номер";
                tasksDataView.Columns[0].Visible = false;
                tasksDataView.Columns[1].HeaderCell.Value = "Дело";
                tasksDataView.Columns[2].HeaderCell.Value = "Приоритет";
                tasksDataView.Columns[2].Visible = false;
                tasksDataView.Columns[3].HeaderCell.Value = "Выполнено";
                tasksDataView.Columns[4].HeaderCell.Value = "От";
                tasksDataView.Columns[5].HeaderCell.Value = "Выполнить до";
                tasksDataView.Columns[6].HeaderCell.Value = "Комментарий";
                tasksDataView.Columns[6].Visible = false;
                BindingSource bs = tasksDataView.DataSource as BindingSource;
                bs.Sort = "priory asc";
            }
        }

        private void createOrdersView()
        {
            if (data.Tables["orders"].Rows.Count != 0)
            {
                showingTableOrders.Clear();

                DataTable orders = data.Tables["orders"];
                DataTable clients = data.Tables["clients"];
                if (orders.Rows.Count != 0)
                {
                    //LINQ к таблицам чтобы выбрать всё и не заморачиваться со связями
                    var query = from order in orders.AsEnumerable()
                                from client in clients.AsEnumerable()
                                where Convert.ToInt16(order["client"]) == Convert.ToInt16(client["id"])
                                select (new
                                {
                                    id = order["id"],
                                    date = order["date"],
                                    order = order["order"],
                                    client = client["name"],
                                    tel = client["tel"],
                                    count = order["count"],
                                    complete = order["complete"],
                                    comment = order["comment"],
                                 });
                    //перегружаем строки в таблицу (по возможности придумать более быстрое решение чем цикл)
                    foreach (var row in query)
                    {
                        showingTableOrders.Rows.Add(row.id, row.order, row.count, row.client, row.tel, row.complete, row.date, row.comment);
                    }

                    BindingSource currSource = new BindingSource(showingTableOrders, "");
                    ordersDataView.DataSource = currSource;

                    //читабельный вид
                    ordersDataView.AutoGenerateColumns = true;
                    ordersDataView.Columns[0].HeaderCell.Value = "Номер";
                    ordersDataView.Columns[0].Visible = false;
                    ordersDataView.Columns[1].HeaderCell.Value = "Заказ";
                    ordersDataView.Columns[2].HeaderCell.Value = "Кол-во";
                    ordersDataView.Columns[3].HeaderCell.Value = "Заказчик";
                    ordersDataView.Columns[4].HeaderCell.Value = "Телефон";
                    ordersDataView.Columns[5].HeaderCell.Value = "Выполнен";
                    ordersDataView.Columns[6].HeaderCell.Value = "Комментарий";
                    ordersDataView.Columns[7].HeaderCell.Value = "Дата";
                    ordersDataView.Columns[7].Visible = false;
                }
            }
        }
    }
}
