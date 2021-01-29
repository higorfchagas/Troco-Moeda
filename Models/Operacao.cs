using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TradebookApi.Models
{
    public partial class Operacao
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorCompra { get; set; }

        public decimal ValorTroco { get; set; }
    }
}
