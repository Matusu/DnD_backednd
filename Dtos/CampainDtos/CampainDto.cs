using Microsoft.Identity.Client;
using webapi.Models;

namespace webapi.Dtos;

public class CampainDto
{
    public string? Name { get; set; }
    public string? UserId { get; set; }
}