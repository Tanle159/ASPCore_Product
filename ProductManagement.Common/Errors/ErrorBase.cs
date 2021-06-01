using System;

namespace ProductManagement.Common.Errors
{
    public class ErrorBase : Exception
    {
        public string Status { get; set; }

        public int Code { get; set; }

        public ErrorBase()
        {
        }

        public ErrorBase(int code, string status)
        {
            this.Code = code;
            this.Status = status;
        }

        public ErrorBase(string message) : base(message)
        {
        }

        public ErrorBase(int code, string status, string message) : base(message)
        {
            this.Code = code;
            this.Status = status;
        }
    }
}