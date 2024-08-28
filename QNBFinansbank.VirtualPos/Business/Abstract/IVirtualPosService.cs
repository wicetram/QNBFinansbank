using QNBFinansbank.VirtualPos.Entity.Request.BatchClose;
using QNBFinansbank.VirtualPos.Entity.Request.Campaign.Check;
using QNBFinansbank.VirtualPos.Entity.Request.Campaign.Usage;
using QNBFinansbank.VirtualPos.Entity.Request.Cancel;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.EOD;
using QNBFinansbank.VirtualPos.Entity.Request.History;
using QNBFinansbank.VirtualPos.Entity.Request.Payment;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.Hash;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Request.PreAuth;
using QNBFinansbank.VirtualPos.Entity.Request.RecurringPayment.Check;
using QNBFinansbank.VirtualPos.Entity.Request.RecurringPayment.Payment;
using QNBFinansbank.VirtualPos.Entity.Request.Refund;
using QNBFinansbank.VirtualPos.Entity.Request.Report;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Check;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Usage;
using QNBFinansbank.VirtualPos.Entity.Request.SegmentInquiry;
using QNBFinansbank.VirtualPos.Entity.Response.BatchClose;
using QNBFinansbank.VirtualPos.Entity.Response.Campaign.Check;
using QNBFinansbank.VirtualPos.Entity.Response.Campaign.Usage;
using QNBFinansbank.VirtualPos.Entity.Response.Cancel;
using QNBFinansbank.VirtualPos.Entity.Response.Check;
using QNBFinansbank.VirtualPos.Entity.Response.EOD;
using QNBFinansbank.VirtualPos.Entity.Response.History;
using QNBFinansbank.VirtualPos.Entity.Response.Payment;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.Hash;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Response.PreAuth;
using QNBFinansbank.VirtualPos.Entity.Response.RecurringPayment.Check;
using QNBFinansbank.VirtualPos.Entity.Response.RecurringPayment.Payment;
using QNBFinansbank.VirtualPos.Entity.Response.Refund;
using QNBFinansbank.VirtualPos.Entity.Response.Report;
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
        /// <param name="reportRequestDto">
        /// İşlem geçmişi sorgulama işlemi için gerekli olan parametreleri içeren bir <see cref="ReportRequestDto"/> nesnesi.
        /// Bu nesne, sorgulama işlemiyle ilgili hesap, sipariş ve sorgulama tarih bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="ReportResponseDto"/> nesnesi döner.
        /// Bu nesne, işlem geçmişi sorgulama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        ReportResponseDto Report(ReportRequestDto reportRequestDto);

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

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde segment sorgulama işlemi gerçekleştirir.
        /// Bu yöntem, segment sorgulama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="segmentInquiryRequestDto">
        /// Segment sorgulama işlemi için gerekli olan parametreleri içeren bir <see cref="SegmentInquiryRequestDto"/> nesnesi.
        /// Bu nesne, sorgulama işlemiyle ilgili hesap, sipariş ve kart bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="SegmentInquiryResponseDto"/> nesnesi döner.
        /// Bu nesne, segment sorgulama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        SegmentInquiryResponseDto SegmentInquiry(SegmentInquiryRequestDto segmentInquiryRequestDto);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde EOD (End of Day) raporlama işlemi gerçekleştirir.
        /// Bu yöntem, EOD raporlama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="eodRequest">
        /// EOD raporlama işlemi için gerekli olan parametreleri içeren bir <see cref="EODRequestDto"/> nesnesi.
        /// Bu nesne, raporlama işlemiyle ilgili hesap, başlangıç ve bitiş tarih bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="EODResponseDto"/> nesnesi döner.
        /// Bu nesne, EOD raporlama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        EODResponseDto EOD(EODRequestDto eodRequest);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde kampanya kontrol işlemi gerçekleştirir.
        /// Bu yöntem, kampanya kontrol parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="campaignCheckRequest">
        /// Kampanya kontrol işlemi için gerekli olan parametreleri içeren bir <see cref="CampaignCheckRequestDto"/> nesnesi.
        /// Bu nesne, kontrol edilecek kampanya ile ilgili hesap, sipariş ve kart bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="CampaignCheckResponseDto"/> nesnesi döner.
        /// Bu nesne, kampanya kontrol işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CampaignCheckResponseDto CampaignCheck(CampaignCheckRequestDto campaignCheckRequest);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde kampanya kullanım işlemi gerçekleştirir.
        /// Bu yöntem, kampanya kullanım parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="campaignUsageRequestDto">
        /// Kampanya kullanım işlemi için gerekli olan parametreleri içeren bir <see cref="CampaignUsageRequestDto"/> nesnesi.
        /// Bu nesne, kampanya ile ilgili hesap, sipariş, kart bilgileri, ek taksit ve erteleme seçeneklerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="CampaignUsageResponseDto"/> nesnesi döner.
        /// Bu nesne, kampanya kullanım işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CampaignUsageResponseDto CampaignUsage(CampaignUsageRequestDto campaignUsageRequestDto);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde tekrarlı ödeme işlemini gerçekleştirir.
        /// Bu yöntem, tekrarlı ödeme parametrelerini alarak işlemi başlatır ve işleme ilişkin sonucu döner.
        /// </summary>
        /// <param name="recurringPaymentRequestDto">
        /// Tekrarlı ödeme işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="RecurringPaymentRequestDto"/> nesnesi.
        /// Bu nesne, ödeme işlemine ait hesap, sipariş ve kart bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="RecurringPaymentResponseDto"/> nesnesi döner.
        /// Bu nesne, tekrarlı ödeme işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        RecurringPaymentResponseDto RecurringPayment(RecurringPaymentRequestDto recurringPaymentRequestDto);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde tekrarlı ödeme kontrol işlemini gerçekleştirir.
        /// Bu yöntem, tekrarlı ödeme kontrol parametrelerini alarak işlemi başlatır ve işleme ilişkin sonucu döner.
        /// </summary>
        /// <param name="checkRecurringPaymentRequestDto">
        /// Tekrarlı ödeme kontrol işlemi için gerekli olan parametreleri içeren bir <see cref="CheckRecurringPaymentRequestDto"/> nesnesi.
        /// Bu nesne, ödeme işlemine ait hesap, sipariş ve işlem rehberi bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren bir <see cref="CheckRecurringPaymentResponseDto"/> nesnesi döner.
        /// Bu nesne, tekrarlı ödeme kontrol işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CheckRecurringPaymentResponseDto CheckRecurringPayment(CheckRecurringPaymentRequestDto checkRecurringPaymentRequestDto);

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde ödeme işlemi sırasında hash kontrolü yapar.
        /// Bu yöntem, verilen <see cref="PaymentHashControlRequestDto"/> nesnesindeki bilgileri kullanarak hash değerlerini kontrol eder ve
        /// sonuçları bir <see cref="PaymentHashResponseDto"/> nesnesi olarak döner.
        /// </summary>
        /// <param name="paymentHashControlRequestDto">
        /// Hash kontrol işlemi için gerekli olan parametreleri içeren <see cref="PaymentHashControlRequestDto"/> nesnesi.
        /// Bu nesne, hash kontrolü için işlem bilgilerini içerir.
        /// </param>
        /// <returns>
        /// Hash kontrolü sonucunu ve ilgili hash değerlerini içeren <see cref="PaymentHashResponseDto"/> nesnesi döner.
        /// Bu nesne, oluşturulan hash değeri, bankadan gelen hash değeri ve işlem sonucunu içerir.
        /// </returns>
        PaymentHashResponseDto HashControl(PaymentHashControlRequestDto paymentHashControlRequestDto);
    }
}
