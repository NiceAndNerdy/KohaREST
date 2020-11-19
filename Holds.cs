using System;
using System.Collections.Generic;


namespace KohaREST
{
    public class Holds : IDisposable, IGettable, IDeletable
    {
        public List<Hold> Results = new List<Hold>();
        public string JSON { get; set; }
        private KohaRESTConnection Con { get; set; }
        public Holds() { }
        public Holds(string JSON)
        {
            this.JSON = JSON;
            Deserialize();
        }
        public Holds(KohaRESTConnection Connection)
        {
            this.Con = Connection;
        }

        public void Deserialize()
        {
            this.Results = (List<Hold>)Serializer.DeserializeIEnumerable<Hold>(JSON);
            foreach (Hold result in Results)
            {
                result.Con = this.Con;
            }
        }

        public void Get(string Key, string Value)
        {
            this.JSON = Con.Get(Resources.Holds, Key, Value);
            this.Deserialize();
        }

        public void Get(string[] Key, string[] Value)
        {
            this.JSON = Con.Get(Resources.Holds, Key, Value);
            this.Deserialize();
        }

        public void Delete()
        {
            foreach (Hold hold in Results)
            {
                hold.Delete();
            }
            Results.Clear();
            this.JSON = String.Empty;
        }

        public void Dispose() { }


    }
}