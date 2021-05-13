using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Locations;
using Android.Widget;
using Java.Lang;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Exception = System.Exception;
using Location = Android.Locations.Location;

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
        LocationManager locationManager; //Location Manager
        string locationProvider = string.Empty; //Location Provider

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.maps_view);

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

                        marker1 = eMap.AddMarker(new MarkerOptions().SetPosition(latlng).SetTitle("My location")
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
	            FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            eMap = googleMap;
            
            //CDN's center
            latlng2 = new LatLng(50.484001, 30.636866);

            //var marker = eMap.AddMarker(new MarkerOptions().SetPosition(latlng2).SetTitle("Center")
             //   .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueViolet)));
            
            //Set the firt view of the CDN
            CameraPosition INIT = new CameraPosition.Builder()
                .Target(latlng2)
                .Zoom(13.2F)
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

        async void BuildPath(string address)
        {
            try
            {
	            eMap.Clear();
	            marker1 = eMap.AddMarker(new MarkerOptions().SetPosition(latlng).SetTitle("My location")
		            .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan)));
	            
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();
                
                    //Toast.MakeText(ApplicationContext,
                   //     string.Format("Latitude: {0}, Longitude: {1}", location.Latitude, location.Longitude),ToastLength.Long).Show();

               var pointCoordinates = new LatLng(location.Latitude, location.Longitude);
               destinationMarker = eMap.AddMarker(new MarkerOptions().SetPosition(pointCoordinates).SetTitle("Destination point")
                   .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed)));
               
               string strGoogleDirectionUrlConstraction="https://maps.googleapis.com/maps/api/directions/json?origin={0},{1}&destination={2},{3}&key=AIzaSyCBOeufwGrgYNWxv84GZY5UM59jkX1xtYQ";
               var strGoogleDirectionUrl = string.Format(strGoogleDirectionUrlConstraction, latlng.Latitude, latlng.Longitude, 
	               location.Latitude, location.Longitude);
               string strJSONDirectionResponse = await FnHttpRequest(strGoogleDirectionUrl);
               
               FnUpdateCameraPosition(pointCoordinates);
               FnSetDirectionQuery ( strJSONDirectionResponse );
            }
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
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng2, 13.2F);
            eMap.MoveCamera(camera);
        }

        void route_Click(object sender, EventArgs e)
        {
            string destinationPointName = destinationPoint.Text;
            BuildPath(destinationPointName);
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
		void FnSetDirectionQuery(string strJSONDirectionResponse)
		{
			var objRoutes = JsonConvert.DeserializeObject<GoogleDirectionClass> ( strJSONDirectionResponse );  
			//objRoutes.routes.Count  --may be more then one 
			if ( objRoutes.routes.Count > 0 )
			{
				string encodedPoints =	objRoutes.routes [0].overview_polyline.points; 

				var lstDecodedPoints =	FnDecodePolylinePoints ( encodedPoints ); 
				//convert list of location point to array of latlng type
				var latLngPoints = new LatLng[lstDecodedPoints.Count]; 
				int index = 0;
				foreach ( var loc in lstDecodedPoints )
				{
					latLngPoints[index++] = loc; //new LatLng ( loc.Latitude , loc.Longitude );
				}

				var polylineoption = new PolylineOptions (); 
				polylineoption.InvokeColor ( Android.Graphics.Color.Green );
				polylineoption.Geodesic ( true );
				polylineoption.Add ( latLngPoints ); 
				RunOnUiThread ( () =>
				eMap.AddPolyline ( polylineoption ) ); 
			}
		}

		List<LatLng> FnDecodePolylinePoints(string encodedPoints) 
		{
			if ( string.IsNullOrEmpty ( encodedPoints ) )
				return null;
			var poly = new List<LatLng>();
			char[] polylinechars = encodedPoints.ToCharArray();
			int index = 0;

			int currentLat = 0;
			int currentLng = 0;
			int next5bits;
			int sum;
			int shifter;

			try
			{
				while (index < polylinechars.Length)
				{
					// calculate next latitude
					sum = 0;
					shifter = 0;
					do
					{
						next5bits = (int)polylinechars[index++] - 63;
						sum |= (next5bits & 31) << shifter;
						shifter += 5;
					} while (next5bits >= 32 && index < polylinechars.Length);

					if (index >= polylinechars.Length)
						break;

					currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

					//calculate next longitude
					sum = 0;
					shifter = 0;
					do
					{
						next5bits = (int)polylinechars[index++] - 63;
						sum |= (next5bits & 31) << shifter;
						shifter += 5;
					} while (next5bits >= 32 && index < polylinechars.Length);

					if (index >= polylinechars.Length && next5bits >= 32)
						break;

					currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
					
					var lat = Convert.ToDouble(currentLat) / 100000.0;
					var lng = Convert.ToDouble(currentLng) / 100000.0;
					LatLng p = new LatLng(lat, lng);
					poly.Add(p);
				} 
			}
			catch 
			{
				//RunOnUiThread ( () =>
				//	Toast.MakeText ( this , Constants.strPleaseWait , ToastLength.Short ).Show () ); 
			}
			return poly;
		}

		
		
		void FnUpdateCameraPosition(LatLng pos)
		{
			try
			{
				CameraPosition.Builder builder = CameraPosition.InvokeBuilder(); 
				builder.Target(pos);
				builder.Zoom(12);
				builder.Bearing(45);
				builder.Tilt(10);
				CameraPosition cameraPosition = builder.Build(); 
				CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition); 
				eMap.AnimateCamera(cameraUpdate);
			}
			catch( Exception e)
			{
				Console.WriteLine ( e.Message );

			}
		}

		WebClient webclient;
		async Task<string> FnHttpRequest(string strUri)
		{ 
			webclient = new WebClient ();
			string strResultData;
			try
			{
				strResultData= await webclient.DownloadStringTaskAsync (new Uri(strUri));
				Console.WriteLine(strResultData);
			}
			catch
			{
				//strResultData = Constants.strException;
				strResultData = "Exeption!";
			}
			finally
			{
				if ( webclient!=null )
				{
					webclient.Dispose ();
					webclient = null; 
				}
			}

			return strResultData;
		}
    }

}