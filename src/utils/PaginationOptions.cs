namespace FusionTech.src.Utils
{
    public class PaginationOptions
{
    public int Limit { get; set; } = 2;
    public int Offset { get; set; } = 0;
    public string? Search { get; set; } = null;
    public float? MinPrice { get; set; } = 0; 
    public float? MaxPrice { get; set; } = 10000; 
}

}
