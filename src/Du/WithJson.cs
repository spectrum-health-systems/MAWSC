// =============================================================================
// DU
// A library for .NET C#
// https://github.com/aprettycoolprogram/du)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2016-2022 A Pretty Cool Program
// =============================================================================

// Du.WithJson.cs
// Does things with JSON
// v0.99.0.0-220523.075036 (standalone version for MAWSC 1.2)

using System.Text.Json;

namespace MAWSC.Du
{
    internal class WithJson
    {
        internal static void SerializeToMinimizedFile<T>(T obj, string jsonFilePath)
        {
            // Not tested as of 5-10-22

            var jsonString = JsonSerializer.Serialize(obj);

            File.WriteAllText(jsonFilePath, jsonString);
        }

        internal static void SerializeToIndentedFile<T>(T obj, string jsonFilePath)
        {
            // Tested 5-10-22 (ApprenticeWizard)

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var jsonString = JsonSerializer.Serialize(obj, jsonOptions);

            File.WriteAllText(jsonFilePath, jsonString);
        }

        internal static T DeserializeFromFile<T>(string filePath)
        {
            // Not tested as of 5-10-22

            var jsonString = File.ReadAllText(filePath);

            //T J = JsonSerializer.Deserialize<T>(jsonString);
            T jsonObject   = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

        ///////// <summary>Serialize a file into a dynamic object.</summary>
        ///////// <param name="configFilePath">The path to the configuration file to serialize.</param>
        ///////// <example>
        ///////// <c>DuJson.SerializeFile<YourObject>(configFilePath)</c>
        ///////// </example>
        ///////// <returns>The contents of the configuration file as an object.</returns>
        //////public static T SerializeFile<T>(string jsonFormattedFilePath)
        //////{
        //////    // Not tested as of 5-10-22

        //////    var jsonString = File.ReadAllText(jsonFormattedFilePath);
        //////    T J = JsonSerializer.Deserialize<T>(jsonString);
        //////    T jsonObject   = JsonSerializer.Deserialize<T>(jsonString);

        //////    return (T)Convert.ChangeType(jsonObject, typeof(T));
        //////}

        /// <summary>Serialize a JSON string into a dynamic object.</summary>
        /// <param name="jsonString">The string to serialize.</param>
        /// <example>
        /// <c>DuJson.SerializeString<YourObject>(jsonString)</c>
        /// </example>
        /// <returns>The contents of the JSON string as an object.</returns>
        public static T SerializeString<T>(string jsonString)
        {
            // Not tested as of 5-10-22

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
            // Not tested as of 5-10-22

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
            // Not tested as of 5-10-22

            T jsonObject = JsonSerializer.Deserialize<T>(jsonString);

            return (T)Convert.ChangeType(jsonObject, typeof(T));
        }

    }
}
