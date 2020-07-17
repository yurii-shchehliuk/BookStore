using Domain;

namespace Application.CommandHandler.ShoppingCartCommand
{
    public class ShoppingCartRepository
    {
        private readonly TestAppContext _context;
        public ShoppingCartRepository(TestAppContext contextT)
        {
            _context = contextT;
        }
        
    }
}
