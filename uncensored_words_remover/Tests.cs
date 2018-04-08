using System;
using System.IO;


class Tests
{
    public static void Main()
    {
        MemoryStream MemStr = new MemoryStream();
        Error_messenger err = new Error_messenger(ref MemStr);
        string words_input_path = "uncensored_words.txt"; //words input file
        string book_input_path= "book.txt"; // book input file
        string book_output_file = "censored_book.txt"; //book output file

        //constructor tests
        {

            Words_remover obj = new Words_remover(words_input_path, book_input_path, book_output_file);
            if (obj._uncensored_words_file_path != words_input_path || obj._book_file_path != book_input_path || obj._censored_book_file_path != book_output_file)
                err.Report_error("Error in constructor tests");
        }

        //
        {
            Words_remover obj = new Words_remover(words_input_path, book_input_path, book_output_file);
            try
            {
                obj.Censore_text();
                foreach (string word in obj._uncensored_words)
                    Console.WriteLine(word);

                Console.WriteLine(obj._uncensored_words.Count);
                Console.WriteLine(obj._uncensored_words_count);
            }
            catch (Exception ex)
            {
                err.Report_error("Unexpected exception in Censore_text() method tests: " + ex.Message);
            }
        }
        
        err.End_of_tests(); 
        Console.ReadLine();
    }
}

