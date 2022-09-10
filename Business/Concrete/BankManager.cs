using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BankManager : IBankService
    {
        ICreditCartDal _ıCreditCartDal;

        public BankManager(ICreditCartDal ıCreditCartDal)
        {
            _ıCreditCartDal = ıCreditCartDal;
        }

        public IResult AddCreditCart(CreditCart creditCart)
        {
            _ıCreditCartDal.Add(creditCart);
            return new SuccessResult(Messages.Added);
        }

        public IResult Pay(int amount)
        {
            return new SuccessResult(amount + " tutarlı ödeme işlemi yapıldı.");
        }

        public IDataResult<List<CreditCart>> GetByCart(int id)
        {
            return new SuccessDataResult<List<CreditCart>>(_ıCreditCartDal.GetAll(c => c.UserId == id));
        }
    }
}
