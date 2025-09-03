namespace linkly_url_shortener.Application.DTO;

public class PagedResultDTO<T>
{
    public List<T>? Items { get; set; }
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}