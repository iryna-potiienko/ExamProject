using Android.App;
using Android.OS;

namespace CarsDatabase
{
    [Activity(Label = "AboutMe")]
    public class AboutMe : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutMe);
        }
    }
}