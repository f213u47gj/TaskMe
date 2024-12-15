using TaskMe.Data;
using TaskMe.Model;
using TaskMe.Repository;
using TaskMe.ViewModel;
using System.Windows;
using Requests.Repository;

namespace TaskMe
{
    public partial class EditRequestWindow : Window
    {
        public EditRequestWindow(Request request)
        {
            InitializeComponent();
            var dbContext = new TaskMeDbContext();
            DataContext = new EditRequestViewModel(request, new RequestRepository(dbContext), new ClientRepository(dbContext), new StatusRepository(dbContext), new ExecutorRepository(dbContext));
        }
    }
}