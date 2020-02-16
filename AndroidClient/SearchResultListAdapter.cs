using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vocraft
{
    class SearchResultListAdapter : BaseAdapter<string>
    {
        Context context;
        static object obj = new object();
        List<string> wordsList = new List<string>();
        WordnikLib.SearchQuery searchQuery = new WordnikLib.SearchQuery();
        public SearchResultListAdapter(Context ctext) => context = ctext;
        public async Task FillListAsync(string wrd_to_search)
        {
            wrd_to_search = wrd_to_search.TrimEnd().TrimStart();
            if (wrd_to_search.Length < 0) { wordsList?.Clear(); NotifyDataSetChanged(); return; };
            var a = await searchQuery.Get(wrd_to_search);
            lock (obj)
            {
                if (a.totalResults > 0) wordsList = a.searchResults?.Select(i => i.word).ToList();
                else wordsList?.Clear();
                NotifyDataSetChanged();
            }
        }
        public override string this[int position] => wordsList[position] ?? string.Empty;
        public override int Count => wordsList.Count;
        public override long GetItemId(int position) => position + 1;
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = LayoutInflater.FromContext(context).Inflate(Resource.Layout.search_result_list_item, parent, false);
            var word = view.FindViewById<TextView>(Resource.Id.tvsearch_result_item);
            word.Text = wordsList[position];
            return view;
        }
    }
}