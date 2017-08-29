namespace WorkUtiliteRmastered
{
    partial class orderForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(orderForm));
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.completeCheckBox = new System.Windows.Forms.CheckBox();
            this.orderTextBox = new System.Windows.Forms.TextBox();
            this.clientTextBox = new System.Windows.Forms.TextBox();
            this.clientTelTextBox = new System.Windows.Forms.TextBox();
            this.orderCount = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 55);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 13);
            label1.TabIndex = 2;
            label1.Text = "Фамилия*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(40, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 13);
            label2.TabIndex = 3;
            label2.Text = "Заказ*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(26, 79);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 13);
            label3.TabIndex = 4;
            label3.Text = "Телефон";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 13);
            label4.TabIndex = 5;
            label4.Text = "Количество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(116, 104);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(58, 13);
            label5.TabIndex = 6;
            label5.Text = "Выполнен";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(49, 195);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(81, 23);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(193, 196);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(81, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // commentTextBox
            // 
            this.commentTextBox.Location = new System.Drawing.Point(12, 124);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(298, 65);
            this.commentTextBox.TabIndex = 6;
            // 
            // completeCheckBox
            // 
            this.completeCheckBox.AutoSize = true;
            this.completeCheckBox.Location = new System.Drawing.Point(180, 104);
            this.completeCheckBox.Name = "completeCheckBox";
            this.completeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.completeCheckBox.TabIndex = 5;
            this.completeCheckBox.UseVisualStyleBackColor = true;
            // 
            // orderTextBox
            // 
            this.orderTextBox.Location = new System.Drawing.Point(84, 6);
            this.orderTextBox.Name = "orderTextBox";
            this.orderTextBox.Size = new System.Drawing.Size(222, 20);
            this.orderTextBox.TabIndex = 1;
            // 
            // clientTextBox
            // 
            this.clientTextBox.Location = new System.Drawing.Point(84, 52);
            this.clientTextBox.Name = "clientTextBox";
            this.clientTextBox.Size = new System.Drawing.Size(222, 20);
            this.clientTextBox.TabIndex = 3;
            this.clientTextBox.TextChanged += new System.EventHandler(this.clientTextBox_TextChanged);
            this.clientTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clientTextBox_KeyDown);
            // 
            // clientTelTextBox
            // 
            this.clientTelTextBox.Location = new System.Drawing.Point(84, 76);
            this.clientTelTextBox.Name = "clientTelTextBox";
            this.clientTelTextBox.Size = new System.Drawing.Size(222, 20);
            this.clientTelTextBox.TabIndex = 4;
            // 
            // orderCount
            // 
            this.orderCount.Location = new System.Drawing.Point(84, 30);
            this.orderCount.Name = "orderCount";
            this.orderCount.Size = new System.Drawing.Size(222, 20);
            this.orderCount.TabIndex = 2;
            this.orderCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // orderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 230);
            this.Controls.Add(this.orderCount);
            this.Controls.Add(this.clientTelTextBox);
            this.Controls.Add(this.clientTextBox);
            this.Controls.Add(this.orderTextBox);
            this.Controls.Add(this.completeCheckBox);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "orderForm";
            this.Text = "Заказ";
            ((System.ComponentModel.ISupportInitialize)(this.orderCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.CheckBox completeCheckBox;
        private System.Windows.Forms.TextBox orderTextBox;
        private System.Windows.Forms.TextBox clientTextBox;
        private System.Windows.Forms.TextBox clientTelTextBox;
        private System.Windows.Forms.NumericUpDown orderCount;
    }
}