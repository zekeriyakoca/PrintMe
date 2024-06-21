using PrintMe.Application.Enums;
using PrintMe.Application.Model;

namespace PrintMe.Application.Constants;

public static class BootstrapConstants
{
    public static readonly List<FrameDto> FRAMES = new List<FrameDto>
    {
        new FrameDto(0, "Rolled-up", "No frame", 0, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/no-frame.png"),
        new FrameDto(1, "Classic Black", "Elegant black frame with a sleek finish, perfect for any artwork.", 3, "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame-corner-1.jpg"),
        new FrameDto(2, "Vintage Gold", "Ornate gold frame with intricate detailing, adds a touch of luxury.", 5, "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame-corner-1.jpg"),
        new FrameDto(3, "Rustic Wood", "Natural wood frame with a rustic charm, ideal for nature prints.", 5, "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame-corner-1.jpg"),
        new FrameDto(4, "Modern Silver", "Contemporary silver frame with a minimalist design.", 6, "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame-corner-1.jpg"),
        new FrameDto(5, "White Wash", "Clean white frame with a distressed finish for a shabby chic look.", 5, "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame-corner-1.jpg"),
        new FrameDto(6, "Matte Black", "Simple matte black frame, versatile for any style of artwork.",4, "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame-corner-1.jpg"),
        new FrameDto(7, "Cherry Wood", "Rich cherry wood frame with a warm, classic feel.", 5, "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame-corner-1.jpg"),
        new FrameDto(8, "Bronze Metallic", "Shiny bronze frame with a metallic finish, adds a modern touch.", 4, "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame-corner-1.jpg")
    };
    
    public static readonly List<SizeDto> SIZES = new List<SizeDto>
    {
        new SizeDto((int)PrintSize.Size13x18, "13x18", "Frame for 13x18 cm prints.", 1),
        new SizeDto((int)PrintSize.Size21x30, "21x30", "Frame for 21x30 cm prints.", 1.56),
        new SizeDto((int)PrintSize.Size30x40, "30x40", "Frame for 30x40 cm prints.", 2.67),
        new SizeDto((int)PrintSize.Size40x50, "40x50", "Frame for 40x50 cm prints.", 4.22),
        new SizeDto((int)PrintSize.Size50x50, "50x50", "Frame for 50x50 cm prints.", 6.89),
        new SizeDto((int)PrintSize.Size70x100, "70x100", "Frame for 70x100 cm prints.", 9.65)
    };
}