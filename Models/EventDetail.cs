using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventListApi.Models
{
    [Table("EventDetail")]
    public class EventDetail
    {
        // Decorated fields according to the SQL EventDetails table design
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
        [Required]
        [MaxLength(100)]
        public string BannerImageName { get; set; }
        [Required]
        [MaxLength(100)]
        public string ThumbnailImageName { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public long CreatedBy { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public long ModifiedBy { get; set; }
        [Required]
        [MaxLength(300)]
        public string OpenTokRoomName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string OpenTokSessionID { get; set; }
        [Required]
        [MaxLength(1000)]
        public string OpenTokToken { get; set; }
    }
}