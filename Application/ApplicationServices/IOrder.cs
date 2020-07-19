using Domain.Entities;

namespace Application.ApplicationServices
{/// <summary>
/// dependency injection interface
/// </summary>
    public interface IOrder : Domain.ICommand
    {
        void CreateOrder(Order order);
        void InsertData1(BasicData1 data1);
        void InsertData2(BasicData2 data2);
    }
}
