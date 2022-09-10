using Business.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        public IResult CheckIfFindeksNo(int userId, int carId)
        {
            Random random = new Random();
            int userFindeks=random.Next(1900);
            Thread.Sleep(1000);
            int carFindeks=random.Next(1900);
            if (userFindeks >= carFindeks)
            {
                return new SuccessResult("Kiralamaya uygunsunuz");
            }
            else
            {
                return new ErrorResult("Yetersiz findeks puanı");
            }
        }
    }
}
