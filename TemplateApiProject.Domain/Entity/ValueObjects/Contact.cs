using TemplateApiProject.Domain.Entity.Base;
using System.Collections.Generic;

namespace TemplateApiProject.Domain.Entity.ValueObjects
{
    public class Contact : ValueObject
    {
        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }

        public Contact()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PhoneNumber.ToUpper();
            yield return CellPhone.ToUpper();
            yield return Email.ToUpper();
            yield return Instagram.ToUpper();
            yield return Facebook.ToUpper();
            yield return Twitter.ToUpper();
        }
    }
}
