using Microsoft.AspNetCore.DataProtection;

namespace BelinAI.Services
{
    public class EncryptionService
    {
        private readonly IDataProtector _protector;

        public EncryptionService(IDataProtectionProvider dataProtectionProvider)
        {
            _protector = dataProtectionProvider.CreateProtector("BelinAI.ApiKeys");
        }

        /// <summary>
        /// Verilen metni þifreler
        /// </summary>
        /// <param name="plainText">Þifrelenecek metin</param>
        /// <returns>Þifrelenmiþ metin</returns>
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            return _protector.Protect(plainText);
        }

        /// <summary>
        /// Þifrelenmiþ metni çözer
        /// </summary>
        /// <param name="encryptedText">Þifrelenmiþ metin</param>
        /// <returns>Orijinal metin</returns>
        public string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
                return string.Empty;

            try
            {
                return _protector.Unprotect(encryptedText);
            }
            catch (Exception)
            {
                // Þifre çözme hatasý durumunda boþ string döner
                // Bu, veritabanýnda bozuk/eski þifrelenmiþ veri olduðunda uygulamanýn çökmesini önler
                return string.Empty;
            }
        }

        /// <summary>
        /// Verinin þifrelenmiþ olup olmadýðýný kontrol eder
        /// </summary>
        /// <param name="text">Kontrol edilecek metin</param>
        /// <returns>Þifrelenmiþ ise true, deðilse false</returns>
        public bool IsEncrypted(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            try
            {
                _protector.Unprotect(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}