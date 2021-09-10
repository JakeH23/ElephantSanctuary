namespace ElephantSanctuary.Services
{
    using ElephantSanctuary.Models.enums;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Text.Json;

    public interface IDataService
    {
        List<T> GetData<T>(InformationType fileName, IFile file);

        List<T> UpdateData<T>(InformationType fileName, IFile file, T item);
    }

    public class DataService : IDataService
    {
        private const string DataFilePath = "../../../../Northcoders/c-sharp-little-web-api/Elephant Sanctuary/Elephant Sanctuary/Data";

        public List<T> GetData<T>(InformationType fileName, IFile file)
        {
            var json = file.ReadAllText(@$"{DataFilePath}/{fileName}.json");
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public List<T> UpdateData<T>(InformationType fileName, IFile file, T item)
        {
            var path = @$"{DataFilePath}/{fileName}.json";
            var json = file.ReadAllText(path);
            var data = JsonSerializer.Deserialize<List<T>>(json);
            data.Add(item);
            var serializedData = JsonSerializer.Serialize(data);
            file.WriteAllText(path, serializedData);
            return data;
        }
    }
}