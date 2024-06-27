using PrintMe.Application.Enums;
using PrintMe.Application.Model;

namespace PrintMe.Application.Constants;

public static class BootstrapConstants
{
    public static readonly List<FrameDto> FRAMES = new List<FrameDto>
    {
        new FrameDto(0, "Rolled-up",
            "Without frame",
            0,
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/roll.jpeg",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/roll.jpeg",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/roll.jpeg",
            "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/no-frame.png",
            new string[]{}),
        new FrameDto(1, "Black Frame | EDSBRUK",
            "This traditional, robust frame has a soft profile and comes in many sizes, perfect for a picture wall.",
            4, "https://www.ikea.com/nl/en/images/products/edsbruk-frame-black-stained__0723741_pe734158_s5.jpg?f=xxs",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame8-edsbruk-mat.png",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame8-edsbruk.png",
            "https://www.ikea.com/nl/en/images/products/edsbruk-frame-black-stained__0723741_pe734158_s5.jpg?f=s",
            new string[]
            {
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-black-stained__0723740_pe734159_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-black-stained__0723739_pe734160_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-black-stained__0723741_pe734158_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-black-stained__1009335_ph176840_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-black-stained__0747489_pe744559_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-black-stained__1203360_pe906293_s5.jpg?f=s"
            }),
        new FrameDto(2, "White Stained Pine Effect | PLOMMONTRÄD",
            "The pattern of PLOMMONTRÄD frame has small variations, making each frame unique – and the slightly wider dimensions...",
            4, "https://www.ikea.com/nl/en/images/products/plommontrad-frame-white-stained-pine-effect__1202413_pe905936_s5.jpg?f=xxs",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame6-plommon-mat.png",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame6-plommon.png",
            "https://www.ikea.com/nl/en/images/products/plommontrad-frame-white-stained-pine-effect__1202413_pe905936_s5.jpg?f=s",
            new string[]
            {
                "https://www.ikea.com/nl/en/images/products/plommontrad-frame-white-stained-pine-effect__1202411_pe905935_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/plommontrad-frame-white-stained-pine-effect__1202412_pe905937_s5.jpg?f=xl",
                "https://www.ikea.com/nl/en/images/products/plommontrad-frame-white-stained-pine-effect__1202413_pe905936_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/plommontrad-frame-white-stained-pine-effect__1274126_ph194587_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/plommontrad-frame-white-stained-pine-effect__1203594_pe906362_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__1203360_pe906293_s5.jpg?f=s"
            }),
        new FrameDto(3, "White Frame | EDSBRUK",
            "This traditional, robust frame has a soft profile and comes in many sizes, perfect for a picture wall.",
            4, "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__0706506_pe725889_s5.jpg?f=xxs",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame5-edsbruk-mat.png",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame5-edsbruk.png",
            "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__0706506_pe725889_s5.jpg?f=s",
            new string[]
            {
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__0706504_pe725890_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__0902092_pe725882_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__0706506_pe725889_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__0939333_ph160793_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__0767914_pe754344_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__1203360_pe906293_s5.jpg?f=s"
            }),
        new FrameDto(4, "Brown Frame | RAMSBORG",
            "Sustainable beauty from sustainably-sourced solid wood, a durable and renewable material that maintains its genuine character with each passing year.", 
            4,
            "https://www.ikea.com/nl/en/images/products/ramsborg-frame-brown__0726700_pe735389_s5.jpg?f=xxs",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame7-ramsborg-mat.png",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame7-ramsborg.png",
            "https://www.ikea.com/nl/en/images/products/ramsborg-frame-brown__0726700_pe735389_s5.jpg?f=s",
            new string[]
            {
                "https://www.ikea.com/nl/en/images/products/ramsborg-frame-brown__0726699_pe735390_s5.jpg?f=xl",
                "https://www.ikea.com/nl/en/images/products/ramsborg-frame-brown__0726698_pe735391_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/ramsborg-frame-brown__0726700_pe735389_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/ramsborg-frame-brown__1350957_pe951835_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/ramsborg-frame-brown__0919777_ph164133_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/edsbruk-frame-white__1203360_pe906293_s5.jpg?f=s"
            }),
        new FrameDto(5, "Black Frame | RÖDALM", "RÖDALM frame has a modern look that does your favourite motifs justice.",
            4,
            "https://www.ikea.com/nl/en/images/products/rodalm-frame-black__1251233_pe924195_s5.jpg?f=xxs",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame1-rodalm-mat.png",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame1-rodalm.png",
            "https://www.ikea.com/nl/en/images/products/rodalm-frame-black__1251233_pe924195_s5.jpg?f=s",
            new string[]
            {
                "https://www.ikea.com/nl/en/images/products/rodalm-frame-black__1251232_pe924196_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/rodalm-frame-black__1298269_pe936170_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/rodalm-frame-black__1251233_pe924195_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/rodalm-frame-black__1298276_pe936177_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/rodalm-frame-black__1298259_pe936159_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/rodalm-frame-black__1330544_pe945716_s5.jpg?f=s"
            }),
        new FrameDto(6, "Black Frame | KNOPPANG",
            "Decorate with pictures you love.",
            4, "https://www.ikea.com/nl/en/images/products/knoppang-frame-black__0638249_pe698799_s5.jpg?f=xxs",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame2-knoppang-mat.png",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame2-knoppang.png",
            "https://www.ikea.com/nl/en/images/products/knoppang-frame-black__0638249_pe698799_s5.jpg?f=s",
            new string[]
            {
                "https://www.ikea.com/nl/en/images/products/knoppang-frame-black__0902477_pe661084_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/knoppang-frame-black__0902012_pe661072_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/knoppang-frame-black__0638249_pe698799_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/knoppang-frame-black__1187224_pe899111_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/knoppang-frame-black__0939314_ph166069_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/knoppang-frame-black__1202391_pe905919_s5.jpg?f=s"
            }),
        new FrameDto(7, "Gold Frame | SILVERHÖJDEN",
            "This frame has a matt metal-like finish and comes in many sizes, perfect for a picture wall.",
            4, "https://www.ikea.com/nl/en/images/products/silverhojden-frame-gold-colour__1179571_pe895993_s5.jpg?f=xxs",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame4-silverhojden-mat.png",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame4-silverhojden.png",
            "https://www.ikea.com/nl/en/images/products/silverhojden-frame-gold-colour__1179571_pe895993_s5.jpg?f=s",
            new string[]
            {
                "https://www.ikea.com/nl/en/images/products/silverhojden-frame-gold-colour__1179570_pe895994_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/silverhojden-frame-gold-colour__1179568_pe895991_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/silverhojden-frame-gold-colour__1179571_pe895993_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/silverhojden-frame-gold-colour__1187227_pe899114_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/silverhojden-frame-gold-colour__1350950_pe951830_s5.jpg?f=xl",
                "https://www.ikea.com/nl/en/images/products/silverhojden-frame-gold-colour__1202816_pe906101_s5.jpg?f=s"
            }),
        new FrameDto(8, "Gold Frame | LOMVIKEN",
            "Decorate with pictures you love. ",
            4, "https://www.ikea.com/nl/en/images/products/lomviken-frame-gold-colour__0661072_pe711302_s5.jpg?f=xxs",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame3-lomviken-mat.png",
            "https://genstorageaccount3116.blob.core.windows.net/printme-images/frame3-lomviken.png",
            "https://www.ikea.com/nl/en/images/products/lomviken-frame-gold-colour__0661072_pe711302_s5.jpg?f=s",
            new string[]
            {
                "https://www.ikea.com/nl/en/images/products/lomviken-frame-gold-colour__0661070_pe711317_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/lomviken-frame-gold-colour__0902049_pe731149_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/lomviken-frame-gold-colour__0661072_pe711302_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/lomviken-frame-gold-colour__0661071_pe711318_s5.jpg?f=s",
                "https://www.ikea.com/nl/en/images/products/lomviken-frame-gold-colour__1171372_pe893053_s5.jpg?f=s"
            })
    };

    public static readonly List<SizeDto> SIZES = new List<SizeDto>
    {
        new SizeDto((int)PrintSize.Size13x18, "13x18", "Frame for 13x18 cm prints.", 1),
        new SizeDto((int)PrintSize.Size21x30, "21x30", "Frame for 21x30 cm prints.", 1.56),
        new SizeDto((int)PrintSize.Size30x40, "30x40", "Frame for 30x40 cm prints.", 2.67),
        new SizeDto((int)PrintSize.Size40x50, "40x50", "Frame for 40x50 cm prints.", 3.22),
        new SizeDto((int)PrintSize.Size50x70, "50x70", "Frame for 50x70 cm prints.", 4.89),
        new SizeDto((int)PrintSize.Size61x91, "61x91", "Frame for 61x91 cm prints.", 5.65)
    };
}