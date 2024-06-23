using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationConfiguration
{
    public interface IApplicationConfigurationService
    {
        public string AssemblyName();

        public string AssemblyVersion();

        public string LastModifiedDate();

        public string EnvironmentName();

        public bool IsDevelopment();

        public bool IsProduction();

        public string ToJson();

        public T ToObject<T>();
    }
}
