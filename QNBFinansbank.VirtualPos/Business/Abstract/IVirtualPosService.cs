using QNBFinansbank.VirtualPos.Entity.Request.BatchClose;
using QNBFinansbank.VirtualPos.Entity.Request.Cancel;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.History;
using QNBFinansbank.VirtualPos.Entity.Request.Payment;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Request.PreAuth;
using QNBFinansbank.VirtualPos.Entity.Request.Refund;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Check;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Usage;
using QNBFinansbank.VirtualPos.Entity.Request.SegmentInquiry;
using QNBFinansbank.VirtualPos.Entity.Response.BatchClose;
using QNBFinansbank.VirtualPos.Entity.Response.Cancel;
using QNBFinansbank.VirtualPos.Entity.Response.Check;
using QNBFinansbank.VirtualPos.Entity.Response.History;
using QNBFinansbank.VirtualPos.Entity.Response.Payment;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Response.PreAuth;
using QNBFinansbank.VirtualPos.Entity.Response.Refund;
using QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Check;
using QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Usage;
using QNBFinansbank.VirtualPos.Entity.Response.SegmentInquiry;

namespace QNBFinansbank.VirtualPos.Business.Abstract
{
    public interface IVirtualPosService
    {
        /// <summary>
        /// QNB Finansbank Sanal Pos ödeme işlemini başlatır ve ödeme sürecini başlatmak için gerekli işlemleri yapar.
        /// Bu yöntem, ödeme parametrelerini alarak ödeme işlemini başlatır ve işleme ilişkin sonucu döner.
        /// </summary>
        /// <param name="startPayment">
        /// Ödeme işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="PaymentRequestDto"/> nesnesi.
        /// Bu nesne, ödeme miktarı, kart bilgileri, müşteri bilgileri gibi detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="PaymentResponseDto"/> nesnesi döner. 
        /// Bu nesne, ödeme işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        PaymentResponseDto Payment(PaymentRequestDto startPayment);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde 3D Model ile başlatılan bir ödemeyi tamamlar.
        /// Bu yöntem, 3D Model ödeme parametrelerini alarak işlemi başlatır ve işleme ilişkin sonucu döner.
        /// </summary>
        /// <param name="threeDModel">
        /// 3D Model Payment işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="ThreeDModelPaymentRequestDto"/> nesnesi.
        /// Bu nesne, işlemle ilgili güvenlik bilgileri, sipariş numarası ve diğer ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="ThreeDModelPaymentResponseDto"/> nesnesi döner.
        /// Bu nesne, işlem sonucunu, işlemle ilgili hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        ThreeDModelPaymentResponseDto ThreeDModelPayment(ThreeDModelPaymentRequestDto threeDModel);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde başlatılmış bir ön otorizasyon (Pre-Auth) işlemini sonlandırır.
        /// Bu yöntem, ön otorizasyon talebini alarak işlemi sonlandırır ve işlem sonucunu döner.
        /// </summary>
        /// <param name="preAuthRequest">
        /// Ön otorizasyon işlemini sonlandırmak için gerekli olan parametreleri içeren bir <see cref="PreAuthRequestDto"/> nesnesi.
        /// Bu nesne, sonlandırılacak işlemle ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="PreAuthResponseDto"/> nesnesi döner. 
        /// Bu nesne, ön otorizasyon işleminin sonlandırılmasının başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        PreAuthResponseDto StopPreAuth(PreAuthRequestDto preAuthRequest);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde bir ödeme işlemini iptal eder.
        /// Bu yöntem, iptal parametrelerini alarak iptal işlemini gerçekleştirir ve işlem sonucunu döner.
        /// </summary>
        /// <param name="cancel">
        /// İptal işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="CancelRequestDto"/> nesnesi.
        /// Bu nesne, iptal edilecek işlemle ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="CancelResponseDto"/> nesnesi döner. 
        /// Bu nesne, iptal işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CancelResponseDto Cancel(CancelRequestDto cancel);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde bir ödeme işleminin geri ödeme (iade) işlemini başlatır.
        /// Bu yöntem, geri ödeme parametrelerini alarak geri ödeme işlemini gerçekleştirir ve işlem sonucunu döner.
        /// </summary>
        /// <param name="refund">
        /// Geri ödeme işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="RefundRequestDto"/> nesnesi.
        /// Bu nesne, geri ödeme yapılacak işlemle ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="RefundResponseDto"/> nesnesi döner. 
        /// Bu nesne, geri ödeme işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        RefundResponseDto Refund(RefundRequestDto refund);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde bir ödeme işleminin durumunu kontrol eder.
        /// Bu yöntem, kontrol parametrelerini alarak ödeme işleminin mevcut durumunu döner.
        /// </summary>
        /// <param name="check">
        /// İşlemin durumunu kontrol etmek için gerekli olan parametreleri içeren bir <see cref="CheckRequestDto"/> nesnesi.
        /// Bu nesne, kontrol edilecek işlemle ilgili detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin durumunu içeren bir <see cref="CheckResponseDto"/> nesnesi döner. 
        /// Bu nesne, işlem durumunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CheckResponseDto Check(CheckRequestDto check);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinden para puanları sorgular.
        /// Bu yöntem, para puan sorgulama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="rewardPointsRequestDto">
        /// Para puan sorgulama işlemi için gerekli olan parametreleri içeren bir <see cref="CheckRewardPointsRequestDto"/> nesnesi.
        /// Bu nesne, sorgulama işlemiyle ilgili hesap, sipariş ve kart bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="CheckRewardPointsResponseDto"/> nesnesi döner.
        /// Bu nesne, para puan sorgulama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CheckRewardPointsResponseDto CheckRewardPoints(CheckRewardPointsRequestDto rewardPointsRequestDto);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinden para puanları kullanarak ödeme yapar.
        /// Bu yöntem, para puan kullanım parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="useRewardPointsRequestDto">
        /// Para puan kullanım işlemi için gerekli olan parametreleri içeren bir <see cref="UseRewardPointsRequestDto"/> nesnesi.
        /// Bu nesne, işlemle ilgili hesap, sipariş ve kart bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="UseRewardPointsResponseDto"/> nesnesi döner.
        /// Bu nesne, para puan kullanım işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        UseRewardPointsResponseDto UseRewardPoints(UseRewardPointsRequestDto useRewardPointsRequestDto);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde işlem geçmişini sorgular.
        /// Bu yöntem, işlem geçmişi sorgulama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="historyRequestDataDto">
        /// İşlem geçmişi sorgulama işlemi için gerekli olan parametreleri içeren bir <see cref="HistoryRequestDto"/> nesnesi.
        /// Bu nesne, sorgulama işlemiyle ilgili hesap, sipariş ve sorgulama tarih bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="HistoryResponseDto"/> nesnesi döner.
        /// Bu nesne, işlem geçmişi sorgulama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        HistoryResponseDto History(HistoryRequestDto historyRequestDataDto);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde toplu kapama (batch close) işlemini gerçekleştirir.
        /// Bu yöntem, toplu kapama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="batchCloseRequestDto">
        /// Toplu kapama işlemi için gerekli olan parametreleri içeren bir <see cref="BatchCloseRequestDto"/> nesnesi.
        /// Bu nesne, işlemle ilgili hesap bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="BatchCloseResponseDto"/> nesnesi döner.
        /// Bu nesne, toplu kapama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        BatchCloseResponseDto BatchClose(BatchCloseRequestDto batchCloseRequestDto);

        SegmentInquiryResponseDto SegmentInquiry(SegmentInquiryRequestDto segmentInquiryRequestDto);
    }
}
