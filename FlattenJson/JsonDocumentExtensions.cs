using System.Collections.Generic;
using System.Text.Json;

namespace FlattenJson
{
    public static class JsonDocumentExtensions
    {
        public static Dictionary<string, string> Flatten(this JsonDocument document)
        {
            var result = new Dictionary<string, string>();
            FlattenElement(string.Empty, document.RootElement, result);
            return result;
        }

        private static void FlattenElement(string key, JsonElement element, Dictionary<string, string> result)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (var pty in element.EnumerateObject())
                    {
                        string nextKey = string.IsNullOrEmpty(key) ? pty.Name : $"{key}.{pty.Name}";
                        FlattenElement(nextKey, pty.Value, result);
                    };
                    break;
                case JsonValueKind.Array:
                    int i = 0;
                    foreach (var arrayItem in element.EnumerateArray())
                    {
                        string nextKey = $"{key}[{i}]";
                        FlattenElement(nextKey, arrayItem, result);
                        i++;
                    }
                    break;
                default:
                    result.Add(key.ToString(), element.ToString());
                    break;
            }
        }
    }
}
