using DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserContext : IdentityDbContext<AnimeUser>
    {
        public UserContext() : base("IdentityDb1") { }
        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }
        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Composition> Compositions { get; set; }
        public virtual DbSet<Franchise> Franchises { get; set; }
        public virtual DbSet<NoManga> NoMangas { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<CompositionFranchise> CompositionFranchises { get; set; }
        public virtual DbSet<CompositionGenre> CompositionGenres { get; set; }
    }
}
