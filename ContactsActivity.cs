using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace CarsDatabase
{
    [Activity(Label = "ContactsActivity")]
    public class ContactsActivity: Activity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            SetContentView (Resource.Layout.contacts_view);
            
            // Create an use a custom adapter (displays the photo if available)
            var contactsAdapter = new ContactsAdapter(this);
            //contactsAdapter.FillContacts();
            var contactsListView = FindViewById<ListView>(Resource.Id.ContactsListView);
            contactsListView.Adapter = contactsAdapter;

            var buttonAll = FindViewById<Button>(Resource.Id.NumbersAll);
            var buttonNumbersEnds7 = FindViewById<Button>(Resource.Id.NumbersEnds7); 
            
            buttonAll.Click += delegate
            {
                contactsAdapter.FillContacts();
            };
            buttonNumbersEnds7.Click+= delegate
            {
                contactsAdapter.FillContactsEnds7();
                //contactsListView.UpdateViewLayout(contactsAdapter.GetView());
            };
        }
    }
}