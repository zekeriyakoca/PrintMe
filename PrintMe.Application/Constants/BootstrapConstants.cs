using PrintMe.Application.Enums;
using PrintMe.Application.Model;

namespace PrintMe.Application.Constants;

public static class BootstrapConstants
{
    public static readonly List<FrameDto> FRAMES = new List<FrameDto>
    {
        new FrameDto(0, "Rolled-up", "No frame", 0, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/no-frame.png"),
        new FrameDto(1, "Classic Black", "Elegant black frame with a sleek finish, perfect for any artwork.", 10, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/frame-1.jpeg"),
        new FrameDto(2, "Vintage Gold", "Ornate gold frame with intricate detailing, adds a touch of luxury.", 10, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/frame-1.jpeg"),
        new FrameDto(3, "Rustic Wood", "Natural wood frame with a rustic charm, ideal for nature prints.", 10, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/frame-1.jpeg"),
        new FrameDto(4, "Modern Silver", "Contemporary silver frame with a minimalist design.", 10, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/frame-1.jpeg"),
        new FrameDto(5, "White Wash", "Clean white frame with a distressed finish for a shabby chic look.", 10, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/frame-1.jpeg"),
        new FrameDto(6, "Matte Black", "Simple matte black frame, versatile for any style of artwork.", 10, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/frame-1.jpeg"),
        new FrameDto(7, "Cherry Wood", "Rich cherry wood frame with a warm, classic feel.", 10, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/frame-1.jpeg"),
        new FrameDto(8, "Bronze Metallic", "Shiny bronze frame with a metallic finish, adds a modern touch.", 10, "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/frame-1.jpeg")
    };
    
    public static readonly List<SizeDto> SIZES = new List<SizeDto>
    {
        new SizeDto((int)PrintSize.Size13x18, "13x18", "Frame for 13x18 cm prints.", 1),
        new SizeDto((int)PrintSize.Size21x30, "21x30", "Frame for 21x30 cm prints.", 2),
        new SizeDto((int)PrintSize.Size30x40, "30x40", "Frame for 30x40 cm prints.", 3),
        new SizeDto((int)PrintSize.Size40x50, "40x50", "Frame for 40x50 cm prints.", 4),
        new SizeDto((int)PrintSize.Size50x50, "50x50", "Frame for 50x50 cm prints.", 5),
        new SizeDto((int)PrintSize.Size70x100, "70x100", "Frame for 70x100 cm prints.", 6)
    };
}