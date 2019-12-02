using System;

namespace DefenseIO.Domain.Domains.Geographic.Services
{
  public class DistanceService
  {
    public double GetDistanceBetweenTwoPointsInKms(GeoPoint p1, GeoPoint p2)
    {
      if ((p1.Latitude == p2.Latitude) && (p1.Longitude == p2.Longitude))
      {
        return 0;
      }
      else
      {
        var radlat1 = Math.PI * p1.Latitude / 180;

        var radlat2 = Math.PI * p2.Latitude / 180;

        var theta = p1.Longitude - p2.Longitude;

        var radtheta = Math.PI * theta / 180;

        var dist = Math.Sin(radlat1) * Math.Sin(radlat2) + Math.Cos(radlat1) * Math.Cos(radlat2) * Math.Cos(radtheta);

        if (dist > 1)
        {
          dist = 1;
        }
        dist = Math.Acos(dist);
        dist = dist * 180 / Math.PI;
        dist = dist * 60 * 1.1515;

        // TO kms
        dist *= 1.609344;

        return dist;
      }
    }

    private double deg2rad(double deg)
    {
      return (deg * Math.PI / 180.0);
    }

    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //::  This function converts radians to decimal degrees             :::
    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    private double rad2deg(double rad)
    {
      return (rad / Math.PI * 180.0);
    }
  }
}
public class GeoPoint
{
  public double Latitude { get; set; }
  public double Longitude { get; set; }

  public GeoPoint(double latitude, double longitude)
  {
    Latitude = latitude;
    Longitude = longitude;
  }
}
