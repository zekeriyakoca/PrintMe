using PrintMe.Application.Enums;

namespace PrintMe.Application.Model;

public record SizeDto(int Id, string Name, string Description, double Multiplier);