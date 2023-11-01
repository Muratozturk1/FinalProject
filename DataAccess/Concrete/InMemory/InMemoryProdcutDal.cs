using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory;

public class InMemoryProdcutDal : IProductDal
{
    List<Product> _prodcuts; //Bu Class içerisinde global bir değişken olduğu için tanımlarken _name şeklinde tanımlanır genelde
    public InMemoryProdcutDal()
    {
        _prodcuts = new List<Product>() {
            new Product{ProductId =1 ,CategoryId = 1 , ProductName = "Bardak",UnitPrice = 15,UnitsInStock = 15},
            new Product{ProductId =2 ,CategoryId = 1 , ProductName = "Kamera",UnitPrice = 500,UnitsInStock = 3},
            new Product{ProductId =3 ,CategoryId = 2 , ProductName = "Telefon",UnitPrice = 1500,UnitsInStock = 2},
            new Product{ProductId =4 ,CategoryId = 2 , ProductName = "Klavye",UnitPrice = 150,UnitsInStock = 65},
            new Product{ProductId =5 ,CategoryId = 2 , ProductName = "Fare",UnitPrice = 85,UnitsInStock = 1}

        };

    }
    public void Add(Product product)
    {
        _prodcuts.Add(product);
    }

    public void Delete(Product product)
    {
        //_prodcuts.Remove(product); Bu kod çalışmaz bu şekilde çalışmaz.çünkü buradaki prodcut referans türünde çalıştığı için silemez
        /*Product silinecekVeri;
        foreach (var p in _prodcuts)
        {
            if (product.ProductId == p.ProductId) 
            {
                silinecekVeri = p;
            }
            _prodcuts.Remove(p);
        } 
        _prodcuts.Remove(p);bu kod çalışır ama mantıklı değil    LINQ = Language Integrated Query(Dile Gömülü Sorgu) */
        //Product prodcutToDelete; hatta buna da gerek yok
         Product prodcutToDelete = _prodcuts.SingleOrDefault(p=>p.ProductId ==product.ProductId);
    }

   

    public Product Get(Expression<Func<Product, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

  

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
        return _prodcuts;
    }

    public List<Product> GetByCategory(int categoryId)
    {
        return _prodcuts.Where(p=> p.CategoryId == categoryId).ToList();

        
    }

    public void Update(Product product)
    {   //Gönderdiğim ürünün idsi ile aynı idye sahip listedeki ürünü bul
        Product productToUptade = _prodcuts.SingleOrDefault(p => p.ProductId == product.ProductId);
        productToUptade.ProductName = product.ProductName;
        productToUptade.CategoryId = product.CategoryId;
        productToUptade.UnitPrice = product.UnitPrice;
        product.UnitsInStock = product.UnitsInStock;
    }

    public void Uptade(Product entity)
    {
        throw new NotImplementedException();
    }
}

