using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //static verirsen newlenmez
        //eğer bir değişken public ise ilk harfi büyük olur PascalCase
        //eğer bir değişken private ise ilk harfi küçük olur camelCase
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün eklenemedi";
        public static string ProductList = "Ürün Listelendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductCountOfCategoryError = "Sınır aşıldı";
        public static string ProductNameAlreadyExists = "Aynı isim ürün zaten mevcut";

        public static string CategoryLimitExceded = "Kategori Limiti aşıldı daha fazla ürün eklenemez";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered="Kullanıcı kaydı oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
