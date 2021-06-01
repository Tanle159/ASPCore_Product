namespace ProductManagement.Common.StatusActions
{
    public abstract class StatusActionBase
    {
        public int Code { get; set; }

        public string Status { get; set; }

        public StatusActionBase()
        {
        }

        public StatusActionBase(int code, string status)
        {
            this.Code = code;
            this.Status = status;
        }
    }
}