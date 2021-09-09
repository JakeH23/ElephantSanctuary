namespace ElephantSanctuary.Business
{
    using ElephantSanctuary.Models;
    using ElephantSanctuary.Models.enums;
    using ElephantSanctuary.Services;
    using System.Collections.Generic;
    using System.IO.Abstractions;

    public interface IElephantManagement
    {
        IEnumerable<Elephant> GetAllElephants();
    }

    public class ElephantManagement : IElephantManagement
    {
        private readonly IDataService dataService;
        private readonly IFile file;

        public ElephantManagement(IDataService dataService)
        {
            this.dataService = dataService;
            this.file = new FileWrapper(new FileSystem());
        }

        public IEnumerable<Elephant> GetAllElephants()
        {
            return this.dataService.GetData<Elephant>(InformationType.elephants, this.file);
        }
    }
}
