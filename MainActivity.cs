using System;
using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace CarsDatabase
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        ListView lstViewData;
        List<Car> listSource = new List<Car>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            //Create Database  
            db = new Database();
            db.createDatabase();
            //db.removeTable
            lstViewData = FindViewById<ListView>(Resource.Id.listView);
            var editBrand = FindViewById<EditText>(Resource.Id.edtName);
            var editBodyType = FindViewById<EditText>(Resource.Id.edtDepart);
            var editColor = FindViewById<EditText>(Resource.Id.edtEmail);
            var editVEngine = FindViewById<EditText>(Resource.Id.VEngine);
            var editPrice = FindViewById<EditText>(Resource.Id.Price);

            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            var btnRemove = FindViewById<Button>(Resource.Id.btnRemove);
            var btnAverage = FindViewById<Button>(Resource.Id.btnAverage);
            Button btnQuary = FindViewById<Button>(Resource.Id.btnQuary);
            Button btnAllCars = FindViewById<Button>(Resource.Id.btnAllCars);

            TextView averageVEngine = FindViewById<TextView>(Resource.Id.AverageVEngine);
            //Load Data  
            LoadData();
            //Event  
            btnAdd.Click += delegate
            {
                Car car = new Car()
                {
                    Brand = editBrand.Text,
                    BodyType = editBodyType.Text,
                    Color = editColor.Text,
                    VEngine=Convert.ToDouble(editVEngine.Text),
                    Price = Convert.ToDouble(editPrice.Text)
                };
                db.insertIntoTable(car);
                LoadData();
            };
            btnEdit.Click += delegate
            {
                Car car = new Car()
                {
                    Id = int.Parse(editBrand.Tag.ToString()),
                    Brand = editBrand.Text,
                    BodyType = editBodyType.Text,
                    Color = editColor.Text,
                    VEngine = Convert.ToDouble(editVEngine.Text),
                    Price = Convert.ToDouble(editPrice.Text)
                };
                db.updateTable(car);
                LoadData();
            };
            btnRemove.Click += delegate
            {
                Car car = new Car()
                {
                    Id = int.Parse(editBrand.Tag.ToString()),
                    Brand = editBrand.Text,
                    BodyType = editBodyType.Text,
                    Color = editColor.Text,
                    VEngine = Convert.ToDouble(editVEngine.Text),
                    Price = Convert.ToDouble(editPrice.Text)
                };
                db.removeTable(car);
                LoadData();
            };
            lstViewData.ItemClick += (s, e) =>
            {
                //Set Backround for selected item  
               /* for (int i = 0; i < lstViewData.Count; i++)
                {
                    if (e.Position == i)
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Gray);
                    else
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }*/
                //Binding Data  
                var txtBrand = e.View.FindViewById<TextView>(Resource.Id.txtView_Name);
                var txtBodyType = e.View.FindViewById<TextView>(Resource.Id.txtView_Depart);
                var txtColor = e.View.FindViewById<TextView>(Resource.Id.txtView_Email);
                var txtVEngine = e.View.FindViewById<TextView>(Resource.Id.VEngine);
                var txtPrice = e.View.FindViewById<TextView>(Resource.Id.Price);
                editBrand.Text = txtBrand.Text;
                editBrand.Tag = e.Id;
                editBodyType.Text = txtBodyType.Text;
                editColor.Text = txtColor.Text;
                editVEngine.Text = txtVEngine.Text;
                editPrice.Text = txtPrice.Text;
            };
            btnAverage.Click += delegate
            {
                averageVEngine.Text = db.AverageVEngine().ToString();
            };
            btnQuary.Click += delegate
            {
                SelectData();
            };
            btnAllCars.Click += delegate
            {
                LoadData();
            };
        }

        private void LoadData()
        {
            listSource = db.selectTable();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
        private void SelectData()
        {
            listSource = db.SqlQuary();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                var intent = new Intent(this, typeof(ContactsActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.nav_gallery)
            {

            }
            else if (id == Resource.Id.nav_slideshow)
            {

            }
            else if (id == Resource.Id.nav_manage)
            {

            }
            else if (id == Resource.Id.nav_share)
            {

            }
            else if (id == Resource.Id.nav_send)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

