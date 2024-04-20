namespace DevOfSwSuppWithOOP.DesignPatterns.Creational.Solution2{
    //MethodFactory
    public class WebElement{
        string name;
        public WebElement(string name){
            Console.WriteLine($"Found {name}");
            this.name = name;
        }
        public void Click(){
            Console.WriteLine($"Clicked {name}");
        }
    }

    public interface LoginPage{
        public WebElement loginButton();
        public WebElement usernameInput();
        public WebElement passwordInput();
    }

    public class ChromeLoginPage:LoginPage{
        public WebElement loginButton(){return new WebElement("#LoginButton");}
        public WebElement usernameInput(){ return new WebElement("#userInput");}
        public WebElement passwordInput(){return new WebElement("#passwordElement");}
    }

    public abstract class LoginPageFactory{
        public abstract LoginPage CreatePage();
    }

    public class ChromeLoginPageFactory:LoginPageFactory{
        public override LoginPage CreatePage(){
            return new ChromeLoginPage();
        }
    }

     public static class ClientCode
    {
        public static void Run()
        {
            //Kad želimo da kod radi za firefox, napravimo novi page i novu tvornicu
            LoginPageFactory loginPageFactory= new ChromeLoginPageFactory();
            //ne zanimam nas kako se page stvara tj. instancira
            LoginPage loginPage = loginPageFactory.CreatePage();
            //za bilo koji page koji prati apstrakcije Click ce raditi
            loginPage.loginButton().Click();
        }
    }
}
