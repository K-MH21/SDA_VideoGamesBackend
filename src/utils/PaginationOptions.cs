namespace FusionTech.src.Utils
{
    public class PaginationOptions
    {
        public int Limit { get; set; } = 20;
        public int Offset { get; set; } = 0;
        public string? Search { get; set; }= "";

        public void IsValid()
        {
            if (Limit <= 0)
                throw CustomException.InternalError("Limit must be greater than zero.");

            if (Offset < 0)
                throw CustomException.InternalError("Offset cannot be negative.");
        }
    }
}
