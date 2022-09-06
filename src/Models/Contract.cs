namespace src.Models;

public class Contract
{
    public Contract()
    {
        this.DataCreation = DateTime.Now;
        this.Value = 0;
        this.TokenId = "000000";
        this.Payed = false;
    }
    
    public Contract(string TokenId, double Value) {
        this.DataCreation = DateTime.Now;
        this.TokenId = TokenId;
        this.Value = Value;
        this.Payed = false;
    }
    public int Id { get; set; }
    public DateTime DataCreation { get; set; }
    public string TokenId { get; set; }
    public double Value { get; set; }
    public Boolean Payed { get; set; }
    public int PersonId { get; set; }
}