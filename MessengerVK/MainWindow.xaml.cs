using System.Threading;
using System.Windows;
using System.Windows.Input;
namespace MessengerVK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        }
        
        //Закрытие окна
        private void BnCancel_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
        //Метод который позволяет перетаскивать окно 
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

       
    }
}
