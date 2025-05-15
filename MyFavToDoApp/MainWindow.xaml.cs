using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyFavToDoApp.ViewModel;

namespace MyFavToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ToDoViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ToDoViewModel();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!_viewModel.AuthStatus.IsAuthenticated)
            {
                Login login = new Login(_viewModel);
                login.ShowDialog();
            }
        }
    }
}