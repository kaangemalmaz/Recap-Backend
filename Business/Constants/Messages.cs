using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba başarı ile eklendi";
        public static string CarAddedError = "Car Name en az 2 harf olmalıdır.";
        public static string MusteriEklendi = "Müşteri başarı ile eklenmiştir.";
        public static string MusteriSilindi = "Müşteri başarı ile silinmiştir.";
        public static string MusteriGuncellendi = "Müşteri başarı ile güncellenmiştir.";
        public static string CarImageAdded = "Araba ekleme işlemi başarı ile tamamlanmıştır.";
        public static string ExceedCarImageCount = "1 araba için 5 den fazla resim yüklenemez";
        public static string CarImageNotFound = "Arabaya ait resim bulunamamıştır.";
        public static string CarUpdatedFail = "Araba resmi güncellenirken hata oluştu";
        public static string CarImageUpdated = "Araba resmi başarı ile güncellendi";
        public static string CarSuccessDeleted = "Araba resmi başarı ile silindi";
        public static string CarNotFound = "Aranan araba sistemde bulunamamıştır.";
        public static string UserNotFound = "Login olmak istenilen kullanıcı sistemde bulunamamıştır";
        public static string PasswordError = "Passwordü hatalı girdiniz. Kontrol Ediniz.";
        public static string SuccessfulLogin = "Başarı ile giriş yaptınız!";
        public static string UserAlreadyExits = "User zaten sistemde kayıtlıdır. Başka bir email deneyiniz.";
        public static string UserAccepted = "Giriş yapılan email kabul edilmiştir.";
        public static string UserSuccesfullyRegistered = "Kullanıcı başarı ile oluşturuldu";
        public static string TokenCreated = "Token başarı ile üretilmiştir.";
        public static string FindeksIsNotEnough = "Üzgünüz findeks değeriniz arabanın findeks değerinden düşük olduğu için işleminizi gerçekleştiremiyoruz.";
        public static string CrediCardAdded = "Kredi kartı başarı ile eklenmiştir.";
        public static string CrediCardDeleted = "Kredi kartı başarı ile silinmiştir.";
        public static string CreditCardUpdated = "Kredi kartı başarı ile güncellenmiştir";
    }
}
