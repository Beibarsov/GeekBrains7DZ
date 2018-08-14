using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

//3. * Реализовать программу из предыдущего урока с шаблоном документа на отпуск 
//в Windows Forms.Сделать несколько текстовых полей(TextBox), куда человек вводит данные,
//а по нажатии кнопки “Сделать” - видит готовое заявление на отпуск.

namespace Task3
{

    public partial class MainWindow : Window
    {
        string str;
        bool finalflag;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            finalflag = true; //Проверка на выполнение всех условий ввода (в конкретном случае что не пустые строки)
            FileStream fs = new FileStream("../../file.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                str += sr.ReadLine() + "\n";

            }
            //Создание и заполнение списка текстовых боксов
            List<TextBox> listBox = new List<TextBox>();
            listBox.Add(nameOOO);
            listBox.Add(nameDir);
            listBox.Add(nameDolzh);
            listBox.Add(nameYr);
            listBox.Add(dateIn);
            listBox.Add(dateOut);
            //Создание и заполнение списка тегов
            List<string> listblock = new List<string>();
            listblock.Add("<name1>");
            listblock.Add("<name2>");
            listblock.Add("<name3>");
            listblock.Add("<name4>");
            listblock.Add("<data1>");
            listblock.Add("<data2>");
            string stringresult = String.Empty;
            string stringoutput = str;
            for (int i = 0; i < listBox.Count; i++)
            {
                if (Return_flag(listBox[i], out stringresult))
                {
                    stringoutput = stringoutput.Replace((string)listblock[i], stringresult);
                }
                else
                {
                    MessageBox.Show("Пустая строка!");
                    finalflag = false;
                }

            }
            if (finalflag == true)
                OutDocument.Text = stringoutput;

        }
        private bool Return_flag(TextBox text, out string stringresult)
        {
            stringresult = text.Text;
            if (text.Text == "")
                return false;
            return true;
        }
    }
}
