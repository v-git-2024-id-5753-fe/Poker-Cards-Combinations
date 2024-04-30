using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_poker_permutations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form_poker_permutations_cls poker_permutation;
        Form_poker_game_cls poker_game;
        private void button_test_any_Click(object sender, EventArgs e)
        {
            poker_permutation.Close();
            poker_game.Close();
            poker_permutation = new Form_poker_permutations_cls();
            poker_game = new Form_poker_game_cls();
            
            poker_permutation.Show();
         //   poker_game.Show();
        }

        private void button_23_Click(object sender, EventArgs e)
        {
            Console.WriteLine("done");
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			poker_permutation = new Form_poker_permutations_cls();
			poker_game = new Form_poker_game_cls();

			poker_permutation.Show();
		}
	}
}
