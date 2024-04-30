using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deck_cards_text;
using array_tools;
namespace deck_combination_find
{
    class cards_suit_found
    {
        public Cards_all_cards_suit_enum[] suit;
        public int[] cards_count;
        Deck_all_cards_text_cls deck_for_calc;
        public cards_suit_found()
        {
            suit = new Cards_all_cards_suit_enum[4];
            cards_count = new int[4];
            deck_for_calc = new Deck_all_cards_text_cls();
            for (int a = 0; a < 4; a++)
            {
                suit[a] = (Cards_all_cards_suit_enum)a;
                cards_count[a] = 0;
            }
        }
        public void CardAdd(Cards_all_cards_enumeration card)
        {
            for (int a = 0; a < 4; a++)
            {
                if (deck_for_calc.Cards[(int)card].suit == suit[a])
                {
                    cards_count[a] += 1;
                }
            }
        }
    }
    enum Cards_combination_win_enum
    {
        HighCard,
        One_pair_of_a_kind,
        Two_pairs_of_a_kind,
        Three_cards_of_a_kind,
        Straight,
        Flush,
        Full_House,
        Four_of_a_kind,
        Straight_Flush,
        Royal_Flush,
        Possible_Straight_1_card,
        Possible_Straight_2_card,
        Possible_Straight_3_card
    }
    class cards_combination_cls
    {
        Deck_all_cards_text_cls deck_for_calc;
        public cards_combination_cls()
        {
            deck_for_calc = new Deck_all_cards_text_cls();
        }
        public bool find_high_card(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            if (cards_in.array.Length < 1)
            {
                return false;
            }
            int card_high_n = 0;
            for (int a = 0; a < cards_in.array.Length; a++)
            {
                if (deck_for_calc.Cards[(int)cards_in.array[a]].kind > deck_for_calc.Cards[(int)cards_in.array[card_high_n]].kind)
                {
                    card_high_n = a;
                }
            }
            cards_out.AddArrayElement(1);
            cards_out.array[0] = cards_in.array[card_high_n];
            cards_out.card_numbers[0] = cards_in.card_numbers[card_high_n];
            return true;
        }
        public bool find_high_card(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out, Cards_all_cards_suit_enum suit)
        {
            cards_out = new cards_array_in_out_cls();
            if (cards_in.array.Length < 1)
            {
                return false;
            }
            int card_high_n = 0;
            for (int a = 0; a < cards_in.array.Length; a++)
            {
                if (deck_for_calc.Cards[(int)cards_in.array[a]].suit == suit)
                {
                    card_high_n = a;
                }
            }
            for (int a = 0; a < cards_in.array.Length; a++)
            {
                if ((deck_for_calc.Cards[(int)cards_in.array[a]].kind > deck_for_calc.Cards[(int)cards_in.array[card_high_n]].kind) &&
                    (deck_for_calc.Cards[(int)cards_in.array[a]].suit == suit))
                {
                    card_high_n = a;
                }
            }
            cards_out.AddArrayElement(1);
            cards_out.array[0] = cards_in.array[card_high_n];
            cards_out.card_numbers[0] = cards_in.card_numbers[card_high_n];
            return true;
        }
        public bool find_one_pair_of_a_kind(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            if (cards_in.array.Length < 2)
            {
                return false;
            }
            cards_array_in_out_cls first_pair = new cards_array_in_out_cls();
            cards_array_in_out_cls second_pair = new cards_array_in_out_cls();
            cards_array_in_out_cls third_pair = new cards_array_in_out_cls();
            cards_array_in_out_cls cards_for_1st_pair = cards_in;
            cards_array_in_out_cls cards_for_2nd_pair = new cards_array_in_out_cls();
            cards_array_in_out_cls cards_for_3rd_pair = new cards_array_in_out_cls();
            bool first_pair_bool = false;
            bool second_pair_bool = false;
            bool third_pair_bool = false;
            for (int a = 0; a < cards_for_1st_pair.array.Length; a++)
            {
                for (int b = a + 1; b < cards_for_1st_pair.array.Length; b++)
                {
                    if (deck_for_calc.Cards[(int)cards_for_1st_pair.array[a]].kind == deck_for_calc.Cards[(int)cards_for_1st_pair.array[b]].kind)
                    {
                        first_pair.AddArrayElement(2);
                        first_pair.array[0] = cards_for_1st_pair.array[a];
                        first_pair.array[1] = cards_for_1st_pair.array[b];
                        first_pair.card_numbers[0] = cards_for_1st_pair.card_numbers[a];
                        first_pair.card_numbers[1] = cards_for_1st_pair.card_numbers[b];
                        first_pair_bool = true;
                        break;
                    }
                }
                if (first_pair_bool == true)
                {
                    break;
                }
            }
            array_tools_cls array_tools = new array_tools_cls();
            if (first_pair_bool == true)
            {
                array_tools.substract_2_arrays(cards_for_1st_pair, first_pair, out cards_for_2nd_pair);
                if (cards_for_2nd_pair.array.Length >= 2)
                {
                    for (int a = 0; a < cards_for_2nd_pair.array.Length; a++)
                    {
                        for (int b = a + 1; b < cards_for_2nd_pair.array.Length; b++)
                        {
                            if (deck_for_calc.Cards[(int)cards_for_2nd_pair.array[a]].kind == deck_for_calc.Cards[(int)cards_for_2nd_pair.array[b]].kind)
                            {
                                second_pair.AddArrayElement(2);
                                second_pair.array[0] = cards_for_2nd_pair.array[a];
                                second_pair.array[1] = cards_for_2nd_pair.array[b];
                                second_pair.card_numbers[0] = cards_for_2nd_pair.card_numbers[a];
                                second_pair.card_numbers[1] = cards_for_2nd_pair.card_numbers[b];
                                second_pair_bool = true;
                                break;
                            }
                        }
                        if (second_pair_bool == true)
                        {
                            break;
                        }
                    }
                }
            }
            if (second_pair_bool == true)
            {
                array_tools.substract_2_arrays(cards_for_2nd_pair, second_pair, out cards_for_3rd_pair);
                if (cards_for_3rd_pair.array.Length >= 2)
                {
                    for (int a = 0; a < cards_for_3rd_pair.array.Length; a++)
                    {
                        for (int b = a + 1; b < cards_for_3rd_pair.array.Length; b++)
                        {
                            if (deck_for_calc.Cards[(int)cards_for_3rd_pair.array[a]].kind == deck_for_calc.Cards[(int)cards_for_3rd_pair.array[b]].kind)
                            {
                                third_pair.AddArrayElement(2);
                                third_pair.array[0] = cards_for_3rd_pair.array[a];
                                third_pair.array[1] = cards_for_3rd_pair.array[b];
                                third_pair.card_numbers[0] = cards_for_3rd_pair.card_numbers[a];
                                third_pair.card_numbers[1] = cards_for_3rd_pair.card_numbers[b];
                                third_pair_bool = true;
                                break;
                            }
                        }
                        if (third_pair_bool == true)
                        {
                            break;
                        }
                    }
                }
            }
            cards_array_in_out_cls cards_for_out = new cards_array_in_out_cls();
            if (first_pair_bool == true)
            {
                cards_for_out = first_pair;
            }
            if (second_pair_bool == true)
            {
                if (deck_for_calc.Cards[(int)cards_for_out.array[0]].kind < deck_for_calc.Cards[(int)second_pair.array[0]].kind)
                    cards_for_out = second_pair;
            }
            if (third_pair_bool == true)
            {
                if (deck_for_calc.Cards[(int)cards_for_out.array[0]].kind < deck_for_calc.Cards[(int)third_pair.array[0]].kind)
                    cards_for_out = third_pair;
            }
            if (first_pair_bool == true)
            {
                cards_out = cards_for_out;
                return true;
            }
            return false;
        }
        public bool find_two_pairs_of_a_kind(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            if (cards_in.array.Length < 4)
            {
                return false;
            }
            cards_array_in_out_cls first_pair = new cards_array_in_out_cls();
            bool first_pair_found = find_one_pair_of_a_kind(cards_in, out first_pair);
            if (first_pair_found == true)
            {
                cards_array_in_out_cls left_cards = new cards_array_in_out_cls();
                array_tools_cls array_tools = new array_tools_cls();
                array_tools.substract_2_arrays(cards_in, first_pair, out left_cards);
                cards_array_in_out_cls second_pair = new cards_array_in_out_cls();
                bool second_pair_found = find_one_pair_of_a_kind(left_cards, out second_pair);
                if (second_pair_found == true)
                {
                    cards_out.AddArrayElement(4);
                    Array.Copy(first_pair.array, 0, cards_out.array, 0, first_pair.array.Length);
                    Array.Copy(second_pair.array, 0, cards_out.array, first_pair.array.Length, second_pair.array.Length);
                    Array.Copy(first_pair.card_numbers, 0, cards_out.card_numbers, 0, first_pair.array.Length);
                    Array.Copy(second_pair.card_numbers, 0, cards_out.card_numbers, first_pair.array.Length, second_pair.array.Length);
                    return true;
                }
            }
            return false;
        }
        public bool find_three_of_a_kind(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            if (cards_in.array.Length < 3)
            {
                return false;
            }
            cards_array_in_out_cls first_three_kind = new cards_array_in_out_cls();
            cards_array_in_out_cls second_three_kind = new cards_array_in_out_cls();
            cards_array_in_out_cls cards_for_1st_3_of_a_kind = cards_in;
            cards_array_in_out_cls cards_for_2nd_3_of_a_kind = new cards_array_in_out_cls();
            bool first_3_of_a_kind_bool = false;
            bool second_3_of_a_kind_bool = false;
            array_tools_cls array_tools = new array_tools_cls();
            for (int a = 0; a < cards_for_1st_3_of_a_kind.array.Length; a++)
            {
                for (int b = a + 1; b < cards_for_1st_3_of_a_kind.array.Length; b++)
                {
                    if (deck_for_calc.Cards[(int)cards_for_1st_3_of_a_kind.array[a]].kind == deck_for_calc.Cards[(int)cards_for_1st_3_of_a_kind.array[b]].kind)
                    {
                        for (int c = b + 1; c < cards_for_1st_3_of_a_kind.array.Length; c++)
                        {
                            if (deck_for_calc.Cards[(int)cards_for_1st_3_of_a_kind.array[a]].kind == deck_for_calc.Cards[(int)cards_for_1st_3_of_a_kind.array[c]].kind)
                            {
                                first_three_kind.AddArrayElement(3);
                                first_three_kind.array[0] = cards_for_1st_3_of_a_kind.array[a];
                                first_three_kind.array[1] = cards_for_1st_3_of_a_kind.array[b];
                                first_three_kind.array[2] = cards_for_1st_3_of_a_kind.array[c];
                                first_three_kind.card_numbers[0] = cards_for_1st_3_of_a_kind.card_numbers[a];
                                first_three_kind.card_numbers[1] = cards_for_1st_3_of_a_kind.card_numbers[b];
                                first_three_kind.card_numbers[2] = cards_for_1st_3_of_a_kind.card_numbers[c];
                                first_3_of_a_kind_bool = true;
                                break;
                            }
                        }
                        if (first_3_of_a_kind_bool == true)
                        {
                            break;
                        }
                    }
                }
                if (first_3_of_a_kind_bool == true)
                {
                    break;
                }
            }
            if (first_3_of_a_kind_bool == true)
            {
                array_tools.substract_2_arrays(cards_for_1st_3_of_a_kind, first_three_kind, out cards_for_2nd_3_of_a_kind);
                if (cards_for_2nd_3_of_a_kind.array.Length >= 3)
                {
                    for (int a = 0; a < cards_for_2nd_3_of_a_kind.array.Length; a++)
                    {
                        for (int b = a + 1; b < cards_for_2nd_3_of_a_kind.array.Length; b++)
                        {
                            if (deck_for_calc.Cards[(int)cards_for_2nd_3_of_a_kind.array[a]].kind == deck_for_calc.Cards[(int)cards_for_2nd_3_of_a_kind.array[b]].kind)
                            {
                                for (int c = b + 1; c < cards_for_2nd_3_of_a_kind.array.Length; c++)
                                {
                                    if (deck_for_calc.Cards[(int)cards_for_2nd_3_of_a_kind.array[a]].kind == deck_for_calc.Cards[(int)cards_for_2nd_3_of_a_kind.array[c]].kind)
                                    {
                                        second_three_kind.AddArrayElement(3);
                                        second_three_kind.array[0] = cards_for_2nd_3_of_a_kind.array[a];
                                        second_three_kind.array[1] = cards_for_2nd_3_of_a_kind.array[b];
                                        second_three_kind.array[2] = cards_for_2nd_3_of_a_kind.array[c];
                                        second_three_kind.card_numbers[0] = cards_for_2nd_3_of_a_kind.card_numbers[a];
                                        second_three_kind.card_numbers[1] = cards_for_2nd_3_of_a_kind.card_numbers[b];
                                        second_three_kind.card_numbers[2] = cards_for_2nd_3_of_a_kind.card_numbers[c];
                                        second_3_of_a_kind_bool = true;
                                        break;
                                    }
                                }
                                if (second_3_of_a_kind_bool == true)
                                {
                                    break;
                                }
                            }
                        }
                        if (second_3_of_a_kind_bool == true)
                        {
                            break;
                        }
                    }
                }
            }
            cards_array_in_out_cls cards_for_out = new cards_array_in_out_cls();
            if (first_3_of_a_kind_bool == true)
            {
                cards_for_out = first_three_kind;
            }
            if (second_3_of_a_kind_bool == true)
            {
                if (deck_for_calc.Cards[(int)cards_for_out.array[0]].kind < deck_for_calc.Cards[(int)second_three_kind.array[0]].kind)
                    cards_for_out = second_three_kind;
            }
            if (first_3_of_a_kind_bool == true)
            {
                cards_out = cards_for_out;
                return true;
            }
            return false;
        }
        public bool find_straight(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            int cards_in_size = cards_in.array.Length;
            if (cards_in.array.Length < 5)
            {
                return false;
            }
            array_tools_cls array_tools = new array_tools_cls();
            cards_array_in_out_cls[] straight_cards = new cards_array_in_out_cls[cards_in_size];
            cards_array_in_out_cls cards_for_calc = cards_in;
            for (int a = 0; a < cards_in_size; a++)
            {
                straight_cards[a] = new cards_array_in_out_cls();
                find_high_card(cards_for_calc, out straight_cards[a]);
                cards_array_in_out_cls left_cards_for_calc;
                array_tools.substract_2_arrays(cards_for_calc, straight_cards[a], out left_cards_for_calc);
                cards_for_calc = left_cards_for_calc;
            }
            bool It_is_Straight;
            int easy_coding = 0;
            for (int a = 0; a < cards_in_size - 5 + 1; a++)
            {
                It_is_Straight = true;
                easy_coding = a;
                if ((deck_for_calc.Cards[(int)straight_cards[easy_coding].array[0]].kind -
                    deck_for_calc.Cards[(int)straight_cards[easy_coding + 1].array[0]].kind) != 1)
                {
                    It_is_Straight = false;
                }
                easy_coding += 1;
                if ((deck_for_calc.Cards[(int)straight_cards[easy_coding].array[0]].kind -
                    deck_for_calc.Cards[(int)straight_cards[easy_coding + 1].array[0]].kind) != 1)
                {
                    It_is_Straight = false;
                }
                easy_coding += 1;
                if ((deck_for_calc.Cards[(int)straight_cards[easy_coding].array[0]].kind -
                    deck_for_calc.Cards[(int)straight_cards[easy_coding + 1].array[0]].kind) != 1)
                {
                    It_is_Straight = false;
                }
                easy_coding += 1;
                if ((deck_for_calc.Cards[(int)straight_cards[easy_coding].array[0]].kind -
                    deck_for_calc.Cards[(int)straight_cards[easy_coding + 1].array[0]].kind) != 1)
                {
                    It_is_Straight = false;
                }
                if (It_is_Straight == true)
                {
                    cards_array_in_out_cls[] combination_cards = new cards_array_in_out_cls[5];
                    Array.Copy(straight_cards, a, combination_cards, 0, 5);
                    array_tools.make_arrays_one_array(combination_cards, out cards_out);
                    return true;
                }
            }
            return false;
        }
        public bool find_flush(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            int cards_in_size = cards_in.array.Length;
            if (cards_in.array.Length < 5)
            {
                return false;
            }
            cards_suit_found suit_counter = new cards_suit_found();
            for (int a = 0; a < cards_in_size; a++)
            {
                suit_counter.CardAdd(cards_in.array[a]);
            }
            Cards_all_cards_suit_enum suit_found = Cards_all_cards_suit_enum.suit_C;
            bool suit_found_bool = false;
            for (int a = 0; a < suit_counter.suit.Length; a++)
            {
                if (suit_counter.cards_count[a] >= 5)
                {
                    suit_found = suit_counter.suit[a];
                    suit_found_bool = true;
                }
            }
            if (suit_found_bool == true)
            {
                cards_array_in_out_cls[] combination_cards = new cards_array_in_out_cls[5];
                cards_array_in_out_cls cards_for_calc = cards_in;
                array_tools_cls array_tools = new array_tools_cls();
                for (int a = 0; a < combination_cards.Length; a++)
                {
                    combination_cards[a] = new cards_array_in_out_cls();
                    find_high_card(cards_for_calc, out combination_cards[a], suit_found);
                    cards_array_in_out_cls left_cards_for_calc;
                    array_tools.substract_2_arrays(cards_for_calc, combination_cards[a], out left_cards_for_calc);
                    cards_for_calc = left_cards_for_calc;
                }
                array_tools.make_arrays_one_array(combination_cards, out cards_out);
                return true;
            }
            return false;
        }
        public bool find_full_house(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            if (cards_in.array.Length < 5)
            {
                return false;
            }
            cards_array_in_out_cls three_of_a_kind = new cards_array_in_out_cls();
            bool three_of_a_kind_bool = false;
            cards_array_in_out_cls two_of_a_kind = new cards_array_in_out_cls();
            bool two_of_a_kind_bool = false;
            cards_array_in_out_cls three_of_a_kind_left_cards = new cards_array_in_out_cls();
            three_of_a_kind_bool = find_three_of_a_kind(cards_in, out three_of_a_kind);
            if (three_of_a_kind_bool == true)
            {
                array_tools_cls array_tools = new array_tools_cls();
                array_tools.substract_2_arrays(cards_in, three_of_a_kind, out three_of_a_kind_left_cards);
                two_of_a_kind_bool = find_one_pair_of_a_kind(three_of_a_kind_left_cards, out two_of_a_kind);
                if (two_of_a_kind_bool == true)
                {
                    cards_array_in_out_cls cards_for_out = new cards_array_in_out_cls();
                    cards_for_out.AddArrayElement(5);
                    array_tools.merge_2_arrays(three_of_a_kind, two_of_a_kind, out cards_for_out);
                    cards_out = cards_for_out;
                    return true;
                }
            }
            return false;
        }
        public bool find_four_of_a_kind(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            if (cards_in.array.Length < 4)
            {
                return false;
            }
            array_tools_cls array_tools = new array_tools_cls();
            for (int a = 0; a < cards_in.array.Length; a++)
            {
                for (int b = a + 1; b < cards_in.array.Length; b++)
                {
                    if (deck_for_calc.Cards[(int)cards_in.array[a]].kind == deck_for_calc.Cards[(int)cards_in.array[b]].kind)
                    {
                        for (int c = b + 1; c < cards_in.array.Length; c++)
                        {
                            if (deck_for_calc.Cards[(int)cards_in.array[a]].kind == deck_for_calc.Cards[(int)cards_in.array[c]].kind)
                            {
                                for (int d = c + 1; d < cards_in.array.Length; d++)
                                {
                                    if (deck_for_calc.Cards[(int)cards_in.array[a]].kind == deck_for_calc.Cards[(int)cards_in.array[d]].kind)
                                    {
                                        cards_out.AddArrayElement(4);
                                        cards_out.array[0] = cards_in.array[a];
                                        cards_out.array[1] = cards_in.array[b];
                                        cards_out.array[2] = cards_in.array[c];
                                        cards_out.array[3] = cards_in.array[d];
                                        cards_out.card_numbers[0] = cards_in.card_numbers[a];
                                        cards_out.card_numbers[1] = cards_in.card_numbers[b];
                                        cards_out.card_numbers[2] = cards_in.card_numbers[c];
                                        cards_out.card_numbers[3] = cards_in.card_numbers[d];
                                        return true;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return false;
        }
        public bool find_straight_flush(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            int cards_in_size = cards_in.array.Length;
            if (cards_in.array.Length < 5)
            {
                return false;
            }
            cards_suit_found suit_counter = new cards_suit_found();
            for (int a = 0; a < cards_in_size; a++)
            {
                suit_counter.CardAdd(cards_in.array[a]);
            }
            Cards_all_cards_suit_enum suit_found = Cards_all_cards_suit_enum.suit_C;
            bool suit_found_bool = false;
            int suit_found_size = 0;
            for (int a = 0; a < suit_counter.suit.Length; a++)
            {
                if (suit_counter.cards_count[a] >= 5)
                {
                    suit_found = suit_counter.suit[a];
                    suit_found_bool = true;
                    suit_found_size = suit_counter.cards_count[a];
                }
            }
            if (suit_found_bool == true)
            {
                cards_array_in_out_cls straight_flush_cards = new cards_array_in_out_cls();
                cards_array_in_out_cls cards_for_calc = cards_in;
                cards_array_in_out_cls[] combination_cards = new cards_array_in_out_cls[suit_found_size];
                array_tools_cls array_tools = new array_tools_cls();
                for (int a = 0; a < combination_cards.Length; a++)
                {
                    combination_cards[a] = new cards_array_in_out_cls();
                    find_high_card(cards_for_calc, out combination_cards[a], suit_found);
                    cards_array_in_out_cls left_cards_for_calc;
                    array_tools.substract_2_arrays(cards_for_calc, combination_cards[a], out left_cards_for_calc);
                    cards_for_calc = left_cards_for_calc;
                }
                cards_array_in_out_cls combination_cards_combined = new cards_array_in_out_cls();
                array_tools.make_arrays_one_array(combination_cards, out combination_cards_combined);
                bool straight_flash_bool = find_straight(combination_cards_combined, out straight_flush_cards);
                if (straight_flash_bool == true)
                {
                    cards_out = straight_flush_cards;
                    return true;
                }
            }
            return false;
        }
        public Cards_combination_win_enum find_highest_combination(cards_array_in_out_cls cards_in, out cards_array_in_out_cls cards_out)
        {
            cards_out = new cards_array_in_out_cls();
            Cards_combination_win_enum highest_combination = Cards_combination_win_enum.HighCard;
            cards_array_in_out_cls highest_combination_cards = new cards_array_in_out_cls();
            cards_array_in_out_cls current_combination_cards;
            if (find_high_card(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.HighCard;
            }
            if (find_one_pair_of_a_kind(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.One_pair_of_a_kind;
            }
            if (find_two_pairs_of_a_kind(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
            }
            if (find_three_of_a_kind(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.Three_cards_of_a_kind;
            }
            if (find_straight(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.Straight;
            }
            if (find_flush(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.Flush;
            }
            if (find_full_house(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.Full_House;
            }
            if (find_four_of_a_kind(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.Four_of_a_kind;
            }
            if (find_straight_flush(cards_in, out current_combination_cards) == true)
            {
                highest_combination_cards = current_combination_cards;
                highest_combination = Cards_combination_win_enum.Straight_Flush;
            }
            cards_out = highest_combination_cards;
            return highest_combination;
        }
        cards_array_in_out_cls cards_for_calc_1;
        cards_array_in_out_cls cards_for_calc_2;
        cards_array_in_out_cls cards_for_calc_3;
        Cards_all_cards_enumeration card_buffer;
        Cards_combination_win_enum highest_combination;
        public Cards_combination_win_enum find_highest_combination_via_if(cards_array_in_out_cls cards_in)
        {
            highest_combination = Cards_combination_win_enum.HighCard;            
            int combination_size = cards_in.array.Length;
            cards_for_calc_1 = cards_in;
            cards_for_calc_2 = new cards_array_in_out_cls(combination_size);
            cards_for_calc_3 = new cards_array_in_out_cls(combination_size);
            //cards_for_calc_2.AddArrayElement(combination_size);
            //cards_for_calc_3.AddArrayElement(combination_size);
            Array.Copy(cards_for_calc_1.array, cards_for_calc_2.array, combination_size);
            Array.Copy(cards_for_calc_1.array, cards_for_calc_3.array, combination_size);
            
           // bool for_flush = true;
            for (int a = 0; a < combination_size - 1; a++)
            {
                for (int b = a + 1; b < combination_size; b++)
                {
                    if (cards_for_calc_2.array[a] > cards_for_calc_2.array[b])
                    {
                        card_buffer = cards_for_calc_2.array[a];
                        cards_for_calc_2.array[a] = cards_for_calc_2.array[b];
                        cards_for_calc_2.array[b] = card_buffer;
                    }
                }
            }
            //int suit_cnt = 1;
            //for (int a = 0; a < combination_size - 1; a++)
            //{
            //    if (deck_for_calc.Cards[(int)cards_for_calc_2.array[a]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[a + 1]].suit)
            //    {
            //        suit_cnt++;
            //        if (suit_cnt == 5)
            //        {
            //            for_flush = true;
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        suit_cnt = 0;
            //    }
            //}
            for (int a = 0; a < combination_size - 1; a++)
            {
                for (int b = a + 1; b < combination_size; b++)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[a]].kind > deck_for_calc.Cards[(int)cards_for_calc_1.array[b]].kind)
                    {
                        card_buffer = cards_for_calc_1.array[a];
                        cards_for_calc_1.array[a] = cards_for_calc_1.array[b];
                        cards_for_calc_1.array[b] = card_buffer;
                    }

                }
            }
            int combination_size_2 = combination_size;
            for (int a = 0; a < combination_size_2 - 1; a++)
            {
                for (int b = a + 1; b < combination_size_2; b++)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_3.array[a]].kind == deck_for_calc.Cards[(int)cards_for_calc_3.array[b]].kind)
                    {
                        card_buffer = cards_for_calc_3.array[b];
                        cards_for_calc_3.array[b] = cards_for_calc_3.array[combination_size_2 - 1];
                        cards_for_calc_3.array[combination_size_2 - 1] = card_buffer;
                        combination_size_2--;
                    }
                    if (deck_for_calc.Cards[(int)cards_for_calc_3.array[a]].kind > deck_for_calc.Cards[(int)cards_for_calc_3.array[b]].kind)
                    {
                        card_buffer = cards_for_calc_3.array[a];
                        cards_for_calc_3.array[a] = cards_for_calc_3.array[b];
                        cards_for_calc_3.array[b] = card_buffer;
                    }

                }
            }
            // straight flush             
                if (combination_size >= 5)
                {
                    if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[0]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].kind) == -1) &&
                            (deck_for_calc.Cards[(int)cards_for_calc_2.array[0]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].suit))
                    {
                        if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].kind) == -1) &&
                            (deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit))
                        {
                            if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].kind) == -1) &&
                            (deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit))
                            {
                                if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].kind) == -1) &&
                            (deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit))
                                {
                                    highest_combination = Cards_combination_win_enum.Straight_Flush;
                                    return highest_combination;
                                }
                            }
                        }
                    }
                }
                if (combination_size >= 6)
                {
                    if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].kind) == -1) &&
                        (deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit))
                    {
                        if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].kind) == -1) &&
                        (deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit))
                        {
                            if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].kind) == -1) &&
                        (deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit))
                            {
                                if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].kind) == -1) &&
                            (deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].suit))
                                {
                                    highest_combination = Cards_combination_win_enum.Straight_Flush;
                                    return highest_combination;
                                }
                            }
                        }
                    }
                }
                if (combination_size >= 7)
                {
                    if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].kind) == -1) &&
                    (deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit))
                    {
                        if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].kind) == -1) &&
                    (deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit))
                        {
                            if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].kind) == -1) &&
                        (deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].suit))
                            {
                                if (((deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].kind - deck_for_calc.Cards[(int)cards_for_calc_2.array[6]].kind) == -1) &&
                                    (deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[6]].suit))
                                {
                                    highest_combination = Cards_combination_win_enum.Straight_Flush;
                                    return highest_combination;
                                }
                            }
                        }
                    }
                }
            
            // four of a kind
            if (combination_size >= 4)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Four_of_a_kind;
                            return highest_combination;
                        }
                    }
                }
            }
            if (combination_size >= 5)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Four_of_a_kind;
                            return highest_combination;
                        }
                    }
                }
            }
            if (combination_size >= 6)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Four_of_a_kind;
                            return highest_combination;
                        }
                    }
                }
            }
            if (combination_size >= 7)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Four_of_a_kind;
                            return highest_combination;
                        }
                    }
                }
            }
            // full house
            if (combination_size >= 5)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }
            }
            if (combination_size >= 6)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }


                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }
            }
            if (combination_size >= 7)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }


                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }
            }
            if (combination_size >= 5)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }
            }
            if (combination_size >= 6)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }

                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }
            }
            if (combination_size >= 7)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }

                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                        {
                            highest_combination = Cards_combination_win_enum.Full_House;
                            return highest_combination;
                        }
                    }
                }
            }
            // flush 
            
                if (combination_size >= 5)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_2.array[0]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].suit)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit)
                        {
                            if (deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit)
                            {
                                if (deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit)
                                {
                                    highest_combination = Cards_combination_win_enum.Flush;
                                    return highest_combination;
                                }
                            }
                        }
                    }
                }
                if (combination_size >= 6)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_2.array[1]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit)
                        {
                            if (deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit)
                            {
                                if (deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].suit)
                                {
                                    highest_combination = Cards_combination_win_enum.Flush;
                                    return highest_combination;
                                }
                            }
                        }
                    }
                }
                if (combination_size >= 7)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_2.array[2]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit)
                    {
                        if (deck_for_calc.Cards[(int)cards_for_calc_2.array[3]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit)
                        {
                            if (deck_for_calc.Cards[(int)cards_for_calc_2.array[4]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].suit)
                            {
                                if (deck_for_calc.Cards[(int)cards_for_calc_2.array[5]].suit == deck_for_calc.Cards[(int)cards_for_calc_2.array[6]].suit)
                                {
                                    highest_combination = Cards_combination_win_enum.Flush;
                                    return highest_combination;
                                }
                            }
                        }
                    }
                }
            
            //straight
            if (combination_size >= 5)
            {
                if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[0]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[1]].kind) == -1)
                {
                    if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[1]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[2]].kind) == -1)
                    {
                        if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[2]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[3]].kind) == -1)
                        {
                            if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[3]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[4]].kind) == -1)
                            {
                                highest_combination = Cards_combination_win_enum.Straight;
                                return highest_combination;
                            }
                        }
                    }
                }
            }
            if (combination_size >= 6)
            {
                if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[1]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[2]].kind) == -1)
                {
                    if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[2]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[3]].kind) == -1)
                    {
                        if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[3]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[4]].kind) == -1)
                        {
                            if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[4]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[5]].kind) == -1)
                            {
                                highest_combination = Cards_combination_win_enum.Straight;
                                return highest_combination;
                            }
                        }
                    }
                }
            }
            if (combination_size >= 7)
            {
                if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[2]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[3]].kind) == -1)
                {
                    if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[3]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[4]].kind) == -1)
                    {
                        if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[4]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[5]].kind) == -1)
                        {
                            if ((deck_for_calc.Cards[(int)cards_for_calc_3.array[5]].kind - deck_for_calc.Cards[(int)cards_for_calc_3.array[6]].kind) == -1)
                            {
                                highest_combination = Cards_combination_win_enum.Straight;
                                return highest_combination;
                            }
                        }
                    }
                }
            }
            // three of a kind
            if (combination_size >= 3)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Three_cards_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            if (combination_size >= 4)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Three_cards_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            if (combination_size >= 5)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Three_cards_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            if (combination_size >= 6)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Three_cards_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            if (combination_size >= 7)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Four_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            // two pairs of a kind            
            if (combination_size >= 4)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            if (combination_size >= 5)
            {

                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            if (combination_size >= 6)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            if (combination_size >= 7)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                {
                    if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                    {
                        highest_combination = Cards_combination_win_enum.Two_pairs_of_a_kind;
                        return highest_combination;
                    }
                }
            }
            // one pair
            if (combination_size >= 2)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[0]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind)
                {
                    highest_combination = Cards_combination_win_enum.One_pair_of_a_kind;
                    return highest_combination;
                }
            }
            if (combination_size >= 3)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[1]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind)
                {
                    highest_combination = Cards_combination_win_enum.One_pair_of_a_kind;
                    return highest_combination;
                }
            }
            if (combination_size >= 4)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[2]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind)
                {
                    highest_combination = Cards_combination_win_enum.One_pair_of_a_kind;
                    return highest_combination;
                }
            }
            if (combination_size >= 5)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[3]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind)
                {
                    highest_combination = Cards_combination_win_enum.One_pair_of_a_kind;
                    return highest_combination;
                }
            }
            if (combination_size >= 6)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[4]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind)
                {
                    highest_combination = Cards_combination_win_enum.One_pair_of_a_kind;
                    return highest_combination;
                }
            }
            if (combination_size >= 7)
            {
                if (deck_for_calc.Cards[(int)cards_for_calc_1.array[5]].kind == deck_for_calc.Cards[(int)cards_for_calc_1.array[6]].kind)
                {
                    highest_combination = Cards_combination_win_enum.One_pair_of_a_kind;
                    return highest_combination;
                }
            }
            return highest_combination;
        }
    }
    class combination_found_output_cls
    {
        public int[] combinations_size;
        const int combinations_enum_size = 9;        
        public long total_combinations;
        public combination_found_output_cls()
        {
            combinations_size = new int[9];
            for (int a = 0; a < combinations_enum_size; a++)
            {
                combinations_size[a] = 0;
            }
            total_combinations = 0;
            
        }
        public void Add(Cards_combination_win_enum combination)
        {
            combinations_size[(int)combination] += 1;
            total_combinations += 1;
        }
        public void Substract(Cards_combination_win_enum combination)
        {
            combinations_size[(int)combination] -= 1;
            total_combinations -= 1;
        }
    }
    class combination_search_win_cards_cls
    {
        permutaions_via_recursion_cls permutaions_via_recursion;
        public combination_found_output_cls combination_found_output;
        cards_combination_cls cards_combination;
        public combination_search_win_cards_cls(int card_num)
        {
            permutaions_via_recursion = new permutaions_via_recursion_cls(card_num);
            permutaions_via_recursion.find_permutations();
            combination_found_output = new combination_found_output_cls();
            cards_combination = new cards_combination_cls();
        }
        public void win_combinations_get()
        {
            cards_array_in_out_cls cards_of_calc;
            Cards_combination_win_enum win_combination = Cards_combination_win_enum.HighCard;
            for (int a = 0; a < permutaions_via_recursion.Permutations.Length; a++)
            {
                win_combination =
                cards_combination.find_highest_combination(permutaions_via_recursion.Permutations[a], out cards_of_calc);
                combination_found_output.Add(win_combination);
            }
        }
    }
    class combination_search_win_cards_v2_one_permutation_cls
    {
        public int cards_size;
        int expected_permutaion_num;
        permutation_card_cls[] cards;
        permutation_card_cls[] card_of_stages;
        public cards_array_in_out_cls Permutation;
        public combination_found_output_cls combination_found_output;
        cards_combination_cls cards_combination;
        public combination_search_win_cards_v2_one_permutation_cls(int cards_num)
        {
            cards_size = cards_num;
            expected_permutaion_num = 1;
            for (int a = 52; a > 52 - cards_size; a--)
            {
                expected_permutaion_num *= a;
            }
            cards = new permutation_card_cls[52];
            card_of_stages = new permutation_card_cls[cards_num];
            for (int a = 0; a < cards_num; a++)
            {
                card_of_stages[a] = new permutation_card_cls();
            }
            for (int a = 0; a < 52; a++)
            {
                cards[a] = new permutation_card_cls();
                cards[a].number = a;
                cards[a].card_taken = false;
            }
            Permutation = new cards_array_in_out_cls();
            Permutation.AddArrayElement(cards_size);
            combination_found_output = new combination_found_output_cls();
            cards_combination = new cards_combination_cls();
        }
        long permutation_proccessed_num = 0;
        long permutation_proccessed_total = 0;
        double permutation_proccessed_threshold = 0.01;
        int find_permutations_function_start = 0;
        int find_permutations_rec_stage = 0;
        cards_array_in_out_cls cards_of_calc;
        Cards_combination_win_enum win_combination;
        public void find_win_combinations(bool print_yes_no = false)
        {
            if (cards_size <= 7)
            {
                if (find_permutations_function_start == 0)
                {
                    Console.WriteLine(expected_permutaion_num);
                    find_permutations_function_start = 1;
                    find_permutations_rec_stage = 0;
                    permutation_proccessed_num = 0;
                    if (print_yes_no == true)
                    {
                        Console.Clear();
                        Console.WriteLine(expected_permutaion_num);
                        Console.ReadKey();
                    }
                }
                int func_stage = find_permutations_rec_stage;
                for (int a = 0; a < 52; a++)
                {
                    if (cards[a].card_taken == false)
                    {
                        cards[a].card_taken = true;
                        card_of_stages[func_stage].number = a;
                        if (func_stage < cards_size - 1)
                        {
                            find_permutations_rec_stage = func_stage + 1;
                            find_win_combinations(print_yes_no);
                        }
                        else
                        {
                            for (int card_select = 0; card_select < cards_size; card_select++)
                            {
                                Permutation.array[card_select] = (Cards_all_cards_enumeration)card_of_stages[card_select].number;
                                Permutation.card_numbers[card_select] = card_of_stages[card_select].number;
                            }
                            win_combination = Cards_combination_win_enum.HighCard;
                            win_combination =
                            cards_combination.find_highest_combination(Permutation, out cards_of_calc);
                            combination_found_output.Add(win_combination);
                            if (print_yes_no == true)
                            {
                                for (int card_select = 0; card_select < cards_size; card_select++)
                                {
                                    Console.Write(Permutation.array[card_select].ToString());
                                    Console.Write(" ");
                                }
                                Console.Write("\r\n");
                            }
                            //permutation_proccessed_num++;
                            //if ((double)permutation_proccessed_num / (double)expected_permutaion_num >= permutation_proccessed_threshold)
                            //{
                            //    Console.WriteLine(permutation_proccessed_threshold.ToString("00%") + ". " + Convert.ToString(permutation_proccessed_num));
                            //    permutation_proccessed_threshold += 0.01;
                            //}
                            permutation_proccessed_num++;
                            permutation_proccessed_total++;
                            if (permutation_proccessed_num == 10000)
                            {
                                Console.WriteLine(permutation_proccessed_total);
                                permutation_proccessed_num = 0;
                            }
                        }
                        cards[a].card_taken = false;
                    }
                }
            }
        }
    }
    class combination_search_win_cards_v2_one_permutation_for_one_card_cls
    {
        public int cards_size;
        long expected_permutaion_num;
        permutation_card_cls[] cards;
        permutation_card_cls[] card_of_stages;
        public cards_array_in_out_cls Permutation;
        public combination_found_output_cls combination_found_output;
        cards_combination_cls cards_combination;
        Cards_all_cards_enumeration card_for_combinations;
        public combination_search_win_cards_v2_one_permutation_for_one_card_cls(Cards_all_cards_enumeration card, int cards_num)
        {
            cards_size = cards_num;
            expected_permutaion_num = 1;
            card_for_combinations = card;
            for (int a = 51; a > 52 - cards_size; a--)
            {
                expected_permutaion_num *= a;
            }
            cards = new permutation_card_cls[52];
            card_of_stages = new permutation_card_cls[cards_num];
            for (int a = 0; a < cards_num; a++)
            {
                card_of_stages[a] = new permutation_card_cls();
            }
            for (int a = 0; a < 52; a++)
            {
                cards[a] = new permutation_card_cls();
                cards[a].number = a;
                cards[a].card_taken = false;
            }
            Permutation = new cards_array_in_out_cls();
            Permutation.AddArrayElement(cards_size);
            combination_found_output = new combination_found_output_cls();
            cards_combination = new cards_combination_cls();
        }
        long permutation_proccessed_num = 0;
        long permutation_proccessed_total = 0;
        double permutation_proccessed_threshold = 0.01;
        int find_permutations_function_start = 0;
        int find_permutations_rec_stage = 0;
        cards_array_in_out_cls cards_of_calc;
        Cards_combination_win_enum win_combination;
        public void find_win_combinations(bool print_yes_no = false)
        {
            if (cards_size <= 7)
            {
                if (find_permutations_function_start == 0)
                {
                    Console.WriteLine(expected_permutaion_num);
                    find_permutations_function_start = 1;
                    find_permutations_rec_stage = 0;
                    permutation_proccessed_num = 0;
                    if (print_yes_no == true)
                    {
                        
                        Console.WriteLine(expected_permutaion_num);
                        
                    }
                }
                int func_stage = find_permutations_rec_stage;
                for (int a = 0; a < 52; a++)
                {
                    if (func_stage == 0)
                    {
                        a = (int)card_for_combinations;
                    }
                    if (cards[a].card_taken == false)
                    {
                        cards[a].card_taken = true;
                        card_of_stages[func_stage].number = a;
                        if (func_stage < cards_size - 1)
                        {
                            find_permutations_rec_stage = func_stage + 1;
                            find_win_combinations(print_yes_no);
                        }
                        else
                        {
                            for (int card_select = 0; card_select < cards_size; card_select++)
                            {
                                Permutation.array[card_select] = (Cards_all_cards_enumeration)card_of_stages[card_select].number;
                                Permutation.card_numbers[card_select] = card_of_stages[card_select].number;
                            }
                            win_combination = Cards_combination_win_enum.HighCard;
                            win_combination =
                            cards_combination.find_highest_combination_via_if(Permutation);
                            combination_found_output.Add(win_combination);
                            if ((print_yes_no == true) && (win_combination == Cards_combination_win_enum.One_pair_of_a_kind))
                            {
                                for (int card_select = 0; card_select < cards_size; card_select++)
                                {
                                    Console.Write(Permutation.array[card_select].ToString());
                                    Console.Write(" ");
                                }
                                Console.Write("\r\n");
                            }
                            //permutation_proccessed_num++;
                            //if ((double)permutation_proccessed_num / (double)expected_permutaion_num >= permutation_proccessed_threshold)
                            //{
                            //    Console.WriteLine(permutation_proccessed_threshold.ToString("00%") + ". " + Convert.ToString(permutation_proccessed_num));
                            //    permutation_proccessed_threshold += 0.01;
                            //}
                            permutation_proccessed_num++;
                            permutation_proccessed_total++;
                            if (permutation_proccessed_num == 1000000)
                            {
                                Console.WriteLine(permutation_proccessed_total);
                                permutation_proccessed_num = 0;
                            }
                        }
                        cards[a].card_taken = false;
                    }
                    if (func_stage == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
    class permutation_card_cls
    {
        public bool card_taken;
        public int number;
        public permutation_card_cls()
        {
            card_taken = false;
            number = 0;
        }
    }
    class permutaions_via_recursion_cls
    {
        public int cards_size;
        int expected_permutaion_num;
        permutation_card_cls[] cards;
        permutation_card_cls[] card_of_stages;
        public cards_array_in_out_cls[] Permutations;
        int Permutations_size;
        public permutaions_via_recursion_cls(int cards_num)
        {
            cards_size = cards_num;
            expected_permutaion_num = 1;
            for (int a = 52; a > 52 - cards_size; a--)
            {
                expected_permutaion_num *= a;
            }
            cards = new permutation_card_cls[52];
            card_of_stages = new permutation_card_cls[cards_num];
            for (int a = 0; a < cards_num; a++)
            {
                card_of_stages[a] = new permutation_card_cls();
            }
            for (int a = 0; a < 52; a++)
            {
                cards[a] = new permutation_card_cls();
                cards[a].number = a;
                cards[a].card_taken = false;
            }
            Permutations = new cards_array_in_out_cls[expected_permutaion_num];
            Permutations_size = 0;
            for (int a = 0; a < expected_permutaion_num; a++)
            {
                Permutations[a] = new cards_array_in_out_cls();
                Permutations[a].AddArrayElement(cards_size);
            }
        }
        int permutation_proccessed_num = 0;
        double permutation_proccessed_threshold = 0.1;
        int find_permutations_function_start = 0;
        int find_permutations_rec_stage = 0;
        public void find_permutations(bool print_yes_no = false)
        {
            if (cards_size <= 7)
            {
                if (find_permutations_function_start == 0)
                {
                    find_permutations_function_start = 1;
                    find_permutations_rec_stage = 0;
                    permutation_proccessed_num = 0;
                    if (print_yes_no == true)
                    {
                        Console.Clear();
                        Console.WriteLine(expected_permutaion_num);
                        Console.ReadKey();
                    }
                }
                int func_stage = find_permutations_rec_stage;
                for (int a = 0; a < 52; a++)
                {
                    if (cards[a].card_taken == false)
                    {
                        cards[a].card_taken = true;
                        card_of_stages[func_stage].number = a;
                        if (func_stage < cards_size - 1)
                        {
                            find_permutations_rec_stage = func_stage + 1;
                            find_permutations(print_yes_no);
                        }
                        else
                        {
                            Permutations_size++;
                            for (int card_select = 0; card_select < cards_size; card_select++)
                            {
                                Permutations[Permutations_size - 1].array[card_select] = (Cards_all_cards_enumeration)card_of_stages[card_select].number;
                                Permutations[Permutations_size - 1].card_numbers[card_select] = card_of_stages[card_select].number;
                            }
                            if (print_yes_no == true)
                            {
                                for (int card_select = 0; card_select < cards_size; card_select++)
                                {
                                    Console.Write(Permutations[Permutations_size - 1].array[card_select].ToString());
                                    Console.Write(" ");
                                }
                                Console.Write("\r\n");
                            }
                            permutation_proccessed_num++;
                            if ((double)permutation_proccessed_num / (double)expected_permutaion_num >= permutation_proccessed_threshold)
                            {
                                Console.WriteLine(permutation_proccessed_threshold.ToString("00%") + ". " + Convert.ToString(permutation_proccessed_num));
                                permutation_proccessed_threshold += 0.1;
                            }
                        }
                        cards[a].card_taken = false;
                    }
                }
            }
        }
    }
    class permutaions_via_recursion_one_permutation_cls
    {
        public int cards_size;
        int expected_permutaion_num;
        permutation_card_cls[] cards;
        permutation_card_cls[] card_of_stages;
        public cards_array_in_out_cls Permutation;
        public permutaions_via_recursion_one_permutation_cls(int cards_num)
        {
            cards_size = cards_num;
            expected_permutaion_num = 1;
            for (int a = 52; a > 52 - cards_size; a--)
            {
                expected_permutaion_num *= a;
            }
            cards = new permutation_card_cls[52];
            card_of_stages = new permutation_card_cls[cards_num];
            for (int a = 0; a < cards_num; a++)
            {
                card_of_stages[a] = new permutation_card_cls();
            }
            for (int a = 0; a < 52; a++)
            {
                cards[a] = new permutation_card_cls();
                cards[a].number = a;
                cards[a].card_taken = false;
            }
            Permutation = new cards_array_in_out_cls();
            Permutation.AddArrayElement(cards_size);
        }
        int permutation_proccessed_num = 0;
        double permutation_proccessed_threshold = 0.1;
        int find_permutations_function_start = 0;
        int find_permutations_rec_stage = 0;
        public void find_permutations(bool print_yes_no = false)
        {
            if (cards_size <= 7)
            {
                if (find_permutations_function_start == 0)
                {
                    find_permutations_function_start = 1;
                    find_permutations_rec_stage = 0;
                    permutation_proccessed_num = 0;
                    if (print_yes_no == true)
                    {
                        Console.Clear();
                        Console.WriteLine(expected_permutaion_num);
                        Console.ReadKey();
                    }
                }
                int func_stage = find_permutations_rec_stage;
                for (int a = 0; a < 52; a++)
                {
                    if (cards[a].card_taken == false)
                    {
                        cards[a].card_taken = true;
                        card_of_stages[func_stage].number = a;
                        if (func_stage < cards_size - 1)
                        {
                            find_permutations_rec_stage = func_stage + 1;
                            find_permutations(print_yes_no);
                        }
                        else
                        {
                            for (int card_select = 0; card_select < cards_size; card_select++)
                            {
                                Permutation.array[card_select] = (Cards_all_cards_enumeration)card_of_stages[card_select].number;
                                Permutation.card_numbers[card_select] = card_of_stages[card_select].number;
                            }
                            if (print_yes_no == true)
                            {
                                for (int card_select = 0; card_select < cards_size; card_select++)
                                {
                                    Console.Write(Permutation.array[card_select].ToString());
                                    Console.Write(" ");
                                }
                                Console.Write("\r\n");
                            }
                            permutation_proccessed_num++;
                            if ((double)permutation_proccessed_num / (double)expected_permutaion_num >= permutation_proccessed_threshold)
                            {
                                Console.WriteLine(permutation_proccessed_threshold.ToString("00%") + ". " + Convert.ToString(permutation_proccessed_num));
                                permutation_proccessed_threshold += 0.1;
                            }
                        }
                        cards[a].card_taken = false;
                    }
                }
            }
        }
    }
}