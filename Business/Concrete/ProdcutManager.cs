using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ProdcutManager : IProductService
{
    IProductDal _prodcutDal;
    public ProdcutManager(IProductDal prodcutDal) 
    {
        _prodcutDal = prodcutDal;
    
    }
    public List<Product> GetAll()
    {
        //İş Kodları
        //Yetkisi var mı ?
        return _prodcutDal.GetAll();
    }

    public List<Product> GetAllByCategoryID(int id)
    {
        return _prodcutDal.GetAll(p => p.CategoryId == id);
    }

    public List<Product> GetByUnitPrice(decimal min, decimal max)
    {
        return _prodcutDal.GetAll(p=>p.UnitPrice >=min && p.UnitPrice <= max);
    }
}

