## Code Smells
http://en.wikipedia.org/wiki/Code_smell

http://www.codinghorror.com/blog/2006/05/code-smells.html

## SOLID Principles

http://en.wikipedia.org/wiki/SOLID_(object-oriented_design)

Watched the following video (Dimecasts SOLID SRP): http://dimecasts.net/Casts/CastDetails/88

## Code Smell Example: Too Many Parameters
```csharp
public void CustomerInsert(CustomerInsertValues values)
{
    // setup sql insert parameters
}

public void CustomerInsert(int id, string firstName, string lastName, .....)
{
    // setup sql insert parameters
}

public class CustomerInsertValues
{
    public int Id {get; set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
}
```