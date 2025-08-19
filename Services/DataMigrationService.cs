namespace BelinAI.Services
{
    /// <summary>
    /// Mevcut þifrelenmemiþ API anahtarlarýný þifreler
    /// </summary>
    public class DataMigrationService
    {
        private readonly EncryptionService _encryptionService;

        public DataMigrationService(EncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        /// <summary>
        /// Þifrelenmemiþ API anahtarlarýný þifreler
        /// </summary>
        /// <param name="apiKey">Kontrol edilecek API anahtarý</param>
        /// <returns>Þifrelenmiþ API anahtarý</returns>
        public string EnsureEncrypted(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                return string.Empty;

            if (_encryptionService.IsEncrypted(apiKey))
                return apiKey;

            return _encryptionService.Encrypt(apiKey);
        }

        /// <summary>
        /// Veriyi güvenli þekilde çözer, baþarýsýz olursa boþ string döner
        /// </summary>
        /// <param name="encryptedData">Þifrelenmiþ veri</param>
        /// <returns>Çözülmüþ veri veya boþ string</returns>
        public string SafeDecrypt(string encryptedData)
        {
            return _encryptionService.Decrypt(encryptedData);
        }
    }
}