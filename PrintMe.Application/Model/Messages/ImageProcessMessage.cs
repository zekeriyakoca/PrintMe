using PrintMe.Application.Enums;

namespace PrintMe.Application.Model;

public record ImageProcessMessage(string ImageId, string ImageUrl, string ImageDescription, List<MockupTemplate> MockupTemplates, CatalogTags? Tag);