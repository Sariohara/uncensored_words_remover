using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tests
{
    public static void Main()
    {
        MemoryStream MemStr = new MemoryStream();
        Error_messenger err = new Error_messenger(ref MemStr);

        //constructor tests
        {
            string file_path1 = "words_input_file";
            string file_path2 = "book_input_file";
            string file_path3 = "book_output_file";
            Words_remover obj = new Words_remover(file_path1, file_path2, file_path3);
            if (obj._uncensored_words_file_path != file_path1 || obj._book_file_path != file_path2 || obj._censored_book_file_path != file_path3)
                err.Report_error("Error in constructor tests");
        }

        err.End_of_tests(); 
        Console.ReadLine();

    }
}

