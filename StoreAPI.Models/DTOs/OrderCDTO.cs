namespace StoreAPI.Models.DTOs;
// Transacciones SQLpublic class OredrCDTOs

public class OrderCDTO
{
    public Double Total { get; set; }
    public int SystemUserId { get; set; }

    public List<int> Products { get; set; }
}