using QNBFinansbank.MoneyTransfer.Entity.Request.Check;
using QNBFinansbank.MoneyTransfer.Entity.Request.Transfer;
using QNBFinansbank.MoneyTransfer.Entity.Response.Check;
using QNBFinansbank.MoneyTransfer.Entity.Response.Transfer;

namespace QNBFinansbank.MoneyTransfer.Business.Abstract
{
    public interface IMoneyTransferService
    {
        /// <summary>
        /// IBAN kullanarak para transferi işlemini gerçekleştirir.
        /// Bu yöntem, transfer parametrelerini alarak IBAN üzerinden para transferi yapar ve işleme ilişkin sonucu döner.
        /// </summary>
        /// <param name="transferRequestDto">
        /// Para transferi işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="TransferRequestDto"/> nesnesi.
        /// Bu nesne, transfer miktarı, alıcı bilgileri gibi detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="TransferResponseDto"/> nesnesi döner. 
        /// Bu nesne, transfer işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        TransferResponseDto IBANMoneyTransfer(TransferRequestDto transferRequestDto);

        /// <summary>
        /// Kredi kartı kullanarak para transferi işlemini gerçekleştirir.
        /// Bu yöntem, transfer parametrelerini alarak kredi kartı üzerinden para transferi yapar ve işleme ilişkin sonucu döner.
        /// </summary>
        /// <param name="transferRequestDto">
        /// Para transferi işlemini başlatmak için gerekli olan parametreleri içeren bir <see cref="TransferRequestDto"/> nesnesi.
        /// Bu nesne, transfer miktarı, alıcı bilgileri gibi detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="TransferResponseDto"/> nesnesi döner. 
        /// Bu nesne, transfer işleminin başarı durumunu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        TransferResponseDto CreditCardMoneyTransfer(TransferRequestDto transferRequestDto);

        /// <summary>
        /// Gerçekleştirilen para transferi işlemlerini kontrol eder.
        /// Bu yöntem, belirli bir transferin durumu hakkında bilgi almak için kullanılır ve ilgili transferin sonucunu döner.
        /// </summary>
        /// <param name="checkTransferRequestDto">
        /// Kontrol edilmesi gereken transferin bilgilerini içeren bir <see cref="CheckTransferRequestDto"/> nesnesi.
        /// Bu nesne, transfer ID'si gibi detayları içerebilir.
        /// </param>
        /// <returns>
        /// Transferin durumunu içeren bir <see cref="CheckTransferResponseDto"/> nesnesi döner. 
        /// Bu nesne, transferin başarı durumu, işlem sonucunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        CheckTransferResponseDto Check(CheckTransferRequestDto checkTransferRequestDto);
    }
}
