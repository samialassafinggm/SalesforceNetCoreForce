﻿namespace SalesforceNetCoreForce.Models; 

public class CaseModel {
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }

    // Additional properties and methods can be added as needed

    public CaseModel(string subject, string description, string status, string priority)
    {
        Subject = subject;
        Description = description;
        Status = status;
        Priority = priority;
    }

    public CaseModel() {
            
    }

    public List<CaseModel> CreateDummyCases() {
      
        List<CaseModel> cases = new List<CaseModel>();
        
        for (int i =1; i <= 2000; i++) {

            CaseModel test = new CaseModel($"Case Model num{i}","Case description","Sami","High");
            cases.Add(test);
        }

        return cases;
    }
}