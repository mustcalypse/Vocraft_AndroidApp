using Android.App;
using Android.OS;
using Android.Views;

namespace Vocraft
{
    public class MainScreenFragment : Fragment
    {
        int layout;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var s = Arguments?.GetString("chosen_menu_item") ?? string.Empty;
            createLayout(s.ToLower());
        }
        void createLayout(string choose)
        {
            if (choose == "examples")
                layout = Resource.Layout.examples_layout;
            else if (choose == "relateds")
                layout = Resource.Layout.relateds_layout;
            else if (choose == "article")
                layout = Resource.Layout.article_layout;
            else
                layout = Resource.Layout.definitions_layout;
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState) => view.RequestLayout();
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(layout, container, false);
        }
    }
}