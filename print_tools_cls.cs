using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deck_cards_text;
using System.Windows.Forms;
using System.Drawing;
using deck_combination_find;
using cards_permutations_factorial;
class print_richtextbox_cls
{
    RichTextBox textbox_provided;    
    Deck_all_cards_text_cls deck_for_print;
    
    public print_richtextbox_cls( RichTextBox textbox_out)
    {
        textbox_provided = textbox_out;        
        deck_for_print = new Deck_all_cards_text_cls();
    }
    public void print_cards(Cards_all_cards_enumeration[] cards)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            textbox_provided.SelectionColor = deck_for_print.Cards[(int)cards[i]].print_color;
            textbox_provided.SelectedText = deck_for_print.Cards[(int)cards[i]].print_name + " ";
        }
        textbox_provided.SelectedText = "\r\n";
    }
    public void print_cards(Cards_all_cards_enumeration[] cards, string str = "")
    {
        if (str.Length > 0)
        {
            textbox_provided.SelectionColor = Color.Black;
            textbox_provided.SelectedText = str;
        }
        for (int i = 0; i < cards.Length; i++)
        {
            textbox_provided.SelectionColor = deck_for_print.Cards[(int)cards[i]].print_color;
            textbox_provided.SelectedText = deck_for_print.Cards[(int)cards[i]].print_name + " ";
        }
        textbox_provided.SelectedText = "\r\n";
    }
    public void print_win_combinations(combination_found_output_cls found_combinations, string str = "")
    {
        if (str.Length > 0)
        {
            textbox_provided.SelectionColor = Color.Black;
            textbox_provided.SelectedText = str;
        }
        for (int a = 0; a < found_combinations.combinations_size.Length; a++)
        {
            textbox_provided.SelectionColor = Color.Black;
            textbox_provided.SelectedText = (Cards_combination_win_enum)a + " " +
            Convert.ToString(found_combinations.combinations_size[a]);

            textbox_provided.SelectedText = "\r\n";
        }
        textbox_provided.SelectionColor = Color.Black;
        textbox_provided.SelectedText = "Total_Combinations" + " " +
        Convert.ToString(found_combinations.total_combinations);
    }

    public void print_win_combination_output_factorial(win_combination_output_cls output_to_print, string str = "")
    {
        if (str.Length > 0)
        {
            textbox_provided.SelectionColor = Color.Black;
            textbox_provided.SelectedText = str;
        }
      
        textbox_provided.SelectionColor = Color.Black;
        textbox_provided.SelectedText = "Win combinations: " + output_to_print.win_permutations.ToString() + "\r\n";
        textbox_provided.SelectedText = "All permutations: " + output_to_print.all_permutations.ToString() + "\r\n";
        textbox_provided.SelectedText = "Probability: " + output_to_print.permutations_probability_get().ToString("0.0000") + "\r\n";

    }
}
