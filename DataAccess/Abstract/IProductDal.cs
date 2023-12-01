using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract;

    //IProdcutDal isminde I = interface olduğunu anlatır.Product ise hangi tabloya karşılık geldiğini entitye yani  Dal ise =onun hangi katmana karşılık geldiğini anlatır
    //Burası bizim veritabanındaki Product ile ilgili yapacağımız operasyonları yönettiğimiz interface operasyon ekleme silme falan
    public interface IProductDal :IEntityRepository<Product>
    {
    // Şimdi burada prodcut ve category adlı 2 nesnemiz var ve ikisinde değişen tek yer prodcut ve category o yüzden generics ile yaparsak
    // her seferinde tek tek bu işlemi yapmamıza gerek kalmaz.
      List<ProdcutDetailDto> GetProdcutDetails();
    }
