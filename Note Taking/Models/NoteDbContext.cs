using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note_Taking.Models
{
    public class NoteDbContext : DbContext
       
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
        { }
        public DbSet<Note> Notes { get; set; }
    }
}
