using PrintMe.Application.Model;

namespace PrintMe.Application.Constants;

public static class MockupTemplates
{
    private static List<MockupTemplate> _horizontalForVerticalFrameMockupTemplates = new List<MockupTemplate>
    {
        new MockupTemplate
        {
            Id = 1,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/1.jpg",
            X = 1461,
            Y = 535,
            Width = 2541 - 1461,
            Height = 2202 - 535,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 2,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/2.jpg",
            X = 2256,
            Y = 536,
            Width = 3405 - 2256,
            Height = 2175 - 536,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 3,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/3.jpg",
            X = 1468,
            Y = 778,
            Width = 2534 - 1468,
            Height = 2298 - 778,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 4,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/4.jpg",
            X = 1659,
            Y = 944,
            Width = 2670 - 1659,
            Height = 2453 - 944,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 5,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/5.jpg",
            X = 1263,
            Y = 492,
            Width = 2736 - 1263,
            Height = 2776 - 492,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 6,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/6.jpg",
            X = 1453,
            Y = 237,
            Width = 2548 - 1453,
            Height = 1779 - 237,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 7,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/7.jpg",
            X = 1910,
            Y = 718,
            Width = 3267 - 1910,
            Height = 2644 - 718,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 25,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/25.png",
            X = 2121,
            Y = 424,
            Width = 2970 - 2121,
            Height = 1610 - 424,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 26,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/26.png",
            X = 1983,
            Y = 291,
            Width = 3247 - 1983,
            Height = 1973 - 291,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 27,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/27.png",
            X = 1993,
            Y = 393,
            Width = 3198 - 1993,
            Height = 2305 - 393,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 28,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/28.png",
            X = 1810,
            Y = 1225,
            Width = 2997 - 1810,
            Height = 2977 - 1225,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 29,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/29.png",
            X = 2257,
            Y = 277,
            Width = 3044 - 2257,
            Height = 1648 - 277,
            Type = MockupTemplateType.HorizontalForVerticalFrame
        },
        // new MockupTemplate
        // {
        //     Id = 30,
        //     TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/30.png",
        //     X = 2014,
        //     Y = 309,
        //     Width = 3286 - 2014,
        //     Height = 1684 - 309,
        //     Type = MockupTemplateType.HorizontalForVerticalFrame
        // }
    };

    private static List<MockupTemplate> _horizontalForHorizontalFrameMockupTemplates = new List<MockupTemplate>
    {
        new MockupTemplate
        {
            Id = 100,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/100.png",
            X = 1281,
            Y = 437,
            Width = 3592 - 1281,
            Height = 1934 - 437,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 102,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/102.png",
            X = 1799,
            Y = 678,
            Width = 3311 - 1799,
            Height = 1768 - 678,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 103,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/103.png",
            X = 1765,
            Y = 505,
            Width = 3285 - 1765,
            Height = 1594 - 505,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 104,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/104.png",
            X = 955,
            Y = 615,
            Width = 2620 - 955,
            Height = 1860 - 615,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 106,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/106.png",
            X = 2077,
            Y = 556,
            Width = 2817 - 2077,
            Height = 937 - 556,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 107,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/107.png",
            X = 1188,
            Y = 259,
            Width = 2044 - 1188,
            Height = 815 - 259,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 108,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/108.png",
            X = 1827,
            Y = 1608,
            Width = 2900 - 1827,
            Height = 2378 - 1608,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 109,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/109.png",
            X = 1427,
            Y = 734,
            Width = 3644 - 1427,
            Height = 2511 - 734,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 110,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/110.png",
            X = 916,
            Y = 242,
            Width = 1707 - 916,
            Height = 755 - 242,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 111,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/111.png",
            X = 1567,
            Y = 1230,
            Width = 3490 - 1567,
            Height = 2602 - 1230,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 112,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/112.png",
            X = 675,
            Y = 600,
            Width = 2826 - 675,
            Height = 1902 - 600,
            Type = MockupTemplateType.HorizontalForHorizontalFrame
        }
    };

