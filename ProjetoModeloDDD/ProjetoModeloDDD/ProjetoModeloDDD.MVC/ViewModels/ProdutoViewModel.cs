using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo de Nome")]
        [MaxLength(250, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "9999999999999")]
        public decimal Valor { get; set; }
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        [DisplayName("Disponível")]
        public bool Disponivel { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}