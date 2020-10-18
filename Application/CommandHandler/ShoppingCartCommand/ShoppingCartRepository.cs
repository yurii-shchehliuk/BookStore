using Domain;

namespace Application.CommandHandler.ShoppingCartCommand
{
    public class ShoppingCartRepository
    {
        private readonly AppDbContext _context;
        public ShoppingCartRepository(AppDbContext contextT)
        {
            _context = contextT;
        }
        
    }
}
