using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating
{
    public class JsonPolicySerializer
    {
        public IPolicy GetPolicyFromJsonString(string input)
        {
            try
            {
                // TODO: Fix broken deserializer
                return JsonConvert.DeserializeObject<IPolicy>(input, new StringEnumConverter());
            }
            catch (Exception e)
            {
                throw new Exception($"Error trying to Deserialize policy. {e}");
            }
        }
    }
}