namespace StarWarsPlanet.DataAccess;

using System.Text.Json;
using StarWarsPlanet.ApiDataAccess;
using StarWarsPlanets.DTOs;
using StarWarsPlanet.Model;
using StarWarsPlanet.UserInteraction;

public class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _mockDataReader;
    private readonly IUserInteractor _planetsStatsUserInteractor;


    public PlanetsFromApiReader(
        IApiDataReader apiDataReader,
        IApiDataReader mockDataReader,
        IUserInteractor planetsStatsUserInteractor)
    {
        _apiDataReader = apiDataReader;
        _mockDataReader = mockDataReader;
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public async Task<IEnumerable<Planet>> Read()
    {
        var baseAddress = "https://swapi.dev/api/";
        var requestUri = "planets";

        String? json = null;
        try
        {
            json = await _apiDataReader.Read(baseAddress, requestUri);
        }
        catch (HttpRequestException ex)
        {
            _planetsStatsUserInteractor.ShowMessage("API request was unsuccessfull. " +
                "Switching to mock data. " +
                "Exception message: " + ex.Message);
        }

        json ??= await _mockDataReader.Read(baseAddress, requestUri);

        var root = JsonSerializer.Deserialize<Root>(json);

        return ToPlanets(root);
    }

    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }

        return root.results.Select(
            planetDto => (Planet)planetDto);
    }
}

