using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MicWord = Microsoft.Office.Interop.Word;

namespace Word_helper.Src.Core
{

    


    class WordHelper
    {
        private readonly FileInfo _fileInfo;

        public WordHelper(string fileName)
        {
            if (FileExists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                MessageBox.Show("HA! File not found " + fileName);
                throw new ArgumentException("File not found");
            }
        }

        private bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }
        internal void Process(Dictionary<string, string> items)
        {
            var app = new MicWord.Application();
            try
            {
                object file = _fileInfo.FullName;
                object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    foreach (MicWord.Range rng in app.ActiveDocument.StoryRanges)
                    {
                        MicWord.Find find = rng.Find;
                        find.Text = item.Key;
                        find.Replacement.Text = item.Value;
                        find.Replacement.ParagraphFormat.Alignment = MicWord.WdParagraphAlignment.wdAlignParagraphJustify;
                        find.Wrap = MicWord.WdFindWrap.wdFindContinue;

                        var wrap = MicWord.WdFindWrap.wdFindContinue;
                        var replace = MicWord.WdReplace.wdReplaceAll;
                        find.Execute(FindText: missing,
                            MatchCase: true,
                            MatchWholeWord: true,
                            MatchWildcards: false,
                            MatchSoundsLike: missing,
                            MatchAllWordForms: false,
                            Forward: true,
                            Wrap: wrap,
                            Format: false,
                            ReplaceWith: missing,
                            Replace: replace);
                    }
                }

                if (_fileInfo.DirectoryName != null)
                {
                    var newFileName = Path.Combine(_fileInfo.DirectoryName + "/Новая папка", _fileInfo.Name);
                    app.ActiveDocument.SaveAs2(newFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Функция process " + ex.Message);
                throw;
            }
            finally
            {
                app.ActiveDocument.Close();
                app.Quit();
            }
        }
    }
}
