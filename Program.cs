using StarWarsPlanet.ApiDataAccess;
using StarWarsPlanet.App;
using StarWarsPlanet.DataAccess;
using StarWarsPlanet.UserInteraction;

try
{
    var ConsoleUserInteractor = new ConsoleUserInteractor();
    var PlanetsStatsUserInteractor =
        new PlanetsStatsUserInteractor(ConsoleUserInteractor);

    await new StarWarsPlanetsApp(
        new PlanetsFromApiReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader(),
            ConsoleUserInteractor),
        new PlanetStatisticsAnalyser(
            PlanetsStatsUserInteractor),
        PlanetsStatsUserInteractor).Run();
}
catch (Exception ex)
{
    Console.WriteLine("An error occured. " +
        "Exception message: " + ex.Message);
}
Console.WriteLine("Press any key to close.");
Console.ReadKey();