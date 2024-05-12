# DevOfSwSuppWithOOP

## Opis
Skup definicija i edukacijskih primjera u svrhu učenja za kolegiji Razvoj programske podrške objektno orjentiranim načelima (RPPOON).

## Sadržaj
- Opis
- Sadržaj
- Literatura
- Sadržaj kolegija
- Korištenje
- Doprinosi
- Autori
- Zahvale

## Literatura
- https://refactoring.guru, 04.14.2024.
- https://sourcemaking.com, 04.14.2024.
- https://www.freecodecamp.org/news/clean-coding-for-beginners, 04.14.2024.
- https://github.com/Luzkan/smells, 04.14.2024.
- Design Patterns, Elements of Reausable Object-Oriented Software, Gamma, Helm, Johnson, Vlissides
- https://www.youtube.com/@CodeAesthetic, 04.14.2024.
- https://www.youtube.com/watch?v=tv-_1er1mWI, 04.14.2024.
- https://www.youtube.com/watch?v=mE3qTp1TEbg&list=PLlsmxlJgn1HJpa28yHzkBmUY-Ty71ZUGc, 04.14.2024.
- https://code-maze.com, 04.17.2024.
- https://code-smells.com, 04.17.2024.
- https://makolyte.com, 04.17.2024.
https://www.codingdrills.com/tutorial/design-patterns-tutorial/introduction-to-dp, 05.11.2024

## Sadržaj kolegija
- Objektno orjentirano programiranje
- SOLID Načela
- STUPID kod, Mirisi u kodu i antiobrasci
- Oblikovni obrasci
    - Obrasci stvaranja
        - Metoda tvornica
        - Apstraktna tvornica
        - Graditelj
        - Prototip
        - Singleton
    - Obrasci strukture
        - Adapter
        - Most
        - Kompozit
        - Dekorator
        - Fasada
        - Flyweight
        - Proxy
    - Obrasci ponašanja
        - Lanac odgovornosti
        - Naredba
        - Iterator
        - Mediator
        - Memento
        - Promatrač
        - Stanje
        - Strategija
        - Metoda predložak
        - Posjetitelj
- Osnove unit testiranje u C#
# Sadržaj repozitorija
[OOP](https://github.com/FC122/DevOfSwSuppWithOOP/blob/master/DevOfSwSuppWithOOP/OOP/README.hr.md)

[Clean code](https://github.com/FC122/DevOfSwSuppWithOOP/blob/master/DevOfSwSuppWithOOP/CleanCode/README.hr.md)

[Code smells and antipatterns](https://github.com/FC122/DevOfSwSuppWithOOP/blob/master/DevOfSwSuppWithOOP/CodeSmellsAndAntipatterns/README.hr.md)

[Creational design patterns](https://github.com/FC122/DevOfSwSuppWithOOP/blob/master/DevOfSwSuppWithOOP/DesignPatterns/Creational/README.hr.md)

[Structural design patterns](https://github.com/FC122/DevOfSwSuppWithOOP/blob/master/DevOfSwSuppWithOOP/DesignPatterns/Structural/README.hr.md)

[Behavioural design patterns](https://github.com/FC122/DevOfSwSuppWithOOP/blob/master/DevOfSwSuppWithOOP/DesignPatterns/Behavioural/README.hr.md)

[SOLID](https://github.com/FC122/DevOfSwSuppWithOOP/blob/master/DevOfSwSuppWithOOP/SOLID/README.hr.md)
# Korištenje
Kloniraj repo:
```
git clone https://github.com/FC122/DevOfSwSuppWithOOP
```
ili preuzmi .zip i raspakiraj

Otvori solution pomoći Visual Studija ili Visual Studio Codea

U Program.cs kad želiš pokrenuti klijentski kod (ClientCode.cs) nekog namespace-a promjeni referencirani namespace. U primjeru ispod namespace je OOPBankingSystem
```cs
public static class Program{
    public static void Main(string[] args){
        OOPBankingSystem.ClientCode.Run();
    }
}
```
# Autor
Filip Cica

# TODO
Visitor
Null Objekt
Naredba
Mediator
Stanje
Dodati Zadatke iz 3,4,5