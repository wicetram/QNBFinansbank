using QNBFinansbank.VirtualPos.Entity.Request.Cancel;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.Payment;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Request.Refund;
using QNBFinansbank.VirtualPos.Entity.Response.Cancel;
using QNBFinansbank.VirtualPos.Entity.Response.Check;
using QNBFinansbank.VirtualPos.Entity.Response.Payment;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Response.Refund;

namespace QNBFinansbank.VirtualPos.Business.Abstract
{
    public interface IVirtualPosService
    {
        /// <summary>
        /// QNB Finansbank Sanal Pos ödeme işlemini başlatır ve ödeme sürecini başlatmak için gerekli işlemleri yapar.
        /// Bu yöntem, ödeme parametrelerini alarak ödeme işlemini başlatır ve işleme ilişkin sonucu döner.
        /// </summary>
        /// <param name="startPayment">
        /// Ödeme işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="PaymentRequestDataDto"/> nesnesi.
        /// Bu nesne, ödeme miktarı, kart bilgileri, müşteri bilgileri gibi detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="PaymentResponseDto"/> nesnesi döner. 
        /// Bu nesne, ödeme işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        PaymentResponseDto Payment(PaymentRequestDataDto startPayment);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde 3D Model ile başlatılan bir ödemeyi tamamlar.
        /// Bu yöntem, 3D Model ödeme parametrelerini alarak işlemi başlatır ve işleme ilişkin sonucu döner.
        /// </summary>
        /// <param name="threeDModel">
        /// 3D Model Payment işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="ThreeDModelPaymentRequestDto"/> nesnesi.
        /// Bu nesne, işlemle ilgili güvenlik bilgileri, sipariş numarası ve diğer ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="ThreeDModelPaymentResponseDataDto"/> nesnesi döner.
        /// Bu nesne, işlem sonucunu, işlemle ilgili hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        ThreeDModelPaymentResponseDataDto ThreeDModelPayment(ThreeDModelPaymentRequestDto threeDModel);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde bir ödeme işlemini iptal eder.
        /// Bu yöntem, iptal parametrelerini alarak iptal işlemini gerçekleştirir ve işlem sonucunu döner.
        /// </summary>
        /// <param name="cancel">
        /// İptal işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="CancelRequestDataDto"/> nesnesi.
        /// Bu nesne, iptal edilecek işlemle ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="CancelResponseDataDto"/> nesnesi döner. 
        /// Bu nesne, iptal işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CancelResponseDataDto Cancel(CancelRequestDataDto cancel);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde bir ödeme işleminin geri ödeme (iade) işlemini başlatır.
        /// Bu yöntem, geri ödeme parametrelerini alarak geri ödeme işlemini gerçekleştirir ve işlem sonucunu döner.
        /// </summary>
        /// <param name="refund">
        /// Geri ödeme işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="RefundRequestDataDto"/> nesnesi.
        /// Bu nesne, geri ödeme yapılacak işlemle ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="RefundResponseDataDto"/> nesnesi döner. 
        /// Bu nesne, geri ödeme işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        RefundResponseDataDto Refund(RefundRequestDataDto refund);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde bir ödeme işleminin durumunu kontrol eder.
        /// Bu yöntem, kontrol parametrelerini alarak ödeme işleminin mevcut durumunu döner.
        /// </summary>
        /// <param name="check">
        /// İşlemin durumunu kontrol etmek için gerekli olan parametreleri içeren bir <see cref="CheckRequestDataDto"/> nesnesi.
        /// Bu nesne, kontrol edilecek işlemle ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin durumunu içeren bir <see cref="CheckResponseDataDto"/> nesnesi döner. 
        /// Bu nesne, işlem durumunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CheckResponseDataDto Check(CheckRequestDataDto check);
    }
}
