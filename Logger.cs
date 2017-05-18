using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Shauni.TracingV2
{
    using System.Diagnostics;
    using Shauni.TracingV1;

    public class Tracer : Logger
    {
        public Tracer()
        {
            string folder = Directory.GetParent(loggerDir).ToString();
            loggerDir = Path.Combine(folder, "Trace.txt");

            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener(loggerDir));
        }
        /// <summary>
        /// Appends a specified Log to the default logger file and then flushes the output buffer.
        /// </summary>
        /// <param name="message">The message contained in the listener.</param>
        /// <param name="seriousness">The seriousness of the log.</param>
        public override void Append(string message, int seriousness = 0)
        {
            if (!Shauni.Properties.Settings.Default.LoggerEnabled)
                return;

            Log log = new Log() { Message = message, Seriousness = seriousness };
            log.Date = DateTime.Now;

            String voice = log.Seriousness.ToString().InBrackets() + ' ' + log.Date.ToString().InBrackets(Bracket.Brace) + ": \"" + log.Message + '"';

            Trace.WriteLine(voice);        
            Trace.Close();
        }

        public override void Read()
        {
            base.Read();
        }
    }
}

namespace Shauni.TracingV1
{
    public delegate void LogLoadedEventhandler(object sender, LogLoadedCancelEventArgs e);

    /// <summary>
    /// Tries to monitor the application.
    /// </summary>
    public class Logger
    {
        private Thread worker = null;
        private volatile bool cancel = false;
        public string loggerDir = Path.Combine(Paths.Log, "Logger.txt");

        private ManualResetEvent trigger = new ManualResetEvent(true); //Notifica a uno o più thread in attesa che si è verificato un evento.

        public event EventHandler OperationStarted;
        public event EventHandler OperationCompleted;
        public event LogLoadedEventhandler LogLoaded;

        public String Dir { get { return this.loggerDir; } }

        public Logger()
        {
        }

        public virtual void Append(String message, int seriousness = 0)
        {
            if (!Shauni.Properties.Settings.Default.LoggerEnabled)
                return;

            worker = new Thread(delegate()
                { StartAppend(new Log() { Message = message, Seriousness = seriousness }); });
            worker.Start();
        }

        public virtual void Read()
        {
            worker = new Thread(delegate() {StartRead(); });
            worker.Start();
        }

        private void StartRead()
        {
            this.trigger.WaitOne();
            this.InitializeLoading();

            using (StreamReader reader = new StreamReader(loggerDir))
            {
                String line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (String.IsNullOrWhiteSpace(line))
                        continue;

                    Log log = Log.Parse(line);

                    LogLoadedCancelEventArgs lac = new LogLoadedCancelEventArgs(log);
                    this.OnLogLoaded(lac);
                    this.cancel = lac.Cancel;

                    if (cancel)
                        return;
                }
            }

            this.FinalizeLoading();
        }

        private void StartAppend(object logs)
        {
            if (!Directory.Exists(Paths.Log))
                Directory.CreateDirectory(Paths.Log);
            if (!File.Exists(loggerDir))
                File.Create(loggerDir).Dispose();

            Log log = (Log)logs;

            StreamWriter stream = new StreamWriter(loggerDir, true);

            String offset = String.Empty;
            offset = String.IsNullOrWhiteSpace(stream.ToString()) ? String.Empty : @"\n";

            stream.WriteLine(offset + log.Seriousness.ToString().InBrackets() + ' ' + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").InBrackets(Bracket.Brace) + ": \"" + log.Message + '"');
            stream.Close();

            log.Date = DateTime.Now;
        }

        /// <summary>
        /// Makes the worker thread wait on the ManualResetEvent.
        /// </summary>
        public void Pause()
        {
            this.trigger.Reset();
        }

        /// <summary>
        /// Signal the worker thread, raise signal on the ManualResetEvent.
        /// </summary>
        public void Resume()
        {
            this.trigger.Set();
        }

        private void FinalizeLoading()
        {
            if (OperationCompleted != null)
                OperationCompleted(this, EventArgs.Empty);
        }

        private void InitializeLoading()
        {
            if (OperationStarted != null)
                OperationStarted(this, EventArgs.Empty);
        }

        protected virtual void OnLogLoaded(LogLoadedCancelEventArgs e)
        {
            if (LogLoaded != null)
                LogLoaded(this, e);
        }
    }
    /// <summary>
    /// Represents a Log object.
    /// </summary>
    public struct Log
    {
        private static Regex pattern = new Regex(@"(?x) \( (\d{1}) \) \s {([^{]*?)}\:\s ("" .*? "")");
        /// <summary>
        /// Gets or sets the Seriousness of the log.
        /// </summary>
        public int Seriousness { get; set; }
        /// <summary>
        /// Gets or sets the Inner Message of the log.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the instant in time, expressed in date, of the output log.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Converts the string representation of a Log (for example: "(0) {03/10/2012 21.55.01}: "Message Log") to its Log object equivalent.
        /// </summary>
        /// <param name="line">The string log representation.</param>
        public static Log Parse(string line)
        {
            Match match = pattern.Match(line);
            if (!match.Success)
                throw new Exception();

            Log log = new Log();

            log.Seriousness = int.Parse(match.Groups[1].Value);
            log.Date = DateTime.ParseExact(match.Groups[2].Value, "dd/MM/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            log.Message = match.Groups[3].Value.Substring(1, match.Groups[3].Value.Length - 2);

            return log;
        }
    }

    /// <summary>
    /// Cancellable EventArgs, that also exposes current Log to UI.
    /// </summary>
    public class LogLoadedCancelEventArgs : System.ComponentModel.CancelEventArgs
    {
        /// <summary>
        /// Gets the current Log.
        /// </summary>
        public Log Log { get; private set; }

        public LogLoadedCancelEventArgs(Log log)
        {
            this.Log = log;
        }
    }
}
