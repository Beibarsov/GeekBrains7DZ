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

//2. Используя Windows Forms, разработать игру “Угадай число”.
//Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. 
//Для ввода данных от человека используется элемент TextBox.

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        int winResult = 0;
        public MainWindow()
        {
            winResult = random.Next(1, 99);
           // MessageBox.Show(winResult.ToString());
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TextRead.Text == winResult.ToString())
            {
                MessageBox.Show("Выиграл!");
                this.Close();
            }
            if (int.Parse(TextRead.Text) > winResult)
            {
                Podskazka.Text = "Введено больше"; 
            }
            if (int.Parse(TextRead.Text) < winResult)
            {
                Podskazka.Text = "Введено меньше";
            }
            Counter.Content = int.Parse(Counter.Content.ToString()) + 1;
        }
    }
}
