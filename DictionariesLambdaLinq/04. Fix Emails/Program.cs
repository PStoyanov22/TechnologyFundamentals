using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> contactList = new Dictionary<string, string>();

            bool canContinue = true;

            while (canContinue)
            {
                string name = Console.ReadLine();

                if (name != "stop")
                {

                    string email = Console.ReadLine();

                    if (!contactList.ContainsKey(name) && (!email.EndsWith("us")
                   && !email.EndsWith("uk")))
                    {
                        contactList.Add(name, email);
                        canContinue = true;
                    }
                    else if ((contactList.ContainsKey(name) && (!email.EndsWith("us")
                        || !email.EndsWith("uk"))))
                    {
                        contactList[name] = email;
                        canContinue = true;
                    }

                    else
                    {
                        canContinue = false;
                        break;
                    }
                }
                else
                {
                    canContinue = false;
                }
            }

           

            foreach (var item in contactList)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
            
            
        }
    }
}
