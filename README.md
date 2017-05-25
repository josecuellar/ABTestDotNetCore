<html>
<body>

<h1>Very simple AB Testing Engine for DotNet Core</h1>
<p>In repository have two projects: Main library and demo project in ASP.net Core</p>
<br>




<h2>Configure your Expermients with versions (percentage target) in JSON File</h2> 
<p>Implement your custom repository for save experiments in DB, Memory, etc.</p>

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
        "TimesSent": 32
      },
      {
        "KeyWord": "Version2",
        "Title": "title2",
        "Percentage": 20,
        "TimesSent": 6
      },
      {
        "KeyWord": "Version1",
        "Title": "title1",
        "Percentage": 20,
        "TimesSent": 7
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
        "TimesSent": 34
      },
      {
        "KeyWord": "Version21",
        "Title": "title2",
        "Percentage": 25,
        "TimesSent": 11
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
        "TimesSent": 22
      },
      {
        "KeyWord": "Version32",
        "Title": "title3",
        "Percentage": 50,
        "TimesSent": 23
      }
    ]
  }
]
```

<h2>Reference ABTestDotNetCore.Main in your ASP.net Core project</h2> 

<br>

<h2>Configure Middleware in Startup.cs</h2> 
<p>Need manage <i>Begin Request</i> & <i>End Request</i> for all operations</p>

```
	app.UseMiddleware<Main.Middleware.ABTest>();

```

<br>

<h2>Configure Services Singleton in Startup.cs</h2> 
<p>Need manage <i>dependency injection</i> for manage operations in middleware</p>

```
 
	services.AddSingleton<IExperimentService, ExperimentService>();
    services.AddSingleton<IExperimentRepository, JsonExperimentRepository>();

 ``

<br>

<h2>Configure Custom view names expander in Startup.cs</h2> 
<p>All versions have KeyWord for identify custom views. Engine try to get custom view for active experiment of assigned version. If not found, return default view. </p>
<p><i>For example: Partials/ListResults.cshtml | Partials/ListResults.<B>KeyWord Version</B>.cshtml</i></p>

```
 
    services.Configure<RazorViewEngineOptions>(options => {
        options.ViewLocationExpanders.Add(new ABTestViewLocationExpander());
    });

 ``

<br>

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

<h2>¡Check Demo Project with all examples!</h2> 


<br><br>

Feel free for fork and contribute!<br>
Thanks!

</body>
</html>



