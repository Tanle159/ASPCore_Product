using ProductManagement.Common.Constants;

namespace ProductManagement.Common.StatusActions
{
    public class UpdateDataStatus : StatusActionBase 
    {
        public UpdateDataStatus() : base(StatusCodeDescription.Ok, StatusDescription.Success)
        {
        }
    }
}