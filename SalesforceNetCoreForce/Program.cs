using NetCoreForce.Client;
using NetCoreForce.Models;
using SalesforceNetCoreForce;



CredtionalsModel credtionalsModel = new CredtionalsModel();

SalesforceClient salesforceClient = new SalesforceClient();

await salesforceClient.Authenticating(credtionalsModel);

SfAccount sfAccount = await salesforceClient.CallAccount();
