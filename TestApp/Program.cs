using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestApp
{

    
    class Program
    {
        static readonly string url = "https://sandbox3.payture.com/api/Pay";
        
        static async Task Main()
        {
            try
            {
                using var client = new HttpClient();
                var dict = CreateParamsByRequest();
                var req = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new FormUrlEncodedContent(dict)
                };
                var res = await client.SendAsync(req);
                var responseString = res.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseString);

            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",e.Message);
            }
        }

        private static Dictionary<string, string> CreateParamsByRequest()
        {
            return new Dictionary<string, string>
            {
                {"Key", "Merchant"}, 
                {"Amount", "12523"}, 
                {"OrderId", "267eb6d1-548c-9a5a-cb13-252db0e70fa4"},
                {"PayInfo", "PAN=654111111111100000;EMonth=12;EYear=22;CardHolder=Ivan Ivanov;SecureCode=123;OrderId=267eb6d4-547c-9a5a-cb13-252db0e70ea4; Amount=12523"},
                {"CustomFields", "228.83.122.13;Product=Ticket"} 
            };
        }
    }
}