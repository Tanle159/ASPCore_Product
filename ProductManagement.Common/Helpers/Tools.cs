using System;

namespace ProductManagement.Common.Helpers
{
    public static class Tools
    {
        public static bool CheckExists(this string content)
        {
            if (content == null)
                return false;
            if (String.IsNullOrEmpty(content.Trim()))
                return false;
            if (String.IsNullOrWhiteSpace(content.Trim()))
                return false;
            return true;
        }
    }
}
