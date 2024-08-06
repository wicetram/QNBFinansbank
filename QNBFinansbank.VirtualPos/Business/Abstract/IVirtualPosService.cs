using QNBFinansbank.VirtualPos.Entity;

namespace QNBFinansbank.VirtualPos.Business.Abstract
{
    public interface IVirtualPosService
    {
        /// <summary>
        /// QNB Finansbank Sanal Pos ödeme işlemini başlatır
        /// </summary>
        /// <param name="startPayment">Ödeme içeriğine ait parametrelerin olduğu obje</param>
        /// <returns>İşlemin başarılı durumunu içeren obje</returns>
        StartPaymentResponseDto Payment(StartPaymentRequestDto startPayment);
    }
}
