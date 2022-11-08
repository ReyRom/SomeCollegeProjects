
namespace FileSort
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.includeCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // folderTextBox
            // 
            this.folderTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.folderTextBox.Location = new System.Drawing.Point(28, 28);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(628, 33);
            this.folderTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchButton.Location = new System.Drawing.Point(672, 28);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(106, 33);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Обзор...";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // sortButton
            // 
            this.sortButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sortButton.Location = new System.Drawing.Point(613, 83);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(165, 49);
            this.sortButton.TabIndex = 2;
            this.sortButton.Text = "Сортировать";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.modeComboBox.Items.AddRange(new object[] {
            "по дате",
            "по учебному году",
            "по расширению",
            "по типу файла",
            "по размеру"});
            this.modeComboBox.Location = new System.Drawing.Point(245, 71);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(320, 33);
            this.modeComboBox.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 157);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(807, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(79, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Тип сортировки";
            // 
            // includeCheckBox
            // 
            this.includeCheckBox.AutoSize = true;
            this.includeCheckBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.includeCheckBox.Location = new System.Drawing.Point(95, 114);
            this.includeCheckBox.Name = "includeCheckBox";
            this.includeCheckBox.Size = new System.Drawing.Size(422, 29);
            this.includeCheckBox.TabIndex = 6;
            this.includeCheckBox.Text = "сортировать файлы во вложенных каталогах";
            this.includeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(28, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Каталог для сортировки";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 179);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.includeCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.modeComboBox);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.folderTextBox);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Sorting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox includeCheckBox;
        private System.Windows.Forms.Label label2;
    }
}

