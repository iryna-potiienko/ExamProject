﻿namespace EquitationsCalculator
{
    public class ChartData
    {
        public ChartData(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double X { get; set; }

        public double Y { get; set; }
    }
}