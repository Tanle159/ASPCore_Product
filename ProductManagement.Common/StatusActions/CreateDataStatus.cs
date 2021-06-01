using ProductManagement.Common.Constants;

namespace ProductManagement.Common.StatusActions
{
    public class CreateDataStatus<T> : StatusActionBase where T : class
    {
        public T Data { get; set; }

        public CreateDataStatus(T data) : base(StatusCodeDescription.Ok, StatusDescription.Success)
        {
            this.Data = data;
        }
    }
}