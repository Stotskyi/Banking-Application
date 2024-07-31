namespace BankAccountSimulator.DAL.Entities;

    public class User 
    {
        public User(string username)
        {
            Username = username;
            Card = new Card();
            Account = new Account();
        }

        public User()
        {
        }

        public int Id { get; set; }
    
        public string Username { get; set; }

        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        
        public Card Card { get; set; }

       public Account Account { get; set; }

    }
