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

//    node
//{
//    stage 'Checkout code'
//        git 'https://github.com/v4vlviv/QAFreecrm.git'
//    stage 'Restore NUget'
//        bat '"D:\\JenkinsHelper\\nuget.exe" restore QAFreecrm.sln'
//    stage'Build'
//        bat '"C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\MSBuild.exe" QAFreecrm.sln'
//}

//stage'Parralel Test'
//    parallel firefox:{
//        node{
//            bat '"D:\\JenkinsHelper\\NUnit.Console-3.8.0\\nunit3-console.exe" --params:Browser=Firefox "D:\\C#_TestProject\\QAFreecrm\\QAFreecrm\\bin\\Debug\\QAFreecrm.dll"'
//        }
//    }, chrome:{
//        node{
//            bat '"D:\\JenkinsHelper\\NUnit.Console-3.8.0\\nunit3-console.exe" --params:Browser=Chrome "D:\\C#_TestProject\\QAFreecrm\\QAFreecrm\\bin\\Debug\\QAFreecrm.dll"'    
//        }
//    }
        
}
