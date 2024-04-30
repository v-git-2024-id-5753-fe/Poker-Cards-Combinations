namespace WindowsFormsApp_poker_permutations
{
    partial class Form1
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
			this.button_test_any = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button_test_any
			// 
			this.button_test_any.Location = new System.Drawing.Point(107, 44);
			this.button_test_any.Name = "button_test_any";
			this.button_test_any.Size = new System.Drawing.Size(143, 49);
			this.button_test_any.TabIndex = 0;
			this.button_test_any.Text = "New Table";
			this.button_test_any.UseVisualStyleBackColor = true;
			this.button_test_any.Click += new System.EventHandler(this.button_test_any_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 154);
			this.Controls.Add(this.button_test_any);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_test_any;
    }
}

