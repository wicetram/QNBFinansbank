namespace QNBFinansbank.VirtualPos.Entity.Response.EOD
{
    public class EODResponseDto : IDto
    {
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// EOD işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
