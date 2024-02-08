using StarWarsPlanet.Model;

namespace StarWarsPlanet.DataAccess;

public interface IPlanetsReader
{
    Task<IEnumerable<Planet>> Read();
}

