using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //burda IResult ı implemente etmemizin sebebi hem bir message ve success döndürecek olmamız
        //o yüzden IResult ekledik message ve successe ek olarak da bu classla birlikte bir data 
        //göndereceğimiz için t tipinde data ekledik ;)
        T Data { get;}
    }
}
