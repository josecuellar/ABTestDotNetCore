using ABTestDotNetCore.Main.Services;
using ABTestDotNetCore.Main.Services.Impl;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABTestDotNetCore.Main.Middleware
{
    public class ABTest
    {
        private readonly RequestDelegate next;

        public static IList<Experiment> Experiments;
        public static IDictionary<Experiment, string> VersionsAssigned;

        private readonly IExperimentService _experimentService;
        private IAssignVersionProvider _provider;


        public ABTest(
            RequestDelegate next,
            IExperimentService experimentService)
        {
            this.next = next;

            VersionsAssigned = new Dictionary<Experiment, string>();

            _experimentService = experimentService;
        }


        public async Task Invoke(HttpContext context)
        {
            _provider = new CookieAssignVersion(context);

            this.BeginInvoke(context);

            await this.next.Invoke(context);

            this.EndInvoke(context);
        }

        public static string GetKeyWordVersionAssignedFromTitle(string title)
        {
            return VersionsAssigned.FirstOrDefault(x => x.Key.Title == title).Value;
        }

        private void BeginInvoke(HttpContext context)
        {
            Task.Run(async () => {

                Experiments = await _experimentService.GetListActiveExperiments();

                VersionsAssigned = _provider.GetAllAssignedVersions(Experiments);

            });
        }


        private void EndInvoke(HttpContext context)
        {
            _experimentService.SaveExperiments(Experiments);
        }
    }
}
