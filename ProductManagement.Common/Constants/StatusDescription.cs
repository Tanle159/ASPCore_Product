namespace ProductManagement.Common.Constants
{
    public static class StatusDescription
    {
        public const string Success = "Thành công";

        public const string Fail = "Thất bại";

        // Thêm các định nghĩa const NotFound 404 , BadRequest 400, ServerError 500  ...

        public const string NotFound = "Dữ liệu không tìm thấy";

        public const string BadRequest = "Lỗi xảy ra khi gửi yêu cầu";

        public const string ServerError = "Lỗi xảy ra khi Server xử lý yêu cầu";
    }
}