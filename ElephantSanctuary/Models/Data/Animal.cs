namespace ElephantSanctuary.Models.Data
{
    using System;
    using System.Text.Json.Serialization;

    public abstract class Animal
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}