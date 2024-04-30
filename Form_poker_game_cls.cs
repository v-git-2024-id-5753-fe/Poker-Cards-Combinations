using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using deck_cards_text;
using array_tools;
using deck_combination_find;
using write_to_file_tools;
using cards_permutations_factorial;
namespace WindowsFormsApp_poker_permutations
{
    public partial class Form_poker_game_cls : Form
    {
        Cards_permutation_factorial_cls permutation_factorial;
        public Form_poker_game_cls()
        {
            InitializeComponent();
            permutation_factorial = new Cards_permutation_factorial_cls();
            players = new one_player_data_cls[8];

            for (int i = 0; i < players.Length; i++)
            {
                if (i == 0)
                {
                    players[i] = new one_player_data_cls(this, 5, i);
                }
                else
                {
                    players[i] = new one_player_data_cls(this, 2, i);
                }

                players[i].buttons_click_method_set(player_card_button_Click);
            }
            dealer_cards = players[0];
            dealer_cards.player_button = button_dealer_cards;
            my_cards = players[1];
            my_cards.player_button = button_my_cards;
            players[2].player_button = button_player_1;
            players[3].player_button = button_player_2;
            players[4].player_button = button_player_3;
            players[5].player_button = button_player_4;
            players[6].player_button = button_player_5;
            players[7].player_button = button_player_6;
            deck_buttons = new Deck_all_cards_buttons_cls(this);
            deck_buttons.buttons_click_method_set(deck_card_button_Click);

        }
        one_player_data_cls[] players;
        one_player_data_cls my_cards;
        one_player_data_cls dealer_cards;
        Deck_all_cards_buttons_cls deck_buttons;

        private void player_card_button_Click(object sender, EventArgs e)
        {
            Button button_clicked = (Button)sender;
            Cards_all_cards_enumeration card;
            string[] card_info = button_clicked.Name.Split(';');
            Enum.TryParse(card_info[1], out card);
            players[Convert.ToInt32(card_info[0], 10)].RemoveCard(card);
            deck_buttons.button_enable(card);
            permutation_factorial.Return_Card(card);
        }
        private void deck_card_button_Click(object sender, EventArgs e)
        {
            Button button_clicked = (Button)sender;
            Cards_all_cards_enumeration card;
            Enum.TryParse(button_clicked.Name, out card);
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].player_button.Enabled == false)
                {
                    if (players[i].AddCard(card) == true)
                    {
                        deck_buttons.button_disable(card);
                    }
                }
            }
            permutation_factorial.Take_Card(card);
        }
        enum poker_table_game_state_enum
        {
            PlayersSelection,
            CardsDealing
        }
        poker_table_game_state_enum table_game_state = poker_table_game_state_enum.PlayersSelection;
        private void player_button_Click(object sender, EventArgs e)
        {
            Button button_click = (Button)sender;
            if (table_game_state == poker_table_game_state_enum.PlayersSelection)
            {
                for (int i = 2; i < players.Length; i++)
                {
                    if (players[i].player_button == button_click)
                    {
                        this.Controls.Remove(button_click);
                    }
                }
                if (players[0].player_button == button_click)
                {
                    table_game_state = poker_table_game_state_enum.CardsDealing;
                }
            }
            if (table_game_state == poker_table_game_state_enum.CardsDealing)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].player_button.Enabled = true;
                }
                button_click.Enabled = false;
            }
        }




        private void checkBox_write_textbox_CheckedChanged(object sender, EventArgs e)
        {
        }



        private void checkBox_write_console_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_pair_factorial_Click(object sender, EventArgs e)
        {
            form_rich_textbox_cls rich_textbox = new form_rich_textbox_cls();
            array_tools_cls array_tools = new array_tools_cls();
            win_combination_output_cls[] combination_result;
            print_richtextbox_cls print_tools = new print_richtextbox_cls(rich_textbox.RichTextBox_window);
            cards_array_in_out_cls cards_my = my_cards.cards_get();
            cards_array_in_out_cls cards_dealer = dealer_cards.cards_get();
            cards_array_in_out_cls cards_all;
            array_tools.merge_2_arrays_reenumerate(cards_my, cards_dealer, out cards_all);

            for (int a = cards_all.array.Length; a <= 7; a++)
            {
                permutation_factorial.pair_of_a_kind_tmp(cards_all, a, out combination_result);
                print_tools.print_win_combination_output_factorial(combination_result[combination_result.Length - 1]);
            }
            
            


            rich_textbox.Show();
        }
    }
}
