using Domain.Entities;

namespace Application.ApplicationServices
{
    public interface IOrder : Domain.ICommand
    {
        void CreateOrder(Order order);
    }
}
