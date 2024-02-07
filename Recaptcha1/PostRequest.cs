using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Recaptcha1
{
    public static class PostRequest {
        public static int RecaptchaSendPost(string answer)
        {
            int statusCode = 0;
            using (var httpClient = new HttpClient())
            {
                var apiUrl = "https://www.google.com/recaptcha/api/siteverify";
                var postData = new List<KeyValuePair<string, string>>
{
new KeyValuePair<string, string>("secret", "6LfvZ2opAAAAAIotUoCWI5s07Bely6D6CfqLjJuZ"), // ReCAPTCHA secret key
new KeyValuePair<string, string>("response", answer) // Kullanıcının cevabı (token)
};
                var content = new FormUrlEncodedContent(postData);
                var sonuc = httpClient.PostAsync(apiUrl, content).Result;
                statusCode = Convert.ToInt32(sonuc.StatusCode);
            }
            return statusCode;

        }

    }
}
