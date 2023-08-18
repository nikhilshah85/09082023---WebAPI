using Microsoft.AspNetCore.WebUtilities;

namespace di_demo
{
    public class Accounts
    {
        public int accNo { get; set; }
        public string accName { get; set; }
        public string accType { get; set; }
        public double accBalance { get; set; }
        public bool accIsActive { get; set; }

        static List<Accounts> accList = new List<Accounts>()
        {
            new Accounts(){ accNo=101, accName="Nikhil", accBalance=7000, accIsActive=true, accType="Savings"},
            new Accounts(){ accNo=102, accName="Rahul", accBalance=7000, accIsActive=true, accType="Savings"},
            new Accounts(){ accNo=103, accName="Suman", accBalance=7000, accIsActive=true, accType="Current"},
            new Accounts(){ accNo=104, accName="Preeti", accBalance=7000, accIsActive=false, accType="Savings"},
            new Accounts(){ accNo=105, accName="Mohan", accBalance=7000, accIsActive=true, accType="Savings"},
            new Accounts(){ accNo=106, accName="Rohan", accBalance=7000, accIsActive=false, accType="Current"},

        };

        public List<Accounts> GetAllAccounts()
        {
            return accList;
        }






    }
}
