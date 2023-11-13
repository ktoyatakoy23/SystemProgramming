using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Data;
using LibreHardwareMonitor;
using System.Diagnostics;
using LibreHardwareMonitor.Hardware;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using static System.Net.WebRequestMethods;
using System.Drawing;

namespace SQLiteSample
{
    public partial class Form1 : Form
    {
        private String dbFileName;
        private SQLiteConnection m_dbConnection;
        private SQLiteCommand m_sqlCmd;
        Computer computer = new Computer();
        List<string> PathList = new List<string>();
        List<string> PathListGit = new List<string>();



        public Form1()
        {
            InitializeComponent();

            create_btn.Click += create_btn_Click;
            del_btn.Click += del_btn_Click;
        }
      


        private void Form1_Load(object sender, EventArgs e)
        {
            m_dbConnection = new SQLiteConnection();


            dbFileName = @"C:\Users\User\Desktop\1\колледж программирования\БД ЗАДАНИЕ 2\source\testDB.db";

            if (!System.IO.File.Exists(dbFileName))
                MessageBox.Show("Please, create DB and blank table (Push \"Create\" button)");

            try
            {
                m_dbConnection = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3; New=False; Compress=True;");
                m_dbConnection.Open();
                MessageBox.Show("база данных открыта");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            

        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            string UserInputFor_TEST_TEXT = TEST_TEXT.Text;
            string UserInputFor_TEST_TEXT2 = TEST_TEXT2.Text;
            string UserInputFor_TEST_TEXT3 = TEST_TEXT3.Text;
            string CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            string sql_add = "INSERT INTO TestDb (DATE, TEST_TEXT, TEST_TEXT2, TEST_TEXT3) VALUES (@значение, @значение1,  @значение2,  @значение3 );";
            SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

            m_sqlCmd.Parameters.AddWithValue("@значение", CurrentTime);
            m_sqlCmd.Parameters.AddWithValue("@значение1", UserInputFor_TEST_TEXT);
            m_sqlCmd.Parameters.AddWithValue("@значение2", UserInputFor_TEST_TEXT2);
            m_sqlCmd.Parameters.AddWithValue("@значение3", UserInputFor_TEST_TEXT3);

            m_sqlCmd.ExecuteNonQuery();
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            string sql_delete = "DELETE FROM TestDb WHERE id = (SELECT id  FROM TestDb ORDER BY id DESC LIMIT 1);";
            SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_delete, m_dbConnection);
            m_sqlCmd.ExecuteNonQuery();
        }

