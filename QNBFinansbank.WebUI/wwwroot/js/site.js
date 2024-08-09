function submitFormById(formId) {
    var checkExist = setInterval(function () {
        var form = document.getElementById(formId);
        if (form) {
            clearInterval(checkExist);
            form.submit();
        } else {
            console.error("Form with id '" + formId + "' not found.");
        }
    }, 100); // Her 100ms'de bir formu kontrol eder
}
