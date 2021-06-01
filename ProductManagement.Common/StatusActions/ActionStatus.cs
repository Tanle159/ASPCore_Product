namespace ProductManagement.Common.StatusActions
{
    public class ActionStatus : StatusActionBase
    {
        public ActionStatus(string message = "Thành công") : base(200, message)
        {
        }
    }
}