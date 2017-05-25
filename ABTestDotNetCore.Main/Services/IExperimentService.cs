using ABTestDotNetCore.Main.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABTestDotNetCore.Main.Services
{
    public interface IExperimentService
    {
        Task<IList<Experiment>> GetListActiveExperiments();

        Task SaveExperiments(IList<Experiment> experiments);
    }
}
