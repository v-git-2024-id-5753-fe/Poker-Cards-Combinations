using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp_poker_permutations
{
    partial class Form_poker_permutations_cls
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
            this.button_card_combinations = new System.Windows.Forms.Button();
            this.button_cards_highest_combination = new System.Windows.Forms.Button();
            this.checkBox_write_console = new System.Windows.Forms.CheckBox();
            this.checkBox_write_textbox = new System.Windows.Forms.CheckBox();
            this.button_combinations_1_card = new System.Windows.Forms.Button();
            this.button_combinations_2_card = new System.Windows.Forms.Button();
            this.button_combinations_3_card = new System.Windows.Forms.Button();
            this.button_combinations_4_card = new System.Windows.Forms.Button();
            this.button_combinations_5_card = new System.Windows.Forms.Button();
            this.button_combinations_6_card = new System.Windows.Forms.Button();
            this.comboBox_card_select = new System.Windows.Forms.ComboBox();
            this.button_combinations_7_card = new System.Windows.Forms.Button();
            this.button_combinations_1_to_7_cards = new System.Windows.Forms.Button();
            this.button_pair_factorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_dealer_cards
            // 
            this.button_dealer_cards.Enabled = false;
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
            // button_card_combinations
            // 
            this.button_card_combinations.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_card_combinations.Location = new System.Drawing.Point(310, 134);
            this.button_card_combinations.Name = "button_card_combinations";
            this.button_card_combinations.Size = new System.Drawing.Size(160, 30);
            this.button_card_combinations.TabIndex = 3;
            this.button_card_combinations.Text = "Cards Combinations";
            this.button_card_combinations.UseVisualStyleBackColor = true;
            this.button_card_combinations.Click += new System.EventHandler(this.button_cards_combinations_Click);
            // 
            // button_cards_highest_combination
            // 
            this.button_cards_highest_combination.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cards_highest_combination.Location = new System.Drawing.Point(310, 170);
            this.button_cards_highest_combination.Name = "button_cards_highest_combination";
            this.button_cards_highest_combination.Size = new System.Drawing.Size(160, 30);
            this.button_cards_highest_combination.TabIndex = 4;
            this.button_cards_highest_combination.Text = "Highest Combination";
            this.button_cards_highest_combination.UseVisualStyleBackColor = true;
            this.button_cards_highest_combination.Click += new System.EventHandler(this.button_cards_highest_combination_Click);
            // 
            // checkBox_write_console
            // 
            this.checkBox_write_console.AutoSize = true;
            this.checkBox_write_console.Location = new System.Drawing.Point(310, 111);
            this.checkBox_write_console.Name = "checkBox_write_console";
            this.checkBox_write_console.Size = new System.Drawing.Size(64, 17);
            this.checkBox_write_console.TabIndex = 5;
            this.checkBox_write_console.Text = "Console";
            this.checkBox_write_console.UseVisualStyleBackColor = true;
            // 
            // checkBox_write_textbox
            // 
            this.checkBox_write_textbox.AutoSize = true;
            this.checkBox_write_textbox.Location = new System.Drawing.Point(406, 111);
            this.checkBox_write_textbox.Name = "checkBox_write_textbox";
            this.checkBox_write_textbox.Size = new System.Drawing.Size(64, 17);
            this.checkBox_write_textbox.TabIndex = 6;
            this.checkBox_write_textbox.Text = "Textbox";
            this.checkBox_write_textbox.UseVisualStyleBackColor = true;
            this.checkBox_write_textbox.CheckedChanged += new System.EventHandler(this.checkBox_write_textbox_CheckedChanged);
            // 
            // button_combinations_1_card
            // 
            this.button_combinations_1_card.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_combinations_1_card.Location = new System.Drawing.Point(310, 233);
            this.button_combinations_1_card.Name = "button_combinations_1_card";
            this.button_combinations_1_card.Size = new System.Drawing.Size(160, 30);
            this.button_combinations_1_card.TabIndex = 7;
            this.button_combinations_1_card.Text = "Combinations 1 card";
            this.button_combinations_1_card.UseVisualStyleBackColor = true;
            this.button_combinations_1_card.Click += new System.EventHandler(this.button_combinations_1_card_Click);
            // 
            // button_combinations_2_card
            // 
            this.button_combinations_2_card.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_combinations_2_card.Location = new System.Drawing.Point(310, 269);
            this.button_combinations_2_card.Name = "button_combinations_2_card";
            this.button_combinations_2_card.Size = new System.Drawing.Size(160, 30);
            this.button_combinations_2_card.TabIndex = 8;
            this.button_combinations_2_card.Text = "Combinations 2 cards";
            this.button_combinations_2_card.UseVisualStyleBackColor = true;
            this.button_combinations_2_card.Click += new System.EventHandler(this.button_combinations_2_card_Click);
            // 
            // button_combinations_3_card
            // 
            this.button_combinations_3_card.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_combinations_3_card.Location = new System.Drawing.Point(310, 305);
            this.button_combinations_3_card.Name = "button_combinations_3_card";
            this.button_combinations_3_card.Size = new System.Drawing.Size(160, 30);
            this.button_combinations_3_card.TabIndex = 9;
            this.button_combinations_3_card.Text = "Combinations 3 cards";
            this.button_combinations_3_card.UseVisualStyleBackColor = true;
            this.button_combinations_3_card.Click += new System.EventHandler(this.button_combinations_3_card_Click);
            // 
            // button_combinations_4_card
            // 
            this.button_combinations_4_card.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_combinations_4_card.Location = new System.Drawing.Point(310, 341);
            this.button_combinations_4_card.Name = "button_combinations_4_card";
            this.button_combinations_4_card.Size = new System.Drawing.Size(160, 30);
            this.button_combinations_4_card.TabIndex = 10;
            this.button_combinations_4_card.Text = "Combinations 4 cards";
            this.button_combinations_4_card.UseVisualStyleBackColor = true;
            this.button_combinations_4_card.Click += new System.EventHandler(this.button_combinations_4_card_Click);
            // 
            // button_combinations_5_card
            // 
            this.button_combinations_5_card.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_combinations_5_card.Location = new System.Drawing.Point(310, 377);
            this.button_combinations_5_card.Name = "button_combinations_5_card";
            this.button_combinations_5_card.Size = new System.Drawing.Size(160, 30);
            this.button_combinations_5_card.TabIndex = 11;
            this.button_combinations_5_card.Text = "Combinations 5 cards";
            this.button_combinations_5_card.UseVisualStyleBackColor = true;
            this.button_combinations_5_card.Click += new System.EventHandler(this.button_combinations_5_card_Click);
            // 
            // button_combinations_6_card
            // 
            this.button_combinations_6_card.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_combinations_6_card.Location = new System.Drawing.Point(310, 413);
            this.button_combinations_6_card.Name = "button_combinations_6_card";
            this.button_combinations_6_card.Size = new System.Drawing.Size(160, 30);
            this.button_combinations_6_card.TabIndex = 12;
            this.button_combinations_6_card.Text = "Combinations 6 cards";
            this.button_combinations_6_card.UseVisualStyleBackColor = true;
            this.button_combinations_6_card.Click += new System.EventHandler(this.button_combinations_6_card_Click);
            // 
            // comboBox_card_select
            // 
            this.comboBox_card_select.FormattingEnabled = true;
            this.comboBox_card_select.Location = new System.Drawing.Point(310, 206);
            this.comboBox_card_select.Name = "comboBox_card_select";
            this.comboBox_card_select.Size = new System.Drawing.Size(121, 21);
            this.comboBox_card_select.TabIndex = 13;
            // 
            // button_combinations_7_card
            // 
            this.button_combinations_7_card.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_combinations_7_card.Location = new System.Drawing.Point(310, 449);
            this.button_combinations_7_card.Name = "button_combinations_7_card";
            this.button_combinations_7_card.Size = new System.Drawing.Size(160, 30);
            this.button_combinations_7_card.TabIndex = 14;
            this.button_combinations_7_card.Text = "Combinations 7 cards";
            this.button_combinations_7_card.UseVisualStyleBackColor = true;
            this.button_combinations_7_card.Click += new System.EventHandler(this.button_combinations_7_card_Click);
            // 
            // button_combinations_1_to_7_cards
            // 
            this.button_combinations_1_to_7_cards.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_combinations_1_to_7_cards.Location = new System.Drawing.Point(476, 233);
            this.button_combinations_1_to_7_cards.Name = "button_combinations_1_to_7_cards";
            this.button_combinations_1_to_7_cards.Size = new System.Drawing.Size(198, 30);
            this.button_combinations_1_to_7_cards.TabIndex = 15;
            this.button_combinations_1_to_7_cards.Text = "Combinations 1 to 7 cards";
            this.button_combinations_1_to_7_cards.UseVisualStyleBackColor = true;
            this.button_combinations_1_to_7_cards.Click += new System.EventHandler(this.button_combinations_1_to_7_cards_Click);
            // 
            // button_pair_factorial
            // 
            this.button_pair_factorial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pair_factorial.Location = new System.Drawing.Point(476, 269);
            this.button_pair_factorial.Name = "button_pair_factorial";
            this.button_pair_factorial.Size = new System.Drawing.Size(198, 30);
            this.button_pair_factorial.TabIndex = 16;
            this.button_pair_factorial.Text = "Combinations pair factorial";
            this.button_pair_factorial.UseVisualStyleBackColor = true;
            this.button_pair_factorial.Click += new System.EventHandler(this.button_pair_factorial_Click);
            // 
            // Form_poker_permutations_cls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 511);
            this.Controls.Add(this.button_pair_factorial);
            this.Controls.Add(this.button_combinations_1_to_7_cards);
            this.Controls.Add(this.button_combinations_7_card);
            this.Controls.Add(this.comboBox_card_select);
            this.Controls.Add(this.button_combinations_6_card);
            this.Controls.Add(this.button_combinations_5_card);
            this.Controls.Add(this.button_combinations_4_card);
            this.Controls.Add(this.button_combinations_3_card);
            this.Controls.Add(this.button_combinations_2_card);
            this.Controls.Add(this.button_combinations_1_card);
            this.Controls.Add(this.checkBox_write_textbox);
            this.Controls.Add(this.checkBox_write_console);
            this.Controls.Add(this.button_cards_highest_combination);
            this.Controls.Add(this.button_card_combinations);
            this.Controls.Add(this.button_my_cards);
            this.Controls.Add(this.button_dealer_cards);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_poker_permutations_cls";
            this.Text = "Form_poker_table";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Button button_dealer_cards;
        private Button button_my_cards;
        private Button button_card_combinations;
        private Button button_cards_highest_combination;
        private CheckBox checkBox_write_console;
        private CheckBox checkBox_write_textbox;
        private Button button_combinations_1_card;
        private Button button_combinations_2_card;
        private Button button_combinations_3_card;
        private Button button_combinations_4_card;
        private Button button_combinations_5_card;
        private Button button_combinations_6_card;
        private ComboBox comboBox_card_select;
        private Button button_combinations_7_card;
        private Button button_combinations_1_to_7_cards;
        private Button button_pair_factorial;
    }
}