using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi";
        public static string NotAdded = "Eklenemedi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string Listed = "Listelendi";
        public static string DetailsListed = "Detaylı Listelendi";
        public static string CarImageExist="Bir arabanın maximum 5 resmi olabilir.";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string Alreadyrentals="Kiralanmış araba";
    }
}
