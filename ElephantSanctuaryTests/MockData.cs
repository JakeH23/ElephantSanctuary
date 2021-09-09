using System;
using System.Collections.Generic;
using System.Text;
using ElephantSanctuary.Models;

namespace ElephantSanctuaryTests
{
    public class MockData
    {
        public List<Elephant> Elephants => GetTestElephantData();

        private static List<Elephant> GetTestElephantData()
        {
            return new List<Elephant>
                {
                    new Elephant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Black Diamond",
                        Species = "Asian",
                        Sex = "Male",
                        Dob = 1898,
                        Dod = 1929,
                        Wikilink = "https://en.wikipedia.org/wiki/Black_Diamond_(elephant)",
                        Note = "Believed to be the largest Indian elephant in captivity."
                    },
                    new Elephant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Isilo",
                        Species = "African",
                        Sex = "Male",
                        Dob = 1956,
                        Dod = 2014,
                        Wikilink = "https://en.wikipedia.org/wiki/Isilo_(elephant)",
                        Note = "One of South Africa’s largest Africans and the largest living tusker (a male elephant with tusks weighing over 100 pounds) in the southern hemisphere before his death."
                    }
                };
        }
    }
}