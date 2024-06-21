namespace json_to_csv_myconvert
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using CsvHelper;
    using CsvHelper.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Globalization;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            // Path to the JSON file
            string jsonFilePath = "D:\\PROJECT\\MIB\\Perben-2024\\work\\maintainability-low-p4.json";

            // Path to the output CSV file
            string csvFilePath = "D:\\PROJECT\\MIB\\Perben-2024\\work\\output.csv";

            StringBuilder sb = new StringBuilder();

            // Read JSON file into a string
            var jsonData = File.ReadAllText(jsonFilePath);

            // Parse JSON data
            JObject jsonObject = JObject.Parse(jsonData);

            JArray arrayOfIssue = (JArray)jsonObject["issues"];
            Console.WriteLine($"Amount of Issues: {arrayOfIssue.Count}");

            foreach (var issue in arrayOfIssue)
            {
                string key = issue["key"].ToString();
                // Console.WriteLine($"key: {key}");
                sb.Append($"{key}||");

                string rule = issue["rule"].ToString();
                // Console.WriteLine($"rule: {rule}");
                sb.Append($"{rule}||");

                string severity = issue["severity"].ToString();
                // Console.WriteLine($"severity: {severity}");
                sb.Append($"{severity}||");

                string component = issue["component"].ToString();
                // Console.WriteLine($"component: {component}");
                sb.Append($"{component}||");

                string project = issue["project"].ToString();
                // Console.WriteLine($"project: {project}");
                sb.Append($"{project}||");

                if (issue["hash"] != null)
                {
                    string hash = issue["hash"].ToString();
                    // Console.WriteLine($"hash: {hash}");
                    sb.Append($"{hash}||");
                }
                else
                {
                    sb.Append("||");
                }

                JObject textRange = (JObject)issue["textRange"];
                if (textRange != null)
                {
                    int textRangeStartLine = (int)textRange["startLine"];
                    // Console.WriteLine($"textRangeStartLine: {textRangeStartLine}");
                    sb.Append($"{textRangeStartLine}||");

                    int textRangeEndLine = (int)textRange["endLine"];
                    // Console.WriteLine($"textRangeEndLine: {textRangeEndLine}");
                    sb.Append($"{textRangeEndLine}||");

                    int textRangeStartOffset = (int)textRange["startOffset"];
                    // Console.WriteLine($"textRangeStartOffset: {textRangeStartOffset}");
                    sb.Append($"{textRangeStartOffset}||");

                    int textRangeEndOffset = (int)textRange["endOffset"];
                    // Console.WriteLine($"textRangeEndOffset: {textRangeEndOffset}");
                    sb.Append($"{textRangeEndOffset}||");
                }
                else
                {
                    sb.Append("||||||||");
                }

                /***
                JArray arrayOfFlows = (JArray)issue["flows"];
                foreach (var flow in arrayOfFlows)
                {
                    JArray arrayOfFlowLocations = (JArray)flow["locations"];
                    foreach (var location in arrayOfFlowLocations)
                    {
                        string flowLocationComponent = location["component"].ToString();
                        Console.WriteLine($"flowLocationComponent: {flowLocationComponent}");

                        JObject flowLocationTextRange = (JObject)issue["textRange"];
                        if (flowLocationTextRange != null)
                        {
                            int flowLocationTextRangeStartLine = (int)flowLocationTextRange["startLine"];
                            Console.WriteLine($"flowLocationTextRangeStartLine: {flowLocationTextRangeStartLine}");

                            int flowLocationTextRangeEndLine = (int)flowLocationTextRange["endLine"];
                            Console.WriteLine($"flowLocationTextRangeEndLine: {flowLocationTextRangeEndLine}");

                            int flowLocationTextRangeStartOffset = (int)flowLocationTextRange["startOffset"];
                            Console.WriteLine($"flowLocationTextRangeStartOffset: {flowLocationTextRangeStartOffset}");

                            int flowLocationTextRangeEndOffset = (int)flowLocationTextRange["endOffset"];
                            Console.WriteLine($"flowLocationTextRangeEndOffset: {flowLocationTextRangeEndOffset}");
                        }

                        string flowLocationMsg = location["msg"].ToString();
                        Console.WriteLine($"flowLocationMsg: {flowLocationMsg}");
                    }
                }
                ***/

                string status = issue["status"].ToString();
                // Console.WriteLine($"status: {status}");
                sb.Append($"{status}||");

                string message = issue["message"].ToString();
                // Console.WriteLine($"message: {message}");
                sb.Append($"{message}||");

                string effort = issue["effort"].ToString();
                // Console.WriteLine($"effort: {effort}");
                sb.Append($"{effort}||");

                string debt = issue["debt"].ToString();
                // Console.WriteLine($"debt: {debt}");
                sb.Append($"{debt}||");

                string author = issue["author"].ToString();
                // Console.WriteLine($"author: {author}");
                sb.Append($"{author}||");

                string tags = issue["tags"].ToString();
                // Console.WriteLine($"tags: {tags}");
                // Console.Write($"{tags};");

                string creationDate = issue["creationDate"].ToString();
                // Console.WriteLine($"creationDate: {creationDate}");
                sb.Append($"{creationDate}||");

                string updateDate = issue["updateDate"].ToString();
                // Console.WriteLine($"updateDate: {updateDate}");
                sb.Append($"{updateDate}||");

                string type = issue["type"].ToString();
                // Console.WriteLine($"type: {type}");
                sb.Append($"{type}||");

                string organization = issue["organization"].ToString();
                // Console.WriteLine($"organization: {organization}");
                sb.Append($"{organization}||");

                string cleanCodeAttribute = issue["cleanCodeAttribute"].ToString();
                // Console.WriteLine($"cleanCodeAttribute: {cleanCodeAttribute}");
                sb.Append($"{cleanCodeAttribute}||");

                string cleanCodeAttributeCategory = issue["cleanCodeAttributeCategory"].ToString();
                // Console.WriteLine($"cleanCodeAttributeCategory: {cleanCodeAttributeCategory}");
                sb.Append($"{cleanCodeAttributeCategory}||");

                /***
                JArray arrayOfImpacts = (JArray)issue["impacts"];
                foreach (var impact in arrayOfImpacts)
                {
                    string softwareQuality = (string)impact["softwareQuality"];
                    // Console.WriteLine($"softwareQuality: {softwareQuality}");
                    sb.Append($"{softwareQuality};");

                    string impactSeverity = (string)impact["severity"];
                    // Console.WriteLine($"impactSeverity: {impactSeverity}");
                    sb.Append($"{impactSeverity};");
                }
                ***/

                sb.AppendLine();

                // Console.WriteLine();
            }

            File.WriteAllText(csvFilePath, sb.ToString());

            /*
            // Define a list to hold the flattened data
            var records = new List<FlattenedRecord>();

            // Process each item in the JSON array
            foreach (var item in jsonArray)
            {
                FlattenJson(item, records);
            }

            // Write the flattened data to the CSV file
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(records);
            }
            */

            Console.WriteLine("Data has been written to " + csvFilePath);
        }

        // Recursive function to flatten JSON and add to the list
        static void FlattenJson(JToken token, List<FlattenedRecord> records, string parentKey = "")
        {
            if (token is JObject)
            {
                foreach (var property in token.Children<JProperty>())
                {
                    string key = string.IsNullOrEmpty(parentKey) ? property.Name : parentKey + "." + property.Name;
                    FlattenJson(property.Value, records, key);
                }
            }
            else if (token is JArray)
            {
                int index = 0;
                foreach (var item in token.Children())
                {
                    FlattenJson(item, records, parentKey + "[" + index + "]");
                    index++;
                }
            }
            else
            {
                records.Add(new FlattenedRecord
                {
                    Key = parentKey,
                    Value = token.ToString()
                });
            }
        }
    }

    public class FlattenedRecord
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
