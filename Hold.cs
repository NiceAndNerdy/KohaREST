using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace KohaREST
{
    public class Hold : IDisposable, IPostable, IDeletable, IGettable
    {
        [JsonProperty("biblio_id")]
        public int Biblio_Id { get; set; }

        [JsonProperty("cancelation_date")]
        public DateTime? Cancelation_Date { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime? Expiration_Date { get; set; }

        [JsonProperty("hold_date")]
        public DateTime? Hold_Date { get; set; }

        [JsonProperty("hold_id")]
        public int Hold_Id { get; set; }

        [JsonProperty("item_id")]
        public int? Item_Id { get; set; }

        [JsonProperty("item_level")]
        public bool Item_Level { get; set; }

        [JsonProperty("item_type")]
        public string Item_Type { get; set; }

        [JsonProperty("lowest_priority")]
        public bool Lowest_Priority { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("patron_id")]
        public int Patron_Id { get; set; }

        [JsonProperty("pickup_library_id")]
        public string Pickup_Library_Id { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("suspended")]
        public bool Suspended { get; set; }

        [JsonProperty("suspended_until")]
        public string Suspended_Until { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("waiting_date")]
        public DateTime? Waiting_Date { get; set; }

        [JsonIgnore]
        public string JSON { get; set; }
        [JsonIgnore]
        public KohaRESTConnection Con { get; set; }



        public Hold() { }
        public Hold(string JSON)
        {
            this.JSON = JSON;
            Deserialize();
        }
        public Hold(KohaRESTConnection Connection)
        {
            this.Con = Connection;
        }

        public void Deserialize()
        {
            if ((this.JSON.Substring(0) == "[") && (this.JSON.Substring(JSON.Length - 1) == "]"))
            {
                this.JSON = this.JSON.Substring(1, this.JSON.Length - 2).Trim();
            }
            Hold hold = Serializer.Deserialize<Hold>(this.JSON);
            this.Biblio_Id = hold.Biblio_Id;
            this.Cancelation_Date = hold.Cancelation_Date;
            this.Expiration_Date = hold.Cancelation_Date;
            this.Hold_Date = hold.Hold_Date;
            this.Hold_Id = hold.Hold_Id;
            this.Item_Id = hold.Item_Id;
            this.Item_Level = hold.Item_Level;
            this.Item_Type = hold.Item_Type;
            this.Lowest_Priority = hold.Lowest_Priority;
            this.Notes = hold.Notes;
            this.Patron_Id = hold.Patron_Id;
            this.Pickup_Library_Id = hold.Pickup_Library_Id;
            this.Priority = hold.Priority;
            this.Status = hold.Status;
            this.Suspended = hold.Suspended;
            this.Suspended_Until = hold.Suspended_Until;
            this.Timestamp = hold.Timestamp;
            this.Waiting_Date = hold.Waiting_Date;
        }

        public void Serialize()
        {
            this.JSON = Serializer.Serialize<Hold>(this);
        }


        public void Get(int Hold_Id)
        {
            this.JSON = Con.Get(Resources.Holds, "hold_id", Hold_Id.ToString());
            Deserialize();
        }

        public void Get(string Key, string Value)
        {
            this.JSON = Con.Get(Resources.Holds, Key, Value);
            Deserialize();
        }

        public void Get(string[] Key, string[] Value)
        {
            this.JSON = Con.Get(Resources.Holds, Key, Value);
            Deserialize();
        }

        public void CreateBasicHold(int Patron_Id, int Biblio_Id, string Pickup_Library_Id)
        {
            this.Patron_Id = Patron_Id;
            this.Biblio_Id = Biblio_Id;
            this.Pickup_Library_Id = Pickup_Library_Id;
            this.Post();
        }
        public void Post()
        {
            this.JSON = Con.Post(Resources.Holds, this);
        }

        public void Dispose() { }

        public void Delete()
        {
            this.JSON = Con.Delete(Resources.Holds, this.Hold_Id.ToString());
        }


    }
}