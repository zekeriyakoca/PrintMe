using System.Drawing;

namespace PrintMe.Application.Model;

public enum MockupTemplateType
{
    HorizontalForVerticalFrame,
    HorizontalForHorizontalFrame,
    VerticalForVerticalFrame,
    VerticalForHorizontalFrame
}
public class MockupTemplate
{
    public int Id { get; set; }
    public string TemplateImageUrl { get; set; }
    public Point[] Corners { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public MockupTemplateType Type { get; set; }
}