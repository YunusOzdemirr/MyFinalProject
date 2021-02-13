using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccesDataResult<T>:DataResult<T>
    {
        //Başarılı Data Dönerken bunu kullanıyoruz

        //ister data message ver bunları base e gönder
        public SuccesDataResult(T data,string message):base(data,true,message)
        {

        }
        //ister sadece data ver base e data ve true gönder
        public SuccesDataResult(T data):base(data,true)
        {

        }
        //alttaki iki ctor genelde kullanılmaz
        //ister sadece message ver datayı default ver yani T türünde true ve messagı base e gönder
        public SuccesDataResult(string message):base(default,true,message)
        {

        }
        //ister datayı default ver hiç bir şey yani T gönder sadece  message verme true gönder base e
        public SuccesDataResult():base(default,true)
        {

        }
       
    }
}
