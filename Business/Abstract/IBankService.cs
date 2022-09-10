using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBankService
    {
        IDataResult<List<CreditCart>> GetByCart(int id);
        IResult Pay(int amount);
        IResult AddCreditCart(CreditCart creditCart);
    }
}
