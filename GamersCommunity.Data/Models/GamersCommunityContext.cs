using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamersCommunity.Data.Models
{
    public partial class GamersCommunityContext : IdentityDbContext<GcUser>
    {
        public GamersCommunityContext()
        {
        }

        public GamersCommunityContext(DbContextOptions<GamersCommunityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GcGenreInformation> GcGenreInformation { get; set; }

        
    }
}
