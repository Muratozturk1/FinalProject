using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IProductService
{
    // IResult olan normalde void dönüyordu o yüzden öyle ama IDataResult olanlar bir list dönüyordu o yüzden
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetAllByCategoryID(int id);
    IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
    IDataResult<List<ProdcutDetailDto>> GetProductDetails();
    IDataResult<Product> GetById(int productId);
    IResult Add(Product product);

    IResult Update(Product product);
    IResult AddTransactionalTest(Product product);



}

