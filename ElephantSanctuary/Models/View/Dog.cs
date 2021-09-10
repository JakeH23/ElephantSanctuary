namespace ElephantSanctuary.Models.View
{
    using System;
    using System.Collections.Generic;

    public class Dog
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string BreedType { get; set; }

        public string Origin { get; set; }

        public IEnumerable<string> Temperament { get; set; }

        public bool Hypoallergenic { get; set; }

        public int Intelligence { get; set; }

        public string Photo { get; set; }
    }
}