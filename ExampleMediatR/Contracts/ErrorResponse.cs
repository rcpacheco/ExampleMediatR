using System.Collections.Generic;

namespace ExampleMediatR.Contracts
{
    public class ErrorResponse
    {
        public IList<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
