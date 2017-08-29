namespace WorkUtiliteRmastered
{
    partial class settingsForm
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.setDbPathBtn = new System.Windows.Forms.Button();
            this.dbPathTxtBx = new System.Windows.Forms.TextBox();
            this.companyNameTxtBx = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.setDbPathBtn);
            groupBox1.Controls.Add(this.dbPathTxtBx);
            groupBox1.Controls.Add(this.companyNameTxtBx);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(1, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(350, 104);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Основные";
            // 
            // setDbPathBtn
            // 
            this.setDbPathBtn.Location = new System.Drawing.Point(318, 38);
            this.setDbPathBtn.Name = "setDbPathBtn";
            this.setDbPathBtn.Size = new System.Drawing.Size(24, 23);
            this.setDbPathBtn.TabIndex = 4;
            this.setDbPathBtn.Text = "...";
            this.setDbPathBtn.UseVisualStyleBackColor = true;
            this.setDbPathBtn.Click += new System.EventHandler(this.setDbPathBtn_Click);
            // 
            // dbPathTxtBx
            // 
            this.dbPathTxtBx.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WorkUtiliteRmastered.Properties.Settings.Default, "dbPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dbPathTxtBx.Enabled = false;
            this.dbPathTxtBx.Location = new System.Drawing.Point(137, 40);
            this.dbPathTxtBx.Name = "dbPathTxtBx";
            this.dbPathTxtBx.Size = new System.Drawing.Size(177, 20);
            this.dbPathTxtBx.TabIndex = 3;
            this.dbPathTxtBx.Text = global::WorkUtiliteRmastered.Properties.Settings.Default.dbPath;
            // 
            // companyNameTxtBx
            // 
            this.companyNameTxtBx.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WorkUtiliteRmastered.Properties.Settings.Default, "companyName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.companyNameTxtBx.Location = new System.Drawing.Point(137, 13);
            this.companyNameTxtBx.Name = "companyNameTxtBx";
            this.companyNameTxtBx.Size = new System.Drawing.Size(204, 20);
            this.companyNameTxtBx.TabIndex = 2;
            this.companyNameTxtBx.Text = global::WorkUtiliteRmastered.Properties.Settings.Default.companyName;
            this.companyNameTxtBx.TextChanged += new System.EventHandler(this.companyNameTxtBx_TextChanged);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(24, 43);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 13);
            label2.TabIndex = 1;
            label2.Text = "Путь к базе данных";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(125, 13);
            label1.TabIndex = 0;
            label1.Text = "Название организации";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(98, 422);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(189, 422);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Отменить";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 457);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки приложения";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button setDbPathBtn;
        private System.Windows.Forms.TextBox dbPathTxtBx;
        private System.Windows.Forms.TextBox companyNameTxtBx;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}