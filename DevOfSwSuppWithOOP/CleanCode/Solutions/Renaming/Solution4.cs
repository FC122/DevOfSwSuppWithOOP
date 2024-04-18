namespace DevOfSwSuppWithOOP.CleanCode.Renaming.Solution4{
    public class Note
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; private set; }

        public Note(string title, string text)
        {
            Title = title;
            Text = text;
            Date = DateTime.Now;
        }
    }

    public class Notebook
    {
        public string Author { get; private set; }
        public List<Note> notes;

        public Notebook(string author)
        {
            Author = author;
            notes = new List<Note>();
        }

        public void AddNote(Note note)
        {
            notes.Add(note);
        }
    }

    public static class ClientCode
    {
        public static void Run()
        {
            Notebook notebook = new Notebook("Bruno Bajić");
            notebook.AddNote(new Note("Hello World", "Pls Help Im In the Watter"));
            notebook.AddNote(new Note("Zorja Večernja", "Zora je svanula"));

            notebook.notes.ForEach(note => Console.WriteLine($"{note.Title}, {note.Text}\n"));
            
        }
    }
}