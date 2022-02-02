using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Marka eklendi";

        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar Listelendi";
        public static string ErrorBrandExists = "Bu marka mevcut zaten";
        public static string BrandDeleted = "Marka silindi";
        public static string CarImageExceeded = "Resim sayısı aşıldi";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı üye oldu";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetki reddedildi";

        public static string UserAdded = "Kullanıcı eklendi";

        public static string ErrorAddCarImage = "Resim yuklerken hata oluştu ";
    }
}