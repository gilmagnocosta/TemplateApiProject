using TemplateApiProject.Application.ViewModel.Base;
using System;

namespace TemplateApiProject.Application.ViewModel
{
    public class RefreshTokenViewModel
    {
        public int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Token { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
    }
}
