namespace ElephantSanctuary.Models.View
{
    using System;

    public class Elephant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Sex { get; set; }

        public int Dob { get; set; }

        public int Dod { get; set; }

        public string Wikilink { get; set; }

        public string Note { get; set; }
    }
}
