using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainProfile:Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        protected void Configure()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}