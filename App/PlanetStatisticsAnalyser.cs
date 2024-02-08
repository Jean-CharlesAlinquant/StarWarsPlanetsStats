namespace StarWarsPlanet.App;

using StarWarsPlanet.Model;
using StarWarsPlanet.UserInteraction;

public class PlanetStatisticsAnalyser : IPlanetStatisticsAnalyser
{
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public PlanetStatisticsAnalyser(IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public void Analyse(IEnumerable<Planet> planets)
    {
        var propertyNamesToSelectorsMapping =
            new Dictionary<string, Func<Planet, long?>>
            {
                ["population"] = planet => planet.Population,
                ["diameter"] = planet => planet.Diameter,
                ["surface water"] = planet => planet.SurfaceWater,

            };

        var userChoice = _planetsStatsUserInteractor
            .ChooseStaticticsToBeShown(propertyNamesToSelectorsMapping.Keys);

        if (userChoice is null ||
            !propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            _planetsStatsUserInteractor.ShowMessage("Invalid choice");
        }
        else
        {
            ShowStatistics(
                planets,
                userChoice,
                propertyNamesToSelectorsMapping[userChoice]);
        }
    }

    private void ShowStatistics(
    IEnumerable<Planet> planets,
    string propertyName,
    Func<Planet, long?> propertySelector)
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);

        ShowStatistics(
            "Min",
            planets.MinBy(propertySelector),
            propertySelector,
            propertyName);
    }

    private void ShowStatistics(
        string descriptor,
        Planet planet,
        Func<Planet, long?> propertySelector,
        string propertyName)
    {
        _planetsStatsUserInteractor.ShowMessage($"{descriptor} {propertyName} is: " +
                          $"{propertySelector(planet)} " +
                          $"(planet: {planet.Name})");
    }
}