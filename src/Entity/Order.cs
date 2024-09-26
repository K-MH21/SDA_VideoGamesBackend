namespace  FusionTech.src.Entity
 {
    public class Order 
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public int PaymentId { get; set; }
        public int StoreId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; } 
    }
}