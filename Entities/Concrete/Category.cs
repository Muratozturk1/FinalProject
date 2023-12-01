
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

//Çıplak kalmasın classlar herhangi bir inheritance alması daha iyi olur.
public class Category :IEntity
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }


}
