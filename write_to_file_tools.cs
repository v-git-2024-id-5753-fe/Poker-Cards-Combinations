using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deck_combination_find;
using deck_cards_text;
using System.IO;
namespace write_to_file_tools
{
    class write_to_file_tools_cls
    {
        DateTime time;
        string time_str;
        public write_to_file_tools_cls()
        {
            time = DateTime.Now;
            time_str = Convert.ToString(time.Year) + "_" +
                Convert.ToString(time.Month) + "_" +
                Convert.ToString(time.Day) + "_" +
                Convert.ToString(time.Hour) + "_" +
                Convert.ToString(time.Minute) + "_" +
                Convert.ToString(time.Second);
        }
        public void writedata(Cards_all_cards_enumeration card, int positions, combination_found_output_cls result)
        {
            string file_name = card.ToString() + "_" + positions.ToString() + "_" + time_str + ".txt";
            StreamWriter file_writter = new StreamWriter(file_name);
            file_writter.WriteLine(card.ToString());
            for (int a = 0; a < result.combinations_size.Length; a++)
            {
                file_writter.WriteLine(((Cards_combination_win_enum)a).ToString() + "\t" + result.combinations_size[a].ToString());
            }
            file_writter.WriteLine("Total_Combinations" + "\t" + result.total_combinations.ToString());
            file_writter.Close();
        }
    }
}
