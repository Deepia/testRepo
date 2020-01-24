using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fitbit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getToken();
        testMethod();
    }

    public string getToken()
    {
        string token = "";
        try
        {
            var client = new RestClient("https://api.fitbit.com/oauth2/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Basic MjJCQkw0OmYwMGI0MGMwOTA2Y2NjMDJjOGU2ZjQ0N2MxZmE1YzFl");
            request.AddParameter("application/x-www-form-urlencoded", "client_id=22BBL4&grant_type=authorization_code&redirect_uri=https://awesome.hotspex.com/FitBit/auth&code=fe094b4b2f2db864446d1b35233b2fee3b10ef21", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString() != "BadRequest")
            {
                token = response.Content;
            }
           
        }
        catch (Exception ex)
        {

        }
        return token;
    }

    public void testMethod()
    {
        var client = new RestClient("https://api.fitbit.com/1/user/857VZL/profile.json");
        var request = new RestRequest(Method.GET);
        request.AddHeader("postman-token", "d696f15a-ce59-6ff8-57e3-239b1a011963");
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyMkJCTDQiLCJzdWIiOiI4NTdWWkwiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJyc29jIHJhY3QgcnNldCBybG9jIHJ3ZWkgcmhyIHJudXQgcnBybyByc2xlIiwiZXhwIjoxNTc4MDYyMDQxLCJpYXQiOjE1NzgwMzMyNDF9.BfJovrDUQ2AD9AHD5CMi7BhjuJrRr5rOmNJEticyOmo");
       
        IRestResponse response = client.Execute(request);
    }
}