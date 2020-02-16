namespace WordnikLib.Results
{
    public struct FrequencySummary //<CHECKED>
    {
        public int unknownYearCount { get; set; }
        public long totalCount { get; set; }
        public string word { get; set; }
        public Frequency[] frequency { get; set; }
    }

    public struct Frequency
    {
        public long count { get; set; }
        public int year { get; set; }
    }
}