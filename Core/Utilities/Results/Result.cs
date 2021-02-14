using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Burası bizim base classımız tüm veriler buraya gönderiliyor
        //yine aynı şekilde tüm classların burdan implemente olması lazım


        //sadece get olursa aşağıdaki gibi yeni kullanım var
        // public bool Succes => throw new NotImplementedException();
        //ama alttakinin aynısı bir fark yok
        //this demek classın kendisi demek yani result
        //this(succes) tek parametreli constructor ına succesi yolla demek
        //got it 
        //this(succes) =Result(bool success) demek yani tek parametreli constructorı da yolla demek
        //yani ilk, ilk sıradaki constructor çalışacak ama eğer message bilgisi yoksa 
        //sadece tek başına 2. constructor çalışacak demek o yüzden this(succeess) yaptık

        public Result(bool success,string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
