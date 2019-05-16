using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MusicStore.Models
{
    public class MusicStoreDBContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public MusicStoreDBContext()
        {
            
        }
    }
}