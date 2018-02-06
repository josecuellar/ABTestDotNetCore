using System.Collections.Generic;

namespace ABTestDotNetCore.Main.Services
{
    public interface IAssignVersionProvider
    {
        bool IsAssigned(Experiment experiment);

        void Assign(Version version, Experiment toExperiment);

        IDictionary<Experiment, string> GetAllAssignedVersions(IList<Experiment> experiments);
    }
}
