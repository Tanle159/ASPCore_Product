using ProductManagement.Common.Constants;
using ProductManagement.Common.StatusActions;

namespace ProductManagement.Application.ProductsService.StatusAction
{
    public class UpdateProductStatus<T> : StatusActionBase where T : class
    {
        public T Data { get; set; }
        public UpdateProductStatus(T data) : base(StatusCodeDescription.Ok, StatusDescription.Success)
        {
            this.Data = data;
        }
    }
}
