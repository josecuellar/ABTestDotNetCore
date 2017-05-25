
using ABTestDotNetCore.Main.Middleware;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

public class ABTestViewLocationExpander : IViewLocationExpander
{
    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {

        List<string> locations = new List<string>();

        foreach (var versionAssigned in ABTest.VersionsAssigned)
            locations.Add("/Views/{2}/{1}/{0}." + versionAssigned.Value + ".cshtml");

        return locations.Union(viewLocations);          
    }


    public void PopulateValues(ViewLocationExpanderContext context)
    {
        context.Values["customviewlocation"] = nameof(ABTestViewLocationExpander);
    }
}