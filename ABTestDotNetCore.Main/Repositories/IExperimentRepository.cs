using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABTestDotNetCore.Main.Repositories
{
    public interface IExperimentRepository
    {
        Task<IList<Experiment>> GetListActive();

        Task Save(IList<Experiment> experiments);
    }
}
