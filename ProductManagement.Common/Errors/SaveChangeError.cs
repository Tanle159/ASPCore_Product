using ProductManagement.Common.Constants;

namespace ProductManagement.Common.Errors
{
    public class SaveChangeError : ErrorBase
    {
        public SaveChangeError() : base("Có lỗi khi lưu lại thay đổi ! ")
        {
            this.Code = StatusCodeDescription.BadRequest;
            this.Status = StatusDescription.Fail;
        }
    }
}