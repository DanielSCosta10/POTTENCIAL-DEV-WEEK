using System.Collections.Generic;

namespace src.Models;

public class Person
{
    public Person()
    {
        this.Name = "template";
        this.Age = 0;
        this.contracts = new List<Contract>();
        this.Active = true;
    }

    public Person(string Name, int Age, string Cpf){
        this.Name = Name;
        this.Age = Age;
        this.Cpf = Cpf;
        this.contracts = new List<Contract>();
        this.Active = true;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string? Cpf { get; set; }
    public Boolean Active { get; set; }
    public List<Contract> contracts { get; set; }
}