using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationProject
{
    public class Photo
    {
        public Photo(int id, string caption, string additional)
        {
            PhotoID = id;
            Caption = caption;
            Aditional = additional;
        }

        // Return the ID of the photo:
        public int PhotoID { get; }

        // Return the Caption of the photo:
        public string Caption { get; }
        public string Aditional { get; }
    }

    // Photo album: holds image resource IDs and caption:
    public class PhotoAlbum
    {
        // Built-in photo collection - this could be replaced with
        // a photo database:

        static Photo[] mBuiltInPhotos = {
            new Photo ( Resource.Drawable.map_smr,
                        "1) Build route from your current location to any destination that you want travel to", 
                        "\nYou can do it simply by going to Map, entering destination point and clicking button route"),
            new Photo ( Resource.Drawable.contacts_sm,
                        "2) See the set of your contacts which end with number 7",
                        "\nYou can do it by clicking on Contacts in main menu"),
            new Photo ( Resource.Drawable.cars_sm,
                        "3) Add, remove and update your cars",
                        "\nYou can do it on the Cars page"),
            new Photo ( Resource.Drawable.equitations_calculator_sm,
                        "4) Solve your equations using Dyhotomy, Newton and Modified Newton methods",
                        "\nYou can do it by going to Equation Calculator page, entering your values and clicking Calculate button." +
                "\nMoreover, build plot by clicking Plot button!"),
            new Photo ( Resource.Drawable.aboutMe_sm,
                        "5) See information about creator by clicking About author in main menu",
                        "")
            };

        // Array of photos that make up the album:
        private Photo[] mPhotos;

        // Create an instance copy of the built-in photo list 
        public PhotoAlbum()
        {
            mPhotos = mBuiltInPhotos;
        }

        // Return the number of photos in the photo album:
        public int NumPhotos
        {
            get { return mPhotos.Length; }
        }

        // Indexer (read only) for accessing a photo:
        public Photo this[int i]
        {
            get { return mPhotos[i]; }
        }

    }
}