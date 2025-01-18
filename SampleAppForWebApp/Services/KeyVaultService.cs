using Azure.Security.KeyVault.Secrets;

namespace SampleAppForWebApp.Services
{

    public class KeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService(SecretClient secretClient)
        {
            _secretClient = secretClient;
        }

        public string GetSecretValue(string secretName)
        {
            try
            {
                var secret = _secretClient.GetSecret(secretName);
                return secret.Value.Value;
            }
            catch (Exception ex)
            {
                return $"Error retrieving secret: {ex.Message}";
            }
        }
    }

}
