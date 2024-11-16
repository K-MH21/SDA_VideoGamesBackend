namespace FusionTech.src.DTO
{
    public class SupplierDTO
    {
        public class SupplierCreateDto
        {
            [Required(ErrorMessage = "Supplier name is required.")]
            [StringLength(100, ErrorMessage = "Supplier name cannot exceed 100 characters.")]
            public string? SupplierName { get; set; }

            [Phone(ErrorMessage = "Invalid contact number format.")]
            public string? SupplierContactInfo { get; set; }

            [StringLength(200, ErrorMessage = "Supplier bank info cannot exceed 200 characters.")]
            public string? SupplierBankInfo { get; set; }
        }

        public class SupplierReadDto
        {
            public Guid SupplierId { get; set; }
            public string? SupplierName { get; set; }
            public string? SupplierContactInfo { get; set; }
            public string? SupplierBankInfo { get; set; }
        }

        public class SupplierUpdateDto
        {
            [StringLength(100, ErrorMessage = "Supplier name cannot exceed 100 characters.")]
            public string? SupplierName { get; set; }

            [Phone(ErrorMessage = "Invalid contact number format.")]
            public string? SupplierContactInfo { get; set; }

            [StringLength(200, ErrorMessage = "Supplier bank info cannot exceed 200 characters.")]
            public string? SupplierBankInfo { get; set; }
        }
    }
}
