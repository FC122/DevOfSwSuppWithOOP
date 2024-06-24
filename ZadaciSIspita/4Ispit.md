# 1. Dajte prijedloge preimenovanja za imena u danom izlistanju koda za koja smatrate da imaju nedostatke
```cs
public class NoteObject
{
    public string title { get; set; }
    public string text { get; set; }
    public DateTime creation { get; private set; }

    public NoteObject(string titleString, string textString)
    {
        title = titleString;
        text = textString;
        creation = DateTime.Now;
    }
}

public class CollectionOfNotes
{
    public string Author { get; private set; }
    public List<NoteObject> groupOfNotes;

    public CollectionOfNotes(string author)
    {
        Author = author;
        groupOfNotes = new List<NoteObject>();
    }

    public void AddNoteToCollection(NoteObject note)
    {
        groupOfNotes.Add(note);
    }
}
```
Rješenje:
```cs
public class Note
{
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime Creation { get; private set; }

    public Note(string title, string text)
    {
        Title = title;
        Text = text;
        Creation = DateTime.Now;
    }
}

public class NoteCollection
{
    public string Author { get; private set; }
    public List<Note> Notes { get; private set; }

    public NoteCollection(string author)
    {
        Author = author;
        Notes = new List<Note>();
    }

    public void AddNoteToCollection(Note note)
    {
        Notes.Add(note);
    }
}
```

# 2. Refaktorirajte kod dan u sljedećem izlistanju
```cs
class DrugiZadatak
{
    public static List<char> uniqueChars(string text)
    {
        List<char> chars = new List<char>();
        for (int i = 0; i < text.Length; i++)
        {
            int occurrenceCount = 0;
            for (int j = 0; j < text.Length; j++)
            {
                if (text[i] == text[j])
                {
                    occurrenceCount++;
                }
            }
            if (occurrenceCount == 1)
            {
                chars.Add(text[i]);
            }
        }
        return chars;
    }
}
```
Rješenje:
```cs
public static List<char> CountUniqeCharacters(string text)
{
    List<char> characters = new List<char>();
    for (int i = 0; i < text.Length; i++)
    {
        if (CountCharacterOccurrence(text, text[i]) == 1)
        {
            characters.Add(text[i]);
        }
    }
    return characters;
}

public static int CountCharacterOccurrence(string text, char character)
{
    int count = 0;
    for (int j = 0; j < text.Length; j++)
    {
        if (character == text[j])
        {
            count++;
        }
    }
    return count;
}
```
# 3. Dajte primjer pseudokoda koji narusava nacelo isp te objasnite u cemu se to ogleda i zasto je to problem
```cs
interface IBirdable{
    public void Walk();
    public void Fly();
}

class Sparrow: IBirdable{
    public void Walk(){
        Console.WriteLine($"Sparrow is walking fast");
    }
    public void Fly(){
        Console.WriteLine($"Bird is flying fast");
    }
}

class Emu:IBirdable{
    public void Walk(){
        Console.WriteLine($"Emu is walking fast");
    }
    public void Fly(){
        throw new NotImplementedException ();
    }
} 
```
Primjer iznad krši ISP jer forsira implementaciju metode Fly u klasama kod kojih ta metoda ne smije biti implementirana. To je problem kod korištenja klase Emu preko sučelja IBirdable preko metode Fly koja kad bude pozvana će baciti iznimku.

# 4. Na što se odnosi pojam nakupine podataka kao miris u kodu? Navedite nekoliko pristupa za refaktoriranje takvog mirisa.
Kad klasa sadrži veliki broj atributa i/ili kad metoda sadrži veliki broj parametara. Potrebno je razmotriti ima li smisla razbiti klasu na više manjih klasa. U slučaju metode vrijedi isto potrebno razmotriti ima li smisla razbiti metodu na više manjih metoda.

# 5. Na sto se odnosi i sto najcesce odlikuje anti-obrazac magicni brojevi? Zasto moze predstavljati problem?
Anti-obrazac magični brojevi odnosi se na upotrebu numeričkih konstanti direktno u kodu bez jasnog konteksta ili objašnjenja njihove svrhe. Predstavlja problem jer uzrokuje nepreglednost, otežava održavanje i povećava mogućnost grešaka.

# 6. Napišite unit test koji provjerava ispravan rad metode dane sljedećim izlistanjem koda
```cs
public class StringEncoder
{
    private double threshold;

    public StringEncoder(double threshold)
    {
        this.threshold = threshold;
    }

    public string EncodeAsBinaryString(List<double> values)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (double value in values)
        {
            if (value >= threshold)
            {
                stringBuilder.Append("A");
            }
            else
            {
                stringBuilder.Append("a");
            }
        }
        return stringBuilder.ToString();
    }
}
```

Rješenje:
```cs
[TestFixture]
public class StringEncoderTests
{
    [Test]
    public void EncodeAsBinaryString_ThresholdBelowValues_ReturnsLowercaseString()
    {
        // Arrange
        double threshold = 10;
        List<double> values = new List<double> { 5, 7, 8 };

        StringEncoder encoder = new StringEncoder(threshold);

        // Act
        string result = encoder.EncodeAsBinaryString(values);

        // Assert
        Assert.AreEqual("aaa", result);
    }
}
```

# 7. Navedite barem po dvije prednosti i moguca nedostatka oblikovnog obrasca Apstraktna tvornica
- SRP - kod stvaranja proizvoda mozes izvuci na jedno mjesto
- OCP - možeš stvoriti nove vrste proizvoda bez mijenjanja trenutnog koda
- Kod postaje kompleksniji zbog dodatnih klasa

