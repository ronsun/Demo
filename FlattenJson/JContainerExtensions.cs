using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace FlattenJson
{
    public static class JContainerExtensions
    {
        public static Dictionary<string, string> Flatten(this JContainer jContainer)
        {
            IEnumerable<JToken> jTokens = jContainer.Descendants().Where(p => p.Count() == 0);
            return jTokens.ToDictionary(jToken => jToken.Path, jToken => jToken.ToString());
        }
    }
}
