using System;
using System.Collections.Generic;
using System.Text;
using Suder.Tools.Forms;
using System.Windows.Forms;
using Suder.Tools.ELogger;
using System.Threading;
using System.Drawing;

namespace Suder.Tools.Utilities
{
    public class ProgressManager
    {
        static Dictionary<int, ProgressManager> dictInstances;

        static ProgressManager()
        {
            dictInstances = new Dictionary<int, ProgressManager>();
        }

        Thread threadWin;

        ProgressForm pformWait;
        
        ProgressManager(string pText)
        {
            pformWait = new ProgressForm(pText);
            threadWin = new Thread(RunWin);
        }

        
        public static int StartExecuting()
        {
            return StartExecuting(STANDARD_INFO);
        }

        public static int StartExecuting(string pText)
        {
            object o = new object();
            lock (o)
            {
                int _iID = (int)(DateTime.Now.ToBinary() % 1234567890);
                try
                {
                    if (dictInstances.ContainsKey(_iID))
                    {
                        return -1;
                    }

                    ProgressManager pm = new ProgressManager(pText);
                    dictInstances.Add(_iID, pm);
                    pm.threadWin.Start();
                    return _iID;
                }
                catch 
                {
                    return -1;
                }
            }
        }

        public static bool Contains(int pId)
        {
            object o = new object();
            lock (o)
            {
                try
                {
                    return dictInstances.ContainsKey(pId);
                }
                catch (Exception ex)
                {
                    ELog.LogHidden(ex, ErrorCodes.RT_BLAD_WIELOWATKOWOSCI, ELogLevel.Error, "ProgressManager");
                    return true;
                }
            }
        }

        #region to do

        ///// <summary>
        ///// Czekanie zaczyna się od nowa
        ///// </summary>
        ///// <param name="pId">Identyfikator wątku</param>
        //public static void RestartExecuting(string pId)
        //{
            
        //}

        ///// <summary>
        ///// Czekanie zatrzymuje się do czasu wznowienia
        ///// </summary>
        ///// <param name="pId">Identyfikator wątku</param>
        //public static void PauseExecuting(string pId)
        //{

        //}

        ///// <summary>
        ///// Wznowienie zatrzymanego czekania
        ///// </summary>
        ///// <param name="pId">Identyfikator wątku</param>
        //public static void ResumeExecuting(string pId)
        //{

        //}

#endregion


        /// <summary>
        /// Kończy czekanie - wywoływać raczej w sekcji finally
        /// </summary>
        /// <param name="pId">Identyfikator wątku</param>
        public static void StopExecuting(int pId)
        {
            object o = new object();
            lock (o)
            {
                try
                {
                    if (!dictInstances.ContainsKey(pId))
                    {
                        //ELog.LogHidden("Brak podanego klucza - identyfikatora: " + pId, ErrorCodes.RT_BLAD_OBSLUGI_KONTENERA, ELogLevel.Error, "ProgressManager");
                        return;
                    }
                    dictInstances[pId].pformWait.CloseForm = true;
                    dictInstances.Remove(pId);                    
                }
                catch (Exception ex)
                {
                    ELog.LogHidden(ex, ErrorCodes.RT_BLAD_WIELOWATKOWOSCI, ELogLevel.Error, "ProgressManager");
                }
            }
        }

        void RunWin()
        {
            try
            {
                //Form f = Form.ActiveForm;
                Rectangle _rtg;
                //if (f != null && f is IMultipleMonitorForm)
                //    _rtg = (f as IMultipleMonitorForm).GetWorkingArea();
                //else
                    _rtg = SystemInformation.WorkingArea;
                pformWait.Location = new Point(_rtg.X + _rtg.Width / 2 - pformWait.Width / 2,_rtg.Y + _rtg.Height / 2 - pformWait.Height * 2);
                //pformWait.Location = new Point(_rtg.Width / 2 - pformWait.Width / 2, _rtg.Height / 2 - pformWait.Height * 2);
                //Form _f = Form.ActiveForm;
                //if (_f != null)
                //    if (_f.InvokeRequired)
                //        _f.Invoke(new ShowDialogInvoker(ShowDialogMethod), _f);
                //    else
                //        this.pformWait.ShowDialog(_f);
                //else
                    this.pformWait.ShowDialog();
            }
            catch (Exception ex)
            {
                ELog.LogHidden(ex, ErrorCodes.RT_BLAD_WIELOWATKOWOSCI, ELogLevel.Error, this);
            }
        }

        //delegate void ShowDialogInvoker(Form pForm);

        //void ShowDialogMethod(Form pForm)
        //{
        //    this.pformWait.ShowDialog(pForm);
        //}

        static readonly string STANDARD_INFO = "Trwa przetwarzanie danych dla aplikacji, proszę czekać.";            
    }
}
