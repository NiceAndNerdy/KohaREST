using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohaREST
{
    public class Patrons : IDisposable, IGettable, IDeletable
    {
        public List<Patron> Results = new List<Patron>();
        public string JSON { get; set; }
        private KohaRESTConnection Con { get; set; }
        public Patrons() { }
        public Patrons(string JSON)
        {
            this.JSON = JSON;
            Deserialize();
        }
        public Patrons(KohaRESTConnection Connection)
        {
            this.Con = Connection;
        }

        public void Deserialize()
        {
            this.Results = (List<Patron>)Serializer.DeserializeIEnumerable<Patron>(JSON);
            foreach (Patron result in Results)
            {
                result.Con = this.Con;
            }
        }

        public void Get(string Key, string Value)
        {
            this.JSON = Con.Get(Resources.Patrons, Key, Value);
            this.Deserialize();
        }

        public void Get(string[] Key, string[] Value)
        {
            this.JSON = Con.Get(Resources.Patrons, Key, Value);
            this.Deserialize();
        }

        public void Delete()
        {
            foreach (Patron hold in Results)
            {
                hold.Delete();
            }
            Results.Clear();
            this.JSON = String.Empty;
        }

        public void Dispose() { }

    }
}
