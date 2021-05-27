using System;
using System.Windows.Forms;
using System.Diagnostics;


namespace ThreeHost
{
    static class Program
    {
		static public Sherpa.HttpServer app_server = null;
		static public Sherpa.HttpServer content_server = null;

		static public Timer progtime = new Timer();

		static void logfunc(string s)
		{
			Trace.Write(s);
		}

		[STAThread]
        static void Main()
        {
			app_server = new Sherpa.HttpServer(Sherpa.HttpServer.defaultPort);
			app_server.SetLogFunc(logfunc);

			content_server = new Sherpa.HttpServer(Sherpa.HttpServer.defaultPort + 1);
			content_server.SetLogFunc(logfunc);

			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			BrowserForm form = new BrowserForm();

			Application.Run(form);

			form.DumpSettings();

			app_server.Dispose();
			content_server.Dispose();
		}
	}
}
