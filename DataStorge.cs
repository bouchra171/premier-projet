using Newtonsoft.Json;
using System.IO;


namespace premier_projet.Services
{
    public class DataStorage
    {
        public void SaveData<T>(string? fileLocation, List<T> data)
        {
            string? jsonData = JsonConvert.SerializeObject(data);
            if (fileLocation != null && jsonData != null)
            {
                File.WriteAllText(fileLocation, jsonData);
            }
        }

        public List<T> LoadData<T>(string? fileLocation)
        {
            if (fileLocation != null && File.Exists(fileLocation))
            {
                string? jsonData = File.ReadAllText(fileLocation);
                List<T>? data = JsonConvert.DeserializeObject<List<T>>(jsonData);
                if (data == null)
                {
                    return new List<T>();
                }
                return data;
            }

            return new List<T>();
        }
    }
}
