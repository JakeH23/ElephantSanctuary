namespace ElephantSanctuary.Business
{
    using ElephantSanctuary.Models;
    using ElephantSanctuary.Models.enums;
    using ElephantSanctuary.Services;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Linq;

    public interface IElephantManagement
    {
        IEnumerable<Elephant> GetAllElephants();

        Elephant GetElephantByName(string name);
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

        public Elephant GetElephantByName(string name)
        {
            var elephants = this.dataService.GetData<Elephant>(InformationType.elephants, this.file);
            return elephants.SingleOrDefault(x => x.Name == name);
        }
    }
}
