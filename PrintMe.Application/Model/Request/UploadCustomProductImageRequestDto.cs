using Microsoft.AspNetCore.Http;

namespace PrintMe.Application.Model;

public class UploadCustomProductImageRequestDto
{
    public IFormFile Image { get; set; }
}