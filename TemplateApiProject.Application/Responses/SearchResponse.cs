using System.Collections.Generic;

namespace TemplateApiProject.Application.Responses
{
    public class SearchResponse<T> where T : class
    {
        public ICollection<T> Result { get; set; }
        public int Size
        {
            get
            {
                return Result.Count;
            }
        }

        public SearchResponse(ICollection<T> resultList)
        {
            Result = resultList;
        }
    }
}
