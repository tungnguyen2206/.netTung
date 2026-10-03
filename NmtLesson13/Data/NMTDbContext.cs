using Microsoft.EntityFrameworkCore;
using NMT.Models;

namespace NMT.Data;

public class NMTDbContext : DbContext
{
    public NMTDbContext(DbContextOptions<NMTDbContext> options) : base(options)
    {
    }

    public DbSet<NMTMember> Members => Set<NMTMember>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NMTMember>().HasData(
            new NMTMember
            {
                NMTMemberId = "m-001",
                NMTUserName = "chungtv",
                NMTPassword = "Password123!",
                NMTFullName = "Trịnh Văn Chung",
                NMTEmail = "chungtv@gmail.com"
            },
            new NMTMember
            {
                NMTMemberId = "m-002",
                NMTUserName = "lananh",
                NMTPassword = "SecurePass456#",
                NMTFullName = "Nguyễn Lan Anh",
                NMTEmail = "lananh@gmail.com"
            },
            new NMTMember
            {
                NMTMemberId = "m-003",
                NMTUserName = "dinhthang",
                NMTPassword = "MyPassword789$",
                NMTFullName = "Đinh Thắng",
                NMTEmail = "dinhthang@gmail.com"
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
