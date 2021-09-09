namespace ElephantSanctuary.Models
{
    using System;
    using System.Text.Json.Serialization;

    public class Elephant
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

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
