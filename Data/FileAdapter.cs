using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Persistance
{
    //here will be all necessary checking for restricted access
    public class FileAdapter : IFileAdapter
    {
        private FileContext myFileContext = new FileContext();

        public void AddAdult(Adult a)
        {
            int max = myFileContext.Adults.Max(a => a.Id);
            //giving unique id
            a.Id = (++max);
            myFileContext.Adults.Add(a);
            myFileContext.SaveChanges();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = myFileContext.Adults.Max(a => a.Id);
            //giving unique id
            adult.Id = (++max);
            myFileContext.Adults.Add(adult);
            myFileContext.SaveChanges();
            return adult;
        }

        public IList<string> GetHairColors()
        {
            List<string> hairColors = new List<string>();
            foreach (Adult a in myFileContext.Adults)
            {
                if (!hairColors.Contains(a.HairColor) && a.HairColor!=null)
                {
                    hairColors.Add(a.HairColor);
                }
            }

            return hairColors;
        }

        public Adult FilterById(int id)
        {
            return (Adult)myFileContext.Adults.Where(p => p.Id == id);  
        }

        public IList<Adult> FilterByFirstName(string name)
        {
            return myFileContext.Adults.Where(p => p.FirstName == name).ToList();
        }
        
        public IList<Adult> FilterByLastName(string name)
        {
            return myFileContext.Adults.Where(p => p.LastName == name).ToList();
        }
        
        public IList<Adult> FilterByHairColor(string color)
        {
            return myFileContext.Adults.Where(p => p.HairColor == color).ToList();
        }
        
        public IList<Adult> FilterByEyeColor(string color)
        {
            return myFileContext.Adults.Where(p => p.EyeColor == color).ToList();
        }
        
        public IList<Adult> FilterByAge(int age)
        {
            return myFileContext.Adults.Where(p => p.Age == age).ToList();
        }
        
        public IList<Adult> FilterByAgeOlderThan(int age)
        {
            return myFileContext.Adults.Where(p => p.Age > age).ToList();
        }
        
        public IList<Adult> FilterByAgeYoungerThan(int age)
        {
            return myFileContext.Adults.Where(p => p.Age < age).ToList();
        }

        public IList<Adult> FilterBySex(char s)
        {
            return myFileContext.Adults.Where(p => char.Parse(p.Sex) == s).ToList();
        }
        
        public IList<Adult> FilterByJobTitle(string name)
        {
            return myFileContext.Adults.Where(p => p.JobTitle.JobTitle == name).ToList();
        }
        
        public IList<Adult> FilterBySalaryBiggerThan(int s)
        {
            return myFileContext.Adults.Where(p => p.JobTitle.Salary > s).ToList();
        }
        
        public IList<Adult> FilterBySalarySmallerThan(int s)
        {
            return myFileContext.Adults.Where(p => p.JobTitle.Salary < s).ToList();
        }
        
        public void RemovePerson(Person p)
        {
            myFileContext.Adults.RemoveAt(p.Id);
            myFileContext.SaveChanges();
        }

        public async Task<Adult> RemoveAdult(int id)
        {
            Adult toRemove = myFileContext.Adults.First(a => a.Id == id);
            myFileContext.Adults.Remove(toRemove);
            myFileContext.SaveChanges();
            return toRemove;
        }

        public void RemoveLastPerson()
        {
            myFileContext.Adults.RemoveAt(myFileContext.Adults.Count-1);
            myFileContext.SaveChanges();
        }

        public async Task<Adult> UpdateAdult(Adult p)
        {
            Adult toUpdate = myFileContext.Adults.First(a => a.Id == p.Id);
            toUpdate.FirstName = p.FirstName;
            toUpdate.LastName = p.LastName;
            toUpdate.Age = p.Age;
            toUpdate.Height = p.Height;
            toUpdate.JobTitle.JobTitle = p.JobTitle.JobTitle;
            toUpdate.JobTitle.Salary = p.JobTitle.Salary;
            toUpdate.Sex = p.Sex;
            toUpdate.Weight = p.Weight;
            toUpdate.EyeColor = p.EyeColor;
            myFileContext.SaveChanges();
            return toUpdate;
        }

        public async Task<IList<Adult>> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(myFileContext.Adults);
            return tmp;
        }

        public async Task<Adult> Get(int id)
        {
            return myFileContext.Adults.FirstOrDefault(a => a.Id == id);
        }
    }
}