namespace WordnikLib
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    class UrlProviderAttribute : System.Attribute
    {
        public string ApiFileName { get; set; }
        public string ClassName { get; set; }

        public UrlProviderAttribute(string api_file_name, string class_name)
        {
            ApiFileName = api_file_name;
            ClassName = class_name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class)]
    class UrlOrderAttribute : System.Attribute
    {
        public string[] Orders { get; set; }
        public UrlOrderAttribute(params string[] orders) => Orders = orders;
        public string GenerateEndPoint(UrlProviderAttribute p)
        {
            foreach (string item in Orders)
                if (item.Contains(p.ApiFileName))
                    return item.Replace("%c", p.ClassName);
            throw new System.ArgumentNullException();
        }
    }
}