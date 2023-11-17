namespace web_api
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public Client ClientInfo { get; set; }

        public int Points { get; set; }
    }


    public class Client
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
} 