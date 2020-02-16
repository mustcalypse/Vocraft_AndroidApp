namespace WordnikLib.Results
{
    public struct ExamplesResult //<CHECKED>
    {
        public Example[] examples { get; set; }
    }

    public struct Example
    {
        public long exampleId { get; set; }
        public long documentId { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string word { get; set; }
        public int year { get; set; }
        public float rating { get; set; }
        public string url { get; set; }
    }
}