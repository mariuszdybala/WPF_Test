using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Janek.Tools
{

  public class MyCommand:ICommand
  {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
 
        public event EventHandler CanExecuteChanged;
 
        public MyCommand(Action<object> execute) 
                       : this(execute, null)
        {
        }

        public MyCommand(Action<object> execute, 
                       Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
 
        public  bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
 
            return _canExecute(parameter);
        }
 
        public  void Execute(object parameter)
        {
            _execute(parameter);
        }
 
        public void RaiseCanExecuteChanged()
        {
            if( CanExecuteChanged != null )
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
  }
}
