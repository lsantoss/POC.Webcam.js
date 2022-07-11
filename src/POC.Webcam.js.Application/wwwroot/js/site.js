// Toastr Options
toastr.options = {
    "closeButton": true,
    "progressBar": true,
    "debug": false,
    "newestOnTop": false,
    "preventDuplicates": false,
    "positionClass": "toast-top-right",
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "10000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

// Toastr
(function () {
    var displayMessage = function (message, msgType) {
        toastr[msgType](message);
    };

    if (document.getElementById('success').value) {
        displayMessage(document.getElementById('success').value, 'success');
    }
    if (document.getElementById('info').value) {
        displayMessage(document.getElementById('info').value, 'info');
    }
    if (document.getElementById('warning').value) {
        displayMessage(document.getElementById('warning').value, 'warning');
    }
    if (document.getElementById('error').value) {
        displayMessage(document.getElementById('error').value, 'error');
    }
})();