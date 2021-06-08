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
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtBrand { get; set; }
        public TextView txtBodyType { get; set; }
        public TextView txtColor { get; set; }
    }
    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Car> carsList;
        public ListViewAdapter(Activity activity, List<Car> carsList)
        {
            this.activity = activity;
            this.carsList = carsList;
        }
        public override int Count
        {
            get { return carsList.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return carsList[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view, parent, false);
            var txtBrand = view.FindViewById<TextView>(Resource.Id.txtView_Name);
            var txtBodyType = view.FindViewById<TextView>(Resource.Id.txtView_Depart);
            var txtColor = view.FindViewById<TextView>(Resource.Id.txtView_Email);
            var txtVEngine = view.FindViewById<TextView>(Resource.Id.VEngine);
            var txtPrice = view.FindViewById<TextView>(Resource.Id.Price);
            txtBrand.Text = carsList[position].Brand;
            txtBodyType.Text = carsList[position].BodyType;
            txtColor.Text = carsList[position].Color;
            txtVEngine.Text = carsList[position].VEngine.ToString();
            txtPrice.Text = carsList[position].Price.ToString();
            return view;
        }
    }
}