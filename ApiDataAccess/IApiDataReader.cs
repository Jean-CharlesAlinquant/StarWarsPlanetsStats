namespace StarWarsPlanet.ApiDataAccess;

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}
