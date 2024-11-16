namespace FusionTech.src.DTO
{
    public class PublisherDTO
    {
        public class PublisherCreateDto
        {
            [Required(ErrorMessage = "Publisher name is required.")]
            [StringLength(100, ErrorMessage = "Publisher name cannot exceed 100 characters.")]
            public string? PublisherName { get; set; }

            [EmailAddress(ErrorMessage = "Invalid email format.")]
            public string? PublisherEmail { get; set; }
            public string? PublisherPicturePath { get; set; }
        }

        public class PublisherReadDto
        {
            public Guid PublisherId { get; set; }
            public string? PublisherName { get; set; }
            public string? PublisherEmail { get; set; }
            public string? PublisherPicturePath { get; set; }
        }

        public class PublisherUpdateDto
        {
            [StringLength(100, ErrorMessage = "Publisher name cannot exceed 100 characters.")]
            public string? PublisherName { get; set; }

            [EmailAddress(ErrorMessage = "Invalid email format.")]
            public string? PublisherEmail { get; set; }
            public string? PublisherPicturePath { get; set; }
        }
    }
}
