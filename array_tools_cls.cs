using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deck_cards_text;
namespace array_tools
{
    class cards_array_in_out_cls
    {
        public Cards_all_cards_enumeration[] array;
        public int[] card_numbers;
        public cards_array_in_out_cls(int num = 0)
        {
            array = new Cards_all_cards_enumeration[num];
            card_numbers = new int[num];
        }
        public void AddArrayElement()
        {
            Array.Resize(ref array, array.Length + 1);
            Array.Resize(ref card_numbers, array.Length + 1);
        }
        public void AddArrayElement(int size)
        {
            Array.Resize(ref array, array.Length + size);
            Array.Resize(ref card_numbers, card_numbers.Length + size);
        }
    }
    class array_tools_cls
    {
        public void merge_2_arrays(cards_array_in_out_cls arr_1_in,
            cards_array_in_out_cls arr_2_in, out cards_array_in_out_cls arr_out)
        {
            int arr_out_size = arr_1_in.array.Length + arr_2_in.array.Length;
            arr_out = new cards_array_in_out_cls();
            arr_out.AddArrayElement(arr_out_size);
            Array.Copy(arr_1_in.array, 0, arr_out.array, 0, arr_1_in.array.Length);
            Array.Copy(arr_2_in.array, 0, arr_out.array, arr_1_in.array.Length, arr_2_in.array.Length);
            Array.Copy(arr_1_in.card_numbers, 0, arr_out.card_numbers, 0, arr_1_in.array.Length);
            Array.Copy(arr_2_in.card_numbers, 0, arr_out.card_numbers, arr_1_in.array.Length, arr_2_in.array.Length);
        }
        public void merge_2_arrays_reenumerate(cards_array_in_out_cls arr_1_in,
            cards_array_in_out_cls arr_2_in, out cards_array_in_out_cls arr_out)
        {
            int arr_out_size = arr_1_in.array.Length + arr_2_in.array.Length;
            arr_out = new cards_array_in_out_cls();
            arr_out.AddArrayElement(arr_out_size);
            Array.Copy(arr_1_in.array, 0, arr_out.array, 0, arr_1_in.array.Length);
            Array.Copy(arr_2_in.array, 0, arr_out.array, arr_1_in.array.Length, arr_2_in.array.Length);
            for (int a = 0; a < arr_out.array.Length; a++)
            {
                arr_out.card_numbers[a] = a;
            }
        }
        public void make_arrays_one_array(cards_array_in_out_cls[] arr_in, 
            out cards_array_in_out_cls arr_out)
        {
            int arr_out_size = arr_in.Length;
            arr_out = new cards_array_in_out_cls();
            arr_out.AddArrayElement(arr_out_size);
            
            for (int a = 0; a < arr_in.Length; a++)
            {
                arr_out.array[a] = arr_in[a].array[0];
                arr_out.card_numbers[a] = arr_in[a].card_numbers[0];
            }
        }
        public void substract_2_arrays(cards_array_in_out_cls arr_1_in,
            cards_array_in_out_cls arr_2_in, out cards_array_in_out_cls arr_out)
        {
            int arr_out_size = arr_1_in.array.Length - arr_2_in.array.Length;
            arr_out = new cards_array_in_out_cls();
            bool check_output;
            arr_out.AddArrayElement(arr_out_size);
            int arr_out_counter = 0;
            for (int a = 0; a < arr_1_in.card_numbers.Length; a++)
            {
                check_output = true;
                for (int b = 0; b < arr_2_in.card_numbers.Length; b++)
                {
                    if (arr_1_in.card_numbers[a] == arr_2_in.card_numbers[b])
                    {
                        check_output = false;                        
                    }
                }
                if (check_output == true)
                {
                    arr_out_counter++;
                    arr_out.card_numbers[arr_out_counter - 1] = arr_1_in.card_numbers[a];
                    arr_out.array[arr_out_counter - 1] = arr_1_in.array[a];
                }
            }            
        }
    }
}
