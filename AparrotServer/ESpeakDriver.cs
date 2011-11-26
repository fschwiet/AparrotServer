using System;
using System.IO;

namespace AparrotServer
{
    class ESpeakDriver : ProcessDriver
    {
        public byte[] Run(string parameters)
        {
            var espeakFilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Settings.Default.ESpeakFilepath);
            var exe = Path.GetFullPath(Path.Combine(espeakFilepath, "command_line\\espeak.exe"));

            var outputFile = Path.GetTempFileName();

            try
            {
                base.StartProcess(exe, "-w \"" + outputFile + "\" " + parameters);

                base._process.WaitForExit(3000);

                base.Shutdown();

                return File.ReadAllBytes(outputFile);
            }
            finally
            {
                File.Delete(outputFile);
            }
        }
    }
}