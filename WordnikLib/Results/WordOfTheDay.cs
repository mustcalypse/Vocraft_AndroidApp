namespace WordnikLib.Results
{
    public struct WordOfTheDay //<CHECKED>
    {
        public string word { get; set; }
        public string note { get; set; }
        public SimpleDefinition[] definitions { get; set; }
        public SimpleExample[] examples { get; set; }
    }

    public struct SimpleDefinition
    {
        public string partOfSpeech { get; set; }
        public string text { get; set; }
        public string source { get; set; }
    }

    public struct SimpleExample
    {
        public long id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string url { get; set; }
    }
}