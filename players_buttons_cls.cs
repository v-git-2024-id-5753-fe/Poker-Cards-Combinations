using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using deck_cards_text;
using array_tools;
enum player_state_enum
{
    NotPlaying,
    InTheGame
}

enum card_button_state_enum
{
    OnTable,
    NotOnTable
}
class one_player_data_cls
{
    public Button player_button;
    public player_state_enum player_state;
    public Button[] CardsButtons;
    public card_button_state_enum[] cards_buttons_state;
    int player_number;
    int cards_buttons_size;
    Form form_supplied;
    Deck_all_cards_text_cls deck_for_text;
    public one_player_data_cls(Form form_in, int cards_num, int player_num)
    {
        cards_buttons_size = cards_num;
        player_number = player_num;
        form_supplied = form_in;
        CardsButtons = new Button[cards_buttons_size];
        cards_buttons_state = new card_button_state_enum[cards_buttons_size];
        for (int i = 0; i < CardsButtons.Length; i++)
        {
            CardsButtons[i] = new Button();
            cards_buttons_state[i] = card_button_state_enum.NotOnTable;
        }
        player_state = player_state_enum.NotPlaying;
        deck_for_text = new Deck_all_cards_text_cls();
        player_cards_buttons_make();
    }

    public void buttons_click_method_set(EventHandler method)
    {
        for (int i = 0; i < cards_buttons_size; i++)
        {
            CardsButtons[i].Click += method;
        }
    }
        void player_cards_buttons_make(int offset_x = 480, int offset_y = 40)
    {
        int rows_cnt = 0;
        for (int i = 0; i < cards_buttons_size; i++)
        {
            CardsButtons[i].Name = "No_card";
            CardsButtons[i].Text = "No_card";
            CardsButtons[i].Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CardsButtons[i].ForeColor = Color.Black;
            CardsButtons[i].Size = new Size(50, 30);
            CardsButtons[i].Location = new Point(offset_x + (Deck_all_cards_buttons_cls.button_x_size +
                Deck_all_cards_buttons_cls.button_x_space_size) * rows_cnt, offset_y + (Deck_all_cards_buttons_cls.button_y_size
                + Deck_all_cards_buttons_cls.button_y_space_size) * player_number);
            rows_cnt++;
            cards_buttons_state[i] = card_button_state_enum.NotOnTable;
        }
    }
    public bool AddCard(Cards_all_cards_enumeration card)
    {
        for (int i = 0; i < cards_buttons_size; i++)
        {
            if (cards_buttons_state[i] == card_button_state_enum.NotOnTable)
            {
                cards_buttons_state[i] = card_button_state_enum.OnTable;
                CardsButtons[i].Name = Convert.ToString(player_number) + ";" + card.ToString();
                CardsButtons[i].Text = deck_for_text.Cards[(int)card].print_name;
                CardsButtons[i].ForeColor = deck_for_text.Cards[(int)card].print_color;
                player_cards_buttons_refresh();
                return true;
            }
        }
        return false;
    }
    public void RemoveCard(Cards_all_cards_enumeration card)
    {
        for (int i = 0; i < cards_buttons_size; i++)
        {
            if (CardsButtons[i].Name.Split(';')[1] == card.ToString())
            {
                cards_buttons_state[i] = card_button_state_enum.NotOnTable;
                CardsButtons[i].Name = Convert.ToString(player_number) + ";" + "no_card";
                
                player_cards_buttons_refresh();
                return;
            }
        }
    }
    void player_cards_buttons_refresh(int offset_x = 480, int offset_y = 40)
    {
        int rows_cnt = 0;
        for (int i = 0; i < cards_buttons_size; i++)
        {
            form_supplied.Controls.Remove(CardsButtons[i]);
        }
        for (int i = 0; i < cards_buttons_size; i++)
        {
            if (cards_buttons_state[i] == card_button_state_enum.OnTable)
            {                               
                CardsButtons[i].Location = new Point(offset_x + (Deck_all_cards_buttons_cls.button_x_size +
                    Deck_all_cards_buttons_cls.button_x_space_size) * rows_cnt, offset_y + (Deck_all_cards_buttons_cls.button_y_size
                + Deck_all_cards_buttons_cls.button_y_space_size) * player_number);
                rows_cnt++;
                form_supplied.Controls.Add(CardsButtons[i]);
            }
        }
    }
    public cards_array_in_out_cls cards_get()
    {
        int arr_size = 0;
        cards_array_in_out_cls cls_out = new cards_array_in_out_cls();
        for (int i = 0; i < cards_buttons_size; i++)
        {
            if (cards_buttons_state[i] == card_button_state_enum.OnTable)
            {
                arr_size += 1;
                cls_out.AddArrayElement();
                string card_name = CardsButtons[i].Name.Split(';')[1];
                Cards_all_cards_enumeration card;
                Enum.TryParse(card_name, out card);
                cls_out.array[arr_size - 1] = card;
                cls_out.card_numbers[arr_size - 1] = i;
            }
        }
        return cls_out;
    }
}
