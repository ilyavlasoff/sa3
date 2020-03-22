namespace systemAnalyze3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.relationsMatrixView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.topsCount = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.levelUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.levelDisplayBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.relationsMatrixView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // relationsMatrixView
            // 
            this.relationsMatrixView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.relationsMatrixView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.relationsMatrixView.Location = new System.Drawing.Point(12, 12);
            this.relationsMatrixView.Name = "relationsMatrixView";
            this.relationsMatrixView.Size = new System.Drawing.Size(615, 475);
            this.relationsMatrixView.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Количество вершин";
            // 
            // topsCount
            // 
            this.topsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.topsCount.Location = new System.Drawing.Point(491, 496);
            this.topsCount.Name = "topsCount";
            this.topsCount.ReadOnly = true;
            this.topsCount.Size = new System.Drawing.Size(43, 20);
            this.topsCount.TabIndex = 13;
            this.topsCount.ValueChanged += new System.EventHandler(this.topsCount_ValueChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(540, 496);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click_1);
            // 
            // levelUpDown
            // 
            this.levelUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.levelUpDown.Location = new System.Drawing.Point(64, 538);
            this.levelUpDown.Name = "levelUpDown";
            this.levelUpDown.ReadOnly = true;
            this.levelUpDown.Size = new System.Drawing.Size(43, 20);
            this.levelUpDown.TabIndex = 15;
            this.levelUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 540);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "G (";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 540);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = ") =";
            // 
            // levelDisplayBox
            // 
            this.levelDisplayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.levelDisplayBox.Location = new System.Drawing.Point(138, 538);
            this.levelDisplayBox.Name = "levelDisplayBox";
            this.levelDisplayBox.Size = new System.Drawing.Size(489, 55);
            this.levelDisplayBox.TabIndex = 18;
            this.levelDisplayBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 627);
            this.Controls.Add(this.levelDisplayBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.levelUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.topsCount);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.relationsMatrixView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.relationsMatrixView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView relationsMatrixView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown topsCount;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown levelUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox levelDisplayBox;
    }
}

