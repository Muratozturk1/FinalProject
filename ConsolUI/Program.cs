// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//CategoryTest();


//ProductTest();

static void ProductTest()
{
    /*ProdcutManager prodcutManager = new ProdcutManager(new EfProdcutDal());

    var result = prodcutManager.GetProductDetails();
    if (result.Success == true) 
    {
        foreach (var prodcut in result.Data)
        {
            Console.WriteLine(prodcut.ProdcutName + "/" + prodcut.CategoryName);
        }
    }
    else 
    {
        Console.WriteLine(result.Message);
    }
   */
}

static void CategoryTest()
{
   /* CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }*/
}