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
        /// Verilen metni �ifreler
        /// </summary>
        /// <param name="plainText">�ifrelenecek metin</param>
        /// <returns>�ifrelenmi� metin</returns>
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            return _protector.Protect(plainText);
        }

        /// <summary>
        /// �ifrelenmi� metni ��zer
        /// </summary>
        /// <param name="encryptedText">�ifrelenmi� metin</param>
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
                // �ifre ��zme hatas� durumunda bo� string d�ner
                // Bu, veritaban�nda bozuk/eski �ifrelenmi� veri oldu�unda uygulaman�n ��kmesini �nler
                return string.Empty;
            }
        }

        /// <summary>
        /// Verinin �ifrelenmi� olup olmad���n� kontrol eder
        /// </summary>
        /// <param name="text">Kontrol edilecek metin</param>
        /// <returns>�ifrelenmi� ise true, de�ilse false</returns>
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