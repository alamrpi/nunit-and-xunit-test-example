namespace Sparky
{
    public interface ICustomer
    {
         int Discount { get; set; }
         bool IsPlatinum { get; set; }
        string GetFullName(string firstName, string lastName);
    }
    public class Customer : ICustomer
    {
        public int Discount { get; set; }
        public bool IsPlatinum { get; set; }
        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }

        public string GetFullName(string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(firstName))
                throw new ArgumentException("First name is empty");
            
            Discount = 20;
            return $"{firstName} {lastName}";
        }
    } 
}
