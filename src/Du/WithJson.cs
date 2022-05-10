// PROJECT: MAWSC (https://github.com/spectrum-health-systems/MAWSC)
//    FILE: MAWSC.Du.WithJson.cs
// UPDATED: 5-10-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// b220510.065025 (ApprenticeWizard)

/* =============================================================================
 * About this class
 * =============================================================================
 * Does things with JSON.
 */


using System.Text.Json;

namespace MAWSC.Du
{
    internal class WithJson
    {
        public static void SerializeToMinimizedFile<T>(T obj, string jsonFilePath)
        {
            var jsonString = JsonSerializer.Serialize(obj);

            File.WriteAllText(jsonFilePath, jsonString);
        }

        public static void SerializeToIndentedFile<T>(T obj, string jsonFilePath)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var jsonString = JsonSerializer.Serialize(obj, jsonOptions);

            File.WriteAllText(jsonFilePath, jsonString);
        }



        /// <summary>Serialize a file into a dynamic object.</summary>
        /// <param name="configFilePath">The path to the configuration file to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeFile<YourObject>(configFilePath)</c>
        /// </example>
        /// <returns>The contents of the configuration file as an object.</returns>
        public static T SerializeFile<T>(string jsonFormattedFilePath)
        {
            var jsonString = File.ReadAllText(jsonFormattedFilePath);
            T J = JsonSerializer.Deserialize<T>(jsonString);
            T jsonObject   = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

        /// <summary>Serialize a JSON string into a dynamic object.</summary>
        /// <param name="jsonString">The string to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeString<YourObject>(jsonString)</c>
        /// </example>
        /// <returns>The contents of the JSON string as an object.</returns>
        public static T SerializeString<T>(string jsonString)
        {
            T jsonObject = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

        /// <summary>Serialize a file into a dynamic object.</summary>
        /// <param name="configFilePath">The path to the configuration file to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeFile<YourObject>(configFilePath)</c>
        /// </example>
        /// <returns>The contents of the configuration file as an object.</returns>
        public static T DeserializeFile<T>(string jsonFormattedFilePath)
        {



            var jsonString = File.ReadAllText(jsonFormattedFilePath);
            T jsonObject = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

        /// <summary>Serialize a JSON string into a dynamic object.</summary>
        /// <param name="jsonString">The string to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeString<YourObject>(jsonString)</c>
        /// </example>
        /// <returns>The contents of the JSON string as an object.</returns>
        public static T DeserializeString<T>(string jsonString)
        {
            T jsonObject = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

    }
}
