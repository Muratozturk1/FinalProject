using Azure.Core;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.Concrete;

public class ProdcutManager : IProductService
{
    IProductDal _prodcutDal;
    ICategoryService _categoryService;

    public ProdcutManager(IProductDal prodcutDal,ICategoryService categoryService) 
    {
        _prodcutDal = prodcutDal;
        _categoryService = categoryService;
       
    }

    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Add(Product product)
    {
       IResult result = BusinessRules.Run(CheckIfProductCountCategoryCorrect(product.CategoryId),
           CheckIfProductNameExists(product.ProductName),
           CheckIfCategoryLimitExceded());

        if(result != null)
        {
            return result;        
        }
        
        _prodcutDal.Add(product);

         return new SuccessResult(Messages.ProductNameInvalid);
      
    }
    [CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {
        if(DateTime.Now.Hour == 22) 
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        
        }

        //İş Kodları
        //Yetkisi var mı ?
        return new SuccessDataResult<List<Product>>(_prodcutDal.GetAll(),Messages.ProductsListed);
    }

    public IDataResult<List<Product>> GetAllByCategoryID(int id)
    {
        return new SuccessDataResult<List<Product>>(_prodcutDal.GetAll(p=>p.CategoryId == id));
    }
    [CacheAspect]
    [PerformanceAspect(5)]
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product> (_prodcutDal.Get(p => p.ProductId == productId));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_prodcutDal.GetAll(p=>p.UnitPrice >=min && p.UnitPrice <= max));
    }

    public IDataResult<List<ProdcutDetailDto>> GetProductDetails()
    {
        return new SuccessDataResult<List<ProdcutDetailDto>>(_prodcutDal.GetProdcutDetails());
    }


    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")] // ürün güncellemeolunca cachei siler
    public IResult Update(Product product)
    {
        throw new NotImplementedException();
    }
    private IResult CheckIfProductCountCategoryCorrect(int categoryId) 
    {
        var result = _prodcutDal.GetAll(p => p.CategoryId == categoryId).Count;
        if (result >= 10)
        {
            return new ErrorResult(Messages.ProductCountOfCategeroyError);
        }
        return new SuccessResult();
    }
    private IResult CheckIfProductNameExists(string productName) 
    {
        var result = _prodcutDal.GetAll(p => p.ProductName == productName).Any();

        if(result == true) 
        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }
        return new SuccessResult();
    } 
   private IResult CheckIfCategoryLimitExceded() // burayı direk kategorimanagerde yapsaydık o zaman o categori başlı başına 
    {                                            // bir service diyebilirdik
        var result = _categoryService.GetAll();
        if(result.Data.Count > 15) 
        {
            return new ErrorResult(Messages.CategoryLimitExceded);
        }
        return new SuccessResult();
    
    }

    [TransactionScopeAspect]
    public IResult AddTransactionalTest(Product product)
    {

        Add(product);
        if (product.UnitPrice < 10) 
        {
            throw new Exception("");
        }
       
        Add (product);

        return null;

    }
}

