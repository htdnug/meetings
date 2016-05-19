using System;

namespace WebApplication.Models.Criteria
{
    [Serializable]
    public abstract class PaginatedCriteriaBase
    {
        protected PaginatedCriteriaBase()
        {
            this.PageNumber = 1;
            this.MaximumRows = 10;
        }

        public int PageNumber { get; private set; }

        public int MaximumRows { get; private set; }

        public int RowsToSkip
        {
            get { return this.MaximumRows * (this.PageNumber - 1); }
        }

        public void SetMaximumRows(int? maximumRows)
        {
            if (maximumRows.HasValue)
            {
                this.MaximumRows = maximumRows.Value;
            }
        }

        public void SetPageNumber(int? pageNumber)
        {
            if (pageNumber.HasValue)
            {
                this.PageNumber = pageNumber.Value;
            }
        }
    }
}