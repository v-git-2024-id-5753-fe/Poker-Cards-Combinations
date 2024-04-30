using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace deck_cards_text
{
    enum Cards_all_cards_enumeration
    {
        card_2C,
        card_3C,
        card_4C,
        card_5C,
        card_6C,
        card_7C,
        card_8C,
        card_9C,
        card_10C,
        card_JC,
        card_QC,
        card_KC,
        card_AC,
        card_2D,
        card_3D,
        card_4D,
        card_5D,
        card_6D,
        card_7D,
        card_8D,
        card_9D,
        card_10D,
        card_JD,
        card_QD,
        card_KD,
        card_AD,
        card_2H,
        card_3H,
        card_4H,
        card_5H,
        card_6H,
        card_7H,
        card_8H,
        card_9H,
        card_10H,
        card_JH,
        card_QH,
        card_KH,
        card_AH,
        card_2S,
        card_3S,
        card_4S,
        card_5S,
        card_6S,
        card_7S,
        card_8S,
        card_9S,
        card_10S,
        card_JS,
        card_QS,
        card_KS,
        card_AS
    }
    enum Cards_all_cards_kind_enumeration
    {
        kind_2,
        kind_3,
        kind_4,
        kind_5,
        kind_6,
        kind_7,
        kind_8,
        kind_9,
        kind_10,
        kind_J,
        kind_Q,
        kind_K,
        kind_A
    }
    enum Cards_all_cards_suit_enum
    {
        suit_C,
        suit_D,
        suit_H,
        suit_S
    }
    enum Cards_all_cards_state_enum
    {
        In_Deck,
        Not_in_Deck
    }
    class Cards_all_cards_one_card_str
    {
        public Cards_all_cards_enumeration card;
        public double card_chance;
        public Cards_all_cards_suit_enum suit;
        public double suit_chance;
        public Cards_all_cards_kind_enumeration kind;
        public double kind_chance;
        public Cards_all_cards_state_enum state;
        public string print_name;
        public Color print_color;
    }
    class Print_assist_functions_cls
    {
        public void print_text_set_color(string text, Color color_of_text, RichTextBox textbox_out)
        {
            textbox_out.SelectionColor = color_of_text;
            textbox_out.SelectedText = text;
        }
    }
    class Deck_all_cards_text_cls
    {
        public Cards_all_cards_one_card_str[] Cards = new Cards_all_cards_one_card_str[52];
        public const int Deck_size = 52;
        public Color card_C_S_color = Color.Black;
        public Color card_D_H_color = Color.Red;
        Print_assist_functions_cls print_assist_functions;
        public Deck_all_cards_text_cls()
        {
            for (int i = 0; i < Deck_size; i++)
            {
                Cards[i] = new Cards_all_cards_one_card_str();
            }
            print_assist_functions = new Print_assist_functions_cls();
            cards_enum_set();
            cards_suit_set();
            cards_kind_set();
            cards_print_name_set();
        }
        public void Print_deck_info(RichTextBox textbox_to)
        {
            textbox_to.Text = "";
            for (int i = 0; i < Deck_size; i++)
            {
                textbox_to.SelectedText = Cards[i].card.ToString() + "\t";
                textbox_to.SelectedText = Cards[i].suit.ToString() + "\t";
                textbox_to.SelectedText = Cards[i].kind.ToString() + "\t";
                print_assist_functions.print_text_set_color(Cards[i].print_name, Cards[i].print_color, textbox_to);
                textbox_to.SelectedText = "\r\n";
            }
        }
        private void cards_enum_set()
        {
            for (int i = 0; i < Deck_size; i++)
            {
                Cards[i].card = (Cards_all_cards_enumeration)i;
            }
        }
        private void cards_suit_set()
        {
            Cards_all_cards_suit_enum suit_enum = Cards_all_cards_suit_enum.suit_C;
            string suit_str = "";
            for (int i = 0; i < Deck_size; i++)
            {
                suit_str = Convert.ToString(Cards[i].card);
                suit_str = suit_str.Substring(suit_str.Length - 1);
                if (suit_str == "C") suit_enum = Cards_all_cards_suit_enum.suit_C;
                if (suit_str == "D") suit_enum = Cards_all_cards_suit_enum.suit_D;
                if (suit_str == "H") suit_enum = Cards_all_cards_suit_enum.suit_H;
                if (suit_str == "S") suit_enum = Cards_all_cards_suit_enum.suit_S;
                Cards[i].suit = suit_enum;
            }

        }
        private void cards_kind_set()
        {
            for (int i = 0; i < Deck_size; i++)
            {
                Cards_all_cards_kind_enumeration kind_enum = Cards_all_cards_kind_enumeration.kind_2;
                string kind_str = Convert.ToString(Cards[i].card);
                kind_str = kind_str.Substring(0, kind_str.Length - 1);
                kind_str = "kind_" + kind_str.Substring(5);
                Enum.TryParse(kind_str, out kind_enum);
                Cards[i].kind = kind_enum;
            }
        }
        private void cards_print_name_set()
        {
            for (int i = 0; i < Deck_size; i++)
            {
                string print_str = Cards[i].kind.ToString().Substring(5);
                if (Cards[i].suit == Cards_all_cards_suit_enum.suit_C)
                {
                    print_str += Convert.ToChar(0x2663).ToString();
                    Cards[i].print_name = print_str;
                    Cards[i].print_color = Color.Black;

                }
                if (Cards[i].suit == Cards_all_cards_suit_enum.suit_D)
                {
                    print_str += Convert.ToChar(0x2666).ToString();
                    Cards[i].print_name = print_str;
                    Cards[i].print_color = Color.Red;
                }
                if (Cards[i].suit == Cards_all_cards_suit_enum.suit_H)
                {
                    print_str += Convert.ToChar(0x2665).ToString();
                    Cards[i].print_name = print_str;
                    Cards[i].print_color = Color.Red;
                }
                if (Cards[i].suit == Cards_all_cards_suit_enum.suit_S)
                {
                    print_str += Convert.ToChar(0x2660).ToString();
                    Cards[i].print_name = print_str;
                    Cards[i].print_color = Color.Black;
                }
            }
        }
    }
}