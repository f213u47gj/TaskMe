namespace TaskMe.Model
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string ClientName
        {
            get => $"{FirstName} {SecondName}";
        }
    }
}