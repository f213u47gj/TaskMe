using TaskMe.Data;
using TaskMe.Repository;
using TaskMe.ViewModel;
using System.Windows;
using TaskMe.Repository;
using Requests.Repository;

namespace TaskMe
{
    public partial class CreateRequestWindow : Window
    {
        public CreateRequestWindow()
        {
            InitializeComponent();

            var dbContext = new TaskMeDbContext();
            var requestRepository = new RequestRepository(dbContext);
            var clientRepository = new ClientRepository(dbContext);
            var statusRepository = new StatusRepository(dbContext);

            DataContext = new CreateRequestViewModel(requestRepository, clientRepository, statusRepository);
        }
    }
}
