namespace WordnikLib.Results
{
    public struct AudioFile //<CHECKED>
    {
        public string word { get; set; }
        public long id { get; set; }
        public string fileUrl { get; set; }
        public string audioType { get; set; }
        public double duration { get; set; }
        public string attributionUrl { get; set; }
        public string attributionText { get; set; }
        public string createdBy { get; set; }
    }
}