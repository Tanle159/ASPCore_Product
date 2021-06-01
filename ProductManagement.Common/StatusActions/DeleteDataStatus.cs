namespace ProductManagement.Common.StatusActions
{
    public class DeleteDataStatus : StatusActionBase
    {
        public DeleteDataStatus(string message = "Xóa thành công") : base(200, message)
        {
        }
    }
}