using System.Collections.Generic;

namespace ElephantSanctuary.Models.Data
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

        public List<string> IsValid()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                errors.Add($"{nameof(Elephant)}.{nameof(this.Name)} must have a value");
            }
            if (string.IsNullOrWhiteSpace(this.Species))
            {
                errors.Add($"{nameof(Elephant)}.{nameof(this.Species)} must have a value");
            }
            if (string.IsNullOrWhiteSpace(this.Sex))
            {
                errors.Add($"{nameof(Elephant)}.{nameof(this.Sex)} must have a value");
            }
            if (this.Dob == 0)
            {
                errors.Add($"{nameof(Elephant)}.{nameof(this.Dob)} must have a value");
            }
            if (this.Dod == 0)
            {
                errors.Add($"{nameof(Elephant)}.{nameof(this.Dod)} must have a value");
            }
            if (string.IsNullOrWhiteSpace(this.Wikilink))
            {
                errors.Add($"{nameof(Elephant)}.{nameof(this.Wikilink)} must have a value");
            }
            if (string.IsNullOrWhiteSpace(this.Note))
            {
                errors.Add($"{nameof(Elephant)}.{nameof(this.Note)} must have a value");
            }

            return errors;
        }
    }
}
