using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace ExaminationProject
{
    [Activity(Label = "About author")]
    public class AboutMe : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutMe);
        }
    }
}