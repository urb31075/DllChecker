﻿using System;
using System.Text;

namespace DllChecker
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    internal class MsBuild
    {
        public delegate void OutMessage(string message);

        public Task<bool> Execute(string msbuildPath, string prjFile, string commandLine, OutMessage outMessage)
        {

            var t = Task.Run(
                () =>
                {
                    outMessage?.Invoke($"Execute: {msbuildPath}");
                    outMessage?.Invoke($"Project: {commandLine}");
                    outMessage?.Invoke($"CommandLine: {commandLine}");
                    try
                    {
                        var process = new Process
                        {
                            StartInfo =
                                 {
                                     FileName = msbuildPath,
                                     Arguments = $"{prjFile} {commandLine}",
                                     RedirectStandardOutput = true,
                                     RedirectStandardError = true,
                                     UseShellExecute = false,
                                     CreateNoWindow = true
                                 },
                            EnableRaisingEvents = true
                        };

                        outMessage?.Invoke($"Start! at {DateTime.Now.ToShortTimeString()}");

                        var targetCodePage = Encoding.GetEncoding("CP866").CodePage;
                        process.Start();
                        var outputCodePage = process.StandardOutput.CurrentEncoding.CodePage;

                        var startTime = DateTime.Now;
                        var returnResult = false;
                        while (true)
                        {
                            var output = process.StandardOutput.ReadLine();
                            if (output != null)
                            {
                                var convertResult = ConvertCodePage(output, outputCodePage, targetCodePage);
                                outMessage?.Invoke(convertResult);
                            }

                            if (process.HasExited)
                            {
                                outMessage?.Invoke($"ExitCode: {process.ExitCode}");
                                returnResult = true;
                                break;
                            }

                            if (DateTime.Now - startTime > TimeSpan.FromSeconds(10 * 60))
                            {
                                outMessage?.Invoke("Exit by timeout!");
                                break;
                            }
                        }
                        process.Close();
                        return returnResult;
                    }
                    catch (Exception ex)
                    {
                        outMessage?.Invoke("Error!: " + ex.Message);
                        outMessage?.Invoke("Error!: " + ex.StackTrace);
                        return false;
                    }
                });
            return t;
        }


        private static string ConvertCodePage(string str, int strCodePage, int targetCodePage)
        {
            //Encoding.GetEncoding(targetCodePage).GetString(Encoding.GetEncoding(strCodePage).GetBytes(str));
            var bytes = Encoding.GetEncoding(strCodePage).GetBytes(str);
            var res = Encoding.GetEncoding(targetCodePage).GetString(bytes);
            return res;
        }
    }
}
