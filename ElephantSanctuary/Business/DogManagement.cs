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

    public interface IDogManagement
    {
        IEnumerable<ViewModel.Dog> GetAllDogs();

        ViewModel.Dog GetDogByName(string name);

        IEnumerable<ViewModel.Dog> AddDog(ViewModel.Dog dog);
    }

    public class DogManagement : IDogManagement
    {
        private readonly IDataService dataService;
        private readonly IFile file;
        private readonly IMapper mapper;

        public DogManagement(IDataService dataService, IMapper mapper)
        {
            this.dataService = dataService;
            this.file = new FileWrapper(new FileSystem());
            this.mapper = mapper;
        }

        public IEnumerable<ViewModel.Dog> GetAllDogs()
        {
            var dogsData = this.dataService.GetData<DataModel.Dog>(InformationType.dogs, this.file);
            return this.mapper.Map<IEnumerable<ViewModel.Dog>>(dogsData);
        }

        public ViewModel.Dog GetDogByName(string name)
        {
            var dogsData = this.dataService.GetData<DataModel.Dog>(InformationType.dogs, this.file);
            var dog = dogsData.SingleOrDefault(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
            return dog is null ? null : this.mapper.Map<ViewModel.Dog>(dog);
        }

        public IEnumerable<ViewModel.Dog> AddDog(ViewModel.Dog dog)
        {
            var data = this.mapper.Map<DataModel.Dog>(dog);

            data.Id = Guid.NewGuid();

            var updatedDataList = this.dataService.UpdateData(InformationType.dogs, this.file, data);

            return this.mapper.Map<IEnumerable<ViewModel.Dog>>(updatedDataList);
        }
    }
}
