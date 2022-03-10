namespace TodoApp.Data_Model.Entity;

public class Card
{
    public int BoardId { get; set; }
    public string? Title{ get; set; }
    public string? Description { get; set; }
    public int AssociatedPersonId { get; set; }
    public Size CardSize { get; set; }
}
public enum Size
{
    XS = 1,
    S,
    M,
    L,
    XL
}