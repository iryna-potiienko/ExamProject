using System;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.App;
using Android.Provider;
using System.Collections.Generic;
using Android.Database;

namespace ExaminationProject
{
    public class ContactsAdapter : BaseAdapter {
        List<Contact> contactList;
        Activity activity;
        
        public ContactsAdapter (Activity activity)
        {
            this.activity = activity;
            
            FillContacts ();
        }
        
        public override int Count {
            get { return contactList.Count; }
        }

        public override Java.Lang.Object GetItem (int position)
        {
            return null; // could wrap a Contact in a Java.Lang.Object to return it here if needed
        }

        public override long GetItemId (int position)
        {
            return contactList [position].Id;
        }
        
        public override View GetView (int position, View convertView, ViewGroup parent)
        {          
            var view = convertView ?? activity.LayoutInflater.Inflate (Resource.Layout.ContactListItem, parent, false);
            var contactName = view.FindViewById<TextView> (Resource.Id.ContactName);
            var contactNumber = view.FindViewById<TextView>(Resource.Id.ContactNumber);
            var contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);
            
            contactName.Text = contactList [position].DisplayName;
            contactNumber.Text = contactList [position].PhoneNumber;
            
            if (contactList [position].PhotoId == null) {
                
                contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);
                contactImage.SetImageResource (Resource.Drawable.ContactImage);
                
            } else {
                
                var contactUri = ContentUris.WithAppendedId (ContactsContract.Contacts.ContentUri, contactList [position].Id);
                var contactPhotoUri = Android.Net.Uri.WithAppendedPath (contactUri, Contacts.Photos.ContentDirectory);
    
                contactImage.SetImageURI (contactPhotoUri);
            }
            return view;
        }
        
        public void FillContacts ()
        {
            var uri = ContactsContract.Contacts.ContentUri;
            
            string[] projection = { 
                ContactsContract.Contacts.InterfaceConsts.Id, 
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.Contacts.InterfaceConsts.PhotoId,
                ContactsContract.Contacts.InterfaceConsts.HasPhoneNumber
            };

            // CursorLoader introduced in Honeycomb (3.0, API11)
            var loader = new CursorLoader(activity, uri, projection, null, null, null);
            var cursor = (ICursor)loader.LoadInBackground();

            contactList = new List<Contact> ();

            String phoneNumber = "";
            if (cursor.MoveToFirst ()) {
                do
                {
                    var contactName =
                        cursor.GetString(cursor.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName));
                    string[] selectionArgs =
                    {
                        contactName
                    };
                    var hasPhoneNumber = Convert.ToInt32(cursor.GetString(cursor.GetColumnIndex(projection[3])));
                    if (hasPhoneNumber==1)
                    {
                        var loader1 = new CursorLoader(
                            activity,
                            ContactsContract.CommonDataKinds.Phone.ContentUri,
                            null,
                            ContactsContract.Contacts.InterfaceConsts.DisplayName + " = ?",
                            selectionArgs,
                            null
                        );
                        var cursorPhone = (ICursor)loader1.LoadInBackground();
                        while (cursorPhone.MoveToNext())
                        {
                            phoneNumber =
                                cursorPhone.GetString(
                                    cursorPhone.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number));

                            if (phoneNumber.EndsWith("7"))
                            {
                                contactList.Add(new Contact
                                {
                                    Id = cursor.GetLong(cursor.GetColumnIndex(projection[0])),
                                    DisplayName = contactName,
                                    PhotoId = cursor.GetString(cursor.GetColumnIndex(projection[2])),
                                    PhoneNumber = phoneNumber
                                });
                            }
                        }
                    }
                } while (cursor.MoveToNext());
            }
        }

        public void FillContactsEnds7()
        {
            int i = 0;
            var contactsEnds7 = new List<Contact>();
            foreach (var contact in contactList)
            {
                if (contact.PhoneNumber.EndsWith("7"))
                {
                    contactsEnds7.Add(contact);
                    GetView(i,null,null);
                    i++;
                }
            }

            contactList = contactsEnds7;
        }
    }
}