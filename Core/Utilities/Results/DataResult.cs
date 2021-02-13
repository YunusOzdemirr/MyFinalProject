using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //Bu methodların dönüş tipini belirlemek için kullandığımı class
        //örnek olarak
        //IDataResult<List<Product>> yani dönüş tipini belirliyoruz
        //neden IDataResult kullanıyoruz çünkü burda constructorlar veriyi base yani Resulta Döndürüyorlar
        //IDataResultın içinde sadece T tipinde Data var
        public DataResult(T data,bool success, string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
