using System.Collections.Generic;
using System.Threading.Tasks;
using WordnikLib.ParameterProviders;
using WordnikLib.Results;

namespace WordnikLib
{
    [UrlOrder("word.json/%q/%c?", "words.json/%c/%q?")]
    public abstract class ApiQuery<TResult, TParam> where TParam : IParameters
    {
        static readonly string api_key = "#NO_KEY";
        static ApiQuery() => HttpHelper.BaseURL = "http://api.wordnik.com/v4/";
        string GenerateUrl(TParam @params) => @params.Generate(GetType(), $"{nameof(api_key)}={api_key}");

        protected async Task<TResult> Get() => await Get(System.Activator.CreateInstance<TParam>());

        public virtual async Task<TResult> Get(string word)
        {
            var Parameters = System.Activator.CreateInstance<TParam>();
            Parameters.Query = word;
            return await Get(Parameters);
        }
        public virtual async Task<TResult> Get(TParam @params) => await HttpHelper.GetResultAsync<TResult>(GenerateUrl(@params));
    }    
}

namespace WordnikLib
{
    [UrlProvider("words.json", "search")]
    public class SearchQuery : ApiQuery<WordSearchResults, SearchParameters> { }
    [UrlProvider("words.json", "reverseDictionary")]
    public class ReverseDictionaryQuery : ApiQuery<ReverseDictionary, ReverseDictionaryParameters>
    {
        public override Task<ReverseDictionary> Get(string word) => base.Get(new ReverseDictionaryParameters { query = word });
    }
    [UrlProvider("words.json", "wordOfTheDay")]
    public class WordOfTheDayQuery : ApiQuery<WordOfTheDay, WordOfTheDayParameters>
    {
        new public Task<WordOfTheDay> Get() => base.Get();
    }
    [UrlProvider("words.json", "randomWords")]
    public class RandomWordQuery : ApiQuery<List<RandomWordObject>, RandomWordsParameters>
    {
        new public Task<List<RandomWordObject>> Get() => base.Get();
    }
}

namespace WordnikLib
{
    [UrlProvider("word.json", "examples")]
    public class ExampleQuery : ApiQuery<ExamplesResult, ExamplesParameters> { }
    [UrlProvider("word.json", "audio")]
    public class AudioQuery : ApiQuery<List<AudioFile>, AudioParameters> { }
    [UrlProvider("word.json", "relatedWords")]
    public class RelatedQuery : ApiQuery<List<RelatedWord>, RelatedWordsParameters> { }
    [UrlProvider("word.json", "pronunciations")]
    public class PronunciationsQuery : ApiQuery<List<TextPron>, PronunciationsParameters> { }
    [UrlProvider("word.json", "phrases")]
    public class PhrasesQuery : ApiQuery<List<Bigram>, PhrasesParameters> { }
    [UrlProvider("word.json", "etymologies")]
    public class EtymologiesQuery : ApiQuery<List<string>, EtymologiesParameters> { }
    [UrlProvider("word.json", "topExample")]
    public class TopExampleQuery : ApiQuery<Example, TopExampleParameters> { }
    [UrlProvider("word.json", "definitions")]
    public class DefinitionsQuery : ApiQuery<List<Definition>, DefinitionsParameters> { }
    [UrlProvider("word.json", "frequency")]
    public class FrequencyQuery : ApiQuery<FrequencySummary, FrequencyParameters> { }
}
