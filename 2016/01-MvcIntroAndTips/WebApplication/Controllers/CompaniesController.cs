using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Business;
using WebApplication.Models.Criteria;
using WebApplication.Models.Data;
using WebApplication.Models.Data.InMemory;
using WebApplication.Models.Entities;
using WebApplication.ViewModels.Companies;

namespace WebApplication.Controllers
{
    public class CompaniesController : Controller
    {
        private ICompanyRepository repository;

        public CompaniesController()
        {
            this.repository = new InMemoryCompanyRepository();
        }

        public CompanyCriteria CompanyCriteriaSession
        {
            get
            {
                object value = this.Session["CompanyCriteria"];
                return value == null
                    ? new CompanyCriteria()
                    : value as CompanyCriteria;
            }

            set { this.Session["CompanyCriteria"] = value; }
        }

        public ActionResult Index(int? page, int? size, bool? pageChange, 
            CompanyCriteria criteria)
        {
            var sessionCriteria = this.CompanyCriteriaSession;

            if (pageChange.HasValue && pageChange.Value)
            {
                sessionCriteria.NameSearch = criteria.NameSearch;
            }

            var viewModel = this.GetListViewModel(sessionCriteria);
            return View(viewModel);
        }

        public ActionResult Filter(int? size, CompanyCriteria criteria)
        {
            criteria.SetMaximumRows(size);
            var viewModel = this.GetListViewModel(criteria);
            return this.PartialView("_List", viewModel);
        }

        public ActionResult Clear(int? size)
        {
            var criteria = new CompanyCriteria();
            criteria.SetMaximumRows(size);

            var viewModel = this.GetListViewModel(criteria);
            return this.PartialView("_List", viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new CompanyEditViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var entity = viewModel.Entity;
            var service = this.GetCompanyService();
            service.Add(entity);       
            return this.RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return this.RedirectToAction("Index");
            }

            var service = this.GetCompanyService();
            var entity = service.GetById(id);

            if (entity == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = new CompanyEditViewModel(entity);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyEditViewModel viewModel)
        {
            if (id <= 0)
            {
                return this.RedirectToAction("Index");
            }
            
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }
            
            var service = this.GetCompanyService();
            var entity = viewModel.Entity;
            var original = service.GetById(id);
            original.Name = entity.Name;
            
            // COMMIT !!

            return this.RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    var access = this.DetermineAccess(new List<SecurityRole> { SecurityRole.BidsManager });
        //    if (access != null)
        //    {
        //        return access;
        //    }

        //    var service = this.GetAssigneeService();
        //    var assignee = service.GetById(id);
        //    var viewModel = new AssigneeDeleteViewModel(assignee);
        //    this.LoadViewModelBase(viewModel);
        //    return this.View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, AssigneeDeleteViewModel viewModel)
        //{
        //    var access = this.DetermineAccess(new List<SecurityRole> { SecurityRole.BidsManager });
        //    if (access != null)
        //    {
        //        return access;
        //    }

        //    using (var context = this.GetDbContext())
        //    {
        //        var service = this.GetAssigneeService();
        //        var assignee = service.GetById(id);
        //        assignee.IsDeleted = true;

        //        var userName = Models.SessionWrapper.Instance.UserProfile.Name;
        //        context.SaveChanges(userName);
        //    }

        //    return this.RedirectToAction("Index");
        //}

        private CompanyListViewModel GetListViewModel(CompanyCriteria criteria)
        {
            var viewModel = new CompanyListViewModel(criteria);
            var service = this.GetCompanyService();
            IEnumerable<Company> items = service.GetByFilter(criteria);
            int count = service.GetByFilterCount(criteria);
            viewModel.PagedListItems 
                = new StaticPagedList<Company>(items, criteria.PageNumber, criteria.MaximumRows, count);
            this.CompanyCriteriaSession = criteria;
            return viewModel;
        }

        private CompanyService GetCompanyService()
        {
            return new CompanyService(this.repository);
        }
    }
}