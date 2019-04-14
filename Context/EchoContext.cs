using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace stroisoft
{
    public class Message
    {
      [Key]
      public int Id { get; set; }
      public string Text { get; set; }
    }

    public class User
    {
      [Key]
      public int Id { get; set; }
      public string ClientId { get; set; }
      public string Username { get; set; }
    }
    
    public class EchoContext : DbContext
    {
      public EchoContext(DbContextOptions<EchoContext> options) : base(options) { }
    
      public DbSet<Message> Messages { get; set; }
      public DbSet<User> Users { get; set; }
    }
}