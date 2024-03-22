using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.FileSystem
{
    public class Logger
    {
       
        private readonly string logFilePath;

        public Logger()
        {

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            logFilePath = $"Logs_{currentDate}.txt";
        }

        public async Task LogAsync(string methodName, bool success)
        {
            string outcome = success ? "success" : "failure";
            string logMessage = $"{DateTime.Now} - Method: {methodName}, Outcome: {outcome}\n";

            await WriteLogAsync(logMessage);
        }

        private async Task WriteLogAsync(string logMessage)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                        writer.WriteLine(logMessage);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

        public async Task ReadLogAsync()
        {
            try
            {

                if (File.Exists(logFilePath))
                {
                    using (StreamReader reader = File.OpenText(logFilePath))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Log file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading log file: {ex.Message}");
            }
        }

    }


}