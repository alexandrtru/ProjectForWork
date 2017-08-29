using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace WorkUtiliteRmastered
{
    partial class generalForm
    {     
        //лютый адовый пиздец
        private void printDevice_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataRow device = data.Tables["devices"].Select("id = " +  devicesDataView.SelectedRows[0].Cells[0].Value.ToString())[0];
            DataRow owner = data.Tables["clients"].Select("id = " + device["owner"].ToString())[0];

            Pen line = new Pen(Brushes.Black, 1);
            Pen lineDotted = new Pen(Brushes.Black, 2);
            lineDotted.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            System.Drawing.Font genFont = new System.Drawing.Font("Times new Roman", 11);
            System.Drawing.Font genFontBold = new System.Drawing.Font("Times new Roman", 11, FontStyle.Bold);
            System.Drawing.Font genFontIta = new System.Drawing.Font("Times new Roman", 11, FontStyle.Italic);

            e.Graphics.DrawLine(lineDotted, 2, 270, 825, 270);
            e.Graphics.DrawLine(lineDotted, 400, 2, 400, 270);
            drawSide(e, device, owner, line, lineDotted, genFont, genFontBold, genFontIta, 5, false);
            drawSide(e, device, owner, line, lineDotted, genFont, genFontBold, genFontIta, 405, true);
        }
        //Рисование таблицы
        private void drawSide(System.Drawing.Printing.PrintPageEventArgs e, DataRow device, DataRow owner, Pen line, Pen lineDotted, System.Drawing.Font genFont, System.Drawing.Font genFontBold, System.Drawing.Font genFontIta, float x, bool clside)
        {
            Graphics g = e.Graphics;
            //рамки

            g.DrawRectangle(line, x + 5, 170, 370, 55);
            //g.DrawRectangle(line, 420, 170, 390, 55);
            //текст левый
            g.DrawString(Properties.Settings.Default.companyName, genFontBold, Brushes.Black, x + 140, 5);
            g.DrawLine(line, x, 23, x + 385, 23);
            g.DrawString("Дата:", genFont, Brushes.Black, x + 5, 25);
            g.DrawString(device["date"].ToString(), genFontBold, Brushes.Black, x + 65, 25);
            g.DrawString("Номер:", genFont, Brushes.Black, x + 145, 25);
            g.DrawString(device["id"].ToString(), genFontBold, Brushes.Black, x + 195, 25);
            g.DrawLine(line, x, 45, x + 385, 45);
            g.DrawString("Оборудование:", genFont, Brushes.Black, x + 5, 45);
            g.DrawString(device["device"].ToString(), genFontBold, Brushes.Black, x + 145, 45);
            g.DrawLine(line, x, 65, x + 385, 65);
            g.DrawLine(line, x + 140, 45, x + 140, 145);//vertical line
            g.DrawString("Владелец:", genFont, Brushes.Black, x + 5, 65);
            g.DrawString(owner["name"].ToString(), genFontBold, Brushes.Black, x + 145, 65);
            g.DrawLine(line, x, 85, x + 385, 85);
            g.DrawString("Телефон:", genFont, Brushes.Black, x + 5, 85);
            g.DrawString(owner["tel"].ToString(), genFontBold, Brushes.Black, x + 145, 85);
            g.DrawLine(line, x, 105, x + 385, 105);
            g.DrawString("Стоимость ремонта:", genFont, Brushes.Black, x + 5, 105);
            g.DrawString(device["price"].ToString(), genFontBold, Brushes.Black, x + 145, 105);
            g.DrawLine(line, x, 125, x + 385, 125);
            g.DrawString("Оплачен:", genFont, Brushes.Black, x + 5, 125);
            if (bool.Parse(device["paid"].ToString()))
            {
                g.DrawString("Да".ToString(), genFontBold, Brushes.Black, x + 145, 125);
            }
            else
            {
                g.DrawString("Нет".ToString(), genFontBold, Brushes.Black, x + 145, 125);
            }
            g.DrawLine(line, x, 145, x + 385, 145);
            g.DrawString("Неисправность (со слов клиента):", genFont, Brushes.Black, x + 5, 145);
            g.DrawString(device["defect"].ToString(), genFontBold, Brushes.Black, x + 5, 170);
            if (clside)
                g.DrawString("Ремонт производится по заявленной неисправности. \nЗаправка картриджей производится без гарантии.", genFontIta, Brushes.Black, x + 5, 230);
        }
    }
}