        private async void startJournal_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                for (int i = 0; ; i++)
                {

                    computer.Open();
                    computer.IsCpuEnabled = true;
                    computer.IsGpuEnabled = true;
                    float cpuLoad = GetCpuLoad();

                    DriveInfo drive = new DriveInfo(@"C:\");
                    long freeSpace = drive.AvailableFreeSpace;
                    
                    float freeSpaceGB;
                    freeSpaceGB = (float)freeSpace / (1024 * 1024 * 1024);
                   
                    PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available Mbytes");
                    float ramUsage = ramCounter.NextValue();
                    
                    //string TimeOfLog = DateTime.Now.ToString("HH:mm:ss");
                    long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    
                    string gpuLoad = "intel sucks"; /*GetGPULoad(computer);*/
                    string gpuTemp = "intel sucks"; /*GetGPUTemperature(computer);*/

                    float cpuTemp = GetCPUTemperature(computer);
                    //unix - время
                    string sql_add = "INSERT INTO HardwareUsage (CPUUsage, CPUTemp, RAMUsage, GPUUsage, GPUTemp, HardUsage, TimeOfLog) VALUES (@cpuUsage, @cpuTemp,  @ramUsage,  @gpuUsage, @gpuTemp, @HardUsage, @TimeOfLog );";
                    SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

                    m_sqlCmd.Parameters.AddWithValue("@cpuUsage", cpuLoad);
                    m_sqlCmd.Parameters.AddWithValue("@cpuTemp", cpuTemp);
                    m_sqlCmd.Parameters.AddWithValue("@ramUsage", ramUsage);
                    m_sqlCmd.Parameters.AddWithValue("@gpuUsage", gpuLoad);
                    m_sqlCmd.Parameters.AddWithValue("@gpuTemp", gpuTemp);
                    m_sqlCmd.Parameters.AddWithValue("@HardUsage", freeSpaceGB);
                    m_sqlCmd.Parameters.AddWithValue("@TimeOfLog", TimeOfLog);

                    m_sqlCmd.ExecuteNonQuery();

                    System.Threading.Thread.Sleep(15000);
                }
            });
            
        }
        public float GetCpuLoad()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            float cpuLoad = cpuCounter.NextValue();
            return cpuLoad;
        }
        static float GetGPUTemperature(Computer computer)
        {
            computer.Open();
            computer.IsGpuEnabled = true;
            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuNvidia || hardwareItem.HardwareType == HardwareType.GpuAmd || hardwareItem.HardwareType == HardwareType.GpuIntel)
                {
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
                        {
                            return sensor.Value.GetValueOrDefault(); 
                        }
                    }
                }
            }
            return 0; 
        }
        static float GetGPULoad(Computer computer)
        {
            computer.Open();
            computer.IsGpuEnabled = true;
            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuNvidia || hardwareItem.HardwareType == HardwareType.GpuAmd || hardwareItem.HardwareType == HardwareType.GpuIntel)
                {
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name == "GPU Core")
                        {
                            return sensor.Value.GetValueOrDefault(); 
                        }
                    }
                }
            }
            return 0; 
        }
        static float GetCPUTemperature(Computer computer)
        {
            foreach (var hardwareItem in computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.Cpu)
                {
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("Core"))
                        {
                            return sensor.Value.GetValueOrDefault(); 
                        }
                    }
                }
            }
            return 0; 
        }

        private async void folderInfo_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                string path = FolderPath.Text;

                if (Directory.Exists(path))
                {
                    PathList.Add(path);

                    List<string> info = new List<string>();

                    var dir = new DirectoryInfo(path);
                   
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        info.Add(Path.GetFileNameWithoutExtension(file.FullName));
                    }

                    string ins = string.Join(", ", info);
                    long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    long Firstlaunch = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    long folderSize = GetDirectorySize(directoryInfo);

                    string sql_add = "INSERT INTO DirectoryLog (DirectoryInfo, FirstLaunch, TimeOfLog, path, DirectorySize) VALUES (@значение, @значение1, @значение2, @значение3, @значение4);";
                    SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

                    m_sqlCmd.Parameters.AddWithValue("@значение", ins);
                    m_sqlCmd.Parameters.AddWithValue("@значение1", Firstlaunch);
                    m_sqlCmd.Parameters.AddWithValue("@значение2", TimeOfLog);
                    m_sqlCmd.Parameters.AddWithValue("@значение3", path);
                    m_sqlCmd.Parameters.AddWithValue("@значение4", folderSize);

                    m_sqlCmd.ExecuteNonQuery();


                    FileSystemWatcher watcher = new FileSystemWatcher();
                    watcher.Path = path;

                    watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                    watcher.Filter = "*.*";

                    watcher.Created += new FileSystemEventHandler(OnChanged);
                    watcher.Deleted += new FileSystemEventHandler(OnDelete);
                    watcher.Renamed += new RenamedEventHandler(OnRenamed);

                    watcher.EnableRaisingEvents = true;
                }
                else
                {
                    MessageBox.Show("Такой папки не существует...");
                }

            });
        }

        static long GetDirectorySize(DirectoryInfo directoryInfo)
        {
            long size = 0;

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                size += GetDirectorySize(subDirectory);
            }

            return size;
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            List<string> info = new List<string>();

            string path = PathList.Last();

            var dir = new DirectoryInfo(path);

            foreach (FileInfo file in dir.GetFiles())
            {
               info.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }

            string ins = string.Join(", ", info);
            long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            long folderSize = GetDirectorySize(directoryInfo);

            string sql_add = "INSERT INTO DirectoryLog (DirectoryInfo, TimeOfLog, Path, DirectorySize) VALUES (@значение, @значение1, @значение2, @значение3);";
            SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

            m_sqlCmd.Parameters.AddWithValue("@значение", ins);
            m_sqlCmd.Parameters.AddWithValue("@значение1", TimeOfLog);
            m_sqlCmd.Parameters.AddWithValue("@значение2", path);
            m_sqlCmd.Parameters.AddWithValue("@значение3", folderSize);

            m_sqlCmd.ExecuteNonQuery();
        }

        private void OnDelete(object sender, FileSystemEventArgs e)
        {

            List<string> info = new List<string>();

            string path = PathList.Last();

            var dir = new DirectoryInfo(path);

            foreach (FileInfo file in dir.GetFiles())
            {
                info.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }

            string ins = string.Join(", ", info);
            long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            long folderSize = GetDirectorySize(directoryInfo);

            string sql_add = "INSERT INTO DirectoryLog (DirectoryInfo, TimeOfLog, Path, DirectorySize) VALUES (@значение, @значение1, @значение2, @значение3);";
            SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

            m_sqlCmd.Parameters.AddWithValue("@значение", ins);
            m_sqlCmd.Parameters.AddWithValue("@значение1", TimeOfLog);
            m_sqlCmd.Parameters.AddWithValue("@значение2", path);
            m_sqlCmd.Parameters.AddWithValue("@значение3", folderSize);

            m_sqlCmd.ExecuteNonQuery();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {

            List<string> info = new List<string>();

            string path = PathList.Last();

            var dir = new DirectoryInfo(path);

            foreach (FileInfo file in dir.GetFiles())
            {
                info.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }

            string ins = string.Join(", ", info);
            long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            long folderSize = GetDirectorySize(directoryInfo);

            string sql_add = "INSERT INTO DirectoryLog (DirectoryInfo, TimeOfLog, Path, DirectorySize) VALUES (@значение, @значение1, @значение2, @значение3);";
            SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

            m_sqlCmd.Parameters.AddWithValue("@значение", ins);
            m_sqlCmd.Parameters.AddWithValue("@значение1", TimeOfLog);
            m_sqlCmd.Parameters.AddWithValue("@значение2", path);
            m_sqlCmd.Parameters.AddWithValue("@значение3", folderSize);

            m_sqlCmd.ExecuteNonQuery();
        }











        private async void folderInfoGit_Click_1(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                string path = folderPathGit.Text;

                if (Directory.Exists(path))
                {
                    PathListGit.Add(path);

                    List<string> info = new List<string>();

                    var dir = new DirectoryInfo(path);

                    foreach (FileInfo file in dir.GetFiles())
                    {
                        info.Add(Path.GetFileNameWithoutExtension(file.FullName));
                    }

                    long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    long Firstlaunch = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    long folderSize = GetDirectorySize(directoryInfo);

                    string sql_add = "INSERT INTO NotGit (FirstLaunch, TimeOfLog, Path) VALUES (@значение1, @значение2, @значение3);";
                    SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

                    m_sqlCmd.Parameters.AddWithValue("@значение1", Firstlaunch);
                    m_sqlCmd.Parameters.AddWithValue("@значение2", TimeOfLog);
                    m_sqlCmd.Parameters.AddWithValue("@значение3", path);

                    m_sqlCmd.ExecuteNonQuery();


                    FileSystemWatcher watcher = new FileSystemWatcher();
                    watcher.Path = path;

                    watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                    watcher.Filter = "*.*";

                    watcher.Changed += new FileSystemEventHandler(OnChangedGit);
                    watcher.Deleted += new FileSystemEventHandler(OnDeleteGit);
                    watcher.Renamed += new RenamedEventHandler(OnRenamedGit);

                    watcher.EnableRaisingEvents = true;
                }
                else
                {
                    MessageBox.Show("Такой папки не существует...");
                }

            });
        }


        private void OnRenamedGit(object sender, RenamedEventArgs e)
        {
            List<string> info = new List<string>();

            string path = PathListGit.Last();

            if (e.ChangeType == WatcherChangeTypes.Renamed)
            {
                try
                {
                    string name = e.Name;
                    string oldName = e.OldName;

                    string modifiedContent = "Файл " + oldName + " был переименован в " + name;
                    
                    string modifiedFileContent = modifiedContent;

                    string ins = string.Join(", ", info);
                    long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    long folderSize = GetDirectorySize(directoryInfo);

                    string sql_add = "INSERT INTO NotGit (Changed, TimeOfLog, Path) VALUES (@значение, @значение1, @значение2);";
                    SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

                    m_sqlCmd.Parameters.AddWithValue("@значение", modifiedFileContent);
                    m_sqlCmd.Parameters.AddWithValue("@значение1", TimeOfLog);
                    m_sqlCmd.Parameters.AddWithValue("@значение2", path);

                    m_sqlCmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
        }

        private void OnDeleteGit(object sender, FileSystemEventArgs e)
        {

            List<string> info = new List<string>();

            string path = PathListGit.Last();

            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                try
                {
                    string fileContent = e.Name;

                    string modifiedContent = "Файл " + fileContent + " был удален.";


                    string modifiedFileContent = modifiedContent;


                    string ins = string.Join(", ", info);
                    long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    long folderSize = GetDirectorySize(directoryInfo);

                    string sql_add = "INSERT INTO NotGit (Changed, TimeOfLog, Path) VALUES (@значение, @значение1, @значение2);";
                    SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

                    m_sqlCmd.Parameters.AddWithValue("@значение", modifiedFileContent);
                    m_sqlCmd.Parameters.AddWithValue("@значение1", TimeOfLog);
                    m_sqlCmd.Parameters.AddWithValue("@значение2", path);

                    m_sqlCmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
        }

        private void OnChangedGit(object sender, FileSystemEventArgs e)
        {

            List<string> info = new List<string>();

            string path = PathListGit.Last();
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                try
                {
                    string fileContent = e.Name;

                    string modifiedContent = "Файл " + fileContent + " был изменен.";


                    string modifiedFileContent = modifiedContent;


                    string ins = string.Join(", ", info);
                    long TimeOfLog = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    long folderSize = GetDirectorySize(directoryInfo);

                    string sql_add = "INSERT INTO NotGit (Changed, TimeOfLog, Path) VALUES (@значение, @значение1, @значение2);";
                    SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);

                    m_sqlCmd.Parameters.AddWithValue("@значение", modifiedFileContent);
                    m_sqlCmd.Parameters.AddWithValue("@значение1", TimeOfLog);
                    m_sqlCmd.Parameters.AddWithValue("@значение2", path);

                    m_sqlCmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
        }

       
    }
}

