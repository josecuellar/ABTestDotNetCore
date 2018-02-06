using ABTestDotNetCore.Main.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABTestDotNetCore.Main.Services.Impl
{
    public class ExperimentService : IExperimentService
    {

        readonly IExperimentRepository _experimentRepository;

        public ExperimentService(IExperimentRepository experimentRepository)
        {
            this._experimentRepository = experimentRepository;
        }

        public async Task<IList<Experiment>> GetListActiveExperiments()
        {
            return await _experimentRepository.GetListActive();
        }

        public async Task SaveExperiments(IList<Experiment> experiments)
        {
            await _experimentRepository.Save(experiments);
        }

    }
}
