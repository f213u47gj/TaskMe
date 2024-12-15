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
using TaskMe.Data;
using TaskMe.Repository;
using TaskMe.ViewModel;

namespace TaskMe
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var dbContext = new TaskMeDbContext();
            var requestRepository = new RequestRepository(dbContext);
            var mainViewModel = new MainViewModel(requestRepository);

            DataContext = mainViewModel;
        }
    }
}