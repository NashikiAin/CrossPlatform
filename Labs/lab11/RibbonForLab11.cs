using LabsLibrary;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.IO;
using System.Windows.Forms;

namespace lab11
{
    public partial class RibbonForLab11
    {
        private void RibbonForLab11_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            this.playLab("lab1");
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            this.playLab("lab2");
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            this.playLab("lab3");
        }

        private void playLab(string labName)
        {
            try
            {
                string result = "";
                RunnerLabs labRunner = new RunnerLabs();
                // Путь к файлу input.txt для каждой лабораторной
                string filePath = GetInputFilePath(labName);
                if (filePath == null)
                {
                    throw new ArgumentException("Неверное название лабораторной работы.");
                }

                switch (labName)
                {
                    case "lab1":
                        result = labRunner.RunLab1(filePath);
                        break;
                    case "lab2":
                        result = labRunner.RunLab2(filePath);
                        break;
                    case "lab3":
                        result = labRunner.RunLab3(filePath);
                        break;
                    default:
                        throw new ArgumentException("Лабораторная работа не найдена.");
                }

                MessageBox.Show("Ответ: " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetInputFilePath(string labName)
        {
            string basePath = @"C:\Users\Oleh\Desktop\CrossPlatform";
            string labFolderPath = Path.Combine(basePath, "Labs", labName);

            Console.WriteLine($"Шлях: {labFolderPath}");

            if (Directory.Exists(labFolderPath))
            {
                string filePath = Path.Combine(labFolderPath, "input.txt");
                Console.WriteLine($"Перевірка файлу: {filePath}");

                if (File.Exists(filePath))
                {
                    return filePath;
                }
                else
                {
                    throw new FileNotFoundException($"Файл {filePath} не знайдений.");
                }
            }

            return null;
        }
    }
}
