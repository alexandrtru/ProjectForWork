using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace WorkUtiliteRmastered
{
    partial class generalForm
    {
        public static SQLiteDataAdapter devicesDataAdapter;  //адаптер для таблицы оборудования
        public static SQLiteDataAdapter clientsDataAdapter; //адаптер для таблицы клиентов
        public static SQLiteDataAdapter tasksDataAdapter;//адаптер для заданий
        public static SQLiteDataAdapter ordersDataAdapter;//адаптер для заказов

        private void setAdapters()
        {
            devicesDataAdapter = new SQLiteDataAdapter("select * from devices", sqlConnect);
            //шаблон для вставки новой записи в источник в таблицу Devices
            devicesDataAdapter.InsertCommand = new SQLiteCommand("insert into devices values ( null, @Date, @Device, @OwnerCode, @Issue, @Price, @Paid, @Defect, @IssueDate)", sqlConnect);
            devicesDataAdapter.InsertCommand.Parameters.Add("@Date", DbType.String, 12, "date");
            devicesDataAdapter.InsertCommand.Parameters.Add("@Device", DbType.String, 100, "device");
            devicesDataAdapter.InsertCommand.Parameters.Add("@OwnerCode", DbType.Int16, 20, "owner");
            devicesDataAdapter.InsertCommand.Parameters.Add("@Issue", DbType.Boolean, 1, "issue");
            devicesDataAdapter.InsertCommand.Parameters.Add("@Price", DbType.Int16, 20, "price");
            devicesDataAdapter.InsertCommand.Parameters.Add("@Paid", DbType.Boolean, 1, "paid");
            devicesDataAdapter.InsertCommand.Parameters.Add("@Defect", DbType.AnsiString, 200, "defect");
            devicesDataAdapter.InsertCommand.Parameters.Add("@IssueDate", DbType.String, 12, "issue_date");

            //шаблон для обновления записей в таблице Devices
            devicesDataAdapter.UpdateCommand = new SQLiteCommand("update devices set date = @Date, device = @Device, owner = @OwnerCode, issue = @Issue, price = @Price, paid = @Paid, defect = @Defect, issue_date = @IssueDate where id = @Id", sqlConnect);
            devicesDataAdapter.UpdateCommand.Parameters.Add("@Date", DbType.String, 12, "date");
            devicesDataAdapter.UpdateCommand.Parameters.Add("@Device", DbType.String, 100, "device");
            devicesDataAdapter.UpdateCommand.Parameters.Add("@OwnerCode", DbType.Int16, 20, "owner");
            devicesDataAdapter.UpdateCommand.Parameters.Add("@Issue", DbType.Boolean, 1, "issue");
            devicesDataAdapter.UpdateCommand.Parameters.Add("@Price", DbType.Int16, 20, "price");
            devicesDataAdapter.UpdateCommand.Parameters.Add("@Paid", DbType.Boolean, 1, "paid");
            devicesDataAdapter.UpdateCommand.Parameters.Add("@Defect", DbType.AnsiString, 200, "defect");
            devicesDataAdapter.UpdateCommand.Parameters.Add("@IssueDate", DbType.String, 12, "issue_date");
            devicesDataAdapter.UpdateCommand.Parameters.Add("@Id", DbType.Int16, 12, "id");

            clientsDataAdapter = new SQLiteDataAdapter("Select * from clients", sqlConnect);
            //Шаблон для вставки в таблицу клиентов
            clientsDataAdapter.InsertCommand = new SQLiteCommand("insert into clients values (null, @Name, @Tel)", sqlConnect);
            clientsDataAdapter.InsertCommand.Parameters.Add("@Name", DbType.String, 100, "name");
            clientsDataAdapter.InsertCommand.Parameters.Add("@Tel", DbType.String, 100, "tel");
            //Шаблон для обновления записей в таблице клиентов
            clientsDataAdapter.UpdateCommand = new SQLiteCommand("update clients set name = @name, tel = @tel where id = @id", sqlConnect);
            clientsDataAdapter.UpdateCommand.Parameters.Add("@Name", DbType.String, 100, "name");
            clientsDataAdapter.UpdateCommand.Parameters.Add("@Tel", DbType.String, 100, "tel");
            clientsDataAdapter.UpdateCommand.Parameters.Add("@id", DbType.String, 100, "id");

            tasksDataAdapter = new SQLiteDataAdapter("Select * from tasks", sqlConnect);
            //шаблон для вставки
            tasksDataAdapter.InsertCommand = new SQLiteCommand("insert into tasks values (null, @task, @priory, @complete, @date, @complete_to, @comment)", sqlConnect);
            tasksDataAdapter.InsertCommand.Parameters.Add("@task", DbType.String, 100, "task");
            tasksDataAdapter.InsertCommand.Parameters.Add("@priory", DbType.Int16, 12, "priory");
            tasksDataAdapter.InsertCommand.Parameters.Add("@complete", DbType.Boolean, 1, "complete");
            tasksDataAdapter.InsertCommand.Parameters.Add("@date", DbType.String, 50, "date");
            tasksDataAdapter.InsertCommand.Parameters.Add("@complete_to", DbType.DateTime, 50, "complete_to");
            tasksDataAdapter.InsertCommand.Parameters.Add("@comment", DbType.AnsiString, 200, "comment");
            //шаблон для обновления источника
            tasksDataAdapter.UpdateCommand = new SQLiteCommand("update tasks set task = @task, priory = @priory, complete = @complete, date = @date, complete_to = @complete_to, comment = @comment where id = @id", sqlConnect);
            tasksDataAdapter.UpdateCommand.Parameters.Add("@id", DbType.Int16, 12, "id");
            tasksDataAdapter.UpdateCommand.Parameters.Add("@task", DbType.String, 100, "task");
            tasksDataAdapter.UpdateCommand.Parameters.Add("@priory", DbType.Int16, 12, "priory");
            tasksDataAdapter.UpdateCommand.Parameters.Add("@complete", DbType.Boolean, 1, "complete");
            tasksDataAdapter.UpdateCommand.Parameters.Add("@date", DbType.String, 50, "date");
            tasksDataAdapter.UpdateCommand.Parameters.Add("@complete_to", DbType.DateTime, 50, "complete_to");
            tasksDataAdapter.UpdateCommand.Parameters.Add("@comment", DbType.AnsiString, 200, "comment");

            ordersDataAdapter = new SQLiteDataAdapter("select * from orders", sqlConnect);
            //шаблон для вставки
            ordersDataAdapter.InsertCommand = new SQLiteCommand("insert into orders values (null, @order, @count, @client, @complete, @date, @comment)", sqlConnect);
            ordersDataAdapter.InsertCommand.Parameters.Add("@order", DbType.String, 100, "order");
            ordersDataAdapter.InsertCommand.Parameters.Add("@client", DbType.Int16, 12, "client");
            ordersDataAdapter.InsertCommand.Parameters.Add("@count", DbType.Int16, 12, "count");
            ordersDataAdapter.InsertCommand.Parameters.Add("@complete", DbType.Boolean, 1, "complete");
            ordersDataAdapter.InsertCommand.Parameters.Add("@date", DbType.String, 50, "date");
            ordersDataAdapter.InsertCommand.Parameters.Add("@comment", DbType.AnsiString, 200, "comment");
            //шаблон для обновления источника
            ordersDataAdapter.UpdateCommand = new SQLiteCommand("update orders set 'order' = @order, count = @count, client = @client, complete = @complete, date = @date, comment = @comment where id = @id", sqlConnect);
            ordersDataAdapter.UpdateCommand.Parameters.Add("@id", DbType.Int16, 12, "id");
            ordersDataAdapter.UpdateCommand.Parameters.Add("@order", DbType.String, 100, "order");
            ordersDataAdapter.UpdateCommand.Parameters.Add("@count", DbType.Int16, 12, "count");
            ordersDataAdapter.UpdateCommand.Parameters.Add("@client", DbType.Int16, 12, "client");
            ordersDataAdapter.UpdateCommand.Parameters.Add("@complete", DbType.Boolean, 1, "complete");
            ordersDataAdapter.UpdateCommand.Parameters.Add("@date", DbType.String, 50, "date");
            ordersDataAdapter.UpdateCommand.Parameters.Add("@comment", DbType.AnsiString, 200, "comment");
        }
    }
}
