namespace ElephantSanctuary.Services
{
    using ElephantSanctuary.Models.enums;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Text.Json;

    public interface IDataService
    {
        List<T> GetData<T>(InformationType fileName, IFile file);
    }

    public class DataService : IDataService
    {
        private const string DataFilePath = "../../../../Northcoders/c-sharp-little-web-api/Elephant Sanctuary/Elephant Sanctuary/Data";

        public List<T> GetData<T>(InformationType fileName, IFile file)
        {
            var path = file.ReadAllText(@$"{DataFilePath}/{fileName}.json");
            return JsonSerializer.Deserialize<List<T>>(path);
        }
    }
}