namespace StoreAPI.Models.Entities;

public class SystemUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstNaame { get; set; }
    public string LastName { get; set; }
    
    
    //Propiedades de navegacion
    public List<Order> Orders { get; set; }
}