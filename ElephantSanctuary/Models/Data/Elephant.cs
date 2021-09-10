namespace ElephantSanctuary.Models.Data
{
    using System.Text.Json.Serialization;

    public class Elephant : Animal
    {
        [JsonPropertyName("species")]
        public string Species { get; set; }

        [JsonPropertyName("sex")]
        public string Sex { get; set; }

        [JsonPropertyName("dob")]
        public int Dob { get; set; }

        [JsonPropertyName("dod")]
        public int Dod { get; set; }

        [JsonPropertyName("wikilink")]
        public string Wikilink { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }
    }
}
