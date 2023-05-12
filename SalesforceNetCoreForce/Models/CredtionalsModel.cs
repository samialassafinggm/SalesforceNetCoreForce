using Microsoft.Extensions.Configuration;

namespace SalesforceNetCoreForce; 

public class CredtionalsModel 
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public string SandboxEndPoint { get; set; }

    public string BaseUrl { get; set; }


    public CredtionalsModel() {

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();

        ClientSecret = configuration.GetSection("ApiCredentials").GetSection("ClientSecret").Value.ToString();
        Username = configuration.GetSection("ApiCredentials").GetSection("Username").Value.ToString();
        Password = configuration.GetSection("ApiCredentials").GetSection("Password").Value.ToString();
        ClientId= configuration.GetSection("ApiCredentials").GetSection("ClientId").Value.ToString();
        SandboxEndPoint= configuration.GetSection("ApiCredentials").GetSection("Sandbox-End-Point").Value.ToString();
    }
}