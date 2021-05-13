using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Locations;
using Android.Widget;
using Java.Lang;
using Xamarin.Essentials;
using Exception = System.Exception;
using Location = Android.Locations.Location;
//using GoogleMapsAPI.NET.API.Client;

namespace CarsDatabase
{
    [Activity(Label = "MapsActivity")]
    public class MapsActivity: Activity, IOnMapReadyCallback, ILocationListener
    {
        private GoogleMap eMap; //Map
        private Button recentre; //Button
        private Button route; //Button
        private EditText destinationPoint;
        private LatLng latlng; //Latitude and longitude of our position
        private LatLng latlng2; //CDN's center
        private LatLng _latlngService; //variable that contain the latitude and longitude of the service
        private Marker marker1; //marker of our position
        private Marker destinationMarker;
        double latitudine; //latitude for the method UpdateLocation()
        double longitudine; //longitude for the method UpdateLocation()
        //double lat_s; //variable for take the latitude of the service
        //double lon_s; //variable for take the longitude of the service
        LocationManager locationManager; //Location Manager
        string locationProvider = string.Empty; //Location Provider

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.maps_view);

            //take arguments from the previous activity, that are the latitude and longitude of the choosen service
            //lat_s = Intent.Extras.GetDouble("Latitude");
            //lon_s = Intent.Extras.GetDouble("Longitude");

            //Set up the map
            SetUpMap();

            //Inizialize the location 
            InitializeLocationManager();

            //recenter button
            recentre = FindViewById<Button>(Resource.Id.recenter);
            route = FindViewById<Button>(Resource.Id.route);
            destinationPoint = FindViewById<EditText>(Resource.Id.DestinationPointName);

            recentre.Click += recentre_Click;
            route.Click += route_Click;
        }


        public override void OnBackPressed()
        {
            eMap.Clear();
            this.Finish();
        }

        void InitializeLocationManager()
        {
            // initialise the location manager 
            locationManager = (LocationManager) GetSystemService(LocationService);
            // define its Criteria
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Medium
            };
            // find a location provider (GPS, wi-fi, etc.)
            IList<string> acceptableLocationProviders = locationManager.GetProviders(criteriaForLocationService, true);
            // if we have any, use the first one
            if (acceptableLocationProviders.Any())
                locationProvider = acceptableLocationProviders.First();
            else
                locationProvider = string.Empty;
        }

        public void OnLocationChanged(Location location)
        {
            //if location has changed
            if (location != null)
            {
                latitudine = location.Latitude;
                longitudine = location.Longitude;
                if (latitudine > 0 && longitudine > 0)
                {
                    //if the map already exists
                    if (eMap != null)
                    {
                        latlng = new LatLng(latitudine, longitudine);
                        //If already exists a marker, delete it
                        if (marker1 != null)
                        {
                            marker1.Remove();
                            marker1 = null;
                        }

                        marker1 = eMap.AddMarker(new MarkerOptions().SetPosition(latlng).SetTitle("UpdateLocation")
                            .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan)));
                        //eMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(latlng2, 15.7F));
                    }
                    //Toast.MakeText(ApplicationContext, string.Format("UPDATE LOCATION lat => {0} long => {1}", location.Latitude, location.Longitude), ToastLength.Long).Show();
                }
            }
        } // end onLocationChanged

        protected override void OnResume()
        {
            base.OnResume();
            if (locationProvider != string.Empty)
                locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);
        } // end OnResume

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        } // end OnPause

        private void SetUpMap()
        {
            if (eMap == null)
            {
                /*var mapFrag = MapFragment.NewInstance();
                activity.FragmentManager.BeginTransaction()
                    .Add(Resource.Id.map_container, mapFrag, "map_fragment")
                    .Commit();*/
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            eMap = googleMap;
            //latitude and longitude of the service taken from the previous activity
           /* _latlngService = new LatLng(lat_s, lon_s);

            //service marker
            MarkerOptions options1 = new MarkerOptions()
                .SetPosition(_latlngService)
                .SetTitle("Your Service is here")
                .SetIcon(BitmapDescriptorFactory.DefaultMarker());
            eMap.AddMarker(options1);*/

            //CDN's center
            latlng2 = new LatLng(50.381,  30.495);

            //img overlay
            /*GroundOverlayOptions groundOverlayOptions = new GroundOverlayOptions();
            BitmapDescriptor marker = BitmapDescriptorFactory.DefaultMarker();
            groundOverlayOptions.InvokeImage(image);
            groundOverlayOptions.Position(latlng2, 725, 450);
            groundOverlayOptions.InvokeBearing(-7.70F);
            eMap.AddGroundOverlay(groundOverlayOptions);*/

           var marker = eMap.AddMarker(new MarkerOptions().SetPosition(latlng2).SetTitle("Center")
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueViolet)));
            
            //Set the firt view of the CDN
            CameraPosition INIT = new CameraPosition.Builder()
                .Target(latlng2)
                .Zoom(14.2F)
                .Bearing(82F)
                .Build();

            eMap.AnimateCamera(CameraUpdateFactory.NewCameraPosition(INIT));
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        async void Geocode(string address)
        {
            try
            {
                //destinationMarker.Remove(); //= new Marker();
                //var address1 =  "Microsoft Building 25 Redmond WA USA";
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();
                //if (location != null)
                //{
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Toast.MakeText(ApplicationContext,
                        string.Format("Latitude: {0}, Longitude: {1}", location.Latitude, location.Longitude),
                        ToastLength.Long).Show();
               // }

               var pointCoordinates = new LatLng(location.Latitude,
                   location.Longitude);
               destinationMarker = eMap.AddMarker(new MarkerOptions().SetPosition(pointCoordinates).SetTitle("Destination point")
                   .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed)));
               //var client = new MapsAPIClient("AIzaSyBfckBchOpn-lM4oJ9V9nBDBZmmlousIRQ");
               //var geocodeResult = client.Geocoding.Geocode(brokerModel.Adress).Results.FirstOrDefault().Geometry.Location;
               //var geocodeResult = Geocoding.Geocode("1600 Amphitheatre Parkway, Mountain View, CA");

               //var geocoder = new Geocoder(this);
               //IList<Address> addressList = await geocoder.GetFromLocationNameAsync(address1,1);
               //Address address = addressList.FirstOrDefault();
               
                //return location;
            }
            /*catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }*/
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
                Toast.MakeText(ApplicationContext,
                    ex.Message,
                    ToastLength.Long).Show();
                //return null;
            }
        }

        void recentre_Click(object sender, EventArgs e)
        {
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng2, 16.2F);
            eMap.MoveCamera(camera);
        }

        void calculate_Route()
        {

        }

        void route_Click(object sender, EventArgs e)
        {
            string destinationPointName = destinationPoint.Text;
            //var destinationPointResult = 
                Geocode(destinationPointName);

            /*var pointCoordinates = new LatLng(destinationPointResult.Result.Latitude,
                destinationPointResult.Result.Longitude);
            var marker = eMap.AddMarker(new MarkerOptions().SetPosition(pointCoordinates).SetTitle("Destination point")
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed)));
            */
            calculate_Route();
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

}