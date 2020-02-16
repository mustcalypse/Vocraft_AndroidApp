namespace WordnikLib.Results
{
    public struct WordSearchResults //<CHECKED>
    {
        public WordSearch[] searchResults { get; set; }
        public int totalResults { get; set; }
    }

    public struct WordSearch
    {
        //Will be greater than zero if it has a meaning
        public long count { get; set; }
        public string word { get; set; }
    }
}