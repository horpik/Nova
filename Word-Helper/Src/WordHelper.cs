using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MicrosoftWord = Microsoft.Office.Interop.Word;

namespace Word
{
    public class WordHelper
    {
        private readonly MicrosoftWord.Application _app = new MicrosoftWord.Application();

        public int CreateDocs(List<string> filePaths, Dictionary<string, string> items)
        {
            if (filePaths == null)
            {
                throw new ArgumentException("Переданный в конструктор список является null");
            }

            if (filePaths.Count > 100)
            {
                throw new ArgumentException("Переданный в конструктор список слишком большой");
            }

            foreach (var filePath in filePaths.Where(filePath => !FileExists(filePath)))
            {
                throw new ArgumentException("Данный файл не существует: " + filePath);
            }

            foreach (var item in items)
            {
                if (item.Key.Length > 260 || item.Value.Length > 260)
                {
                    throw new ArgumentException(
                        "В переданном словаре содержится значения, превышающее ограничение в 260 символов\n" +
                        "Ключ: " + item.Key + "\n" +
                        "Значение: " + item.Value);
                }
            }

            byte countCreatedDoc = 0;
            foreach (var filePath in filePaths.Where(filePath => CreateDoc(new FileInfo(filePath), items)))
            {
                countCreatedDoc++;
            }

            Console.WriteLine("Создание документов завершено. Документов создано: {0}", countCreatedDoc);
            return countCreatedDoc;
        }

        private void OpenDocument(string file)
        {
            try
            {
                _app.Documents.Open(file);
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось открыть документ\n" + e);
            }
        }

        private void CloseDocument()
        {
            try
            {
                _app.ActiveDocument.Close();
                _app.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось закрыть файл:\n" + e);
            }
        }

        private bool FileExists(string fileName) => File.Exists(fileName);

        private void ExecuteReplace(MicrosoftWord.Find find, string originalText, string replacedText)
        {
            try
            {
                find.Text = originalText;
                find.Replacement.Text = replacedText;
                find.Replacement.ParagraphFormat.Alignment =
                    MicrosoftWord.WdParagraphAlignment.wdAlignParagraphJustify;
                find.Wrap = MicrosoftWord.WdFindWrap.wdFindContinue;

                var wrap = MicrosoftWord.WdFindWrap.wdFindContinue;
                var replace = MicrosoftWord.WdReplace.wdReplaceAll;
                find.Execute(FindText: Type.Missing,
                    MatchCase: true,
                    MatchWholeWord: true,
                    MatchWildcards: false,
                    MatchSoundsLike: Type.Missing,
                    MatchAllWordForms: false,
                    Forward: true,
                    Wrap: wrap,
                    Format: false,
                    ReplaceWith: Type.Missing,
                    Replace: replace);
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось выполнить замену:\n" + e);
            }
        }

        // TODO внедрить создание документа по имени продукта 
        private void SaveDoc(string directoryName, string fileName)
        {
            try
            {
                var fullDirectoryName = directoryName + "\\Result";
                Directory.CreateDirectory(fullDirectoryName);
                var newFileName = Path.Combine(fullDirectoryName + "\\" + fileName);
                _app.ActiveDocument.SaveAs2(newFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось сохранить файл\n" + e);
            }
        }

        private bool CreateDoc(FileInfo fileInfo, Dictionary<string, string> items)
        {
            try
            {
                OpenDocument(fileInfo.FullName);

                foreach (MicrosoftWord.Range rng in _app.ActiveDocument.StoryRanges)
                {
                    foreach (var item in items)
                    {
                        ExecuteReplace(rng.Find, item.Key, item.Value);
                    }
                }

                if (fileInfo.DirectoryName != null)
                {
                    SaveDoc(fileInfo.DirectoryName, fileInfo.Name);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось создать файл\n" + e);
                return false;
            }
            finally
            {
                Console.WriteLine("Документ {0} создан", fileInfo.Name);
                CloseDocument();
            }
        }
    }
}