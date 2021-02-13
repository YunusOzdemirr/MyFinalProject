using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        //En basic Result bu herşey burdaki ikiliye göre dönüş yapıyor yani 
        //tüm classlar burdan implemente olmak zorunda
        bool Succes { get; }
        string Message { get; }
    }
}
