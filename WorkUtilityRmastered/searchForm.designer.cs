namespace WorkUtiliteRmastered
{
    partial class searchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchForm));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.issueRadioButton = new System.Windows.Forms.RadioButton();
            this.issueTrueRadioButton = new System.Windows.Forms.RadioButton();
            this.issueFalseRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.issueDateRadio = new System.Windows.Forms.RadioButton();
            this.dateRadio = new System.Windows.Forms.RadioButton();
            this.deviceRadio = new System.Windows.Forms.RadioButton();
            this.ownerNameRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(167, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.issueRadioButton);
            this.groupBox1.Controls.Add(this.issueTrueRadioButton);
            this.groupBox1.Controls.Add(this.issueFalseRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 37);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Где искать";
            // 
            // issueRadioButton
            // 
            this.issueRadioButton.AutoSize = true;
            this.issueRadioButton.Checked = true;
            this.issueRadioButton.Location = new System.Drawing.Point(266, 12);
            this.issueRadioButton.Name = "issueRadioButton";
            this.issueRadioButton.Size = new System.Drawing.Size(44, 17);
            this.issueRadioButton.TabIndex = 2;
            this.issueRadioButton.TabStop = true;
            this.issueRadioButton.Text = "Все";
            this.issueRadioButton.UseVisualStyleBackColor = true;
            this.issueRadioButton.CheckedChanged += new System.EventHandler(this.issueRadioButton_CheckedChanged);
            // 
            // issueTrueRadioButton
            // 
            this.issueTrueRadioButton.AutoSize = true;
            this.issueTrueRadioButton.Location = new System.Drawing.Point(167, 12);
            this.issueTrueRadioButton.Name = "issueTrueRadioButton";
            this.issueTrueRadioButton.Size = new System.Drawing.Size(78, 17);
            this.issueTrueRadioButton.TabIndex = 1;
            this.issueTrueRadioButton.Text = "Выданные";
            this.issueTrueRadioButton.UseVisualStyleBackColor = true;
            this.issueTrueRadioButton.CheckedChanged += new System.EventHandler(this.issueTrueRadioButton_CheckedChanged);
            // 
            // issueFalseRadioButton
            // 
            this.issueFalseRadioButton.AutoSize = true;
            this.issueFalseRadioButton.Location = new System.Drawing.Point(77, 11);
            this.issueFalseRadioButton.Name = "issueFalseRadioButton";
            this.issueFalseRadioButton.Size = new System.Drawing.Size(78, 17);
            this.issueFalseRadioButton.TabIndex = 0;
            this.issueFalseRadioButton.Text = "В ремонте";
            this.issueFalseRadioButton.UseVisualStyleBackColor = true;
            this.issueFalseRadioButton.CheckedChanged += new System.EventHandler(this.issueFalseRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.issueDateRadio);
            this.groupBox2.Controls.Add(this.dateRadio);
            this.groupBox2.Controls.Add(this.deviceRadio);
            this.groupBox2.Controls.Add(this.ownerNameRadio);
            this.groupBox2.Location = new System.Drawing.Point(13, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 46);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Что искать";
            // 
            // issueDateRadio
            // 
            this.issueDateRadio.AutoSize = true;
            this.issueDateRadio.Location = new System.Drawing.Point(282, 20);
            this.issueDateRadio.Name = "issueDateRadio";
            this.issueDateRadio.Size = new System.Drawing.Size(91, 17);
            this.issueDateRadio.TabIndex = 3;
            this.issueDateRadio.Text = "Дата выдачи";
            this.issueDateRadio.UseVisualStyleBackColor = true;
            this.issueDateRadio.CheckedChanged += new System.EventHandler(this.issueDateRadio_CheckedChanged);
            // 
            // dateRadio
            // 
            this.dateRadio.AutoSize = true;
            this.dateRadio.Location = new System.Drawing.Point(184, 20);
            this.dateRadio.Name = "dateRadio";
            this.dateRadio.Size = new System.Drawing.Size(92, 17);
            this.dateRadio.TabIndex = 2;
            this.dateRadio.Text = "Дата приёма";
            this.dateRadio.UseVisualStyleBackColor = true;
            this.dateRadio.CheckedChanged += new System.EventHandler(this.dateRadio_CheckedChanged);
            // 
            // deviceRadio
            // 
            this.deviceRadio.AutoSize = true;
            this.deviceRadio.Checked = true;
            this.deviceRadio.Location = new System.Drawing.Point(88, 20);
            this.deviceRadio.Name = "deviceRadio";
            this.deviceRadio.Size = new System.Drawing.Size(98, 17);
            this.deviceRadio.TabIndex = 1;
            this.deviceRadio.TabStop = true;
            this.deviceRadio.Text = "Оборудование";
            this.deviceRadio.UseVisualStyleBackColor = true;
            this.deviceRadio.CheckedChanged += new System.EventHandler(this.deviceRadio_CheckedChanged);
            // 
            // ownerNameRadio
            // 
            this.ownerNameRadio.AutoSize = true;
            this.ownerNameRadio.Location = new System.Drawing.Point(7, 20);
            this.ownerNameRadio.Name = "ownerNameRadio";
            this.ownerNameRadio.Size = new System.Drawing.Size(74, 17);
            this.ownerNameRadio.TabIndex = 0;
            this.ownerNameRadio.Text = "Владелец";
            this.ownerNameRadio.UseVisualStyleBackColor = true;
            this.ownerNameRadio.CheckedChanged += new System.EventHandler(this.ownerNameRadio_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Значение";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(74, 99);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(319, 20);
            this.keyTextBox.TabIndex = 4;
            this.keyTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // searchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 161);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "searchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.search_FormClosing);
            this.Load += new System.EventHandler(this.search_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.RadioButton issueRadioButton;
        private System.Windows.Forms.RadioButton issueTrueRadioButton;
        private System.Windows.Forms.RadioButton issueFalseRadioButton;
        private System.Windows.Forms.RadioButton issueDateRadio;
        private System.Windows.Forms.RadioButton dateRadio;
        private System.Windows.Forms.RadioButton deviceRadio;
        private System.Windows.Forms.RadioButton ownerNameRadio;
    }
}