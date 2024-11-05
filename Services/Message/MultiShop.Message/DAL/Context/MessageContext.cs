using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Entitites;

namespace MultiShop.Message.DAL.Context
{
    public class MessageContext:DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options):base(options)
        { 
        
        }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
