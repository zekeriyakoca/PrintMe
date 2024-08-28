using Microsoft.AspNetCore.Http;
using PrintMe.Application.Enums;

namespace PrintMe.Application.Model;

public class GenerateProductByImageDto
{
    public IEnumerable<IFormFile> Images { get; set; }
    public CatalogTags? Tag { get; set; }
    public List<int> TemplateIds { get; } = new();
    public bool IsVertical { get; set; } = false;
}