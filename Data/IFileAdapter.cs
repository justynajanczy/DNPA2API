using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Persistance
{
    public interface IFileAdapter
    {
        public void AddAdult(Adult a);
        public Task<Adult> AddAdultAsync(Adult adult);
        public IList<string> GetHairColors();
        public Adult FilterById(int id);
        public IList<Adult> FilterByFirstName(string name);
        public IList<Adult> FilterByLastName(string name);
        public IList<Adult> FilterByHairColor(string color);
        public IList<Adult> FilterByEyeColor(string color);
        public IList<Adult> FilterByAge(int age);
        public IList<Adult> FilterByAgeOlderThan(int age);
        public IList<Adult> FilterByAgeYoungerThan(int age);
        public IList<Adult> FilterBySex(char s);
        public IList<Adult> FilterByJobTitle(string name);
        public IList<Adult> FilterBySalaryBiggerThan(int s);
        public IList<Adult> FilterBySalarySmallerThan(int s);
        public void RemovePerson(Person p);
        public Task<Adult> RemoveAdult(int id);
        public void RemoveLastPerson();
        public Task<Adult> UpdateAdult(Adult p);
        public Task<IList<Adult>> GetAdults();
        Task<Adult> Get(int id);

    }
}