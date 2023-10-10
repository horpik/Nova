using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Nova.Commands;
using Nova.Models;
using Nova.Services;
using Nova.Stores;

namespace Nova.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private const string DirectoryPath = @"..\..\Resources\Replacement documents\";
        public ICommand CreateFilesCommand { get; }
        private int _countSelectedFiles;

        public int CountSelectedFiles
        {
            get => _countSelectedFiles;
            set
            {
                _countSelectedFiles = value;
                OnPropertyChanged(nameof(CountSelectedFiles));
            }
        }


        public HomeViewModel(FilesStore filesStore, TagDataStore tagDataStore,
            INavigationService navigationService)
        {
            List<FileItem> fileItems;
            if (filesStore.FileItems == null)
            {
                fileItems = GenerateFilesList();

                filesStore.FileItems = fileItems;
            }
            else
            {
                fileItems = new List<FileItem>(filesStore.FileItems);
            }

            if (tagDataStore.TagDataEntry == null)
            {
                tagDataStore.TagDataEntry = GenerateTagData();
            }


            CountSelectedFiles = GetSelectedFilesCount(fileItems);
            CreateFilesCommand = new CreateFilesCommand(filesStore, tagDataStore);
        }

        private int GetSelectedFilesCount(List<FileItem> fileItems) => fileItems.Count(file => file.IsSelected);


        private List<FileItem> GenerateFilesList()
        {
            var directoryInfo = new DirectoryInfo(DirectoryPath);

            var files = directoryInfo.GetFiles();

            var fileItems = new List<FileItem>();

            foreach (var file in files)
            {
                if (file.Name.Split('.').Contains("docx"))
                {
                    fileItems.Add(new FileItem(file.Name, file.DirectoryName));
                }
            }

            return fileItems;
        }

        private List<TagData> GenerateTagData()
        {
            List<TagData> tagDataList = new List<TagData>();
            tagDataList.Add(new TagData("Название компании", "<CompanyName>"));
            tagDataList.Add(new TagData("Полное название продукта", "<FullProductName>"));
            tagDataList.Add(new TagData("Название продукта", "<ProductName>"));
            tagDataList.Add(new TagData("Тип продукта кратко ПО/ППО/СПО", "<ProductTypeReduction>"));
            tagDataList.Add(new TagData("Тип продукта именительный падеж", "<ProductTypeNC>"));
            tagDataList.Add(new TagData("Тип продукта  родительский падеж", "<ProductTypePaC>"));
            tagDataList.Add(new TagData("Тип продукта предложный падеж", "<ProductTypePrC>"));
            tagDataList.Add(new TagData("Тип продукта творительный падеж", "<ProductTypeCrC>"));
            tagDataList.Add(new TagData("Децимальный номер", "<DecimalNumber>"));
            tagDataList.Add(new TagData("Дополнительное сокращение", "<AdditionalReduction>"));
            tagDataList.Add(new TagData("Дополнительное сокращение полное", "<AdditionalReductionExplanation>"));
            tagDataList.Add(new TagData("Предприятие-изготовитель", "<ManufacturingCompany>"));
            tagDataList.Add(new TagData("Предприятие-разработчик", "<DeveloperCompany>"));
            tagDataList.Add(new TagData("Название предприятия разработчика", "<DeveloperCompanyName>"));
            tagDataList.Add(new TagData("Название предприятия разработчика расшифровка", "<DeveloperCompanyNameDecoding>"));
            tagDataList.Add(new TagData("Лицензия на деятельность по технической защите конфиденциальной информации", "<LicenseForTechnicalProtectionCI>"));
            tagDataList.Add(new TagData("Лицензия на деятельность по разработке и (или) производству средств защиты конфиденциальной информации", "<LicenseDevelopmentProtectingCI>"));
            tagDataList.Add(new TagData("Описание продукта", "<ProductDescription>"));
            tagDataList.Add(new TagData("Идентификация и аутентификация субъектов доступа и объектов доступа", "<IAO>"));
            tagDataList.Add(new TagData("Управление доступом субъектов доступа к объектам доступа", "<ACO>"));
            tagDataList.Add(new TagData("Управление доступом субъектов доступа к объектам доступа", "<RSE>"));
            tagDataList.Add(new TagData("Класс защищённости", "<SecurityClass>"));
            tagDataList.Add(new TagData("Уровень защищённости", "<SecurityLevel>"));
            tagDataList.Add(new TagData("На каком сервере размещается", "<ApplicationServer>"));
            tagDataList.Add(new TagData("В какой субд хранится", "<DBMSDataStorage>"));
            tagDataList.Add(new TagData("Тип организации полностью", "<TypeOrganizationFull>"));
            tagDataList.Add(new TagData("Тип организации кратко", "<TypeOrganizationShort>"));
            tagDataList.Add(new TagData("Адрес", "<Address>"));
            tagDataList.Add(new TagData("Сайт", "<Website>"));
            tagDataList.Add(new TagData("Год", "<Year>"));
            return tagDataList;
        }
    }
}