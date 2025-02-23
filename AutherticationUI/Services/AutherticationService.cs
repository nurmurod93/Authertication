namespace AutherticationUI.Services
{
    public class AutherticationService
    {
        private readonly HttpClient httpClient;

        public AutherticationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<bool> RegisterAsync(string email, string password)
        {
            var result = await httpClient.PostAsJsonAsync("api/account/register", new { Email = email, Password = password });
            return result.IsSuccessStatusCode;        
        }
        public async Task<string?> LoginAsync(string email, string password)
        {
            var response = await httpClient.PostAsJsonAsync("api/account/login", new { Email = email, Password = password });
            if(response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }
            return null;
        }
    }
}
