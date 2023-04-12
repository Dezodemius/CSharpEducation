using System.IO.Pipes;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Newtonsoft.Json;

namespace MyLogger
{
    // This logger will derive from the Microsoft.Build.Utilities.Logger class,
    // which provides it with getters and setters for Verbosity and Parameters,
    // and a default empty Shutdown() implementation.
    public class BasicFileLogger : Logger
    {
        private NamedPipeServerStream serverStream;
        private StreamWriter binaryWriter;
        /// <summary>
        /// Initialize is guaranteed to be called by MSBuild at the start of the build
        /// before any events are raised.
        /// </summary>
        public override void Initialize(IEventSource eventSource)
        {
            Console.WriteLine($"Hello!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! {DateTime.Now}");
            serverStream = new NamedPipeServerStream("kek");
            serverStream.WaitForConnection();
            Console.WriteLine($"Hello222222222222222222222222222222222222222222222 {DateTime.Now}");
            binaryWriter = new StreamWriter(serverStream);
            // eventSource.ProjectStarted += EventSourceOnAnyEventRaised;
            // eventSource.ProjectFinished += EventSourceOnAnyEventRaised;
            eventSource.StatusEventRaised += EventSourceOnAnyEventRaised;
        }

        private void EventSourceOnAnyEventRaised(object sender, ProjectFinishedEventArgs e)
        {
            binaryWriter.WriteLine("Project Finished: " + JsonConvert.SerializeObject(e));
            binaryWriter.WriteLine();
        }
        private void EventSourceOnAnyEventRaised(object sender, BuildStatusEventArgs e)
        {
            binaryWriter.WriteLine("Status: " + JsonConvert.SerializeObject(e));
            binaryWriter.WriteLine();
        }

        private void EventSourceOnAnyEventRaised(object sender, ProjectStartedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.TargetNames))
            {
                binaryWriter.WriteLine("Project Started: " + JsonConvert.SerializeObject(e));
            }
        }

        public override void Shutdown()
        {
            base.Shutdown();

            binaryWriter.Close();
            serverStream.Close();
        }

    }
}