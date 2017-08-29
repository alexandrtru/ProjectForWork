using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace WorkUtiliteRmastered
{
    static class clientSearcher
    {
        static public int searchClient(TextBox cName, TextBox cTel, DataTable cTable)
        {
            try
            {
                string notSelectedText = cName.Text.Substring(cName.SelectionStart);
                int possibleId = int.Parse(cTable.Select("name like '" + notSelectedText + "*'")[0]["id"].ToString());
                try
                {
                    Console.WriteLine(cTable.Select("id = '" + possibleId + "'")[0]["tel"]); 
                    cTel.SelectAll();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    cTel.Text = "";
                }
                return possibleId;
            }
            catch {
                return 0;
            }
        }
    }
}
