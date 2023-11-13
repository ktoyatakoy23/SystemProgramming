using Microsoft.Win32;
using System.Runtime;
using System.IO;

void Main()
{
    List<string> CurrentDirectory = new List<string>();
    string StartDirectory = @"C:";
    CurrentDirectory.Add(StartDirectory);
    void four_one()
    {
        
        Console.WriteLine("Выберите действие:\n" +
                          "1 - Передвижение по директориям.\n" +
                          "2 - Вернуться назад\n" +
                          "3 - Создать папку с заданным именем\n" +
                          "4 - Переименовать файл/папку\n" +
                          "5 - Создать пустой текстовый файл\n" +
                          "6 - Удалить текстовый файл\n" +
                          "7 - Выведение списка папок и файлов в нынешней директории\n" +
                          "8 - Выход\n" +
                          "9 - Очистка консоли");
        try
        {
            Console.WriteLine("");
            Console.Write("Ваш ввод: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GoToDirectory();
                    break;
                case 2:
                    GoBack();
                    break;
                case 3:
                    NewFolder();
                    break;
                case 4:
                    Rename();
                    break;
                case 5:
                    NewTxtFile();
                    break;
                case 6:
                    DeleteTxtFile(); 
                    break;
                case 7:
                    AllFilesAndFolders();
                    break;
                case 8:
                    Console.WriteLine("Выход...");
                    System.Threading.Thread.Sleep(200);
                    break;
                case 9:
                    Console.WriteLine("Очистка...");
                    System.Threading.Thread.Sleep(300);
                    Console.Clear();
                    four_one();
                break;
            }
        }
        catch
        {
            Console.WriteLine("Неверный ввод...");
            four_one();
        }

        void GoToDirectory()
        {
            string StartDirectory = CurrentDirectory.Last();
            Console.WriteLine("Текущеe расположение: " + StartDirectory);

            Console.Write("Куда идем? - ");
            string NewDir = Console.ReadLine();

            if (Directory.Exists(CurrentDirectory.Last() + "\\" + NewDir))
            {
                Console.WriteLine("Вошли в " + CurrentDirectory.Last() + "\\" + NewDir);
                string NewDir2 = CurrentDirectory.Last() + "\\" + NewDir;
                CurrentDirectory.Add(NewDir2);
            }
            else
            {
                Console.WriteLine("Такой папки не существует");
            }
            Console.WriteLine("");
            four_one();
        }

        void GoBack()
        {
            if (CurrentDirectory.Count > 1)
            {
                Console.WriteLine("Текущеe расположение: " + CurrentDirectory.Last() + " идем назад...");

                CurrentDirectory.RemoveAt(CurrentDirectory.Count - 1);
                Console.WriteLine("Текущеe расположение: " + CurrentDirectory.Last());

                Console.WriteLine("");
                four_one();
            }
            else
            {
                Console.WriteLine("Нельзя вернуться назад, вы находитесь в корневой директории.");
               
                Console.WriteLine("");
                four_one();
            }
        }

        void NewFolder()
        {
            Console.WriteLine("Текущеe расположение: " + CurrentDirectory.Last());

            Console.Write("Введите имя новой папки: ");
            string UserFolderName = Console.ReadLine();
            string DonePath = CurrentDirectory.Last() + "\\" + UserFolderName;
        
            if (!Directory.Exists(DonePath))
            {
                try
                {
                    Console.WriteLine("Папка с именем " + UserFolderName + " создана");
                    Directory.CreateDirectory(DonePath);
                    Console.WriteLine("");
                    four_one();
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так...");
                    Console.WriteLine("");
                    four_one();
                }
            }
            else
            {
                Console.WriteLine("Такая папка существует...");
                Console.WriteLine("");
                four_one();
            }
        }
        
        void Rename()
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Что хотите переименовать?\n" +
                                  "1 - папку\n" +
                                  "2 - файл\n" +
                                  "3 - выйти в главное меню");
                Console.Write("Ваш ввод: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        FolderRename();
                        break;
                    case 2:
                       FileRename();
;                        break;
                    case 3:
                        four_one();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Неверный ввод...");
                Rename();
            }

            void FolderRename()
            {
                Console.WriteLine("Текущеe расположение: " + CurrentDirectory.Last());

                Console.Write("Введите имя папки для переименования: ");
                string UserFolderName = Console.ReadLine();
                string DonePath = CurrentDirectory.Last() + "\\" + UserFolderName;


                if (Directory.Exists(DonePath))
                {
                    try
                    {
                        string src = DonePath;

                        Console.Write("Введите новое имя папки для переименования: ");
                        string NewUserFolderName = Console.ReadLine();
                        string NewDonePath = CurrentDirectory.Last() + "\\" + NewUserFolderName;

                        string dest = NewDonePath;

                        try
                        {
                            Directory.Move(src, dest);

                            if (!Directory.Exists(src))
                            {
                                Console.WriteLine("Папка: " + UserFolderName + " переименована в: " + NewUserFolderName);

                                Console.WriteLine("");
                                four_one();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("не удалось переименовать:( попробуй еще раз...");
                            Console.WriteLine("");

                            Rename();
                        }

                        Console.WriteLine("");
                    }
                    catch
                    {
                        Console.WriteLine("Что-то пошло не так...");
                        Console.WriteLine("");
                        Rename();
                    }
                }
                else
                {
                    Console.WriteLine("Такой папки не существует...");
                    Console.WriteLine("");
                    Rename();
                }
            }
            
            void FileRename()
            {
                Console.WriteLine("Текущеe расположение: " + CurrentDirectory.Last());

                Console.Write("Введите имя файла для переименования: ");
                string UserFileName = Console.ReadLine();
                string DonePath = CurrentDirectory.Last() + "\\" + UserFileName;


                if (File.Exists(DonePath))
                {
                    try
                    {
                        string src = DonePath;

                        Console.Write("Введите новое имя файла для переименования: ");
                        string NewUserFileName = Console.ReadLine();
                        string NewDonePath = CurrentDirectory.Last() + "\\" + NewUserFileName;

                        string dest = NewDonePath;

                        try
                        {
                            File.Move(src, dest);

                            if (!File.Exists(src))
                            {
                                Console.WriteLine("Файл: " + UserFileName + " переименован в: " + NewUserFileName);

                                Console.WriteLine("");
                                four_one();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("не удалось переименовать:( попробуй еще раз...");
                            Console.WriteLine("");

                            Rename();
                        }

                        Console.WriteLine("");
                    }
                    catch
                    {
                        Console.WriteLine("Что-то пошло не так...");
                        Console.WriteLine("");
                        Rename();
                    }
                }
                else
                {
                    Console.WriteLine("Такой папки не существует...");
                    Console.WriteLine("");
                    Rename();
                }
            }
        }
        
        void NewTxtFile()
        {
            Console.WriteLine("Текущеe расположение: " + CurrentDirectory.Last());

            Console.Write("Введите имя файла для создания: ");
            string UserFolderName = Console.ReadLine();
            string DonePath = CurrentDirectory.Last() + "\\" + UserFolderName + ".txt";

            
            FileInfo fi1 = new FileInfo(DonePath);

            if (!fi1.Exists)
            {
                Console.WriteLine("файл " + UserFolderName + ".txt" + " создан:)");
                using (StreamWriter sw = fi1.CreateText())

                Console.WriteLine("");
                four_one();
            }
            else
            {
                Console.WriteLine("Такой файл уже существует...");
                Console.WriteLine("");
                four_one();
            }
        }
        
        void DeleteTxtFile()
        {
            Console.WriteLine("Текущеe расположение: " + CurrentDirectory.Last());

            Console.Write("Введите имя файла для удаления: ");
            string UserFolderName = Console.ReadLine();
            string DonePath = CurrentDirectory.Last() + "\\" + UserFolderName + ".txt";


            FileInfo fi1 = new FileInfo(DonePath);

            if (fi1.Exists)
            {
                Console.WriteLine("файл " + UserFolderName + ".txt" + " удален:(");
                fi1.Delete();

                Console.WriteLine("");
                four_one();
            }
            else
            {
                Console.WriteLine("Такого файла нет..");
                Console.WriteLine("");
                four_one();
            }
        }

        void AllFilesAndFolders()
        {
            Console.WriteLine("Текущеe расположение: " + CurrentDirectory.Last());

            Console.WriteLine("Папки: ");
            string[] allfolders = Directory.GetDirectories(CurrentDirectory.Last());
            foreach (string folder in allfolders)
            {
                Console.WriteLine(folder);
            }
            
            Console.WriteLine("");
            Console.WriteLine("Файлы: ");
            string[] allfiles = Directory.GetFiles(CurrentDirectory.Last());
            foreach (string filename in allfiles)
            {
                Console.WriteLine(filename);
            }
            Console.WriteLine("");
            four_one();
        }
    }
    four_one();
}
Main();
