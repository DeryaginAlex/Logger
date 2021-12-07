using NUnit.Framework;
using System.IO;

namespace ServiceCloud.Logger {
    public class SimpleTextFileLoggerTestsContext {
        /// <summary>
        /// Создание журнала
        /// </summary>
        /// <param name="path">Полный путь к журналу</param>
        public void CreateJournal(string path) {
            File.Create(path).Dispose();
        }

        /// <summary>
        /// Удаление журнал
        /// </summary>
        /// <param name="path">Полный путь к журналу</param>
        public void DeleteJournals(string path) {
            File.Delete(path);
        }

        /// <summary>
        /// Создание папки с журналами 
        /// </summary>
        /// <param name="path">Полный путь к журналу</param>
        public void CreateDirectory(string path) {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Удаление из папки всех журналов
        /// </summary>
        /// <param name="path">Полный путь к журналу</param>
        public void DeleteAllJournals(string path) {
            Directory.Delete(path, true);
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Возвращает последнюю строку журнала
        /// </summary>
        /// <param name="path">Полный путь к журналу</param>
        /// <returns></returns>
        public string GetLastLines(string path) {
            string[] text = File.ReadAllLines(path);

            return text[text.Length - 1];
        }

        /// <summary>
        /// Определяет, существует ли заданный журнал.
        /// </summary>
        /// <param name="path">Полный путь к журналу</param>
        /// <returns></returns>
        public bool thisJournalExists(string path) {
            return File.Exists(path);
        }
    }
}