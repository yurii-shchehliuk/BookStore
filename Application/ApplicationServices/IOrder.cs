using Application.DTO.BookDTO;
using Domain.Entities;

namespace Application.ApplicationServices
{
    public interface IOrder : Domain.ICommand
    {
        //Order AddOrder(Book book, int amount);
        //int RemoveItem(Book book);
        void Commit();
    }
}
