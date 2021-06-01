using ProductManagement.Common.Constants;

namespace ProductManagement.Common.StatusActions
{
    public class GetDataStatus<T> : StatusActionBase where T : class
    {
        public T Data { get; set; }

        public GetDataStatus(T data) : base(StatusCodeDescription.Ok, StatusDescription.Success)
        {
            this.Data = data;
        }

        public GetDataStatus() : base(StatusCodeDescription.NotFound, StatusDescription.NotFound)
        {
            this.Data = null;
        }
    }
}