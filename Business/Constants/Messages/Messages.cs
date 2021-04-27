using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
   public static class Messages
    {
        public static readonly string AlreadyRented = "Bu araç şu an kullanımda. ";
        public static readonly string NotFound = "Kayıt bulunamadı.";
        public static readonly string AuthorizationDenied = "Erişim reddedildi.";
        public static readonly string CarImageLimitReached = "Bir araba için maksimum 5 resim yüklenebilir";
        public static readonly string UserRegistered = "Kullanıcı Kaydoldu.";
        public static readonly string UserNotFound = "Kullanıcı Bulunamadı";
        public static readonly string PasswordError = "Hatalı Parola";
        public static readonly string SuccessfulLogin = "Başarılı Gririş";
        public static readonly string UserAlreadyExists = "Bu kullanıcı zaten var";
        public static readonly string AccessTokenCreated = "Token oluşturuldu";
    }
}
