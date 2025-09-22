using System.ComponentModel.DataAnnotations;

namespace FirstWebApplication.Models
{
    public class ObstacleData
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must be at most 50 characters")]
        public string ObstacleName { get; set; } = string.Empty;

        [Range(1, 10000, ErrorMessage = "Height must be between 1 and 10,000")]
        public int ObstacleHeight { get; set; }

        [StringLength(200, ErrorMessage = "Description must be at most 200 characters")]
        public string ObstacleDescription { get; set; } = string.Empty;

        public string? GeometryGeoJson { get; set; }
    }
}
