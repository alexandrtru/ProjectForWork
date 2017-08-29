using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace WorkUtiliteRmastered
{
    partial class generalForm
    {
        //получене данных из базы данных
        public static void getDataFromDatabase() // Заполняем data
        {
            try
            {
                devicesDataAdapter.Fill(data, "devices");//Заполняем таблицу устройств
                if (data.Tables["devices"].Rows.Count > 0) data.Tables["devices"].Columns[0].AutoIncrementSeed = (int.Parse(data.Tables["devices"].Rows[data.Tables["devices"].Rows.Count - 1]["id"].ToString())) + 1;
            }            
            catch (Exception ex)
            {
                System.Console.WriteLine("Ошибка заполнения таблицы устройств: \n" + ex);
                System.Console.WriteLine(ex);
            }

            try 
            {
                clientsDataAdapter.Fill(data, "clients");//заполняем таблицу клиентов
                if (data.Tables["clients"].Rows.Count > 0) data.Tables["clients"].Columns[0].AutoIncrementSeed = (int.Parse(data.Tables["clients"].Rows[data.Tables["clients"].Rows.Count - 1]["id"].ToString())) + 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("ошибка заполненеия таблицы клиентов: \n" + ex);
                System.Console.WriteLine(ex);
            }

            try 
            {
                tasksDataAdapter.Fill(data, "tasks");//заполняем таблицу дел
                if (data.Tables["tasks"].Rows.Count > 0) data.Tables["tasks"].Columns[0].AutoIncrementSeed = (int.Parse(data.Tables["tasks"].Rows[data.Tables["tasks"].Rows.Count - 1]["id"].ToString())) + 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("ошибка заполненеия таблицы заданий: \n" + ex);
                System.Console.WriteLine(ex);
            }

            try 
            {
                ordersDataAdapter.Fill(data, "orders");
                if (data.Tables["orders"].Rows.Count > 0) data.Tables["orders"].Columns[0].AutoIncrementSeed = (int.Parse(data.Tables["orders"].Rows[data.Tables["orders"].Rows.Count - 1]["id"].ToString())) + 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("ошибка заполнения таблицы заказов: \n" + ex);
                System.Console.WriteLine(ex);
            }

        }


    }
}
