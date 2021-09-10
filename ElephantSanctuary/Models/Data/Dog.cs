namespace ElephantSanctuary.Models.Data
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Dog : Animal
    {
        [JsonPropertyName("breed")]
        public string Breed { get; set; }

        [JsonPropertyName("breedType")]
        public string BreedType { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("temperament")]
        public IEnumerable<string> Temperament { get; set; }

        [JsonPropertyName("hypoallergenic")]
        public bool Hypoallergenic { get; set; }

        [JsonPropertyName("intelligence")]
        public int Intelligence { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }
    }
}