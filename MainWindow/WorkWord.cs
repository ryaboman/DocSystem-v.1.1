using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace MainWindow
{
    public class WorkWord
    {
        //Создаём объект документа
        Word.Document doc = null;

        //Создаём объект приложения
        Word.Application app = new Word.Application();

        Word.Table table = null;


        public bool visible { get; set; }

        public WorkWord()
        {
            visible = false;
        }

        public WorkWord(bool visible)
        {
            this.visible = visible;
        }

        //Создаем вордовский файл и сохраняем его в указанной папке
        public void CreateDoc(string pathSaveAs)
        {
            try
            {
                //string pathTemp = Path.GetTempPath();

                doc = app.Documents.Add();
                doc.SaveAs2(pathSaveAs, Word.WdSaveFormat.wdFormatDocumentDefault); //сохраняет с заменой, если файл уже существует
            }
            catch
            {
                doc.Close();
                app.Quit();  //может закрывать все открытые ворды
            }
        }

        //Создаем вордовский файл и сохраняем его в указанной папке
        public void CreateDoc()
        {
            try
            {
                app.Visible = visible;
                doc = app.Documents.Add();                
            }
            catch
            {
                doc.Close();
                app.Quit();  //может закрывать все открытые ворды
            }
        }

        public void WriteData(string text)
        {
            var r = doc.Range();
            r.Text = text;            
        }

        public void AddTable(int rows, int columns)
        {
            Word.Range tableLocation = app.ActiveDocument.Range(0, 0);  //Возможно это место куда вставится таблица

            table = app.ActiveDocument.Tables.Add(tableLocation, rows, columns);

            Word.Border[] borders = new Word.Border[6];//массив бордеров
            borders[0] = table.Borders[Word.WdBorderType.wdBorderLeft];//левая граница 
            borders[1] = table.Borders[Word.WdBorderType.wdBorderRight];//правая граница 
            borders[2] = table.Borders[Word.WdBorderType.wdBorderTop];//нижняя граница 
            borders[3] = table.Borders[Word.WdBorderType.wdBorderBottom];//верхняя граница
            borders[4] = table.Borders[Word.WdBorderType.wdBorderHorizontal];//горизонтальная граница
            borders[5] = table.Borders[Word.WdBorderType.wdBorderVertical];//вертикальная граница
            foreach (Word.Border border in borders)
            {
                border.LineStyle = Word.WdLineStyle.wdLineStyleSingle;//ставим стиль границы 
                border.Color = Word.WdColor.wdColorBlack;//задаем цвет границы
            }
        }

        public void SetColumnWidth(int column, float width)
        {
            try
            {
                if (table != null)
                {
                    table.Columns[column].PreferredWidth = width;
                }
            }
            catch
            {

            }
            
        }

        public void WriteDateInTable(int row, int column, string data)
        {
            try
            {
                if (table != null)
                {

                    Word.Cell cell = app.ActiveDocument.Tables[1].Cell(row, column);                    

                    cell.Range.Text = data;
                    //cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                }
            }
            catch
            {

            }
            
            
        }

        public void SetVisible(bool visible)
        {
            app.Visible = visible;
        }

        public void DocFromPattern(string pathPattern, string pathSaveAs)
        {            
            //pathPattern - путь, где храниться шаблон СЗ
            //pathSaveAs - путь в котором будет сохранен файл
            try
            {                
                app.Visible = true;
                doc = app.Documents.Open(pathPattern);
                pathSaveAs += ".docx"; //добавляем расширение, чтобы правильно был задан путь, так как в названии могут присутствовать точки. Из-за чего воозникает путаница с расширением
                doc.SaveAs2(pathSaveAs, Word.WdSaveFormat.wdFormatDocumentDefault); //сохраняет с заменой, если файл уже существует
                
                //Подпишемся на событие, которое возникник перед сохранением документа
                app.DocumentBeforeSave += new Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(ThisDocument_BeforeSave);

                //Возможно нужно подписаться на события закрытия программы, чтобы в этот момент отписаться от всех событий
                //app.DocumentBeforeClose += new Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(ThisDocument_BeforeClose);

            }
            catch (Exception ex)
            {
                doc.Close();
                doc = null;
            }
        }

        //данная функция открывает документ для редактирования,
        //при этом она подписывается на события перед сохранением
        public void OpenDocForEdit(string pathToDoc)
        {
            try
            {
                //Создаём объект приложения
                Word.Application app = new Word.Application();
                app.Visible = true;
                //А если документ кем-то уже открыт? Нужно выдавать сообщение об этом
                doc = app.Documents.Open(pathToDoc);                
                app.DocumentBeforeSave += new Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(ThisDocument_BeforeSave);
            }
            catch (Exception ex)
            {
                doc.Close();
                doc = null;
            }
        }

        public void SavePDFInvisible(string pathToDoc)
        {
            try
            {
                //Создаём объект приложения
                Word.Application app = new Word.Application();
                app.Visible = false;
                //А если документ кем-то уже открыт? Нужно выдавать сообщение об этом
                doc = app.Documents.Open(pathToDoc);

                string fullName = Path.Combine(doc.Path, Path.GetFileNameWithoutExtension(doc.Name));
                fullName += ".pdf"; //чтобы не было путаницы с расширением
                doc.SaveAs2(fullName, Word.WdSaveFormat.wdFormatPDF);

                doc.Close();
                app.Quit();  //может закрывать все открытые ворды
            }
            catch (Exception ex)
            {
                doc.Close();
                doc = null;
            }
        }

        //Данная функция заполняет закладки текстом из data
        public void BookmarkWrite(string data, string name_bookmark)
        {
            Word.Bookmarks wBookmarks = doc.Bookmarks;

            foreach (Word.Bookmark mark in wBookmarks)
            {
                if (mark.Name == name_bookmark)
                {
                    Word.Range wRange;
                    wRange = mark.Range;
                    wRange.Text = data;
                }
            }
        }
        
        //возможно не нужно создавать данную функцию, ее возможно лучше наследовать
        private void SaveDocAs(string name, Word.WdSaveFormat format) //Правильно ли здесь задан формат
        {
            //name - имя и путь для файла
            doc.SaveAs2(name, format);
        }

        //Обработчик события, перед сохранением документа он его сохраняет в pdf
        private void ThisDocument_BeforeSave(Microsoft.Office.Interop.Word.Document doc, ref bool b, ref bool f)
        {
            string fullName = Path.Combine(doc.Path, Path.GetFileNameWithoutExtension(doc.Name));
            fullName += ".pdf"; //чтобы не было путаницы с расширением
            doc.SaveAs2(fullName, Word.WdSaveFormat.wdFormatPDF);
        }

        /*
        private void ThisDocument_BeforeClose(Microsoft.Office.Interop.Word.Document doc, ref bool cansel)
        {

        }
        */
    }
    
    public class MessageFilter : IOleMessageFilter
    {
        //
        //Class containing the IOleMessageFilter
        //thread error-handling functions.

        //Start the filter.
        public static void Register()
        {
            IOleMessageFilter newFilter = new MessageFilter();
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(newFilter, out oldFilter);
        }

        // Done with the filter, closeit.
        public static void Revoke()
        {
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(null, out oldFilter);
        }

        //
        // IOleMessageFilter function.
        // Handle incoming thread requests.
        int IOleMessageFilter.HadleInComingCall(int dwCallType,
            System.IntPtr hTaskCaller, int dwTickCount, System.IntPtr
            lpInterfaceInfo)
        {
            //Return the flag SEVERCALL_ISHANDLED.
            return 0;
        }

        // Thread call was rejected, so try again.
        int IOleMessageFilter.RetryRejectedCall(System.IntPtr 
            hTaskCallee, int dwTickCount, int dwRejectType)
        {
            if(dwRejectType == 2)
                // flag = SERVERCALL_RETRYLATER.
            {
                // Retry the thread call immediately if return >=0 &
                // <100.
                return 99;
            }
            // Too busy; cancel call
            return -1;
        }

        int IOleMessageFilter.MessagePending(System.IntPtr hTaskCallee, 
            int dwTickCount, int dwPendingType)
        {
            //Return the flag PENDINGMSG_WAITDEFPROCESS.
            return 2;
        }

        // Implement the IOleMessageFilter interface.
        [DllImport("Ole32.dll")]
        private static extern int
            CoRegisterMessageFilter(IOleMessageFilter newFilter, out
            IOleMessageFilter oleFilter);
    }

    [ComImport(), Guid("00000016-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    interface IOleMessageFilter
    {
        [PreserveSig]
        int HadleInComingCall(
            int dwCallType,
            IntPtr hTaskCaller,
            int dwTickCount,
            IntPtr lpInterfaceInfo);

        [PreserveSig]
        int RetryRejectedCall(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwRejectType);

        [PreserveSig]
        int MessagePending(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwPendingType);
    }
    
}