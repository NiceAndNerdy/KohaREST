namespace KohaREST
{
    interface IPostable
    {
        string JSON { get; set; }
        void Post();
        void Deserialize();
        void Serialize();
    }
}

