using System;

namespace ProductManagement.Common.Errors
{
    public class InvalidParameters : Exception
    {
        public string Status { get; set; }

        public int Code { get; set; }

        public InvalidParameters(string message = "Tham số sai") : base(message)
        {
            this.Code = 400;
            this.Status = "Thất bại";
        }
    }
}