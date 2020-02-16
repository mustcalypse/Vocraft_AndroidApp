namespace WordnikLib.ParameterProviders
{
    public enum SourceDictionary
    {
        _none = 0,
        all,
        ahd,
        century,
        wiktionary,
        webster,
        wordnet
    }
    public enum ExpandTerm
    {
        _none = 0,
        synonym,
        hypernym
    }
    public enum RelationshipType
    {
        _none = 0,
        synonym,
        antonym,
        variant,
        equivalent,
        cross_reference,
        related_word,
        rhyme,
        form,
        etymologically_related_term,
        hypernym,
        hyponym,
        inflected_form,
        primary,
        same_context,
        verb_form,
        verb_stem
    }
    public enum PartOfSpeech
    {
        _none = 0,
        noun,
        adjective,
        verb,
        adverb,
        interjection,
        pronoun,
        preposition,
        abbreviation,
        affix,
        article,
        auxiliary_verb,
        conjunction,
        definite_article,
        family_name,
        given_name,
        idiom,
        imperative,
        noun_plural,
        noun_posessive,
        past_participle,
        phrasal_prefix,
        proper_noun,
        proper_noun_plural,
        proper_noun_posessive,
        suffix,
        verb_intransitive,
        verb_transitive
    }
}