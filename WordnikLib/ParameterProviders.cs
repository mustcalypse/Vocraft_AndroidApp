namespace WordnikLib.ParameterProviders
{
    public interface IParameters
    {
        string Query { get; set; }
    }
    public struct DefinitionsParameters : IParameters
    {
        public string Query { get; set; }
        public PartOfSpeech partOfSpeech;
        public bool includeRelated;
        public SourceDictionary sourceDictionaries;
        public bool includeTags;
        public int limit;
        public bool useCanonical;
    }
    public struct ExamplesParameters : IParameters
    {
        public string Query { get; set; }
        public bool includeDuplicates;
        public int skip;
        public int limit;
        public bool useCanonical;
    }
    public struct FrequencyParameters : IParameters
    {
        public string Query { get; set; }
        public int startYear;
        public int endYear;
        public bool useCanonical;
    }
    public struct PronunciationsParameters : IParameters
    {
        public string Query { get; set; }
        public int limit;
        public bool useCanonical;
    }
    public struct PhrasesParameters : IParameters
    {
        public string Query { get; set; }
        public int wlmi;
        public int limit;
        public bool useCanonical;
    }
    public struct RelatedWordsParameters : IParameters
    {
        public string Query { get; set; }
        public RelationshipType relationshipTypes;
        public int limitPerRelationshipType;
        public bool useCanonical;
    }
    public struct TopExampleParameters : IParameters
    {
        public string Query { get; set; }
        public bool useCanonical;
    }
    public struct EtymologiesParameters : IParameters
    {
        public string Query { get; set; }
        public bool useCanonical;
    }
    public struct AudioParameters : IParameters
    {
        public string Query { get; set; }
        public int limit;
        public bool useCanonical;
    }
    public struct RandomWordsParameters : IParameters
    {
        public string Query { get; set; }
        /// <summary>
        /// its value must be 'true'..!
        /// </summary>
        public bool hasDictionaryDef;
        public PartOfSpeech includePartOfSpeech;
        public int limit;
    }
    public struct ReverseDictionaryParameters : IParameters
    {
        public string Query { get; set; }
        public string query;
        [System.Obsolete("use 'query' instead.")]
        public string findSenseForWord;
        public SourceDictionary includeSourceDictionaries;
        public PartOfSpeech includePartOfSpeech;
        public ExpandTerm expandTerms;
        public bool includeTags;
        public int limit;
    }
    public struct SearchParameters : IParameters
    {
        public string Query { get; set; }
        public bool caseSensitive;
        public PartOfSpeech includePartOfSpeech;
        public int skip;
        public int limit;
    }
    public struct WordOfTheDayParameters : IParameters
    {
        public string Query { get; set; }
        /// <summary>
        /// format : "yyyy-MM-dd"
        /// </summary>
        public string date;
    }
}