using System.Diagnostics;
using NetCoreForce.Client;
using NetCoreForce.Models;
using SalesforceNetCoreForce;


Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
CredtionalsModel credtionalsModel = new CredtionalsModel();

SalesforceClient salesforceClient = new SalesforceClient();

await salesforceClient.Authenticating(credtionalsModel);

//SfAccount sfAccount = await salesforceClient.CallAccount();

//bool testDictio =await salesforceClient.UpdateAccount();


bool isCaseCreated = await salesforceClient.CreateCases();
stopwatch.Stop();
double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
Console.WriteLine("Vergangene Zeit für 100 Case: " + elapsedSeconds + " Sekunden");
