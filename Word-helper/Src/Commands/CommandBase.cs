﻿using System;
using System.Windows.Input;

namespace Word_helper.Src.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler ?CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
