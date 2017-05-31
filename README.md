<html>
<body>

<table>
<tr>
  <td><img src="https://github.com/josecuellar/ABTestDotNetCore/blob/master/ABTestDotNetCore/wwwroot/images/testab.JPG" width="100px"></td>
  <td>
    <h1>Simple AB Testing Engine for ASP .Net Core</h1>
  <p>Easy to use & easy to adapt to MVC</p>
  <p>The repository contains two projects: Main library and <b>demo project</b> in ASP.net Core where you can see all configurations and all ABTest Engine functionalities</p>
  </td>
</tr>
</table>

<h2>Configure your Expermients and Versions with percentage target in JSON File</h2> 
<p>Implement your custom repository for get & save experiments (DB, Memory, etc).</p>

```
[
  {
    "Id": "8dcdcfa5-d6f4-42a0-9f53-08c7e9b3db93",
    "Title": "Experiment 1",
    "Versions": [
      {
        "KeyWord": "Version3",
        "Title": "title3",
        "Percentage": 60,
        "TimesSent": 0
      },
      {
        "KeyWord": "Version2",
        "Title": "title2",
        "Percentage": 20,
        "TimesSent": 0
      },
      {
        "KeyWord": "Version1",
        "Title": "title1",
        "Percentage": 20,
        "TimesSent": 0
      }
    ]
  },
  {
    "Id": "63899319-b0a0-4b00-b04c-60abb24152f2",
    "Title": "Experiment 2",
    "Versions": [
      {
        "KeyWord": "Version22",
        "Title": "title3",
        "Percentage": 75,
        "TimesSent": 0
      },
      {
        "KeyWord": "Version21",
        "Title": "title2",
        "Percentage": 25,
        "TimesSent": 0
      }
    ]
  },
  {
    "Id": "a55625a7-8816-40c9-805a-c77b4798d50d",
    "Title": "Experiment 3",
    "Versions": [
      {
        "KeyWord": "Version31",
        "Title": "title2",
        "Percentage": 50,
        "TimesSent": 0
      },
      {
        "KeyWord": "Version32",
        "Title": "title3",
        "Percentage": 50,
        "TimesSent": 0
      }
    ]
  }
]
```

<h2>Versions assigned to user using cookie by experiment</h2> 

<p>You can implement new providers for save to user assigned versions for each experiment</p>

<p><i>Use keywords version for tracking with analytics or other statistics frameworks for measure conversions</i></p> 


<h2>Configure Middleware in Startup.cs</h2> 
<p>Need manage <i>Begin Request</i> & <i>End Request</i> for all operations</p>

```
app.UseMiddleware<Main.Middleware.ABTest>();

```

<h2>Configure Services Singleton in Startup.cs</h2> 
<p>Need manage <i>dependency injection</i> for manage operations in middleware</p>

```
 
services.AddSingleton<IExperimentService, ExperimentService>();
services.AddSingleton<IExperimentRepository, JsonExperimentRepository>();

 ```

<h2>Configure Custom view names expander in Startup.cs</h2> 
<p>All versions have KeyWord for identify custom views. Engine try to get custom view for active experiment of assigned version. If not found, return default view. </p>
<p><i>For example: Partials/ListResults.cshtml | Partials/ListResults.<B>KeyWord Version</B>.cshtml</i></p>

```
 
services.Configure<RazorViewEngineOptions>(options => {
   options.ViewLocationExpanders.Add(new ABTestViewLocationExpander());
});

```

<h2>Manage manually versions assigned</h2> 

```
if (ABTestDotNetCore.Main.Middleware.ABTest.GetKeyWordVersionAssignedFromTitle("SolrVsSQL") == "SolrVersionKeyWord")
{
   <b>//To Solr</b>
}
else
{
   <b>//To Sql</b>
}
```

<h1>Take a look at demo project</h1>

<hr>


![alt text](https://github.com/josecuellar/ABTestDotNetCore/blob/master/ABTestDotNetCore/wwwroot/images/demo1.jpg)
![alt text](https://github.com/josecuellar/ABTestDotNetCore/blob/master/ABTestDotNetCore/wwwroot/images/demo2.jpg)
![alt text](https://github.com/josecuellar/ABTestDotNetCore/blob/master/ABTestDotNetCore/wwwroot/images/demo3.jpg)
![alt text](https://github.com/josecuellar/ABTestDotNetCore/blob/master/ABTestDotNetCore/wwwroot/images/demo4.jpg)

<br>

Feel free for fork and contribute!<br>
Thanks!

</body>
</html>