# 8. Za primjer dan izlistanjem koda odredite obrazac o kojem je riječ i njegovu skupinu. Dopunite kod implementacijom koja nedostaje te napišite klijentski kod za ovaj primjer.
```cs
public abstract class MailProcessor
{
    protected MailProcessor next;
    public void SetNext(MailProcessor mailProcessor)
    {
        this.next = mailProcessor;
    }
    public abstract void Process(Mail mail);
}

public class SpamProcessor : MailProcessor
{
    private ISpamTermsProvider spamTermsProvider;
    private ISenderLogger senderLogger;
    public SpamProcessor(ISpamTermsProvider spamTermsProvider, ISenderLogger senderLogger)
    {
        this.spamTermsProvider = spamTermsProvider;
        this.senderLogger = senderLogger;
    }
    public override void Process(Mail mail)
    {
        foreach (string term in spamTermsProvider.GetTerms())
        {
            if (mail.Contents.Contains(term))
            {
                senderLogger.Log(mail.Sender);
                break;
            }
        }
        if (next != null)
        {
            next.Process(mail);
        }
    }
}

public class ComplaintProcessor : MailProcessor
{
    private IComplaintsService complaintsService;
    public ComplaintProcessor(IComplaintsService complaintsService)
    {
        this.complaintsService = complaintsService;
    }
    public override void Process(Mail mail)
    {
        // Register a complaint using the complaints service
    }
}
```
Rješenje:
```cs
public class Mail
{
    public string Contents { get; private set; }
    public string Sender { get; private set; }
}
public interface ISenderLogger
{
    public void Log(string log);
}
public interface ISpamTermsProvider
{
    public List<string> GetTerms();
}
public interface IComplaintsService { }
public abstract class MailProcessor
{
    protected MailProcessor next;
    public void SetNext(MailProcessor mailProcessor)
    {
        this.next = mailProcessor;
    }
    public abstract void Process(Mail mail);
}

public class SpamProcessor : MailProcessor
{
    private ISpamTermsProvider spamTermsProvider;
    private ISenderLogger senderLogger;
    public SpamProcessor(ISpamTermsProvider spamTermsProvider, ISenderLogger senderLogger)
    {
        this.spamTermsProvider = spamTermsProvider;
        this.senderLogger = senderLogger;
    }
    public override void Process(Mail mail)
    {
        foreach (string term in spamTermsProvider.GetTerms())
        {
            if (mail.Contents.Contains(term))
            {
                senderLogger.Log(mail.Sender);
                break;
            }
        }
        if (next != null)
        {
            next.Process(mail);
        }
    }
}

public class ComplaintProcessor : MailProcessor
{
    private IComplaintsService complaintsService;
    public ComplaintProcessor(IComplaintsService complaintsService)
    {
        this.complaintsService = complaintsService;
    }
    public override void Process(Mail mail)
    {
        // Register a complaint using the complaints service
    }
}
```

# 9. Povezite klase, metode i sucelja s njihovim ulogama u obrascu. O kojem obrascu je rijec i u koju skupinu spada? Navedite dva razloga iz kojih ga je prikladno koristiti.
|Generic             | Contextual                 |
|:-------------------|:---------------------------|
|Kompozit            | IPlayable                  |
|List                | T-Shirt                    |
|Komponenta          | CalculatePriceWithTax      |
|Radnje              | GiftSet                    |

|Generic             | Contextual                 |
|:-------------------|:---------------------------|
|Kompozit            | GiftSet                    |
|List                | T-Shirt                    |
|Komponenta          | IPlayable                  |
|Radnje              | CalculatePriceWithTax      |

# 10. Koji je oblikovni obrazac prikladan za rjesavanje zadatka danog u nastavku i u koju skupinu pripada? Navedite strukture klasa te pripadajuce metode/atribute te koje biste koristili i njihove uloge
Radite na sustavu za nadzor proizvodnje i potrošnje električne energije čija je primarna uloga 
praćenje stanja ukupne proizvodnje i ukupne potrošnje energije. Postoji potreba da se više 
različitih, raznorodnih komponenti sinkronizira s navedenim stanjima te bude automatski obaviješteno
o pro- mjeni pri čemu se ovaj odnos mora moći ostvariti i prekinuti dinamički. Komponenta za 
bilježenje (engl. logging) treba zabilježiti vrijednosti ovih avaju stanja pri svakoj izmjeni. 
Komponenta za re- zervu (engl. backup) treba u slučaju da potrošnja skoči na 90% iznosa 
proizvodnje, aktivirati dodatne kapacitete proizvodnje. Poznato je kako će u budućnosti biti
potrebno dodati i nove komponente u ovaj sustav, a to mora biti moguće napraviti naknadno 
bez utjecaja na klijentski kod.
```cs
  +-----------------------+      +---------------------+      
  |       IObserver       |      |       ISubject      |      
  +-----------------------+      +---------------------+      
  | + Update(production,  |      | - production:double |      
  |     consumption)      |      | - consumption:double|      
  +-----------^-----------+      +-----------^---------+      
              |                              |                   
  +-----------^-----------+      +-----------|---------+                   
  | Logger, BackupSystem  |      |   EnergyMonitor     |                   
  +-----------------------+      +---------------------+                   
  |                       |      | + Attach(observer:  |                   
  | + Update(production,  |      |   IObserver): void  |                   
  |     consumption)      |      | + Detach(observer:  |                   
  |                       |      |   IObserver): void  |                   
  +-----------^-----------+      | + Notify(): void    |                   
                                 +---------------------+       
```