using ProductManagement.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Common.Errors
{
    public class NotFoundError:ErrorBase
    {
        public NotFoundError() : base(StatusDescription.NotFound)
        {
            this.Code = StatusCodeDescription.NotFound;
            this.Status = StatusDescription.Fail;
        }
    }
}
