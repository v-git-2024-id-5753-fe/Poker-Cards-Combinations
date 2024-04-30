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
    public partial class Form_poker_permutations_cls : Form
    {
        public Form_poker_permutations_cls()
        {
            InitializeComponent();
            players = new one_player_data_cls[2];
            players[0] = new one_player_data_cls(this, 5, 0);
            players[1] = new one_player_data_cls(this, 2, 1);
            for (int i = 0; i < players.Length; i++)
            {
                players[i].buttons_click_method_set(player_card_button_Click);
            }
            dealer_cards = players[0];
            dealer_cards.player_button = button_dealer_cards;
            my_cards = players[1];
            my_cards.player_button = button_my_cards;
            deck_buttons = new Deck_all_cards_buttons_cls(this);
            deck_buttons.buttons_click_method_set(deck_card_button_Click);

            string[] combobox_cards_names = new string[52];
            for (int a = 0; a < 52; a++)
            {
                combobox_cards_names[a] = ((Cards_all_cards_enumeration)a).ToString();
            }
            comboBox_card_select.Items.AddRange(combobox_cards_names);
            comboBox_card_select.SelectedIndex = 0;

        }
        one_player_data_cls[] players;
        one_player_data_cls my_cards;
        one_player_data_cls dealer_cards;
        Deck_all_cards_buttons_cls deck_buttons;
        Cards_all_cards_enumeration[] get_cards_arr;
        private void player_card_button_Click(object sender, EventArgs e)
        {
            Button button_clicked = (Button)sender;
            Cards_all_cards_enumeration card;
            string[] card_info = button_clicked.Name.Split(';');
            Enum.TryParse(card_info[1], out card);
            players[Convert.ToInt32(card_info[0], 10)].RemoveCard(card);
            deck_buttons.button_enable(card);
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
        }
        enum poker_table_game_state_enum
        {
            PlayersSelection,
            CardsDealing
        }
        private void player_button_Click(object sender, EventArgs e)
        {
            Button button_click = (Button)sender;
            for (int i = 0; i < players.Length; i++)
            {
                players[i].player_button.Enabled = true;
            }
            button_click.Enabled = false;
        }
        private void button_cards_combinations_Click(object sender, EventArgs e)
        {
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            cards_array_in_out_cls cards_dealer = dealer_cards.cards_get();
            cards_array_in_out_cls cards_my = my_cards.cards_get();
            cards_array_in_out_cls cards_all;
            array_tools_cls array_merge_tool = new array_tools_cls();
            cards_combination_cls combination_find = new cards_combination_cls();
            array_merge_tool.merge_2_arrays_reenumerate(cards_dealer, cards_my, out cards_all);
            print_tool.print_cards(cards_all.array);
            cards_array_in_out_cls cards_pair;
            if (combination_find.find_one_pair_of_a_kind(cards_all, out cards_pair) == true)
            {
                print_tool.print_cards(cards_pair.array, "Pair:");
                cards_array_in_out_cls left_cards_pair = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_pair, out left_cards_pair);
                print_tool.print_cards(left_cards_pair.array, "Pair left cards:");
            }
            cards_array_in_out_cls cards_two_pairs;
            if (combination_find.find_two_pairs_of_a_kind(cards_all, out cards_two_pairs) == true)
            {
                print_tool.print_cards(cards_two_pairs.array, "Two pairs:");
                cards_array_in_out_cls left_cards_two_pairs = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_two_pairs, out left_cards_two_pairs);
                print_tool.print_cards(left_cards_two_pairs.array, "Two pairs left cards:");
            }
            cards_array_in_out_cls cards_3_of_kind;
            if (combination_find.find_three_of_a_kind(cards_all, out cards_3_of_kind) == true)
            {
                print_tool.print_cards(cards_3_of_kind.array, "Three of a kind:");
                cards_array_in_out_cls left_cards_3_of_kind = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_3_of_kind, out left_cards_3_of_kind);
                print_tool.print_cards(left_cards_3_of_kind.array, "Three of a kind left cards:");
            }
            cards_array_in_out_cls cards_high_card;
            if (combination_find.find_high_card(cards_all, out cards_high_card) == true)
            {
                print_tool.print_cards(cards_high_card.array, "High cards:");
                cards_array_in_out_cls left_cards_high_card = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_high_card, out left_cards_high_card);
                print_tool.print_cards(left_cards_high_card.array, "High card left cards:");
            }
            cards_array_in_out_cls cards_straight;
            if (combination_find.find_straight(cards_all, out cards_straight) == true)
            {
                print_tool.print_cards(cards_straight.array, "Straight:");
                cards_array_in_out_cls left_cards_straight = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_straight, out left_cards_straight);
                print_tool.print_cards(left_cards_straight.array, "Straight left cards:");
            }
            cards_array_in_out_cls cards_flush;
            if (combination_find.find_flush(cards_all, out cards_flush) == true)
            {
                print_tool.print_cards(cards_flush.array, "Flush:");
                cards_array_in_out_cls left_cards_flush = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_flush, out left_cards_flush);
                print_tool.print_cards(left_cards_flush.array, "Flush left cards:");
            }
            cards_array_in_out_cls cards_full_house;
            if (combination_find.find_full_house(cards_all, out cards_full_house) == true)
            {
                print_tool.print_cards(cards_full_house.array, "Full house:");
                cards_array_in_out_cls left_cards_full_house = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_full_house, out left_cards_full_house);
                print_tool.print_cards(left_cards_full_house.array, "Full house left cards:");
            }
            cards_array_in_out_cls cards_four_of_a_kind;
            if (combination_find.find_four_of_a_kind(cards_all, out cards_four_of_a_kind) == true)
            {
                print_tool.print_cards(cards_four_of_a_kind.array, "Four of a kind:");
                cards_array_in_out_cls left_cards_four_of_a_kind = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_four_of_a_kind, out left_cards_four_of_a_kind);
                print_tool.print_cards(left_cards_four_of_a_kind.array, "Four of a kind left cards:");
            }
            cards_array_in_out_cls cards_straight_flush;
            if (combination_find.find_straight_flush(cards_all, out cards_straight_flush) == true)
            {
                print_tool.print_cards(cards_straight_flush.array, "Straight flush:");
                cards_array_in_out_cls left_cards_straight_flush = new cards_array_in_out_cls();
                array_merge_tool.substract_2_arrays(cards_all, cards_straight_flush, out left_cards_straight_flush);
                print_tool.print_cards(left_cards_straight_flush.array, "Straight flush:");
            }
            form_textbox.Show();
        }
        private void progressBar_num_proccessed_Click(object sender, EventArgs e)
        {
        }
        private void button_cards_highest_combination_Click(object sender, EventArgs e)
        {
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            cards_array_in_out_cls cards_dealer = dealer_cards.cards_get();
            cards_array_in_out_cls cards_my = my_cards.cards_get();
            cards_array_in_out_cls cards_all;
            array_tools_cls array_merge_tool = new array_tools_cls();
            cards_combination_cls combination_find = new cards_combination_cls();
            array_merge_tool.merge_2_arrays_reenumerate(cards_dealer, cards_my, out cards_all);
            cards_array_in_out_cls highest_combination_cards = new cards_array_in_out_cls();
            Cards_combination_win_enum combination_type = Cards_combination_win_enum.HighCard;
            combination_type = combination_find.find_highest_combination(cards_all, out highest_combination_cards);
            print_tool.print_cards(highest_combination_cards.array, "Highest cards are" + " " + combination_type.ToString() + ":");
            cards_array_in_out_cls left_cards_highest_combination = new cards_array_in_out_cls();
            array_merge_tool.substract_2_arrays(cards_all, highest_combination_cards, out left_cards_highest_combination);
            print_tool.print_cards(left_cards_highest_combination.array, "Highest combination left cards:");
            form_textbox.Show();
        }
        private void checkBox_write_textbox_CheckedChanged(object sender, EventArgs e)
        {
        }
        combination_search_win_cards_v2_one_permutation_cls combination_search_win_cards;
        private void button_combinations_1_card_Click(object sender, EventArgs e)
        {
            Cards_all_cards_enumeration card_picked;
            Enum.TryParse(comboBox_card_select.Text, out card_picked);
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            combination_search_win_cards_for_one_card = new combination_search_win_cards_v2_one_permutation_for_one_card_cls(card_picked, 1);
            combination_search_win_cards_for_one_card.find_win_combinations(checkBox_write_console.Checked);
            print_tool.print_win_combinations(combination_search_win_cards_for_one_card.combination_found_output);
            write_to_file_tools = new write_to_file_tools_cls();
            write_to_file_tools.writedata(card_picked, 1, combination_search_win_cards_for_one_card.combination_found_output);
            form_textbox.Show();
        }

        private void button_combinations_2_card_Click(object sender, EventArgs e)
        {
            Cards_all_cards_enumeration card_picked;
            Enum.TryParse(comboBox_card_select.Text, out card_picked);
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            combination_search_win_cards_for_one_card = new combination_search_win_cards_v2_one_permutation_for_one_card_cls(card_picked, 2);
            combination_search_win_cards_for_one_card.find_win_combinations(checkBox_write_console.Checked);
            print_tool.print_win_combinations(combination_search_win_cards_for_one_card.combination_found_output);
            write_to_file_tools = new write_to_file_tools_cls();
            write_to_file_tools.writedata(card_picked, 2, combination_search_win_cards_for_one_card.combination_found_output);
            form_textbox.Show();
        }
        combination_search_win_cards_v2_one_permutation_for_one_card_cls combination_search_win_cards_for_one_card;
        write_to_file_tools_cls write_to_file_tools;
        private void button_combinations_3_card_Click(object sender, EventArgs e)
        {
            Cards_all_cards_enumeration card_picked;
            Enum.TryParse(comboBox_card_select.Text, out card_picked);
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            combination_search_win_cards_for_one_card = new combination_search_win_cards_v2_one_permutation_for_one_card_cls(card_picked, 3);
            combination_search_win_cards_for_one_card.find_win_combinations(checkBox_write_console.Checked);
            print_tool.print_win_combinations(combination_search_win_cards_for_one_card.combination_found_output);
            write_to_file_tools = new write_to_file_tools_cls();
            write_to_file_tools.writedata(card_picked, 3, combination_search_win_cards_for_one_card.combination_found_output);
            form_textbox.Show();
        }

        private void button_combinations_4_card_Click(object sender, EventArgs e)
        {
            Cards_all_cards_enumeration card_picked;
            Enum.TryParse(comboBox_card_select.Text, out card_picked);
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            combination_search_win_cards_for_one_card = new combination_search_win_cards_v2_one_permutation_for_one_card_cls(card_picked, 4);
            combination_search_win_cards_for_one_card.find_win_combinations(checkBox_write_console.Checked);
            print_tool.print_win_combinations(combination_search_win_cards_for_one_card.combination_found_output);
            write_to_file_tools = new write_to_file_tools_cls();
            write_to_file_tools.writedata(card_picked, 4, combination_search_win_cards_for_one_card.combination_found_output);
            form_textbox.Show();
        }

        private void button_combinations_5_card_Click(object sender, EventArgs e)
        {
            Cards_all_cards_enumeration card_picked;
            Enum.TryParse(comboBox_card_select.Text, out card_picked);
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            combination_search_win_cards_for_one_card = new combination_search_win_cards_v2_one_permutation_for_one_card_cls(card_picked, 5);
            combination_search_win_cards_for_one_card.find_win_combinations(checkBox_write_console.Checked);
            print_tool.print_win_combinations(combination_search_win_cards_for_one_card.combination_found_output);
            write_to_file_tools = new write_to_file_tools_cls();
            write_to_file_tools.writedata(card_picked, 5, combination_search_win_cards_for_one_card.combination_found_output);
            form_textbox.Show();
        }

        private void button_combinations_6_card_Click(object sender, EventArgs e)
        {
            Cards_all_cards_enumeration card_picked;
            Enum.TryParse(comboBox_card_select.Text, out card_picked);
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            combination_search_win_cards_for_one_card = new combination_search_win_cards_v2_one_permutation_for_one_card_cls(card_picked, 6);
            combination_search_win_cards_for_one_card.find_win_combinations(checkBox_write_console.Checked);
            print_tool.print_win_combinations(combination_search_win_cards_for_one_card.combination_found_output);
            write_to_file_tools = new write_to_file_tools_cls();
            write_to_file_tools.writedata(card_picked, 6, combination_search_win_cards_for_one_card.combination_found_output);
            form_textbox.Show();
        }

        private void button_combinations_7_card_Click(object sender, EventArgs e)
        {
            Cards_all_cards_enumeration card_picked;
            Enum.TryParse(comboBox_card_select.Text, out card_picked);
            form_rich_textbox_cls form_textbox = new form_rich_textbox_cls();
            print_richtextbox_cls print_tool = new print_richtextbox_cls(form_textbox.RichTextBox_window);
            combination_search_win_cards_for_one_card = new combination_search_win_cards_v2_one_permutation_for_one_card_cls(card_picked, 7);
            combination_search_win_cards_for_one_card.find_win_combinations(checkBox_write_console.Checked);
            print_tool.print_win_combinations(combination_search_win_cards_for_one_card.combination_found_output);
            write_to_file_tools = new write_to_file_tools_cls();
            write_to_file_tools.writedata(card_picked, 7, combination_search_win_cards_for_one_card.combination_found_output);
            form_textbox.Show();
        }

        private void button_combinations_1_to_7_cards_Click(object sender, EventArgs e)
        {
            button_combinations_1_card.PerformClick();
            button_combinations_2_card.PerformClick();
            button_combinations_3_card.PerformClick();
            button_combinations_4_card.PerformClick();
            button_combinations_5_card.PerformClick();
            button_combinations_6_card.PerformClick();
            button_combinations_7_card.PerformClick();
        }
       
        private void button_pair_factorial_Click(object sender, EventArgs e)
        {
         
        }
    }
}
