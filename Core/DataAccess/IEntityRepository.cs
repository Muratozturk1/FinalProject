
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess;

//burada class demek referans tip demektir
//IEntity dediğimizde IEntitiy ve ondan implement edilen şeyler yazılabilir T yerine demek oluyor
//Bunun sıkıntısı ise burada biz IEntityde yazabiliriz ama o soyut bir interface içinde nesneler yok 
//o yüzden new() koyuyoruz interfaceler newlenemez çünkü
public interface IEntityRepository<T> where T : class,IEntity,new()
{
    List<T> GetAll(Expression<Func<T,bool>> filter =null);
    T Get(Expression<Func<T, bool>> filter = null);

    void Add(T entity);
    void Uptade(T entity);
    void Delete(T entity);
   
}
