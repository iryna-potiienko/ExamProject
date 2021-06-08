using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace ExaminationProject
{
    [Activity(Label = "Contacts")]
    public class ContactsActivity: AppCompatActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);

            SetContentView (Resource.Layout.contacts_view);
            
            // Create an use a custom adapter (displays the photo if available)
            var contactsAdapter = new ContactsAdapter(this);
            //contactsAdapter.FillContacts();
            var contactsListView = FindViewById<ListView>(Resource.Id.ContactsListView);
            contactsListView.Adapter = contactsAdapter;
            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}