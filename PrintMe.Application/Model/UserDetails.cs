namespace PrintMe.Application.Model;

public record UserDetails(string Id, string UserName, string? Email, string? ProfilePictureUrl, bool isAdmin = false);