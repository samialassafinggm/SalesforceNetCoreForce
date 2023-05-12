using System.Dynamic;
using NetCoreForce.Client;
using NetCoreForce.Client.Models;
using NetCoreForce.Models;
using SalesforceNetCoreForce.Models;

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
    
    
    public async Task<bool> UpdateAccount() {
        bool state = false;
        List<SObject>  accounts = new List<SObject>();
        Dictionary<string, string> customHeaders = new Dictionary<string, string>();
        customHeaders.Add("Name", "Test Dictinoary XXXXX");
       
        try {
            await Client.UpdateRecords(accounts, false,customHeaders);
            state = true;
        }
        catch (Exception e) {
            Console.WriteLine("failed:{0}", e.Message);
        }

        return state;
    }


    public async Task<bool> UpdateCases(string caseId) {
        bool state = false;

        var updateCase = new ExpandoObject();
        updateCase.TryAdd("Status", "automated");
        updateCase.TryAdd("GGM Order", " 13245 automated");
        
        try {  
            await Client.InsertOrUpdateRecord("Case", "caseNumber", caseId, updateCase);
            state = true;
        }
        catch (Exception e) {
            Console.WriteLine("failed:{0}", e.Message);
        }
        return state;

    }

    public async Task<bool> CreateCases() {
        bool state = false;
        CaseModel caseTest = new CaseModel();
        List<CaseModel> cases = new List<CaseModel>();
        cases = caseTest.CreateDummyCases();
        CreateResponse? response = new CreateResponse();
      
        foreach (var caseModel in cases) {
            try {
                response = await Client.CreateRecord("Case", caseModel);
           state = true;
           string caseId = response.Id;
           Console.WriteLine("Case created successfully. Case ID: " + caseId);
           
            }
            catch (Exception e) {
                string caseId = response.Id;
            Console.WriteLine("Failed to create case. Error message: " + response.Errors);
            Console.WriteLine("failed:{0}", e.Message);
            }
        }
        return state;
    }
}