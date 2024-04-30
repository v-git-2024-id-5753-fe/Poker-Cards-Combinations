namespace WindowsFormsApp_poker_permutations
{
    partial class form_rich_textbox_cls
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
            this.RichTextBox_window = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RichTextBox_window
            // 
            this.RichTextBox_window.Location = new System.Drawing.Point(13, 13);
            this.RichTextBox_window.Name = "RichTextBox_window";
            this.RichTextBox_window.Size = new System.Drawing.Size(359, 325);
            this.RichTextBox_window.TabIndex = 0;
            this.RichTextBox_window.Text = "";
            // 
            // Form_rich_textbox_cls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 350);
            this.Controls.Add(this.RichTextBox_window);
            this.Name = "Form_rich_textbox_cls";
            this.Text = "Form_rich_textbox_cls";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox RichTextBox_window;
    }
}