namespace ElephantSanctuary.Business
{
    using AutoMapper;
    using ElephantSanctuary.Models.enums;
    using ElephantSanctuary.Services;
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Linq;
    using DataModel = Models.Data;
    using ViewModel = Models.View;

    public interface IElephantManagement
    {
        IEnumerable<ViewModel.Elephant> GetAllElephants();

        ViewModel.Elephant GetElephantByName(string name);

        IEnumerable<ViewModel.Elephant> AddElephant(ViewModel.Elephant elephant);
    }

    public class ElephantManagement : IElephantManagement
    {
        private readonly IDataService dataService;
        private readonly IFile file;
        private readonly IMapper mapper;

        public ElephantManagement(IDataService dataService, IMapper mapper)
        {
            this.dataService = dataService;
            this.file = new FileWrapper(new FileSystem());
            this.mapper = mapper;
        }

        public IEnumerable<ViewModel.Elephant> GetAllElephants()
        {
            var elephantsData = this.dataService.GetData<DataModel.Elephant>(InformationType.elephants, this.file);
            return this.mapper.Map<IEnumerable<ViewModel.Elephant>>(elephantsData);
        }

        public ViewModel.Elephant GetElephantByName(string name)
        {
            var elephantsData = this.dataService.GetData<DataModel.Elephant>(InformationType.elephants, this.file);
            var elephant = elephantsData.SingleOrDefault(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
            return elephant is null ? null : this.mapper.Map<ViewModel.Elephant>(elephant);
        }

        public IEnumerable<ViewModel.Elephant> AddElephant(ViewModel.Elephant elephant)
        {
            var data = this.mapper.Map<DataModel.Elephant>(elephant);

            data.Id = Guid.NewGuid();

            var updatedDataList = this.dataService.UpdateData(InformationType.elephants, this.file, data);

            return this.mapper.Map<IEnumerable<ViewModel.Elephant>>(updatedDataList);
        }
    }
}
