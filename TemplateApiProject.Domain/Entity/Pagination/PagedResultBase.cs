using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApiProject.Domain.Entity.Pagination
{
    public abstract class PagedResultBase
    {
        public int TotalItems { get; protected set; }
        public int TotalPages { get; protected set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int FirstRowOnPage
        {
            get { return (PageNumber - 1) * PageSize + 1; }
        }
        public int LastRowOnPage
        {
            get { return Math.Min(PageNumber * PageSize, TotalItems); }
        }
    }
}
