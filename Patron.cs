using System;
using Newtonsoft.Json;


namespace KohaREST
{
    public class Patron : IDisposable, IPostable, IDeletable, IGettable
    {
        [JsonProperty("patron_id")]
        public int? Patron_Id { get; set; }

        [JsonProperty("cardnumber")]
        public string Cardnumber { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("other_name")]
        public string Other_Name { get; set; }

        [JsonProperty("initials")]
        public string Initials { get; set; }

        [JsonProperty("street_number")]
        public string Street_Number { get; set; }

        [JsonProperty("street_type")]
        public string Street_Type { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postal_code")]
        public string Postal_Code { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("secondary_email")]
        public string Secondary_Email { get; set; }

        [JsonProperty("secondary_phone")]
        public string Secondary_Phone { get; set; }

        [JsonProperty("altaddress_street_number")]
        public string Altaddress_Street_Number { get; set; }

        [JsonProperty("altaddress_street_type")]
        public string Altaddress_Street_Type { get; set; }

        [JsonProperty("altaddress_address")]
        public string Altaddress_Address { get; set; }

        [JsonProperty("altaddress_address2")]
        public string Altaddress_Address2 { get; set; }

        [JsonProperty("altaddress_city")]
        public string Altaddress_City { get; set; }

        [JsonProperty("alt_address_state")]
        public string Altaddress_State { get; set; }

        [JsonProperty("altaddress_postal_code")]
        public string Altaddress_Postal_Code { get; set; }

        [JsonProperty("altaddress_country")]
        public string Altaddress_Country { get; set; }

        [JsonProperty("altaddress_email")]
        public string Altaddress_Email { get; set; }

        [JsonProperty("altaddress_phone")]
        public string Altaddress_Phone { get; set; }

        [JsonProperty("date_of_birth")]
        public DateTime? Date_Of_Birth { get; set; }

        [JsonProperty("library_id")]
        public string Library_Id { get; set; }

        [JsonProperty("category_id")]
        public string Category_Id { get; set; }

        [JsonProperty("date_enrolled")]
        public DateTime? Date_Enrolled { get; set; }

        [JsonProperty("expiry_date")]
        public DateTime? Expiry_Date { get; set; }

        [JsonProperty("incorrect_address")]
        public bool? Incorrect_Address { get; set; }

        [JsonProperty("patron_card_lost")]
        public bool? Patron_Card_Lost { get; set; }

        [JsonProperty("restricted")]
        public bool? Restricted { get; set; }

        [JsonProperty("guarantor_id")]
        public string Guarantor_Id { get; set; }

        [JsonProperty("staff_notes")]
        public string Staff_Notes { get; set; }

        [JsonProperty("relationship_type")]
        public string Relationship_Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("userid")]
        public string Userid { get; set; }

        [JsonProperty("opac_notes")]
        public string Opac_Notes { get; set; }

        [JsonProperty("altaddress_notes")]
        public string Altaddress_Notes { get; set; }

        [JsonProperty("statistics_1")]
        public string Statistics_1 { get; set; }

        [JsonProperty("statistics_2")]
        public string Statistics_2 { get; set; }

        [JsonProperty("autorenew_checkouts")]
        public bool? Autorenew_Checkouts { get; set; }

        [JsonProperty("altcontact_firstname")]
        public string Altcontact_Firstname { get; set; }

        [JsonProperty("altcontact_surname")]
        public string Altcontact_Surname { get; set; }

        [JsonProperty("altcontact_address")]
        public string Altcontact_Address { get; set; }

        [JsonProperty("altcontact_address2")]
        public string Altcontact_Address2 { get; set; }

        [JsonProperty("altcontact_city")]
        public string Altcontact_City { get; set; }

        [JsonProperty("altcontact_state")]
        public string Altcontact_State { get; set; }

        [JsonProperty("altcontact_postal_code")]
        public string Altcontact_Postal_Code { get; set; }

        [JsonProperty("altcontact_country")]
        public string Altcontact_Country { get; set; }

        [JsonProperty("altcontact_phone")]
        public string Altcontact_Phone { get; set; }

        [JsonProperty("sms_number")]
        public string Sms_Number { get; set; }

        [JsonProperty("sms_provider_id")]
        public string Sms_Provider_Id { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("privacy_guarantor_checkouts")]
        public string Privacy_Guarantor_Checkouts { get; set; }

        [JsonProperty("check_previous_checkout")]
        public string Check_Previous_Checkout { get; set; }

        [JsonProperty("update_on")]
        public DateTime? Updated_On { get; set; }

        [JsonProperty("last_seen")]
        public DateTime? Last_Seen { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("login_attempts")]
        public string Login_Attempts { get; set; }


        [JsonIgnore]
        public string JSON { get; set; }
        [JsonIgnore]
        public KohaRESTConnection Con { get; set; }


        public Patron() { }
        public Patron(string JSON)
        {
            this.JSON = JSON;
            Deserialize();
        }
        public Patron(KohaRESTConnection Connection)
        {
            this.Con = Connection;
        }

