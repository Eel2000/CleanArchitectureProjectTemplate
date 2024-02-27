namespace CleanArchitectureProjectTemplate.Domain.Commons;

public class Response<TData> where TData : class
{
    public TData? Data { get; set; }
    public string[] Errors { get; set; }
    public bool Succeeded { get; set; }
    public string? Message { get; set; }


    public Response()
    {
        //default constructor
    }

    public Response(string message, TData data)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }

    public Response(TData data)
    {
        Succeeded = true;
        Data = data;
    }

    public Response(string message, string[] errors)
    {
        Message = message;
        Errors = errors;
        Succeeded = false;
    }
}