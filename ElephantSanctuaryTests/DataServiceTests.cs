namespace ElephantSanctuaryTests
{
    using ElephantSanctuary.Models.Data;
    using ElephantSanctuary.Models.enums;
    using ElephantSanctuary.Services;
    using Moq;
    using System;
    using System.IO.Abstractions;
    using System.IO.Abstractions.TestingHelpers;
    using System.Text.Json;
    using Xunit;

    public class DataServiceTests
    {
        private readonly IFile file;

        public DataServiceTests()
        {
            file = Mock.Of<IFile>();
        }

        [Fact]
        public void CheckFileServiceReturnsElephantDataAsExpected()
        {
            var sut = new DataService();

            var mockData = new MockData();
            var elephantDataToString = JsonSerializer.Serialize(mockData.Elephants);

            Mock.Get(file)
                .Setup(f => f.ReadAllText(It.IsAny<string>()))
                .Returns(DataGetterFake<Elephant>(InformationType.elephants, elephantDataToString));

            var res = sut.GetData<Elephant>(InformationType.elephants, file);

            Assert.NotEmpty(res);
            Assert.Equal("Black Diamond", res[0].Name);
            Assert.Equal("Isilo", res[1].Name);
        }

        [Fact]
        public void CheckFileServiceUpdatesElephantDataAsExpectedOnCreate()
        {
            var sut = new DataService();

            var elephantToAdd = new Elephant
            {
                Id = Guid.NewGuid(),
                Name = "Test-Elephant-Name",
                Species = "African",
                Sex = "Female",
                Dob = 1879,
                Dod = 1952,
                Wikilink = "Test-link",
                Note = "Test-note"
            };

            var mockData = new MockData();
            var elephantDataToString = JsonSerializer.Serialize(mockData.Elephants);

            Mock.Get(file)
                .Setup(f => f.WriteAllText(It.IsAny<string>(), It.IsAny<string>()));

            Mock.Get(file)
                .Setup(f => f.ReadAllText(It.IsAny<string>()))
                .Returns(DataGetterFake<Elephant>(InformationType.elephants, elephantDataToString));

            var res = sut.UpdateData<Elephant>(InformationType.elephants, file, elephantToAdd);

            Assert.NotEmpty(res);
            Assert.Equal(3, res.Count);
            Assert.Equal("Black Diamond", res[0].Name);
            Assert.Equal("Isilo", res[1].Name);
            Assert.Equal("Test-Elephant-Name", res[2].Name);
        }

        private static string DataGetterFake<T>(InformationType fileName, string fakeData)
        {
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData(fakeData);

            mockFileSystem.AddFile($"{fileName}.json", mockInputFile);

            var t = mockFileSystem.GetFile($"{fileName}.json");
            return t.TextContents;
        }
    }
}