using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TaskSYS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Task task;
        private CancellationTokenSource cancellationToken;
        private CancellationToken token;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Method()
        {
            MessageBox.Show("Поток начел работу");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                if (token.IsCancellationRequested)
                {
                    MessageBox.Show("Операция прервана");
                    return;
                }
            }
            MessageBox.Show("Операция успешно выполнена");
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            cancellationToken = new CancellationTokenSource();
            token = cancellationToken.Token;

            task = new Task(new Action(Method));
            task.Start();
        }

        private void CacelButtonClick(object sender, RoutedEventArgs e)
        {
            cancellationToken.Cancel();
        }
    }
}