        public void Deserialize()
        {
            if ((this.JSON.Substring(0) == "[") && (this.JSON.Substring(JSON.Length - 1) == "]"))
            {
                this.JSON = this.JSON.Substring(1, this.JSON.Length - 2).Trim();
            }
            Patron patron = Serializer.Deserialize<Patron>(this.JSON);
            this.Patron_Id = patron.Patron_Id;
            this.Cardnumber = patron.Cardnumber;
            this.Surname = patron.Surname;
            this.Firstname = patron.Firstname;
            this.Title = patron.Title;
            this.Other_Name = patron.Other_Name;
            this.Initials = patron.Initials;
            this.Street_Number = patron.Street_Number;
            this.Street_Type = patron.Street_Type;
            this.Address = patron.Address;
            this.Address2 = patron.Address2;
            this.City = patron.City;
            this.State = patron.State;
            this.Postal_Code = patron.Postal_Code;
            this.Country = patron.Country;
            this.Email = patron.Email;
            this.Phone = patron.Phone;
            this.Mobile = patron.Mobile;
            this.Fax = patron.Fax;
            this.Secondary_Email = patron.Secondary_Email;
            this.Secondary_Phone = patron.Secondary_Phone;
            this.Altaddress_Street_Number = patron.Altaddress_Street_Number;
            this.Altaddress_Street_Type = patron.Altaddress_Street_Type;
            this.Altaddress_Address = patron.Altaddress_Address;
            this.Altaddress_Address2 = patron.Altaddress_Address2;
            this.Altaddress_City = patron.Altaddress_City;
            this.Altaddress_State = patron.Altaddress_State;
            this.Altaddress_Postal_Code = patron.Altaddress_Postal_Code;
            this.Altaddress_Country = patron.Altaddress_Country;
            this.Altaddress_Email = patron.Altaddress_Email;
            this.Altaddress_Phone = patron.Altaddress_Phone;
            this.Date_Of_Birth = patron.Date_Of_Birth;
            this.Library_Id = patron.Library_Id;
            this.Category_Id = patron.Category_Id;
            this.Date_Enrolled = patron.Date_Enrolled;
            this.Expiry_Date = patron.Expiry_Date;
            this.Incorrect_Address = patron.Incorrect_Address;
            this.Patron_Card_Lost = patron.Patron_Card_Lost;
            this.Restricted = patron.Restricted;
            this.Guarantor_Id = patron.Guarantor_Id;
            this.Staff_Notes = patron.Staff_Notes;
            this.Relationship_Type = patron.Relationship_Type;
            this.Gender = patron.Gender;
            this.Userid = patron.Userid;
            this.Opac_Notes = patron.Opac_Notes;
            this.Altaddress_Notes = patron.Altaddress_Notes;
            this.Statistics_1 = patron.Statistics_1;
            this.Statistics_2 = patron.Statistics_2;
            this.Autorenew_Checkouts = patron.Autorenew_Checkouts;
            this.Altcontact_Firstname = patron.Altcontact_Firstname;
            this.Altcontact_Surname = patron.Altcontact_Surname;
            this.Altcontact_Address = patron.Altcontact_Address;
            this.Altcontact_Address2 = patron.Altcontact_Address2;
            this.Altcontact_City = patron.Altcontact_City;
            this.Altcontact_State = patron.Altcontact_State;
            this.Altcontact_Postal_Code = patron.Altcontact_Postal_Code;
            this.Altcontact_Country = patron.Altcontact_Country;
            this.Altcontact_Phone = patron.Altcontact_Phone;
            this.Sms_Number = patron.Sms_Number;
            this.Sms_Provider_Id = patron.Sms_Provider_Id;
            this.Privacy = patron.Privacy;
            this.Privacy_Guarantor_Checkouts = patron.Privacy_Guarantor_Checkouts;
            this.Check_Previous_Checkout = patron.Check_Previous_Checkout;
            this.Updated_On = patron.Updated_On;
            this.Last_Seen = patron.Last_Seen;
            this.Lang = patron.Lang;
            this.Login_Attempts = patron.Login_Attempts;
        }

        public void Serialize()
        {
            this.JSON = Serializer.Serialize<Patron>(this);
        }


        public void Get(int Patron_Id)
        {
            this.JSON = Con.Get(Resources.Patrons, "patron_id", Patron_Id.ToString());
            Deserialize();
        }

        public void Get(string Key, string Value)
        {
            this.JSON = Con.Get(Resources.Patrons, Key, Value);
            Deserialize();
        }

        public void Get(string[] Key, string[] Value)
        {
            this.JSON = Con.Get(Resources.Patrons, Key, Value);
            Deserialize();
        }

        public void CreateBasicPatron(string Surname, string Address, string City, string Library_Id, string Category_Id)
        {
            this.Surname = Surname;
            this.Address = Address;
            this.City = City;
            this.Library_Id = Library_Id;
            this.Category_Id = Category_Id;
            this.Post();
        }
        public void Post()
        {
            this.JSON = Con.Post(Resources.Patrons, this);
            Deserialize();
        }

        public void Delete()
        {
            this.JSON = Con.Delete(Resources.Patrons, this.Patron_Id.ToString());
            Deserialize();
        }

        public void Dispose() { }
    }
}
