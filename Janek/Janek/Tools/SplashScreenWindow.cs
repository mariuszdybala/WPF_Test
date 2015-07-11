using Janek.Animation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Janek.Tools
{
    public class SplashScreenWindow
    {
        BackgroundWorker worker;
        Action mainThreadMethod;
        LoadingWindow splashscreen;
        IEnabled window;

        public SplashScreenWindow()
        {
            splashscreen = new LoadingWindow();
        }

        public void StartMethod(IEnabled _window, Action _mainThreadMethod)
        {
            window = _window;
            mainThreadMethod = _mainThreadMethod;
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            window.SetEnableWindow = false;
            splashscreen.Show();
           worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            splashscreen.Hide();
            window.SetEnableWindow = true;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            mainThreadMethod();
        }

    }
}
