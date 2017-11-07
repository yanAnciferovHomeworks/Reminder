namespace Reminder
{
    partial class RemindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.EventBox = new System.Windows.Forms.GroupBox();
            this.NameEvent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DateEvent = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Events = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            this.EventBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(13, 47);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // EventBox
            // 
            this.EventBox.Controls.Add(this.button2);
            this.EventBox.Controls.Add(this.button1);
            this.EventBox.Controls.Add(this.checkBox1);
            this.EventBox.Controls.Add(this.label3);
            this.EventBox.Controls.Add(this.comboBox1);
            this.EventBox.Controls.Add(this.label2);
            this.EventBox.Controls.Add(this.DateEvent);
            this.EventBox.Controls.Add(this.label1);
            this.EventBox.Controls.Add(this.NameEvent);
            this.EventBox.Location = new System.Drawing.Point(13, 221);
            this.EventBox.Name = "EventBox";
            this.EventBox.Size = new System.Drawing.Size(343, 162);
            this.EventBox.TabIndex = 1;
            this.EventBox.TabStop = false;
            this.EventBox.Text = "Событие";
            // 
            // NameEvent
            // 
            this.NameEvent.Location = new System.Drawing.Point(72, 19);
            this.NameEvent.Name = "NameEvent";
            this.NameEvent.Size = new System.Drawing.Size(265, 20);
            this.NameEvent.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // DateEvent
            // 
            this.DateEvent.AllowDrop = true;
            this.DateEvent.Cursor = System.Windows.Forms.Cursors.Default;
            this.DateEvent.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DateEvent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DateEvent.Location = new System.Drawing.Point(72, 57);
            this.DateEvent.Name = "DateEvent";
            this.DateEvent.ShowUpDown = true;
            this.DateEvent.Size = new System.Drawing.Size(265, 20);
            this.DateEvent.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(265, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Повторять";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 138);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Напоминать";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(225, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Events
            // 
            this.Events.FormattingEnabled = true;
            this.Events.Location = new System.Drawing.Point(189, 49);
            this.Events.Name = "Events";
            this.Events.Size = new System.Drawing.Size(167, 160);
            this.Events.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DelButton);
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 29);
            this.panel1.TabIndex = 3;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(5, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(84, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(100, 23);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Редактировать";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // DelButton
            // 
            this.DelButton.Location = new System.Drawing.Point(190, 3);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(100, 23);
            this.DelButton.TabIndex = 2;
            this.DelButton.Text = "Удалить";
            this.DelButton.UseVisualStyleBackColor = true;
            // 
            // RemindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 222);
            this.Controls.Add(this.Events);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.EventBox);
            this.Name = "RemindForm";
            this.Text = "Напоминальник";
            this.EventBox.ResumeLayout(false);
            this.EventBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox EventBox;
        private System.Windows.Forms.DateTimePicker DateEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameEvent;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Events;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
    }
}

