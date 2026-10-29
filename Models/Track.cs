using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_ivanov.Models;

public class Track
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название трека")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите исполнителя")]
    public string ArtistName { get; set; } = string.Empty;

    [Range(1, 3600, ErrorMessage = "Длительность должна быть от 1 до 3600 секунд")]
    public int DurationSeconds { get; set; }

    // Внешний ключ для связи с альбомом
    public int AlbumId { get; set; }
}   