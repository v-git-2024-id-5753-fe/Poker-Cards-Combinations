using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deck_cards_text;
using array_tools;
using deck_combination_find;
namespace cards_permutations_factorial
{
    class win_combination_output_cls
    {
        public long win_permutations;
        public long all_permutations;
        public double permutations_probability;
        public win_combination_output_cls()
        {
            win_permutations = 0;
            all_permutations = 0;
            permutations_probability = (double)0;
        }
        public double permutations_probability_get()
        {
            permutations_probability = (double)win_permutations / (double)all_permutations;
            return permutations_probability;
        }
    }
    class Cards_permutation_factorial_cls
    {
        Deck_all_cards_text_cls Deck;
        cards_combination_cls Combination;
        int[] cards_of_a_kind;
        const long kinds_number = 13;
        const long cards_number = 52;
        int cards_in_deck = 52;
        public Cards_permutation_factorial_cls()
        {
            Deck = new Deck_all_cards_text_cls();
            cards_of_a_kind = new int[kinds_number];
            for (int a = 0; a < kinds_number; a++)
            {
                cards_of_a_kind[a] = 4;
            }
            Combination = new cards_combination_cls();
        }
        public void Take_Card(Cards_all_cards_enumeration card)
        {
            for (int a = 0; a < cards_number; a++)
            {
                if (Deck.Cards[a].card == card)
                {
                    Deck.Cards[a].state = Cards_all_cards_state_enum.Not_in_Deck;
                }
            }
            Cards_in_deck_recount();
        }
        public void Return_Card(Cards_all_cards_enumeration card)
        {
            for (int a = 0; a < cards_number; a++)
            {
                if (Deck.Cards[a].card == card)
                {
                    Deck.Cards[a].state = Cards_all_cards_state_enum.In_Deck;
                }
            }
            Cards_in_deck_recount();
        }
        void Cards_in_deck_recount()
        {
            for (int a = 0; a < kinds_number; a++)
            {
                cards_of_a_kind[(int)Deck.Cards[a].kind] = 0;
            }
            cards_in_deck = 0;
            for (int a = 0; a < cards_number; a++)
            {
                if (Deck.Cards[a].state == Cards_all_cards_state_enum.In_Deck)
                {
                    cards_of_a_kind[(int)Deck.Cards[a].kind] += 1;
                    cards_in_deck += 1;
                }
            }
        }
        public void pair_of_a_kind_2_positions()
        {
            int permutations_for_one_kind;
            int permutations_for_all_kinds = 0;
            for (int a = 0; a < kinds_number; a++)
            {
                permutations_for_one_kind = cards_of_a_kind[a]*(cards_of_a_kind[a] - 1);
                permutations_for_all_kinds += permutations_for_one_kind;
            }
            Console.WriteLine(permutations_for_all_kinds);
        }
        int free_positions_number_1_card_position_taken(int cards_num)
        {
            return cards_num + 1;
        }
        int free_positions_number_0_card_position_taken()
        {
            return 1;
        }
        long free_positions_variations_pair(int cards_num)
        {
            if (cards_num == 3)
            {
                return 3;
            }
            if (cards_num == 4)
            {
                return 3 + 3;
            }
            if (cards_num == 5)
            {
                return 4 + 3 + 3;
            }
            if (cards_num == 6)
            {
                return 5 + 4 + 3 + 3;
            }
            if (cards_num == 7)
            {
                return 6 + 5 + 4 + 3 + 3;
            }
            return 1;
        }
        public bool pair_of_a_kind(cards_array_in_out_cls cards_in, int cards_pos, out win_combination_output_cls result_out)
        {
            result_out = new win_combination_output_cls();
            if ((cards_in.array.Length == 0) && (cards_pos == 2))
            {               
                for (int a = 0; a < kinds_number; a++)
                {
                    if (cards_of_a_kind[a] >= 2)
                        {
                        result_out.win_permutations += (cards_of_a_kind[a]) *
                            (cards_of_a_kind[a] - 1);
                    }                    
                }
                result_out.all_permutations = 1;
                for (int a = 0; a < cards_pos; a++)
                {
                    result_out.all_permutations *= (cards_in_deck - a);
                }
                return true;
            }
            if ((cards_in.array.Length == 0) && (cards_pos == 3))
            {
                for (int a = 0; a < kinds_number; a++)
                {
                    if (cards_of_a_kind[a] >= 2)
                    {
                        result_out.win_permutations += (cards_of_a_kind[a]) *
                            (cards_of_a_kind[a] - 1) * free_positions_variations_pair(cards_pos) * 48;
                    }
                }
                result_out.all_permutations = 1;
                for (int a = 0; a < cards_pos; a++)
                {
                    result_out.all_permutations *= (cards_in_deck - a);
                }
                return true;
            }
            if ((cards_in.array.Length == 0) && (cards_pos == 4))
            {
                for (int a = 0; a < kinds_number; a++)
                {
                    result_out.win_permutations += (cards_of_a_kind[a]) *
                             (cards_of_a_kind[a] - 1) * free_positions_variations_pair(cards_pos) * 48 * 44;
                }
                result_out.all_permutations = 1;
                for (int a = 0; a < cards_pos; a++)
                {
                    result_out.all_permutations *= (cards_in_deck - a);
                }
                return true;
            }
            if ((cards_in.array.Length == 0) && (cards_pos == 5))
            {
                for (int a = 0; a < kinds_number; a++)
                {
                    if (cards_of_a_kind[a] >= 2)
                    {
                        result_out.win_permutations += (cards_of_a_kind[a]) *
                             (cards_of_a_kind[a] - 1) * free_positions_variations_pair(cards_pos) * 48 * 44 * 40;
                    }
                }
                result_out.all_permutations = 1;
                for (int a = 0; a < cards_pos; a++)
                {
                    result_out.all_permutations *= (cards_in_deck - a);
                }
                return true;
            }
            if ((cards_in.array.Length == 0) && (cards_pos == 6))
            {
                for (int a = 0; a < kinds_number; a++)
                {
                    if (cards_of_a_kind[a] >= 2)
                    {
                        result_out.win_permutations += (cards_of_a_kind[a]) *
                             (cards_of_a_kind[a] - 1) * free_positions_variations_pair(cards_pos) * 48 * 44 * 40 * 36;
                    }
                }
                result_out.all_permutations = 1;
                for (int a = 0; a < cards_pos; a++)
                {
                    result_out.all_permutations *= (cards_in_deck - a);
                }
                return true;
            }
            if ((cards_in.array.Length == 0) && (cards_pos == 7))
            {
                for (int a = 0; a < kinds_number; a++)
                {
                    if (cards_of_a_kind[a] >= 2)
                    {
                        result_out.win_permutations += (cards_of_a_kind[a]) *
                             (cards_of_a_kind[a] - 1) * free_positions_variations_pair(cards_pos) * 48 * 44 * 40 * 36 * 32;
                    }
                }
                result_out.all_permutations = 1;
                for (int a = 0; a < cards_pos; a++)
                {
                    result_out.all_permutations *= (cards_in_deck - a);
                }
                return true;
            }
            return false;
        }
        public bool pair_of_a_kind_tmp(cards_array_in_out_cls cards_in, int cards_pos, out win_combination_output_cls[] result_out)
        {
            result_out = new win_combination_output_cls[0];
            cards_array_in_out_cls cards_found;
            // 2 cards
            if ((cards_in.array.Length == 2) && (cards_pos == 2))
            {
                result_out = new win_combination_output_cls[3];
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[0] = new win_combination_output_cls();
                    Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                    result_out[0].win_permutations = 0;
                    result_out[0].all_permutations = 1;
                    result_out[1] = new win_combination_output_cls();
                    kind = Deck.Cards[(int)cards_in.array[1]].kind;
                    result_out[1].win_permutations = 0;
                    result_out[1].all_permutations = 1;
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = result_out[0].win_permutations + result_out[1].win_permutations;
                    result_out[2].all_permutations = 1;
                }
                else
                {
                    result_out[0] = new win_combination_output_cls();
                    result_out[1] = new win_combination_output_cls();
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = 0;
                    result_out[2].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 2) && (cards_pos == 3))
            {
                result_out = new win_combination_output_cls[3];
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[0] = new win_combination_output_cls();
                    Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                    result_out[0].win_permutations = cards_of_a_kind[(int)kind];
                    result_out[0].all_permutations = cards_in_deck;
                    result_out[1] = new win_combination_output_cls();
                    kind = Deck.Cards[(int)cards_in.array[1]].kind;
                    result_out[1].win_permutations = cards_of_a_kind[(int)kind];
                    result_out[1].all_permutations = cards_in_deck;
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = result_out[0].win_permutations + result_out[1].win_permutations;
                    result_out[2].all_permutations = cards_in_deck;
                }
                else
                {
                    result_out[0] = new win_combination_output_cls();
                    result_out[1] = new win_combination_output_cls();
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = 0;
                    result_out[2].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 2) && (cards_pos == 4))
            {
                result_out = new win_combination_output_cls[3];
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[0] = new win_combination_output_cls();
                    Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                    result_out[0].win_permutations = 2 * cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]);
                    result_out[0].all_permutations = (cards_in_deck) * (cards_in_deck - 1);
                    result_out[1] = new win_combination_output_cls();
                    kind = Deck.Cards[(int)cards_in.array[1]].kind;
                    result_out[1].win_permutations = 2 * cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]);
                    result_out[1].all_permutations = (cards_in_deck) * (cards_in_deck - 1);
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = result_out[1].win_permutations + result_out[0].win_permutations;
                    result_out[2].all_permutations = (cards_in_deck) * (cards_in_deck - 1);
                }
                else
                {
                    result_out[0] = new win_combination_output_cls();
                    result_out[1] = new win_combination_output_cls();
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = result_out[0].win_permutations + result_out[1].win_permutations;
                    result_out[2].all_permutations = cards_in_deck;
                }
                return true;
            }
            if ((cards_in.array.Length == 2) && (cards_pos == 5))
            {
                result_out = new win_combination_output_cls[3];
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[0] = new win_combination_output_cls();
                    Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                    result_out[0].win_permutations = 3 * cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4);
                    result_out[0].all_permutations = (cards_in_deck) * (cards_in_deck - 1) * (cards_in_deck - 2);
                    result_out[1] = new win_combination_output_cls();
                    kind = Deck.Cards[(int)cards_in.array[1]].kind;
                    result_out[1].win_permutations = 3 * cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4);
                    result_out[1].all_permutations = (cards_in_deck) * (cards_in_deck - 1) * (cards_in_deck - 2);
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = result_out[0].win_permutations + result_out[1].win_permutations;
                    result_out[2].all_permutations = (cards_in_deck) * (cards_in_deck - 1) * (cards_in_deck - 2);
                }
                else
                {
                    result_out[0] = new win_combination_output_cls();
                    result_out[1] = new win_combination_output_cls();
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = 0;
                    result_out[2].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 2) && (cards_pos == 6))
            {
                result_out = new win_combination_output_cls[3];
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[0] = new win_combination_output_cls();
                    Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                    result_out[0].win_permutations = 4 * cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4) * (cards_in_deck - cards_of_a_kind[(int)kind] - 8);
                    result_out[0].all_permutations = (cards_in_deck) * (cards_in_deck - 1) * (cards_in_deck - 2) * (cards_in_deck - 3);
                    result_out[1] = new win_combination_output_cls();
                    kind = Deck.Cards[(int)cards_in.array[1]].kind;
                    result_out[1].win_permutations = 4 * cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4) * (cards_in_deck - cards_of_a_kind[(int)kind] - 8);
                    result_out[1].all_permutations = (cards_in_deck) * (cards_in_deck - 1) * (cards_in_deck - 2) * (cards_in_deck - 3);
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = result_out[0].win_permutations + result_out[1].win_permutations;
                    result_out[2].all_permutations = (cards_in_deck) * (cards_in_deck - 1) * (cards_in_deck - 2) * (cards_in_deck - 3);
                }
                else
                {
                    result_out[0] = new win_combination_output_cls();
                    result_out[1] = new win_combination_output_cls();
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = 0;
                    result_out[2].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 2) && (cards_pos == 7))
            {
                result_out = new win_combination_output_cls[3];
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[0] = new win_combination_output_cls();
                    Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                    result_out[0].win_permutations = 5 * cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4) *
                        (cards_in_deck - cards_of_a_kind[(int)kind] - 8) * (cards_in_deck - cards_of_a_kind[(int)kind] - 12);
                    result_out[0].all_permutations = (cards_in_deck) * (cards_in_deck - 1) * (cards_in_deck - 2) * (cards_in_deck - 3) * (cards_in_deck - 4);
                    result_out[1] = new win_combination_output_cls();
                    kind = Deck.Cards[(int)cards_in.array[1]].kind;
                    result_out[1].win_permutations = 5 * cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4) *
                        (cards_in_deck - cards_of_a_kind[(int)kind] - 8) * (cards_in_deck - cards_of_a_kind[(int)kind] - 12);
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = result_out[0].win_permutations + result_out[1].win_permutations;
                    result_out[2].all_permutations = (cards_in_deck) * (cards_in_deck - 1) * (cards_in_deck - 2) * (cards_in_deck - 3) * (cards_in_deck - 4);
                }
                else
                {
                    result_out[0] = new win_combination_output_cls();
                    result_out[1] = new win_combination_output_cls();
                    result_out[2] = new win_combination_output_cls();
                    result_out[2].win_permutations = 0;
                    result_out[2].all_permutations = 1;
                }
                return true;
            }
            // 3 cards
            if ((cards_in.array.Length == 3) && (cards_pos == 3))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = 0;
                        result_out[a].all_permutations = 1;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;                
            }
            if ((cards_in.array.Length == 3) && (cards_pos == 4))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind];
                        result_out[a].all_permutations = cards_in_deck;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 3) && (cards_pos == 5))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind]*(cards_in_deck - cards_of_a_kind[(int)kind]);
                        result_out[a].all_permutations = cards_in_deck*(cards_in_deck - 1);
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 3) && (cards_pos == 6))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4);
                        result_out[a].all_permutations = cards_in_deck * (cards_in_deck - 1) * (cards_in_deck - 2);
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 3) && (cards_pos == 7))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4) * (cards_in_deck - cards_of_a_kind[(int)kind] - 8);
                        result_out[a].all_permutations = cards_in_deck * (cards_in_deck - 1) * (cards_in_deck - 2) * (cards_in_deck - 3);
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            // 4 cards
            if ((cards_in.array.Length == 4) && (cards_pos == 4))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = 0;
                        result_out[a].all_permutations = 1;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 4) && (cards_pos == 5))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind];
                        result_out[a].all_permutations = cards_in_deck;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 4) && (cards_pos == 6))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]);
                        result_out[a].all_permutations = cards_in_deck * (cards_in_deck - 1);
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 4) && (cards_pos == 7))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]) * (cards_in_deck - cards_of_a_kind[(int)kind] - 4);
                        result_out[a].all_permutations = cards_in_deck * (cards_in_deck - 1) * (cards_in_deck - 2);
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            // 5 cards
            if ((cards_in.array.Length == 5) && (cards_pos == 5))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = 0;
                        result_out[a].all_permutations = 1;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 5) && (cards_pos == 6))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind];
                        result_out[a].all_permutations = cards_in_deck;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 5) && (cards_pos == 7))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind] * (cards_in_deck - cards_of_a_kind[(int)kind]);
                        result_out[a].all_permutations = cards_in_deck * (cards_in_deck - 1);
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            // 6 cards
            if ((cards_in.array.Length == 6) && (cards_pos == 6))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = 0;
                        result_out[a].all_permutations = 1;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            if ((cards_in.array.Length == 6) && (cards_pos == 7))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = cards_of_a_kind[(int)kind];
                        result_out[a].all_permutations = cards_in_deck;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            // 7 cards
            if ((cards_in.array.Length == 7) && (cards_pos == 7))
            {
                result_out = new win_combination_output_cls[cards_in.array.Length + 1];
                result_out[result_out.Length - 1] = new win_combination_output_cls();
                if (Combination.find_one_pair_of_a_kind(cards_in, out cards_found) == false)
                {
                    result_out[result_out.Length - 1] = new win_combination_output_cls();
                    for (int a = 0; a < cards_in.array.Length - 1; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                        Cards_all_cards_kind_enumeration kind = Deck.Cards[(int)cards_in.array[0]].kind;
                        result_out[a].win_permutations = 0;
                        result_out[a].all_permutations = 1;
                        result_out[result_out.Length - 1].win_permutations += result_out[a].win_permutations;
                    }
                    result_out[result_out.Length - 1].all_permutations = result_out[0].all_permutations;
                }
                else
                {
                    for (int a = 0; a < cards_in.array.Length; a++)
                    {
                        result_out[a] = new win_combination_output_cls();
                    }
                    result_out[result_out.Length - 1].win_permutations = 1;
                    result_out[result_out.Length - 1].all_permutations = 1;
                }
                return true;
            }
            return false;
        }
    }
}
