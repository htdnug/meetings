using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models.Entities;

namespace WebApplication.Models.Data.InMemory
{
    public class InMemoryCompanyRepository : ICompanyRepository
    {
        private List<Company> Items;

        public InMemoryCompanyRepository()
        {
            this.Items = new List<Company>();
            this.Items.Add(new Company { Id = 1, Name = "ABC, Inc." });
            this.Items.Add(new Company { Id = 2, Name = "XYZ, Inc." });
            this.Items.Add(new Company { Id = 3, Name = "RST, LLC." });
        }

        public void Add(Company company)
        {
            int next = this.Items.Max(x => x.Id) + 1;
            company.Id = next;
            this.Items.Add(company);
        }

        public void Delete(int id)
        {
            var item = this.Items.SingleOrDefault(x => x.Id == id);
            if (item != null)
            {
                this.Items.Remove(item);
            }
        }

        public IQueryable<Company> GetAll()
        {
            return this.Items.AsQueryable();
        }

        public Company GetById(int id)
        {
            return this.Items.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}