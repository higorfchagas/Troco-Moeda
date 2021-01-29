using Microsoft.EntityFrameworkCore;
using TradebookApi.Models;

namespace testetobr.Data {

    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }
        public DbSet<Operacao> Operacao { get; set; }
        public DbSet<SaidaTroco> SaidaTroco { get; set; }
    }
}