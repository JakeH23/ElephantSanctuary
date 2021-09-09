namespace ElephantSanctuaryTests
{
    using ElephantSanctuary.Services;
    using System.IO.Abstractions;
    using System.Text.Json;
    using ElephantSanctuary.Models;
    using ElephantSanctuary.Models.enums;
    using Xunit;
    using System.IO.Abstractions.TestingHelpers;
    using Moq;

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