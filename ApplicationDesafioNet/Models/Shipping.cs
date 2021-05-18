using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDesafioNet.Models
{
    public class Shipping
    {
        public static string BASE_URL = "https://localhost:44337/api/file";

        public Sucess SendListData(List<import> items)
        {
            var client = new RestClient(BASE_URL + "/insertItems");
            var request = new RestRequest();
            request.Method = Method.POST;
            request.AddJsonBody(items);
            try
            {
                var response = client.Execute<Sucess>(request);
                Console.WriteLine(response.Content);
                return response.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
    }
}
