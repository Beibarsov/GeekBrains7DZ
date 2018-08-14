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

//1. а) Добавить в программу “Удвоитель” подсчет количества отданных команд удвоителю.
//б) Добавить меню и команду “Играть”. При нажатии появляется сообщение, 
//какое число должен получить игрок.Игрок должен постараться получить это число за минимальное количество ходов.
//в) * Добавить кнопку “Отменить”, которая отменяет последние ходы.

namespace GeekBrains7DZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ticket = 0;
        Random random = new Random();
        int winResult = 0;
        int prevresult = 0;

        public MainWindow()
        {
           
            InitializeComponent();


        }

        /// <summary>
        /// +1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prevresult = int.Parse(LabelResult.Content.ToString());
            LabelResult.Content = (int.Parse(LabelResult.Content.ToString()) + 1).ToString();
            ticket++;

        }
        /// <summary>
        /// *2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clickx2(object sender, RoutedEventArgs e)
        {
            prevresult = int.Parse(LabelResult.Content.ToString());
            LabelResult.Content = (int.Parse(LabelResult.Content.ToString()) * 2).ToString();
            ticket++;
        }

        /// <summary>
        /// Сброс игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clickreset(object sender, RoutedEventArgs e)
        {
            prevresult = int.Parse(LabelResult.Content.ToString());
            LabelResult.Content = 0;
            ticket++;
        }
        /// <summary>
        /// Отрисовка количества попыток и проверка на победу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Write_Ticket(object sender, RoutedEventArgs e)
        {
            ticketCounter.Content = ticket;
            if ((LabelWinResult.Content.ToString() == LabelResult.Content.ToString()))
                MessageBox.Show($"Победа за {ticket.ToString()} ходов");
        }


        /// <summary>
        /// Начало новой игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGame(object sender, RoutedEventArgs e)
        {
            winResult = random.Next(2,10);
            LabelWinResult.Content = winResult;
            ticket = 0;
            LabelResult.Content = 0;
            ticketCounter.Content = ticket;

        }
        /// <summary>
        /// Отмена одного хода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_reset(object sender, RoutedEventArgs e)
        {
            LabelResult.Content = prevresult;
            ticket++;
        }
    }
}
