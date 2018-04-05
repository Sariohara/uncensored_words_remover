using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Words_remover
{
    public string _uncensored_words_file_path { get; private set; }
    public string _book_file_path { get; private set; }
    public string _censored_book_file_path { get; private set; }
    private List<string> _uncensored_words;
    StreamReader StrRd;

    public Words_remover(string uncensored_words_file_path, string book_file_path, string censored_book_file_path)
    {
        _uncensored_words_file_path = uncensored_words_file_path;
        _book_file_path = book_file_path;
        _censored_book_file_path = censored_book_file_path;
    }

    public void Print()
    {
        Console.WriteLine(StrRd.ReadToEnd());
    }
}

