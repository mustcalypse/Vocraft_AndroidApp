using Android.App;
using Android.OS;
using Android.Widget;

namespace Vocraft
{
    [Activity(Label = "Vocraft", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView lvSearchResultContainer;
        SearchResultListAdapter searchResultListAdapter;
        SearchView txtSearch;
        Button[] buttons;
        WordnikLib.RandomWordQuery randomWord = new WordnikLib.RandomWordQuery();
        string wordOftheDay;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            #region initializing
            base.OnCreate(savedInstanceState);
            SetTheme(Android.Resource.Style.ThemeDeviceDefaultLightNoActionBar);
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            SetContentView(Resource.Layout.Main);
            lvSearchResultContainer = FindViewById<ListView>(Resource.Id.lvSearchResultContainer);
            lvSearchResultContainer.SetBackgroundColor(Android.Graphics.Color.LightGray);
            txtSearch = FindViewById<SearchView>(Resource.Id.txtSearch);
            searchResultListAdapter = new SearchResultListAdapter(this);
            lvSearchResultContainer.Adapter = searchResultListAdapter;
            lvSearchResultContainer.ItemClick += ListView1_ItemClick;
            txtSearch.QueryTextChange += TxtSearch_QueryTextChange;
            var btnShowDefinitions = FindViewById<Button>(Resource.Id.btnShowDefinitions);
            var btnShowExamples = FindViewById<Button>(Resource.Id.btnShowExamples);
            var btnShowRelateds = FindViewById<Button>(Resource.Id.btnShowRelateds);
            var btnShowEtimology = FindViewById<Button>(Resource.Id.btnShowArticle);
            btnShowDefinitions.Click += buttonsClick;
            btnShowExamples.Click += buttonsClick;
            btnShowRelateds.Click += buttonsClick;
            btnShowEtimology.Click += buttonsClick;
            buttons = new Button[] { btnShowDefinitions, btnShowExamples, btnShowRelateds, btnShowEtimology };
            btnShowDefinitions.PerformClick();           
            #endregion
        }
        protected override void OnStart()
        {
            base.OnStart();
            txtSearch.Post(async () => wordOftheDay = (await new WordnikLib.WordOfTheDayQuery().Get()).word);
        }

        private void TxtSearch_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (txtSearch.Query == "random")
            {
                txtSearch.Post(async () =>
                {
                    var res = await randomWord.Get();
                    if (res.Count > 0) txtSearch.SetQuery(res[0].word, false);
                });
                return;
            }
            lvSearchResultContainer.Post(async () =>
            {
                await searchResultListAdapter.FillListAsync(txtSearch.Query);
            });
        }

        private void ListView1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string chosen_word = searchResultListAdapter[e.Position];
            if (chosen_word.Length > 0) { }
        }

        private void buttonsClick(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (var item in buttons)
                item.SetTextColor(Android.Graphics.Color.Black);
            btn.SetTextColor(Android.Graphics.Color.Red);

            Bundle bundle = new Bundle();
            bundle.PutString("chosen_menu_item", btn.Text);
            MainScreenFragment mainScreen = new MainScreenFragment
            {
                Arguments = bundle
            };
            var tr = FragmentManager.BeginTransaction();
            tr.Replace((Resource.Id.LayoutMainScreen), mainScreen);
            tr.Commit();
        }
    }
}