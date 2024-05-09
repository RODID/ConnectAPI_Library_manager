using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Client
{
    public class HttpRequestSender
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiUrl = "https://localhost:7122/getMeBooks/";

        public List<Book> GetAllBooks()
        {
            HttpResponseMessage response = httpClient.GetAsync(apiUrl + "getAll").Result;
            Console.WriteLine("Status code: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Book>>(json);
            }
            return null;
        }

        public void AddBook(string title, string author, string genre, int published)
        {
            Book book = new Book(title, author, genre, published);
            string json = JsonConvert.SerializeObject(book);

            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(apiUrl + "addBook", httpContent).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(title + " successfully added!");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        public void EditBook(int id, string title, string author, string genre, int published)
        {
            Book book = new Book(id, title, author, genre, published);
            string json = JsonConvert.SerializeObject(book);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(apiUrl + "updateBook", httpContent).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(title + " successfully edited!");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        public void DeleteBook(int id)
        {
            string url = apiUrl + "deleteBook?id=" + id;

            HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Id " + id + " successfully deleted.");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }
}
