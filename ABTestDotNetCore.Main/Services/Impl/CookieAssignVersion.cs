using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ABTestDotNetCore.Main.Services.Impl
{
    public class CookieAssignVersion : IAssignVersionProvider
    {

        readonly HttpContext _context;
        private const int _DAYS_EXPIRE_VERSION_ASSIGNED = 30;

        public CookieAssignVersion(HttpContext context)
        {
            _context = context;
        }


        public bool IsAssigned(Experiment experiment)
        {
            return (_context.Request.Cookies.Keys.Contains(experiment.GetKey()));
        }


        public void Assign(Version version, Experiment toExperiment)
        {
            _context.Response.Cookies.Append(toExperiment.GetKey(), version.KeyWord, new CookieOptions() { Expires = DateTime.Now.AddDays(_DAYS_EXPIRE_VERSION_ASSIGNED) });
        }


        public IDictionary<Experiment, string> GetAllAssignedVersions(IList<Experiment> experiments)
        {

            IDictionary<Experiment, string> versionsAssigned = new Dictionary<Experiment, string>();

            foreach (var experiment in experiments)
            {
                if (!IsAssigned(experiment))
                {
                    Version version = experiment.NextVersion();

                    Assign(version, experiment);

                    versionsAssigned.Add(experiment, version.KeyWord);

                    continue;
                }

                versionsAssigned.Add(experiment, _context.Request.Cookies[experiment.GetKey()]);
            }

            return versionsAssigned;

        }
    }
}
