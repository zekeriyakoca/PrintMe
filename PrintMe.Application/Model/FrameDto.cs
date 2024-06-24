namespace PrintMe.Application.Model;

public record FrameDto(
    int Id, 
    string Name, 
    string Description, 
    long Price, 
    string Thumbnail, 
    string Mask, 
    string MaskWithoutMat, 
    string Image, 
    string[] AllImages
);