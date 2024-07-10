namespace OutOfOffice.Server.Data.Responses
{
    public class PageResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalEntries { get; set; }
    }
}
