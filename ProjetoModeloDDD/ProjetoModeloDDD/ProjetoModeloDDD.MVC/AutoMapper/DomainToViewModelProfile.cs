using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelProfile: Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelProfileMappings"; }
        }
        protected void Configure()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}