namespace Polyv.SDK.Live.Abstractions.Values
{
    public class PolyvResponseTotal<TData> : PolyvResponse<TData>
    {
        public int Total { get; set; }
    }
}
