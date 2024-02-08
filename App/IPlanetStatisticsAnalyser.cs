namespace StarWarsPlanet.App;

using StarWarsPlanet.Model;

public interface IPlanetStatisticsAnalyser
{
    void Analyse(IEnumerable<Planet> planets);
}
