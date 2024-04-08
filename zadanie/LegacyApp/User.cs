using System;
using System.Dynamic;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        
        public void SetCredit(Client client)
        //new method to set credit limit for user
        {
            Client = client;
            if (client.Type == "VeryImportantClient")
            {
                HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    creditLimit = creditLimit * 2;
                    CreditLimit = creditLimit;
                }
            }
            else
            {
                HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                    CreditLimit = creditLimit;
                }
            }
            
        }
        
        public bool IsType(Client client)
        {
            
            if (client.Type == "VeryImportantClient")
            {
                if (HasCreditLimit == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else if (client.Type == "ImportantClient")
            {
                return true;

            }
            else if(client.Type == "NormalClient")
            {   if (HasCreditLimit == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                return false;
            }
        }
    }
    
    
}