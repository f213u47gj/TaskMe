namespace TaskMe.Model
{
    public class Executor
    {
        public int ExecutorId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string ExecutorName
        {
            get => $"{FirstName} {SecondName}";
        }
    }
}
