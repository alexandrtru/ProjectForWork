using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace WorkUtiliteRmastered
{
    class clientFinder
    {
        private DataTable clients = generalForm.data.Tables["clients"];
        public int possibleClientId = 0;

        public void getCondidatId(string input)
        {
            if (input != "")
            {
                try
                { 
                    possibleClientId = int.Parse(clients.Select("name like '" + input + "*'")[0]["id"].ToString());
                }
                catch
                {
                    possibleClientId = 0;
                }
                //System.Console.WriteLine("possible client ID :" + possibleClientId);
            }
            else {
                possibleClientId = 0;
            }
        }
        public string getCondidatName()
        {
            try
            {
                //System.Console.WriteLine("get client name by id :" + possibleClientId);
                return clients.Select("id = '" + possibleClientId.ToString()+ "'")[0]["name"].ToString();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return "";
            }
        }
        public string getPhone()
        {
            try
            {
                return generalForm.data.Tables["clients"].Select("id = '" + possibleClientId + "'")[0]["tel"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public bool equalClient(string input)
        {
            try
            {
                if (clients.Select("name = '" + input + "'").Length != 0)
                {
                    MessageBox.Show("Клиент " + input + " обнаружен");
                    return true;
                }
                else
                {
                    MessageBox.Show("Клиент " + input + " не обнаружен, ветка else");
                    return false;
                }
            }
            catch {
                MessageBox.Show("Клиент " + input + " не обнаружен, ветка catch");
                return false;
            }
        }
    }
}
