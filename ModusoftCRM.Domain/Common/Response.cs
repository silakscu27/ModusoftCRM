namespace ModusoftCRM.Domain.Common
{
    public class Response<T>
    {
        public Response(Guid id)
        {
            Errors = new List<string>();
        }

        public Response(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            Errors = new List<string>();
        }

        public Response(string? message)
        {
            Succeeded = false;
            Message = message;
            Errors = new List<string>();
        }

        public Response(string? message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = new List<string>();
        }

        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public T? Data { get; set; }
    }
}
