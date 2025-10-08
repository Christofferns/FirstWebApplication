using System.ComponentModel.DataAnnotations;

namespace FirstWebApplication.Models
{
    public class ObstacleData
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must be at most 50 characters")]
        public string ObstacleName { get; set; } = string.Empty;

        public int Id { get; set; } // Auto-increment fra DB

        [Range(1, 10000, ErrorMessage = "Height must be between 1 and 10,000")]
        public int ObstacleHeight { get; set; }

        [StringLength(200, ErrorMessage = "Description must be at most 200 characters")]
        public string ObstacleDescription { get; set; } = string.Empty;

        // GeoJSON FeatureCollection med det som tegnes i kartet
        public string? GeometryGeoJson { get; set; }

        // Primære koordinater (første markør om den finnes, ellers senter av tegningen)
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        // NYTT: Alle markør-koordinater som JSON-array: [[lat,lng],[lat,lng],...]
        public string? MarkerCoordinatesJson { get; set; }
    }
}
