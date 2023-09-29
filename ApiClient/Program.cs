using System;
using System.Net.Http;
using System.Threading.Tasks;


while(true) 
{
    // Create an instance of HttpClient
    using (HttpClient client = new HttpClient())
    {
        // Define the base address of the API
        client.BaseAddress = new Uri("https://localhost:7223");

        try
        {
            // Send a GET request to the WeatherForecast endpoint
            HttpResponseMessage response = await client.GetAsync("/WeatherForecast");

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the content of the response
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Content:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Request failed with status code: {response.StatusCode}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request exception: {e.Message}");
        }
    }


    Thread.Sleep(1000);
}
