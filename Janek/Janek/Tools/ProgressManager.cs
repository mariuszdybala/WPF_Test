using Janek.Animation;
using Janek.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Janek.Tools
{
    public class ProgressManager
    {
        static Dictionary<int, ProgressManager> dictInstances;
        LoadingWindow window;
        //TEst window;
        Thread threadWin;

        static ProgressManager()
        {
            dictInstances = new Dictionary<int, ProgressManager>();
        }

        ProgressManager()
        {
          
           // 
          //  window = new TEst();
            threadWin = new Thread(Run);
        }

        private void Run()
        {
             window = new LoadingWindow();

            window.ShowDialog();
            window.Closed += (sender, e) => window.Dispatcher.InvokeShutdown();
            System.Windows.Threading.Dispatcher.Run();
            
        }

        static public int StartProgressManager()
        {
            object o = new object();
            lock (o)
            {
                int _iID = (int)(DateTime.Now.ToBinary() % 1234567890);
                try
                {
                    ProgressManager pm = new ProgressManager();
                    dictInstances.Add(_iID, pm);
                    pm.threadWin.SetApartmentState(ApartmentState.STA);
                    pm.threadWin.IsBackground = true;
                    pm.threadWin.Start();
                    return _iID;
                }
                catch
                {
                    return -1;
                }
            }

        }
        public static void StopExecuting(int pId)
        {
            object o = new object();
            lock (o)
            {
                try
                {
                    if (!dictInstances.ContainsKey(pId))
                    {
                        return;
                    }
                    //dictInstances[pId].window.Dispatcher.InvokeShutdown();
                    dictInstances[pId].threadWin.Abort();
                    dictInstances.Remove(pId);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
