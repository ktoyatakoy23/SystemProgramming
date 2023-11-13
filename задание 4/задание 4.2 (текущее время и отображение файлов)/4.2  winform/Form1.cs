using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._2__winform
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            StartClockUpdate();
            StartFilesUpdate();
        }

        private async void StartClockUpdate()
        {
            while (true)
            {
                await Task.Delay(1000);
                UpdateClock();
            }
        }

        private void UpdateClock()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateClock));
            }
            else
            {
                Time.Text = "Текущее время: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        private async void StartFilesUpdate()
        {
            while (true)
            {
                await UpdateFiles();
                await Task.Delay(100); 
            }
        }

        private async Task UpdateFiles()
        {
            await Task.Run(() =>
            {
                string[] allFiles = Directory.GetFiles("C:\\Users\\Софич и Владич\\Downloads\\test");
                if (allFiles.Length > 0)
                {
                    string[] latestFile = allFiles;
                    UpdateUI(latestFile);                    
                }
                else
                {
                    Files.Text = "";
                }
            });
        }

        private void UpdateUI(string[] latestFile)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(latestFile)));
            }
            else
            {
                List<string> filesList = new List<string>();

                for (int file = 0; file < latestFile.Length; file++)
                {
                    filesList.Add(latestFile[file]);
                }

                string filesText = string.Join(Environment.NewLine, filesList);
                Files.Text = filesText;
            }
        }

    }


    
}

