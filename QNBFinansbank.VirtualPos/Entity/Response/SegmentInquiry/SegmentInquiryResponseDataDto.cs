namespace QNBFinansbank.VirtualPos.Entity.Response.SegmentInquiry
{
    /// <summary>
    /// Segment sorgulama işlemi sonucunda dönen verileri ve işlem sonucunu temsil eder.
    /// </summary>
    public class SegmentInquiryResponseDataDto : IDto
    {
        /// <summary>
        /// İşlem sonucunu ve ilgili bilgileri içerir.
        /// Bu alan, işlemin başarılı olup olmadığını, hata kodunu ve mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Segment sorgulama işlemi sonucunda dönen detaylı verileri içerir.
        /// Bu alan, segment sorgulama işleminin sonucuna ait detayları içerir.
        /// </summary>
        public SegmentInquiryResponseDto? SegmentInquiryResponse { get; set; }
    }
}
