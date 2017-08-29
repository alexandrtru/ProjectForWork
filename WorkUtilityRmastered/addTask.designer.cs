namespace WorkUtiliteRmastered
{
    partial class addTask
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addTask));
            this.label1 = new System.Windows.Forms.Label();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.prioryComboBox = new System.Windows.Forms.ComboBox();
            this.completeToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comment = new System.Windows.Forms.TextBox();
            this.timeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Что делать?*";
            // 
            // taskTextBox
            // 
            this.taskTextBox.Location = new System.Drawing.Point(108, 3);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(298, 20);
            this.taskTextBox.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(237, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Приоритет*";
            // 
            // prioryComboBox
            // 
            this.prioryComboBox.FormattingEnabled = true;
            this.prioryComboBox.Items.AddRange(new object[] {
            "Срочное",
            "Не срочное",
            "Перманентное"});
            this.prioryComboBox.Location = new System.Drawing.Point(108, 42);
            this.prioryComboBox.Name = "prioryComboBox";
            this.prioryComboBox.Size = new System.Drawing.Size(171, 21);
            this.prioryComboBox.TabIndex = 2;
            this.prioryComboBox.SelectedIndexChanged += new System.EventHandler(this.prioryComboBox_SelectedIndexChanged);
            // 
            // completeToDatePicker
            // 
            this.completeToDatePicker.Location = new System.Drawing.Point(108, 79);
            this.completeToDatePicker.Name = "completeToDatePicker";
            this.completeToDatePicker.Size = new System.Drawing.Size(129, 20);
            this.completeToDatePicker.TabIndex = 3;
            this.completeToDatePicker.Value = new System.DateTime(2015, 8, 15, 11, 6, 3, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Выполнить до";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Время (час)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Комментарий";
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(108, 117);
            this.comment.Multiline = true;
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(247, 51);
            this.comment.TabIndex = 5;
            // 
            // timeMaskedTextBox
            // 
            this.timeMaskedTextBox.Location = new System.Drawing.Point(315, 82);
            this.timeMaskedTextBox.Mask = "00:00";
            this.timeMaskedTextBox.Name = "timeMaskedTextBox";
            this.timeMaskedTextBox.Size = new System.Drawing.Size(40, 20);
            this.timeMaskedTextBox.TabIndex = 4;
            this.timeMaskedTextBox.ValidatingType = typeof(System.DateTime);
            this.timeMaskedTextBox.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.timeMaskedTextBox_TypeValidationCompleted);
            this.timeMaskedTextBox.TextChanged += new System.EventHandler(this.timeMaskedTextBox_TextChanged);
            // 
            // addTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 233);
            this.Controls.Add(this.timeMaskedTextBox);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.completeToDatePicker);
            this.Controls.Add(this.prioryComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.taskTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addTask";
            this.Text = "Задание";
            this.Load += new System.EventHandler(this.addTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox prioryComboBox;
        private System.Windows.Forms.DateTimePicker completeToDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox comment;
        private System.Windows.Forms.MaskedTextBox timeMaskedTextBox;
    }
}