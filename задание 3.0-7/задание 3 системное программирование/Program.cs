using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Management;
using System;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using System.Xml.Linq;
using System.Threading;

void ex0()
{
    Console.WriteLine("Вывод чисел от 1 до 100...");
    for (int i = 1; i < 100; i++)
    {

        if (i % 5 == 0 && i % 3 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else
        {

            if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
//ex0();

void ex05()
{
    string curFile = @"C:\Users\User\Desktop\test\test.txt";
    Console.WriteLine(File.Exists(curFile) ? "файл существует." : "файла нет:(");

    if (File.Exists(curFile))
    {
        FileInfo fileInfo = new FileInfo(curFile);
        if (fileInfo.Exists)
        {
            Console.WriteLine($"Имя файла: {fileInfo.Name}");
            Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
            Console.WriteLine($"Размер: {fileInfo.Length}");
            Console.WriteLine($"Путь: {fileInfo.FullName}");
            Console.WriteLine($"Дата последнего доступа: {fileInfo.LastAccessTime}");
            Console.WriteLine($"Дата последнего изменения: {fileInfo.LastWriteTime}");
        }
    }

}

//ex05();

void ex1()
{
    string cpuInfo = string.Empty;
    ManagementClass mc = new ManagementClass("win32_processor");
    ManagementObjectCollection moc = mc.GetInstances();

    foreach (ManagementObject mo in moc)
    {
        cpuInfo = mo.Properties["processorID"].Value.ToString();
        break;
    }
    Console.WriteLine(cpuInfo);
    Console.WriteLine("Подтвердить или запретить запись? 1/2 ");
    int input = Convert.ToInt32(Console.ReadLine());
    if (input == 1)
    {
        Console.WriteLine("Запись подтверждена");
    }
    if (input == 2)
    {
        Console.WriteLine("Запись отменена");
    }
}

//ex1();

void ex2()
{
    string curFile = @"C:\Users\Софич и Владич\Desktop\test"; Console.WriteLine(Directory.Exists(curFile) ? "папка существует." : "папки нет:(");
    DirectoryInfo DirectoryInfo = new DirectoryInfo(curFile);
    if (DirectoryInfo.Exists)
    {
        long dirSize = DirectoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(file => (file).Length); Console.WriteLine("Папка весит - " + dirSize + "байт");
        int size = 100;
        if (dirSize > size)
        {
            string path = @"C:\Users\Софич и Владич\Desktop\test\";
            DirectoryInfo fileInf = new DirectoryInfo(path);
           
            foreach (FileInfo file in fileInf.GetFiles())
            {
                file.Delete();
            }
          
            Console.WriteLine("done");
        }
        else
        {
            Console.WriteLine("Папка меньшe " + size + " потому не удаляю");
        }
    }
   
}

//ex2();

void ex3()
{
    string cpuInfo = string.Empty;
    ManagementClass mc = new ManagementClass("win32_processor");
    ManagementObjectCollection moc = mc.GetInstances();

    foreach (ManagementObject mo in moc)
    {
        cpuInfo = mo.Properties["processorID"].Value.ToString();
        break;
    }
    Console.WriteLine(cpuInfo);
    start:
    int input;
    Console.WriteLine("Подтвердить или запретить запись? 1/2 ");
    while (!int.TryParse(Console.ReadLine(), out input))
    {
        Console.WriteLine("Ошибка ввода! Введите целое число");
    }
    if (input == 1)
    {
        Console.WriteLine("Запись подтверждена");
        StreamWriter sw = new StreamWriter(@"C:\Users\Софич и Владич\Desktop\test\cpu.txt");
        sw.WriteLine(cpuInfo);
        sw.Close();
        goto end;
    }
    if (input == 2)
    {
        Console.WriteLine("Запись отменена");
        goto end;
    }
    if (input != 1 )
    {
        goto start;
    }
    if (input != 2)
    {
        goto start;
    }
    end:
    Console.WriteLine();
}

//ex3();

void ex4()
{
    string curFile = @"C:\Users\Софич и Владич\Desktop\test"; Console.WriteLine(Directory.Exists(curFile) ? "папка существует." : "папки нет:(");
    DirectoryInfo DirectoryInfo = new DirectoryInfo(curFile);
    if (DirectoryInfo.Exists)
    {
        string cpuInfo = string.Empty;
        ManagementClass mc = new ManagementClass("win32_processor");
        ManagementObjectCollection moc = mc.GetInstances();

        foreach (ManagementObject mo in moc)
        {
            cpuInfo = mo.Properties["processorID"].Value.ToString();
            break;
        }
        
        StreamReader sr = new StreamReader(@"C:\Users\Софич и Владич\Desktop\test\cpu.txt");
        string CpuInfoFromTxt = sr.ReadLine();
       
        if (CpuInfoFromTxt == cpuInfo)
        {
            long dirSize = DirectoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(file => (file).Length); Console.WriteLine("Папка весит - " + dirSize + "байт");
            int size = 1000;
            if (dirSize > size)
            {
                string path = @"C:\Users\Софич и Владич\Desktop\test\";
                DirectoryInfo fileInf = new DirectoryInfo(path);

                foreach (FileInfo file in fileInf.GetFiles())
                {
                    file.Delete();
                }

                Console.WriteLine("done");
            }
            else
            {
                Console.WriteLine("Папка меньшe " + size + " потому не удаляю");
            }
        }
        else
        {
            Console.WriteLine("ОШИБКА");
        }
    }

}
//ex4();

void ex5()
{
    string cpuInfo = string.Empty;
    ManagementClass mc = new ManagementClass("win32_processor");
    ManagementObjectCollection moc = mc.GetInstances();

    foreach (ManagementObject mo in moc)
    {
        cpuInfo = mo.Properties["processorID"].Value.ToString();
        break;
    }
    Console.WriteLine(cpuInfo);
start:
    int input;
    Console.WriteLine("Подтвердить или запретить запись? 1/2 ");
    while (!int.TryParse(Console.ReadLine(), out input))
    {
        Console.WriteLine("Ошибка ввода! Введите целое число");
    }
    if (input == 1)
    {
        Console.WriteLine("Запись подтверждена");
        
        string key = "CPUINFO";
        string path = @"HKEY_CURRENT_USER\SOFTWARE\EX5";
        Registry.SetValue(path, key, cpuInfo, RegistryValueKind.String); 
        goto end;
    }
    if (input == 2)
    {
        Console.WriteLine("Запись отменена");
        goto end;
    }
    if (input != 1)
    {
        goto start;
    }
    if (input != 2)
    {
        goto start;
    }
end:
    Console.WriteLine();
}

//ex5();

void ex6()
{
    string key = "CPUINFO";
    string path = @"HKEY_CURRENT_USER\SOFTWARE\EX5";
        
    string cpuInfo = string.Empty;
    ManagementClass mc = new ManagementClass("win32_processor");
    ManagementObjectCollection moc = mc.GetInstances();

    foreach (ManagementObject mo in moc)
    {
        cpuInfo = mo.Properties["processorID"].Value.ToString();
        break;
    }

    object value = Registry.GetValue(path, key, null);

    if (value != null)
    {
        Console.WriteLine("Значение ключа в реестре: " + value.ToString());
           
        if (value.ToString() == cpuInfo)
        {
                Console.WriteLine("Значение в реестре совпадает с индентификатором CPU");
        }
        else
        {
                Console.WriteLine("ОШИБКА");          
        }
    }
    else
    {
        Console.WriteLine("Ключ в реестре не найден.");
    }

}
//ex6();

void ex7()
{
    RegistryKey currentUserKey = Registry.CurrentUser;
    RegistryKey FirstKey = currentUserKey.OpenSubKey("SOFTWARE", true);
    
    string UserPathUI;
    string StartPath = "HKEY_CURRENT_USER\\SOFTWARE";
    
    List<string> Paths = new List<string>();
    List<int> length = new List<int>();

    Paths.Add(FirstKey.ToString());
    Console.WriteLine("Начальный раздел - " + StartPath);
start:
    Console.WriteLine("Выберите действие:\n" +
                      "1 - Перейти в подраздел\n" +
                      "2 - Вернуться назад\n" +
                      "3 - Просмотреть элементы\n" +
                      "4 - Просмотреть имена и значения Value\n" +
                      "5 - Очищение консоли\n" +
                      "6 - Выход");
    try
    {
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите имя подраздела: ");
                
                try
                {
                    string UserPath = Console.ReadLine();
                    length.Add(UserPath.Length);
                   
                    RegistryKey UserKey = FirstKey.OpenSubKey(UserPath, true);
                    UserPathUI = "HKEY_CURRENT_USER\\SOFTWARE\\" + UserPath;
                    
                    Console.WriteLine(UserPathUI);

                    if (UserKey != null)
                    {
                        Console.WriteLine("Успешный вход в подраздел.");
                        Paths.Add(UserKey.ToString());

                        goto start;
                    }
                    else
                    {
                        Console.WriteLine("раздел не существует...");
                    }
                }
                catch
                {
                    Console.WriteLine("ошибка");
                }
                goto start;
            case 2:
                Console.WriteLine("Возвращаемся назад...");

                Paths.RemoveAt(Paths.Count - 1);
                string CurrentPath = Paths.Last();

                Console.WriteLine("текущий раздел - " + CurrentPath);

                goto start;
            case 3:
                string path = Paths.Last();
                string Newpath = path.Substring(path.Length - length.Last());

                Console.WriteLine("Ищем в " + Newpath);
                RegistryKey Subkeys = FirstKey.OpenSubKey(Newpath, true);
              
                if (Subkeys != null)
                {
                    string[] subKeysArr = Subkeys.GetSubKeyNames();
                    foreach (string subKey in subKeysArr)
                    {
                        Console.WriteLine("Подразделы в - " + Newpath + ": " + subKey);
                    }
                }
                else
                {
                    Console.WriteLine("раздел не существует...");
                }
                goto start;
            case 4:
                string ValuePath = Paths.Last();
                string ValueNewpath = ValuePath.Substring(ValuePath.Length - length.Last());

                Console.WriteLine("Ищем в " + ValueNewpath);
                RegistryKey ValueSubkeys = FirstKey.OpenSubKey(ValueNewpath, true);

                if (ValueSubkeys != null)
                {
                    foreach (string valueName in ValueSubkeys.GetValueNames())
                    {
                        RegistryValueKind valueKind = ValueSubkeys.GetValueKind(valueName);
                        object valueData = ValueSubkeys.GetValue(valueName);
                        Console.WriteLine("Имя ключа - " + valueName + "\n" + "Значение ключа - " + valueData);
                        Console.WriteLine("");
                    }

                }
                else
                {
                    Console.WriteLine("раздел не существует...");
                }
                goto start;
            case 5:
                Console.WriteLine("Очистка...");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                goto start;
            case 6:
                Console.WriteLine("Выход...");
                System.Threading.Thread.Sleep(200);
                break;
        }
    }
    catch
    {
        Console.WriteLine("Неверный ввод...");
        goto start;
    }
}
ex7();

