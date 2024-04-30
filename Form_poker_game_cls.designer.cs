using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp_poker_permutations
{
    partial class Form_poker_game_cls
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
            this.button_dealer_cards = new System.Windows.Forms.Button();
            this.button_my_cards = new System.Windows.Forms.Button();
            this.checkBox_write_console = new System.Windows.Forms.CheckBox();
            this.checkBox_write_textbox = new System.Windows.Forms.CheckBox();
            this.button_player_1 = new System.Windows.Forms.Button();
            this.button_player_2 = new System.Windows.Forms.Button();
            this.button_player_3 = new System.Windows.Forms.Button();
            this.button_player_4 = new System.Windows.Forms.Button();
            this.button_player_5 = new System.Windows.Forms.Button();
            this.button_player_6 = new System.Windows.Forms.Button();
            this.button_pair_factorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_dealer_cards
            // 
            this.button_dealer_cards.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dealer_cards.Location = new System.Drawing.Point(310, 40);
            this.button_dealer_cards.Name = "button_dealer_cards";
            this.button_dealer_cards.Size = new System.Drawing.Size(160, 30);
            this.button_dealer_cards.TabIndex = 1;
            this.button_dealer_cards.Text = "Cards on table";
            this.button_dealer_cards.UseVisualStyleBackColor = true;
            this.button_dealer_cards.Click += new System.EventHandler(this.player_button_Click);
            // 
            // button_my_cards
            // 
            this.button_my_cards.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_my_cards.Location = new System.Drawing.Point(310, 75);
            this.button_my_cards.Name = "button_my_cards";
            this.button_my_cards.Size = new System.Drawing.Size(160, 30);
            this.button_my_cards.TabIndex = 2;
            this.button_my_cards.Text = "My cards";
            this.button_my_cards.UseVisualStyleBackColor = true;
            this.button_my_cards.Click += new System.EventHandler(this.player_button_Click);
            // 
            // checkBox_write_console
            // 
            this.checkBox_write_console.AutoSize = true;
            this.checkBox_write_console.Location = new System.Drawing.Point(310, 321);
            this.checkBox_write_console.Name = "checkBox_write_console";
            this.checkBox_write_console.Size = new System.Drawing.Size(64, 17);
            this.checkBox_write_console.TabIndex = 5;
            this.checkBox_write_console.Text = "Console";
            this.checkBox_write_console.UseVisualStyleBackColor = true;
            this.checkBox_write_console.CheckedChanged += new System.EventHandler(this.checkBox_write_console_CheckedChanged);
            // 
            // checkBox_write_textbox
            // 
            this.checkBox_write_textbox.AutoSize = true;
            this.checkBox_write_textbox.Location = new System.Drawing.Point(406, 321);
            this.checkBox_write_textbox.Name = "checkBox_write_textbox";
            this.checkBox_write_textbox.Size = new System.Drawing.Size(64, 17);
            this.checkBox_write_textbox.TabIndex = 6;
            this.checkBox_write_textbox.Text = "Textbox";
            this.checkBox_write_textbox.UseVisualStyleBackColor = true;
            this.checkBox_write_textbox.CheckedChanged += new System.EventHandler(this.checkBox_write_textbox_CheckedChanged);
            // 
            // button_player_1
            // 
            this.button_player_1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_player_1.Location = new System.Drawing.Point(310, 110);
            this.button_player_1.Name = "button_player_1";
            this.button_player_1.Size = new System.Drawing.Size(160, 30);
            this.button_player_1.TabIndex = 7;
            this.button_player_1.Text = "Player 1";
            this.button_player_1.UseVisualStyleBackColor = true;
            this.button_player_1.Click += new System.EventHandler(this.player_button_Click);
            // 
            // button_player_2
            // 
            this.button_player_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_player_2.Location = new System.Drawing.Point(310, 145);
            this.button_player_2.Name = "button_player_2";
            this.button_player_2.Size = new System.Drawing.Size(160, 30);
            this.button_player_2.TabIndex = 8;
            this.button_player_2.Text = "Player 2";
            this.button_player_2.UseVisualStyleBackColor = true;
            this.button_player_2.Click += new System.EventHandler(this.player_button_Click);
            // 
            // button_player_3
            // 
            this.button_player_3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_player_3.Location = new System.Drawing.Point(310, 180);
            this.button_player_3.Name = "button_player_3";
            this.button_player_3.Size = new System.Drawing.Size(160, 30);
            this.button_player_3.TabIndex = 9;
            this.button_player_3.Text = "Player 3";
            this.button_player_3.UseVisualStyleBackColor = true;
            this.button_player_3.Click += new System.EventHandler(this.player_button_Click);
            // 
            // button_player_4
            // 
            this.button_player_4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_player_4.Location = new System.Drawing.Point(310, 215);
            this.button_player_4.Name = "button_player_4";
            this.button_player_4.Size = new System.Drawing.Size(160, 30);
            this.button_player_4.TabIndex = 10;
            this.button_player_4.Text = "Player 4";
            this.button_player_4.UseVisualStyleBackColor = true;
            this.button_player_4.Click += new System.EventHandler(this.player_button_Click);
            // 
            // button_player_5
            // 
            this.button_player_5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_player_5.Location = new System.Drawing.Point(310, 250);
            this.button_player_5.Name = "button_player_5";
            this.button_player_5.Size = new System.Drawing.Size(160, 30);
            this.button_player_5.TabIndex = 11;
            this.button_player_5.Text = "Player 5";
            this.button_player_5.UseVisualStyleBackColor = true;
            this.button_player_5.Click += new System.EventHandler(this.player_button_Click);
            // 
            // button_player_6
            // 
            this.button_player_6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_player_6.Location = new System.Drawing.Point(310, 285);
            this.button_player_6.Name = "button_player_6";
            this.button_player_6.Size = new System.Drawing.Size(160, 30);
            this.button_player_6.TabIndex = 12;
            this.button_player_6.Text = "Player 6";
            this.button_player_6.UseVisualStyleBackColor = true;
            this.button_player_6.Click += new System.EventHandler(this.player_button_Click);
            // 
            // button_pair_factorial
            // 
            this.button_pair_factorial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pair_factorial.Location = new System.Drawing.Point(613, 134);
            this.button_pair_factorial.Name = "button_pair_factorial";
            this.button_pair_factorial.Size = new System.Drawing.Size(183, 30);
            this.button_pair_factorial.TabIndex = 17;
            this.button_pair_factorial.Text = "Combinations pair factorial";
            this.button_pair_factorial.UseVisualStyleBackColor = true;
            this.button_pair_factorial.Click += new System.EventHandler(this.button_pair_factorial_Click);
            // 
            // Form_poker_game_cls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 511);
            this.Controls.Add(this.button_pair_factorial);
            this.Controls.Add(this.button_player_6);
            this.Controls.Add(this.button_player_5);
            this.Controls.Add(this.button_player_4);
            this.Controls.Add(this.button_player_3);
            this.Controls.Add(this.button_player_2);
            this.Controls.Add(this.button_player_1);
            this.Controls.Add(this.checkBox_write_textbox);
            this.Controls.Add(this.checkBox_write_console);
            this.Controls.Add(this.button_my_cards);
            this.Controls.Add(this.button_dealer_cards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_poker_game_cls";
            this.Text = "Form_poker_game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Button button_dealer_cards;
        private Button button_my_cards;
        private CheckBox checkBox_write_console;
        private CheckBox checkBox_write_textbox;
        private Button button_player_1;
        private Button button_player_2;
        private Button button_player_3;
        private Button button_player_4;
        private Button button_player_5;
        private Button button_player_6;
        private Button button_pair_factorial;
    }
}