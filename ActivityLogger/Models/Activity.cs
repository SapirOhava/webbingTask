using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityLogger.Models
{
    public enum ActivityType
    {
        CREATE, DELETE, UPDATE
    }

    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(100)]
        public string ServiceID { get; set; }

        [Required]
        [MaxLength(100)]
        public string EntityID { get; set; }

        [Required]
        public ActivityType Type { get; set; }

        [MaxLength(100)]
        public string UserID { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
