using System;

namespace DefenseIO.Domain.Domains.Geographic.Services
{
  public class DistanceService
  {
    public double GetDistanceBetweenTwoPointsInKms(GeoPoint p1, GeoPoint p2)
    {
      double deg2radMultiplier = Math.PI / 180;

      p1.Latitude *= deg2radMultiplier;
      p1.Longitude *= deg2radMultiplier;
      p2.Latitude *= deg2radMultiplier;
      p1.Longitude *= deg2radMultiplier;

      double radius = 6378.137; // earth mean radius defined by WGS84

      double dlon = p2.Longitude - p1.Longitude;

      double distance = Math.Acos(Math.Sin(p1.Latitude) * Math.Sin(p2.Latitude) + Math.Cos(p1.Latitude) * Math.Cos(p2.Latitude) * Math.Cos(dlon)) * radius;

      return distance;
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
}
