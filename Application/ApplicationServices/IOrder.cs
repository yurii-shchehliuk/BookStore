using Domain.Entities;

namespace Application.ApplicationServices
{/// <summary>
/// dependency injection interface
/// </summary>
    public interface IOrder : Domain.ICommand
    {
        void CreateOrder(Order order);
    }
}
