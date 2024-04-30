using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using deck_cards_text;
class Deck_all_cards_buttons_cls
{
    Form form_supplied;
    public Deck_all_cards_buttons_cls(Form form_out, int x_offset = 10, int y_offset = 40)
    {
        form_supplied = form_out;
        g_elem_x_offset = x_offset;
        g_elem_y_offset = y_offset;        
        CardButtons = new Button[52];
        deck_for_buttons = new Deck_all_cards_text_cls();
        cards_buttons_make();
    }
    int g_elem_x_offset;
    int g_elem_y_offset;
    public const int button_x_size = 50;
    public const int button_y_size = 30;
    public const int button_x_space_size = 10;
    public const int button_y_space_size = 5;
    public Button[] CardButtons;
    Deck_all_cards_text_cls deck_for_buttons;
    void cards_buttons_make()
    {
        int rows_cnt = 0;
        int columns_cnt = 0;
        for (int i = 0; i < Deck_all_cards_text_cls.Deck_size; i++)
        {
            CardButtons[i] = new Button();            
            CardButtons[i].Name = deck_for_buttons.Cards[i].card.ToString();
            CardButtons[i].Text = deck_for_buttons.Cards[i].print_name;
            CardButtons[i].Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CardButtons[i].ForeColor = deck_for_buttons.Cards[i].print_color;
            CardButtons[i].Size = new Size(button_x_size, button_y_size);
            CardButtons[i].Location = new Point(g_elem_x_offset + (button_x_size + button_x_space_size) * rows_cnt,
                g_elem_y_offset + (button_y_size + button_y_space_size) * columns_cnt);
            form_supplied.Controls.Add(CardButtons[i]);
            columns_cnt += 1;
            if (columns_cnt == 13)
            {
                rows_cnt += 1;
                columns_cnt = 0;
            }            
        }
    }
    public void buttons_click_method_set(EventHandler method)
    {
        for (int i = 0; i < Deck_all_cards_text_cls.Deck_size; i++)
        {
            CardButtons[i].Click += method;
        }
    }
    public void button_enable(Cards_all_cards_enumeration card)
    {
        for (int i = 0; i < Deck_all_cards_text_cls.Deck_size; i++)
        {
            Cards_all_cards_enumeration card_of_button;
            Enum.TryParse(CardButtons[i].Name, out card_of_button);
            if (card == card_of_button)
            {
                CardButtons[i].Enabled = true;
            }
        }
    }
    public void button_disable(Cards_all_cards_enumeration card)
    {
        for (int i = 0; i < Deck_all_cards_text_cls.Deck_size; i++)
        {
            Cards_all_cards_enumeration card_of_button;
            Enum.TryParse(CardButtons[i].Name, out card_of_button);
            if (card == card_of_button)
            {
                CardButtons[i].Enabled = false;
            }
        }
    }
}
