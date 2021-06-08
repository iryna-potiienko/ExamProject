using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExaminationProject
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string BodyType { get; set; }
        public string Color { get; set; }
        public double VEngine { get; set; }
        public double Price { get; set; }
    }
}