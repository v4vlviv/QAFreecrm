using System;
using System.IO;


namespace QAFreecrm.Tools
{
    public class CsvReader : IDisposable
    {
        private string path;
        private string[] currentData;
        private StreamReader reader;

        public CsvReader(string path)
        {
            if (!File.Exists(path)) throw new InvalidOperationException("path does not exist");
            this.path = path;
            Initialize();
        }

        private void Initialize()
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
        }

        public bool Next()
        {
            string current = null;
            if ((current = reader.ReadLine()) == null) return false;
            currentData = current.Split(',');
            return true;
        }

        public string this[int index]
        {
            get { return currentData[index]; }
        }


        public void Dispose()
        {
            reader.Close();
        }
    }
}
