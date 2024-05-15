namespace DevOfSwSuppWithOOP.DesignPatterns.Behavioral.Memento{
    namespace Problem{
        public class File//izvornik
        {
            public string FileData { get; private set; }
            public File() { FileData = ""; }
            public void Append(string data) {FileData+=data;}
        } 
        public static class ClientCode{
            public static void Run(){
                List<File> fileHistory = new List<File>();
                File file = new File();
                file.Append("Seminarski rad");//Pišeš rad
                //Želiš saveat progres - kliknes Ctrl s - ovo se dogodi:
                File fileVersion1 = new File();
                fileVersion1.Append(file.FileData);
                fileHistory.Add(fileVersion1);
                //Kad zelis undoat moras ovo radit:
                file = fileHistory.Last();
                //Postoji li bolji pristup?
            }
        }
    }
    namespace Solution{
        public class File//izvornik
        {
            public string FileData { get; private set; }
            public File() { FileData = ""; }
            public void Append(string data) {}
            public FileClipboard SaveDataToClipboard()
            {
                return new FileClipboard(FileData);
            }
            public void PasteFromClipboard(FileClipboard fileClipboard)
            {
                FileData = fileClipboard.FileData;
            }
        }

        public class FileClipboard//Memento
        {
            public string FileData { get; private set; }
            public FileClipboard(string FileData)
            {
                this.FileData = FileData;
            }
            public string GetClipboardData()
            {
                return FileData;
            }
        }

        public class Cache//skrbnik
        {
            File file;
            List<FileClipboard> fileClipboards = new List<FileClipboard>();
            public Cache(File file)
            {
                this.file = file;
            }
            public void SaveToCache(FileClipboard fileClipboard)
            {
                fileClipboards.Add(fileClipboard);
            }
            public void Undo()
            {
                int count = fileClipboards.Count;
                if (count > 1)
                {
                    file.PasteFromClipboard(fileClipboards.ElementAt(count - 2));
                    fileClipboards.RemoveAt(count - 1);
                }
            }
        }

        public static class ClientCode
        {
            public static void Run()
            {
                File file = new File();
                Cache cache = new Cache(file);
                file.Append("Seminarski rad");
                cache.SaveToCache(new FileClipboard(file.FileData));
                cache.Undo();
            }
        }
    }
}