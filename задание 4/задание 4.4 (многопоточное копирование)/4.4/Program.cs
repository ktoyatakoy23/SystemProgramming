//без многопоточности
void nonMulti()
{
    string src = "C:\\test";
    string dest = "C:\\test2";

    if (Directory.Exists(src))
    {
        foreach (string filepath in Directory.GetFiles(src))
        {

            if (File.Exists(filepath))
            {
                string filename = new FileInfo(filepath).Name;
                File.Copy(src + "\\" + filename, dest + "\\" + filename);
                Console.WriteLine("Перемещен файл с именем: " + filename);
            }
            else
            {
                Console.WriteLine("файл(ы) не существует...");
            }
        }
    }
    else
    {
        Console.WriteLine("Такой папки не существует...");
    }
}

//c многопоточностью
void multi()
{
    string src = "C:\\test";
    string dest = "C:\\test2";

    if (Directory.Exists(src))
    {
        string[] files = Directory.GetFiles(src);
        Parallel.ForEach(files, files =>
        {
            if (File.Exists(files))
            {
                {
                    string filename = new FileInfo(files).Name;
                    File.Copy(src + "\\" + filename, dest + "\\" + filename);
                    Console.WriteLine("Перемещен файл с именем: " + filename);
                }

            }
            else
            {
                Console.WriteLine("файл(ы) не существует...");
            }
        });
    }
    else
    {
        Console.WriteLine("Такой папки не существует...");
    }
}

//multi();

nonMulti();