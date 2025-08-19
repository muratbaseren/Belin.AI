namespace BelinAI.Services
{
    /// <summary>
    /// Mevcut �ifrelenmemi� API anahtarlar�n� �ifreler
    /// </summary>
    public class DataMigrationService
    {
        private readonly EncryptionService _encryptionService;

        public DataMigrationService(EncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        /// <summary>
        /// �ifrelenmemi� API anahtarlar�n� �ifreler
        /// </summary>
        /// <param name="apiKey">Kontrol edilecek API anahtar�</param>
        /// <returns>�ifrelenmi� API anahtar�</returns>
        public string EnsureEncrypted(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                return string.Empty;

            if (_encryptionService.IsEncrypted(apiKey))
                return apiKey;

            return _encryptionService.Encrypt(apiKey);
        }

        /// <summary>
        /// Veriyi g�venli �ekilde ��zer, ba�ar�s�z olursa bo� string d�ner
        /// </summary>
        /// <param name="encryptedData">�ifrelenmi� veri</param>
        /// <returns>��z�lm�� veri veya bo� string</returns>
        public string SafeDecrypt(string encryptedData)
        {
            return _encryptionService.Decrypt(encryptedData);
        }
    }
}