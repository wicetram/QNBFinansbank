namespace QNBFinansbank.VirtualPos.Entity.Response.LinkPay
{
    public class LinkPayResponseDto : IDto
    {
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Link ile ödeme işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
