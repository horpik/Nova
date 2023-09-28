using System.Windows.Input;


namespace Word_helper.Src.ViewModels
{
    class CreateDocumentsViewModel : ViewModelBase
    {
        public ICommand CreateDocumentsCommand { get; }

        public CreateDocumentsViewModel(ICommand CreateDocumentsCommand)
        {
            this.CreateDocumentsCommand = CreateDocumentsCommand;
        }
    }
}
