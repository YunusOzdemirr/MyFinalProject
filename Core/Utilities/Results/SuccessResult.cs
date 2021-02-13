using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //Void methodlarda geri dönüş değeri göndermeyen sadece işlemi yaptığını bildiren
        //Methodlarda yai crud işlemlerinde bunlar kullanılıyor
        //SuccessDataResulttan farkı Data değil de mesasage döneriyor sadece

        //base demek yukarda inheritance dediğimiz classa gönder demek
        //messsage verdim ve true gönderiyoruz demek
        //yani Managerda return new SuccessResult("İşlem başarılı"); anlamına geliyor 1.ctor
        public SuccessResult(string message):base(true,message)
        {
             
        }

        //messsage vermedim direk true gönderiyoruz 
        //yani Managerda return new SuccessResult(); gönderdik demek
        public SuccessResult():base(true)
        {

        }
    }
}
