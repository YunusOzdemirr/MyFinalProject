using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        //Void methodlarda geri dönüş değeri göndermeyen sadece işlemi yaptığını bildiren
        //Methodlarda yani crud işlemlerinde bunlar kullanılıyor
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
