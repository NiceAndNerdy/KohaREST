namespace KohaREST
{
    interface IGettable
    {
        string JSON { get; set; }
        void Get(string Key, string Value);
        void Get(string[] Key, string[] Value);
        void Deserialize();
    }
}
