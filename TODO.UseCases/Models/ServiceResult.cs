using System.Net;

namespace TODO.UseCases.Models;

public class ServiceResult
{
    public object ResultObject { get; set; }
    
    public HttpStatusCode Status { get; set; }
}