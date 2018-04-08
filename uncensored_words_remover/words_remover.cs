using System;
using System.IO;
using System.Collections.Generic;


class Words_remover
{
    public string _uncensored_words_file_path { get; private set; }
    public string _book_file_path { get; private set; }
    public string _censored_book_file_path { get; private set; }
    public List<string> _uncensored_words { get; private set; }
    public int _uncensored_words_count { get; private set; }
    

    public Words_remover(string uncensored_words_file_path, string book_file_path, string censored_book_file_path)
    {
        _uncensored_words_file_path = uncensored_words_file_path;
        _book_file_path = book_file_path;
        _censored_book_file_path = censored_book_file_path;
        _uncensored_words = new List<string>();
        _uncensored_words_count = 0;
    }

    public void Censore_text()
    {
        Load_uncensored_words();
        try
        {
            StreamReader StrRd = new StreamReader(_book_file_path);
            MemoryStream MemStr = new MemoryStream();
            StreamWriter StrWr = new StreamWriter(MemStr);
            string line;
            while((line = StrRd.ReadLine()) != null)
            {
                Compare(ref line);
                StrWr.WriteLine(line);
            }
            StrRd.Close();

            FileStream fS = new FileStream(_censored_book_file_path, FileMode.OpenOrCreate);
            fS.SetLength(0);
            MemStr.Seek(0,SeekOrigin.Begin);
            MemStr.CopyTo(fS);
            fS.Close();            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }    

    }

    private void Load_uncensored_words()
    {
        try
        {
            StreamReader StrRd = new StreamReader(_uncensored_words_file_path);
            string line;
            while ((line = StrRd.ReadLine()) != null)
            {
                _uncensored_words.Add(line);
            }
            StrRd.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    } 

    private void Compare(ref string line)
    {
        string[] words = Get_words_from_line(ref line);
        line = "";
        bool control = false;
        foreach(string word in words)
        {
            foreach(string uncensored_word in _uncensored_words)
            {
                if (word.ToLower() == uncensored_word.ToLower())
                {
                    control = true;
                    _uncensored_words_count++;
                    for (int i = 0; i < word.Length; i++)
                    {
                        line += "*";
                    }
                }
            }
            if (!control)
            {
                line += word;
            }
            line += " ";
            control = false;
        }
    }

    private string[] Get_words_from_line(ref string line)
    {
        string[] separators = new string[] { " ", "  ", "   ", "    ", "-" };
        string[] words = line.Split(separators, StringSplitOptions.None);

        return words;
    }
    
    
}

