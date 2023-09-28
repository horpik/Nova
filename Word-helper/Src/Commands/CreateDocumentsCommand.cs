using Serilog;
using System;
using System.Windows;

namespace Word_helper.Src.Commands
{
    class CreateDocumentsCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show("Successfully create docs.", "Done", MessageBoxButton.OK);
        }
    }
}
