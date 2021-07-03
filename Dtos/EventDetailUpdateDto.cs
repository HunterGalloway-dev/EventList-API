using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventListApi.Dtos
{
    public class EventDetailUpdateDto
    {
                // Decorated fields in order to perform error throwing. As without decorating fields you get a 500 Internal server error (Bad) sends stack trace back which isn't good
        // Decorated fields based off of EventDetailModel
        // Instead if the client provides data that is miss-inputed they will receive a 400 Bad Request (Better than saying our server had an error)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long EventDetailId { get; set; }
        [Required]
        public long OwnerAccountId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Caption { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int EventType { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int MainCategory { get; set; }
        [MaxLength(100)]
        public string BannerImageName { get; set; }
        [MaxLength(100)]
        public string ThumbnailImageName { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public long CreatedBy { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        [MaxLength(300)]
        public string OpenTokRoomName { get; set; }
        [MaxLength(1000)]
        public string OpenTokSessionID { get; set; }
        [MaxLength(1000)]
        public string OpenTokToken { get; set; }
    }
}