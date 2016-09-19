using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GCRebuilder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length > 1)
            {
                try
                {
                    MainForm mf = new GCRebuilder.MainForm(args);

                    if (mf.IsImagePath(args[0]))
                    {
                        if (args.Length == 4)
                        {
                            mf.ImageOpen(args[0]);
                            mf.SetSelectedNode(args[1]);
                            if (args[2].Equals("e"))
                                mf.Export(args[3]);
                            else if (args[2].Equals("i"))
                                mf.Import(args[3]);
                            else
                                Usage();
                        }
                        else
                        {
                            Usage();
                        }
                    }
                    else if (mf.IsRootPath(args[0]))
                    {
                        if (args.Length == 2)
                        {
                            mf.RootOpen(args[0]);
                            mf.Rebuild(args[1]);
                        }
                        else
                        {
                            Usage();
                        }
                    }
                    else
                    {
                        Usage();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    return ex.HResult;
                }
            }
            else if ((args.Length == 1) && (args[0].Equals("help")))
            {
                Usage();
            }
            else
            {
                ShowWindow(GetConsoleWindow(), 0);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(args));
            }

            return 0;
        }

        static void Usage()
        {
            Console.WriteLine("iso_path [node_path e|i file_or_folder]");
            Console.WriteLine("root_path [iso_path]");
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
