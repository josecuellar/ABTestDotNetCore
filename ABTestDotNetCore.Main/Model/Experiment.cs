using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABTestDotNetCore.Main
{
    public class Experiment
    {

        private const string PREFIX_COOKIE_VERSION_ASSIGNED = "Experiment_";

        public Guid Id { get; set; }

        public string Title { get; set; }

        public IList<Version> Versions { get; set; }

        [JsonIgnore]
        public int TimesSended
        {
            get
            {
                return this.Versions.Sum(x => x.TimesSent);
            }
        }

        //Default constructor for deserializing  :(
        public Experiment()
        {

        }

        public Experiment(Guid id, string title, IList<Version> versions)
        {
            if (id == null)
                throw (new ArgumentNullException("Id Experiment is required"));

            if (string.IsNullOrEmpty(title))
                throw (new ArgumentNullException("Title Experiment is required"));

            if (versions == null || (versions != null && !versions.Any()))
                throw (new ArgumentOutOfRangeException("Versions are mandatory for create a experiment"));

            CheckTotalPercentageOfVersions(versions);

            this.Id = id;
            this.Title = title;
            this.Versions = versions;
        }


        public Version NextVersion()
        {
            int random = (new Random()).Next(100);

            this.Versions = this.Versions.ToList()
                .OrderByDescending(y => y.Percentage)
                .ThenBy(x => x.TimesSent).ToList();

            int accumulated = 0;
            foreach (var version in this.Versions)
            {
                int rangeFrom = accumulated;
                int rangeTo = accumulated + version.Percentage;

                if (Enumerable.Range(rangeFrom, rangeTo).Contains(random))
                {
                    this.Versions[this.Versions.IndexOf(version)] = version.AddSent();
                    return version;
                }

                accumulated += version.Percentage;
            };

            Version versionLast = Versions.Last();
            this.Versions[this.Versions.IndexOf(versionLast)] = versionLast.AddSent();

            return versionLast;
        }


        public string GetKey()
        {
            return PREFIX_COOKIE_VERSION_ASSIGNED + this.Id.ToString();
        }

        private void CheckTotalPercentageOfVersions(IList<Version> versions)
        {
            var totalPercentageVersions = 0;
            ((List<Version>)versions).ForEach(x => totalPercentageVersions += x.Percentage);

            if (totalPercentageVersions < 0 || totalPercentageVersions > 100)
                throw (new InvalidOperationException("Sum percentages versions must be exactly 100"));
        }



    }
}
