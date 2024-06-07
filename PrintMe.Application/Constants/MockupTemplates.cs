using PrintMe.Application.Model;

namespace PrintMe.Application.Constants;

public static class MockupTemplates
{
    public static List<MockupTemplate> GetMockupTemplates()
    {
        return new List<MockupTemplate>
        {
            new MockupTemplate
            {
                Id = 1,
                TemplateImageUrl = "https://genstorageaccount3116.blob.core.windows.net/print-me-product-images/pexels-thought-catalog-317580-2401863.jpg",
                X = 855,
                Y = 1292,
                Width = 2168 - 855,
                Height = 2941 - 1292
            }
        };
    }
}