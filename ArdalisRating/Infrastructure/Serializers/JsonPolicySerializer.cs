using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ArdalisRating
{
    public class JsonPolicySerializer : IPolicySerializer
    {

        public Policy GetPolicyFromString(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<Policy>(input, new StringEnumConverter());
            }
            catch (Exception e)
            {
                throw new Exception($"Error trying to Deserialize policy. {e}");
            }
        }
    }
}