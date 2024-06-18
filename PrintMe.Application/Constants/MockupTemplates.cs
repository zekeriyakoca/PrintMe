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
            }
        };
    private static List<MockupTemplate> _horizontalForHorizontalFrameMockupTemplates = new List<MockupTemplate>
        {
            
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
            }
        };
    private static List<MockupTemplate> _verticalForHorizontalFrameMockupTemplates = new List<MockupTemplate>
        {
            
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