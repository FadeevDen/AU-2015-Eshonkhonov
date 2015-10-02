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
using VkNet.Enums.Filters;
namespace MessengerVK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
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
