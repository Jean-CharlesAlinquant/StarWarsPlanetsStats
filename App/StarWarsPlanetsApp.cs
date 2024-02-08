namespace StarWarsPlanet.App;

using StarWarsPlanet.DataAccess;
using StarWarsPlanet.UserInteraction;

public class StarWarsPlanetsApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetStatisticsAnalyser _planetsStatisticsAnalyser;
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public StarWarsPlanetsApp(
        IPlanetsReader planetsReader,
        IPlanetStatisticsAnalyser planetStatisticsAnalyser,
        IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyser = planetStatisticsAnalyser;
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        _planetsStatsUserInteractor.Show(planets);
        _planetsStatisticsAnalyser.Analyse(planets);
    }
}
