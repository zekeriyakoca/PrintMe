using System.ComponentModel.DataAnnotations;

namespace PrintMe.Application.Model;

public record PaginationRequestDto([Range(1,100)]int PageSize = 10, [Range(1,Int32.MaxValue)]int PageIndex = 0);