using PagedList;

namespace WebApplication.ViewModels
{
    public abstract class PagedListViewModelBase<T> : ViewModelBase
    {
        public StaticPagedList<T> PagedListItems { get; set; }

        public int PageSize
        {
            get { return this.PagedListItems.PageSize; }
        }
    }
}