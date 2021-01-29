using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TradebookApi.Models
{
    public partial class SaidaTroco
    {
        [Key]
        public int IdSaidaTroco { get; set; }

        public int NotaDe200 {get; set;}
        public int NotaDe100 {get; set;}
        public int NotaDe50 {get; set;}  
        public int NotaDe20 {get; set;}     
        public int NotaDe10 {get; set;}        
        public int NotaDe5 {get; set;}       
        public int NotaDe2 {get; set;}       
        public int MoedaDe100 {get; set;}
        public int MoedaDe50 {get; set;}
        public int MoedaDe25 {get; set;}
        public int MoedaDe10 {get; set;}
        public int MoedaDe5 {get; set;}
        public int IdOperacao { get; set; }
    }
}
