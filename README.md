# KohaREST
.NET Framework class library implementation of the Koha ILS REST API

Koha for the rest of us.  Ba dum bum.  So far, I've only implemented the stuff I need for a current project.  Mostly adding and deleting holds, adding and deleting patrons, etc.  I've also not really documented anything, but what's there, I feel, is largely self explanatory.  Here's some example code:

using (KohaRESTConnection con = new KohaRESTConnection("YourBaseURL", "BasicAuthUser", "BasicAuthPassword"))  // Establishes REST connection
            {
                using (Holds holds = new Holds(con))  //  All objects require the KohaRESTConnection object to talk to the server.
                {                                     //  They can also be used as data objects without it.
                    holds.Get("patron_id", "123456");  // Gets list of holds by some parameter.   
                    foreach (Hold myHold in holds.Results)
                    {
                        Console.WriteLine(myHold.Hold_Id);
                    }
                    holds.Delete();  // Deletes all retrieved hold results.  Use Hold.Delete to delete individual holds.  See below.
                }

                using (Hold hold1 = new Hold(con))
                {
                    hold1.CreateBasicHold(123456, 45678, "LIB");  //  Creates a basic hold.  Takes borrowermumber, biblio number, and library identifier.  
                }

                Hold hold = new Hold(con);
                hold.Get("hold_id", "456789");  Retrieves single instance of a hold.    
                hold.Delete();

                using (Patron patron = new Patron(con))
                {
                    patron.Surname = "Test";
                    patron.Firstname = "This is a";
                    patron.City = "Springfield";
                    patron.Library_Id = "RPL";
                    patron.Category_Id = "Adult";
                    patron.Address = "123 Fake Street";
                    patron.State = "Hawaii";
                    patron.Userid = "fake.patron";
                    patron.Post();  //  Adds a patron.  Patron.CreateBasicPatron takes minimum parameters required by API.

                    patron.Delete();

                }
}
