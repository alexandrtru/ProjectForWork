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
    public partial class addTask : Form
    {
        DataRow workingRow;//строка с которой работаем в этой форме
        bool edit;// редактируем ли запись?

        public addTask(DataRow inRow)
        {
            if (inRow != null)//если на вход полчаем строку таблицы... 
            {
                workingRow = inRow;//устанавливаем её как рабочую
                edit = true;//указывавем что редактируем запись
            }
            else//.. если на вход ничего не получено
            {
                workingRow = generalForm.data.Tables["tasks"].NewRow();//инициализируем новую строку таблицы тасков
                edit = false;//указываем что не редактируем
            }
            InitializeComponent();
        }

        //по отрисовке фотмы
        private void addTask_Load(object sender, EventArgs e)
        {
            prioryComboBox.SelectedIndex = 2;//по умолчанию отображаем все записи таблицы
            completeToDatePicker.Value = System.DateTime.Now;
            if (edit) fillFields(); // но если редактируем то заполняем поля
        }
        //по кнопке ОК
        private void button1_Click(object sender, EventArgs e)
        {
            //КОСТЫЛИ! УБРАТЬ В ДАЛЬНЕЙШЕМ
            if (taskTextBox.Text.Trim() != "" && prioryComboBox.SelectedIndex != 2 && timeMaskedTextBox.MaskFull)// проверяем поле заданния на пустоту
            {
               //заполняем поля рабочей строки данными из формы
               workingRow["task"] = taskTextBox.Text;
               workingRow["priory"] = prioryComboBox.SelectedIndex;
               workingRow["complete"] = false;
               workingRow["comment"] = comment.Text;
               workingRow["complete_to"] = new DateTime(completeToDatePicker.Value.Year, completeToDatePicker.Value.Month, completeToDatePicker.Value.Day, int.Parse(timeMaskedTextBox.Text.Substring(0, 2)), int.Parse(timeMaskedTextBox.Text.Substring(3, 2)), 0);
               if (!edit)//если мы создавали новую строку то вставляем её в таблицу
                    {
                        workingRow["date"] = System.DateTime.Now.ToShortDateString();
                        generalForm.data.Tables["tasks"].Rows.Add(workingRow);
                    }
               this.DialogResult = DialogResult.OK;
            }
            else if (taskTextBox.Text.Trim() != "" && prioryComboBox.SelectedIndex == 2){
               //заполняем поля рабочей строки данными из формы
               workingRow["task"] = taskTextBox.Text;
               workingRow["priory"] = prioryComboBox.SelectedIndex;
               workingRow["complete"] = false;
               workingRow["comment"] = comment.Text;
               if (!edit)//если мы создавали новую строку то вставляем её в таблицу
                    {
                        workingRow["date"] = System.DateTime.Now.ToShortDateString();
                        generalForm.data.Tables["tasks"].Rows.Add(workingRow);
                    }
               this.DialogResult = DialogResult.OK; 
            } else {
              MessageBox.Show("Не все поля заполенены. \nНужные поля отмечены знаком '*'");
            }
        }
        //при смене приоритета
        private void prioryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //в зависимости от приритета дело открываем/закрываем контролы
            if (prioryComboBox.SelectedIndex != 2)
            {
                completeToDatePicker.Enabled = true;
                timeMaskedTextBox.Enabled = true;
            }
            else {
                completeToDatePicker.Enabled = false;
                timeMaskedTextBox.Enabled = false;
            }
        }
        //заполнение полей формы
        private void fillFields() {
            taskTextBox.Text = workingRow["task"].ToString();
            prioryComboBox.SelectedIndex = int.Parse(workingRow["priory"].ToString());
            System.Console.WriteLine(int.Parse(workingRow["priory"].ToString()));
            //пытаемся установить дату в кОнтроле
            try
            {
                completeToDatePicker.Value = DateTime.Parse(workingRow["complete_to"].ToString());
                timeMaskedTextBox.Text = (workingRow["complete_to"].ToString()).Substring(11,5);
            }
            catch { }
            comment.Text = workingRow["comment"].ToString();
        }

        private void timeMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            timeMaskedTextBox.ValidateText();
        }

        private void timeMaskedTextBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (timeMaskedTextBox.MaskFull)
            {
                if (!e.IsValidInput)
                {
                    if (int.Parse(timeMaskedTextBox.Text.Substring(0, 2)) > 23)
                    {
                        timeMaskedTextBox.Text = timeMaskedTextBox.Text.Replace(timeMaskedTextBox.Text.Substring(0, 2), "23");
                    }
                    if (int.Parse(timeMaskedTextBox.Text.Substring(3, 2)) > 59)
                    {
                        timeMaskedTextBox.Text = timeMaskedTextBox.Text.Replace(timeMaskedTextBox.Text.Substring(3, 2), "59");
                    }
                }
            }
        }
    }
}