    private static List<MockupTemplate> _verticalForVerticalFrameMockupTemplates = new List<MockupTemplate>
    {
        new MockupTemplate
        {
            Id = 11,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/11.jpg",
            X = 397,
            Y = 250,
            Width = 759 - 397,
            Height = 775 - 250,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 12,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/12.jpg",
            X = 1616,
            Y = 1430,
            Width = 3090 - 1616,
            Height = 3487 - 1430,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 13,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/13.jpg",
            X = 312,
            Y = 216,
            Width = 625 - 312,
            Height = 658 - 216,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 14,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/14.jpg",
            X = 876,
            Y = 1795,
            Width = 3197 - 876,
            Height = 4731 - 1795,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 15,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/15.jpg",
            X = 1207,
            Y = 627,
            Width = 2121 - 1207,
            Height = 1913 - 627,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },

        new MockupTemplate
        {
            Id = 16,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/16.webp",
            X = 450,
            Y = 314,
            Width = 1241 - 450,
            Height = 1384 - 314,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        // new MockupTemplate
        // {
        //     Id = 17,
        //     TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/17.webp",
        //     X = 314,
        //     Y = 304,
        //     Width = 1142 - 314,
        //     Height = 1426 - 304,
        //     Type = MockupTemplateType.VerticalForVerticalFrame
        // },
        new MockupTemplate
        {
            Id = 18,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/18.webp",
            X = 350,
            Y = 308,
            Width = 1129 - 350,
            Height = 1394 - 308,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 19,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/19.webp",
            X = 706,
            Y = 384,
            Width = 1269 - 706,
            Height = 1201 - 384,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 115,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/115.jpg",
            X = 504,
            Y = 310,
            Width = 720 - 504,
            Height = 613 - 310,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 116,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/116.jpg",
            X = 394,
            Y = 102,
            Width = 675 - 394,
            Height = 443 - 102,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 117,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/117.jpg",
            X = 596,
            Y = 582,
            Width = 960 - 596,
            Height = 1067 - 582,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 118,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/118.jpg",
            X = 568,
            Y = 535,
            Width = 1034 - 568,
            Height = 1136 - 535,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 124,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/124.jpg",
            X = 325,
            Y = 187,
            Width = 664 - 325,
            Height = 594 - 187,
            Type = MockupTemplateType.VerticalForVerticalFrame
        },
        new MockupTemplate
        {
            Id = 125,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/125.png",
            X = 460,
            Y = 232,
            Width = 696 - 460,
            Height = 546 - 232,
            Type = MockupTemplateType.VerticalForVerticalFrame
        }
        ,
        new MockupTemplate
        {
            Id = 126,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/126.png",
            X = 358,
            Y = 183,
            Width = 568 - 358,
            Height = 448 - 183,
            Type = MockupTemplateType.VerticalForVerticalFrame
        }
    };

    private static List<MockupTemplate> _verticalForHorizontalFrameMockupTemplates = new List<MockupTemplate>
    {
        new MockupTemplate
        {
            Id = 51,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/51.png",
            X = 566,
            Y = 868,
            Width = 2129 - 566,
            Height = 1938 - 868,
            Type = MockupTemplateType.VerticalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 52,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/52.png",
            X = 453,
            Y = 665,
            Width = 1336 - 453,
            Height = 1264 - 665,
            Type = MockupTemplateType.VerticalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 53,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/53.png",
            X = 552,
            Y = 1232,
            Width = 2480 - 552,
            Height = 2600 - 1232,
            Type = MockupTemplateType.VerticalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 54,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/54.png",
            X = 854,
            Y = 481,
            Width = 2558 - 854,
            Height = 1521 - 481,
            Type = MockupTemplateType.VerticalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 55,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/55.png",
            X = 330,
            Y = 612,
            Width = 1995 - 330,
            Height = 1857 - 612,
            Type = MockupTemplateType.VerticalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 122,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/122.jpg",
            X = 244,
            Y = 397,
            Width = 693 - 244,
            Height = 697 - 397,
            Type = MockupTemplateType.VerticalForHorizontalFrame
        },
        new MockupTemplate
        {
            Id = 123,
            TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-frames/123.jpg",
            X = 212,
            Y = 368,
            Width = 697 - 212,
            Height = 695 - 368,
            Type = MockupTemplateType.VerticalForHorizontalFrame
        },
    };

    public static List<MockupTemplate> GetMockupTemplates()
    {
        return new List<MockupTemplate>()
            .Concat(_horizontalForVerticalFrameMockupTemplates)
            .Concat(_horizontalForHorizontalFrameMockupTemplates)
            .Concat(_verticalForVerticalFrameMockupTemplates)
            .Concat(_verticalForHorizontalFrameMockupTemplates)
            .ToList();
    }
}