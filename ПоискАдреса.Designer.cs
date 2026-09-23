
using GlacialComponents.Controls;

namespace Лоцман_добавка
{
    partial class ПоискАдреса
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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txFlat = new PresentationControls.CheckBoxComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.txHouse = new GlacialComponents.Controls.GLLookUpComboBox();
            this.glПоискУлица = new GlacialComponents.Controls.GLLookUpComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(484, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Поиск";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "Поиск по адресу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Улица";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "Дом";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Кв.";
            // 
            // txFlat
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txFlat.CheckBoxProperties = checkBoxProperties1;
            this.txFlat.DisplayMemberSingleItem = "";
            this.txFlat.FormattingEnabled = true;
            this.txFlat.Location = new System.Drawing.Point(59, 40);
            this.txFlat.Name = "txFlat";
            this.txFlat.Size = new System.Drawing.Size(404, 21);
            this.txFlat.TabIndex = 3;
            this.txFlat.Enter += new System.EventHandler(this.txFlat_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox12);
            this.groupBox1.Controls.Add(this.checkBox11);
            this.groupBox1.Controls.Add(this.checkBox9);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Location = new System.Drawing.Point(21, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 133);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сведения о принадлежности помещений в доме";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(162, 29);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 17);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Tag = "2";
            this.checkBox2.Text = "Тип договора";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(15, 29);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(62, 17);
            this.checkBox3.TabIndex = 18;
            this.checkBox3.Tag = "1";
            this.checkBox3.Text = "Ф.И.О.";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(309, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Tag = "3";
            this.checkBox1.Text = "Дата договора";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(162, 98);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(120, 17);
            this.checkBox12.TabIndex = 16;
            this.checkBox12.Tag = "9";
            this.checkBox12.Text = "Инвент.стоимость";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(15, 98);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(52, 17);
            this.checkBox11.TabIndex = 15;
            this.checkBox11.Tag = "8";
            this.checkBox11.Text = "Этаж";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(309, 61);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(171, 17);
            this.checkBox9.TabIndex = 13;
            this.checkBox9.Tag = "7";
            this.checkBox9.Text = "Приведенная площадь кв.м.";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(162, 61);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(141, 17);
            this.checkBox8.TabIndex = 12;
            this.checkBox8.Tag = "6";
            this.checkBox8.Text = "Жилая площадь, кв.м.";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(15, 61);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(141, 17);
            this.checkBox7.TabIndex = 11;
            this.checkBox7.Tag = "5";
            this.checkBox7.Text = "Общая площадь, кв.м.";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(447, 29);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(113, 17);
            this.checkBox6.TabIndex = 10;
            this.checkBox6.Tag = "4";
            this.checkBox6.Text = "Долевое участие";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // txHouse
            // 
            this.txHouse.AllowTypeAllSymbols = true;
            this.txHouse.DropDownHeight = 150;
            this.txHouse.IntegralHeight = false;
            this.txHouse.Item = null;
            this.txHouse.ListControl = null;
            this.txHouse.Location = new System.Drawing.Point(372, 15);
            this.txHouse.Name = "txHouse";
            this.txHouse.Size = new System.Drawing.Size(91, 21);
            this.txHouse.SubItem = null;
            this.txHouse.TabIndex = 2;
            this.txHouse.СохранениеЛиста = false;
            this.txHouse.Leave += new System.EventHandler(this.txHouse_Leave);
            // 
            // glПоискУлица
            // 
            this.glПоискУлица.AllowTypeAllSymbols = true;
            this.glПоискУлица.DropDownHeight = 150;
            this.glПоискУлица.IntegralHeight = false;
            this.glПоискУлица.Item = null;
            this.glПоискУлица.ListControl = null;
            this.glПоискУлица.Location = new System.Drawing.Point(161, 15);
            this.glПоискУлица.Name = "glПоискУлица";
            this.glПоискУлица.Size = new System.Drawing.Size(169, 21);
            this.glПоискУлица.Sorted = true;
            this.glПоискУлица.SubItem = null;
            this.glПоискУлица.TabIndex = 1;
            this.glПоискУлица.СохранениеЛиста = false;
            this.glПоискУлица.Enter += new System.EventHandler(this.glПоискУлица_Enter);
            this.glПоискУлица.Leave += new System.EventHandler(this.glПоискУлица_Leave);
            // 
            // ПоискАдреса
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txFlat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txHouse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.glПоискУлица);
            this.Name = "ПоискАдреса";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск по адресу";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLLookUpComboBox glПоискУлица;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private GLLookUpComboBox txHouse;
        private System.Windows.Forms.Label label5;
        private PresentationControls.CheckBoxComboBox txFlat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}