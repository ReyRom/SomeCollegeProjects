using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSort
{
    public partial class Main : Form
    {
        delegate void Sorting(FileInfo file);       //объявление делегата, используемого для хранения ссылок на методы сортировки
        
        int errorsCounter = 0;
        int fileCounter = 0;

        [DllImport("DLLSORT.dll", CallingConvention = CallingConvention.StdCall)]       //объявление функции из библиотеки DLLSORT.dll, написанной на C++
        static extern IntPtr size_sort(long fileSize);

        public Main()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();  // создание объекта диалогового окна выбора каталога
            if (folderBrowser.ShowDialog() == DialogResult.OK)              
            {
                folderTextBox.Text = folderBrowser.SelectedPath;            // запись пути к каталогу в текстовое поле
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            string path = folderTextBox.Text;
            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                Sorting sorting;
                switch (modeComboBox.SelectedIndex)
                {
                    case 0:
                        {
                            sorting = (file) => DateSorting(file);          // присвоение делегату ссылки на метод
                            break;
                        }
                    case 1:
                        {
                            sorting = (file) => StudYearSorting(file);
                            break;
                        }
                    case 2:
                        {
                            sorting = (file) => ExtensionSorting(file);
                            break;
                        }
                    case 3:
                        {
                            sorting = (file) => TypeSorting(file);
                            break;
                        }
                    case 4:
                        {
                            sorting = (file) => SizeSorting(file);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Необходимо выбрать тип сортировки");
                            return;
                        }
                }

                SearchOption option;
                if (includeCheckBox.Checked)
                {
                    option = SearchOption.AllDirectories;
                }
                else
                {
                    option = SearchOption.TopDirectoryOnly;
                }

                FileInfo[] files = directory.GetFiles("*.*", option);

                Task[] tasks = new Task[files.Length];          // объявление массива задач
                
                foreach (var file in files)
                {
                    tasks[fileCounter] = Task.Factory.StartNew(() => sorting(file));   // запуск задач в массиве и вызов делегата содержащего ссылку на один из методов сортировки
                    fileCounter++;
                }                                                                       
                Task.WaitAll(tasks);
                statusStrip.Items.Clear();
                statusStrip.Items.Add($"Отсортировано {files.Length-errorsCounter} из {files.Length} файлов");
                errorsCounter = 0;
                fileCounter = 0;
            }
            else
            { 
                MessageBox.Show("Данный каталог не существует"); 
            }
        }

        /// <summary>
        /// Сортровка файла в каталог, исходя из его размера
        /// </summary>
        /// <param name="file">объект файла</param>
        void SizeSorting(FileInfo file)
        {
            string targetPath = $@"{file.Directory}\{Marshal.PtrToStringAnsi(size_sort(file.Length))}";
            MoveFile(file, targetPath);
        }

        /// <summary>
        /// Сортровка файла в каталог, исходя из даты его создания с учетом учебного года
        /// </summary>
        /// <param name="file">объект файла</param>
        void StudYearSorting(FileInfo file)
        {
            string targetPath;
            DateTime writingData = file.CreationTime;
            DateTime studYearStart = new DateTime(writingData.Year, 9, 1);
            if (writingData >= studYearStart)
            {
                targetPath = $@"{file.Directory}\{writingData.Year}-{writingData.Year+1} уч. год";
            }
            else
            {
                targetPath = $@"{file.Directory}\{writingData.Year - 1}-{writingData.Year} уч. год";
            }
            MoveFile(file, targetPath);
        }

        /// <summary>
        /// Сортровка файла в каталог, исходя из даты его создания
        /// </summary>
        /// <param name="file">объект файла</param>
        void DateSorting(FileInfo file)
        {
            DateTime writingData = file.CreationTime;
            string targetPath = $@"{file.Directory}\{writingData.Year}\{writingData.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru-RU"))}\{writingData.Day}";
            MoveFile(file, targetPath);
        }

        /// <summary>
        /// Сортровка файла в каталог, исходя из его расширения
        /// </summary>
        /// <param name="file">объект файла</param>
        void ExtensionSorting(FileInfo file)
        {
            string targetPath = $@"{file.Directory}\{file.Extension}";
            MoveFile(file, targetPath);
        }

        /// <summary>
        /// Сортровка файла в каталог, исходя из его типа
        /// </summary>
        /// <param name="file">объект файла</param>
        void TypeSorting(FileInfo file)
        {
            string folder;
            switch (file.Extension)
            {
                case ".jpeg": case ".jpg": case ".bmp": case ".gif": case ".tiff": case ".png":
                    {
                        folder = "Изображения";
                        break; 
                    }
                case ".txt": case ".rtf": case ".doc": case ".docx":
                    {
                        folder = "Текстовые файлы";
                        break;
                    }
                case ".xls": case ".xlsx": case ".xlsm": case ".ods":
                    {
                        folder = "Таблицы";
                        break;
                    }
                case ".avi": case ".wmf": case ".3gp": case ".mp4": case ".mpg2": case ".mkv":
                    {
                        folder = "Видео";
                        break;
                    }
                case ".mp3": case ".wma":
                    {
                        folder = "Аудио";
                        break;
                    }
                case ".zip": case ".rar": case ".7z": case ".tg":
                    {
                        folder = "Архивы";
                        break;
                    } 
                case ".exe": case ".cmd": case ".bat": case ".msi":
                    {
                        folder = "Исполняемые файлы";
                        break;
                    } 
                default:
                    {
                        folder = "Другое";
                        break;
                    }
            }
            string targetPath = $@"{file.Directory}\{folder}";
            MoveFile(file, targetPath);
        }

        /// <summary>
        /// Перемещение файлов в целевые каталоги
        /// </summary>
        /// <param name="file">объект файла</param>
        /// <param name="targetPath">имя целевого каталога</param>
        void MoveFile(FileInfo file, string targetPath)
        {
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);          //создание каталога, если он не существует
            }
            try
            {
                file.MoveTo($@"{targetPath}\{file.Name}");      //перемещение файла
            }
            catch (Exception)
            {
                errorsCounter++;                                //увеличение счетчика ошибок, при их возникновении
            }
        }
    }
}
