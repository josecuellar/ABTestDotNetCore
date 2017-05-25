using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ABTestDotNetCore.Main.Repositories.Impl
{
    public class JsonExperimentRepository : IExperimentRepository
    {

        readonly IHostingEnvironment _env;

        public JsonExperimentRepository(IHostingEnvironment env)
        {
            _env = env;
        }

        public string GetPathJson()
        {
            return _env.WebRootPath + @"\json\Experiments.json";
        }

        public async Task<IList<Experiment>> GetListActive()
        {
            return await Task.Run(() =>
            {

                var json = File.ReadAllText(GetPathJson());

                return Deserialize(json);

            });
        }


        public async Task Save(IList<Experiment> experiments)
        {
            await Task.Run(() =>
            {

                string experimentsSer = JsonConvert.SerializeObject(experiments);

                File.WriteAllText(GetPathJson(), experimentsSer);

            });
        }


        private string Serialize(List<Experiment> experiments)
        {
            if (experiments == null)
                throw (new ArgumentNullException("experiments object is mandatory"));

            return JsonConvert.SerializeObject(experiments);
        }


        private List<Experiment> Deserialize(string experiments)
        {
            if (string.IsNullOrWhiteSpace(experiments))
                throw (new ArgumentNullException("experiments string serialized is mandatory"));

            return JsonConvert.DeserializeObject<List<Experiment>>(experiments);
        }
    }
}
