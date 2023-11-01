// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

ProdcutManager prodcutManager = new ProdcutManager(new EfProdcutDal());
foreach (var prodcut in prodcutManager.GetAll())
{
    Console.WriteLine(prodcut.ProductName);
}

