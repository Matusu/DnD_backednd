using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<Character> Character { get; set; }
    public DbSet<Campain> Campain { get; set; }
    public DbSet<CharacterHasSpells> CharacterHasSpells { get; set; }
    public DbSet<Class> Class { get; set; }
    public DbSet<ClassHasSpells> ClassHasSpells { get; set; }
    public DbSet<Feature> Feature { get; set; }
    public DbSet<HasFeature> HasFeature { get; set; }
    public DbSet<Race> Race { get; set; }
    public DbSet<Spell> Spell { get; set; }
    public DbSet<User> User { get; set; }
}