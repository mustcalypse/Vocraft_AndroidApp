using System;
using System.Linq;
using WordnikLib.ParameterProviders;

namespace WordnikLib
{
    static class UrlGenerator
    {
        public static string Generate(this IParameters @params, Type queryType, params string[] constant_params)
        {
            T GetAttribute<T>(bool inherited) where T : Attribute => (queryType.GetCustomAttributes(typeof(T), inherited)[0] as T);

            string createEndPoint()
            {
                string end_p = GetAttribute<UrlOrderAttribute>(true).GenerateEndPoint(GetAttribute<UrlProviderAttribute>(false));
                return end_p.Replace("%q", @params.Query);
            }

            Func<System.Reflection.FieldInfo, bool> isValid = (x) =>
            {
                object v = x.GetValue(@params);
                switch (v)
                {
                    case int i when (i == default):
                    case bool b when (b == default):
                    case ExpandTerm e when (e == default):
                    case PartOfSpeech p when (p == default):
                    case RelationshipType r when (r == default):
                    case SourceDictionary s when (s == default):
                    case string t when (t == string.Empty):
                    case null: return false;
                    default: return true;
                }
            };

            Func<System.Reflection.FieldInfo, string> selector = (i) => $"{i.Name}={i.GetValue(@params).ToString().Replace("_", "-")}";

            string createParameters() => string.Join("&", @params.GetType().GetFields().Where(isValid).Select(selector));

            string url = createEndPoint();
            string plain_Params = createParameters();
            return $"{url}{plain_Params}&{ string.Join("&", constant_params)}";
        }
    }
}