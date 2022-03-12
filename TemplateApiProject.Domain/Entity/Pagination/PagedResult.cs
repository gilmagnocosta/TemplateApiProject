using System.Collections.Generic;

namespace TemplateApiProject.Domain.Entity.Pagination
{
    public class PagedResult<TViewModel> : PagedResultBase
    {
        public IList<TViewModel> Items { get; protected set; }
        
        public PagedResult()
        {
            this.Items = new List<TViewModel>();
        }

        public PagedResult(IList<TViewModel> items, int totalItems, int page, int size)
        {
            Items = items;
            TotalItems = totalItems;
            TotalPages = totalItems / size;
            PageNumber = page;
            PageSize = size;
        }
    }
}
