using NetCoreForce.Client;
using NetCoreForce.Models;

namespace SalesforceNetCoreForce; 

public class SalesforceClient {



    public AuthenticationClient Auth { get; set; }

    public ForceClient Client   { get; set; }

    public async Task Authenticating(CredtionalsModel credtionalsModel) {
        Auth = new AuthenticationClient();
        try {
            await Auth.UsernamePasswordAsync(credtionalsModel.ClientId, credtionalsModel.ClientSecret, credtionalsModel.Username, credtionalsModel.Password, credtionalsModel.SandboxEndPoint);
            Client = new ForceClient(Auth.AccessInfo.InstanceUrl, Auth.ApiVersion, Auth.AccessInfo.AccessToken);
        }

        catch (Exception e) {
            Console.WriteLine("failed:{0}", e.Message);
        }
    }

    public async Task<SfAccount> CallAccount() {

            SfAccount account = new SfAccount();
            try {
                account = await Client.GetObjectById<SfAccount>(SfAccount.SObjectTypeName, "0019X00000Bn5YXQAZ");
            }
            catch (Exception e) {
                Console.WriteLine("failed:{0}", e.Message);
            }

            return account;
        }
    }