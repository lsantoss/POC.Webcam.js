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

// Toastr global using TempData
(function () {
    if (document.getElementById('toastr-success').value) {
        toastr.success(document.getElementById('toastr-success').value);
    }
    if (document.getElementById('toastr-info').value) {
        toastr.info(document.getElementById('toastr-info').value);
    }
    if (document.getElementById('toastr-warning').value) {
        toastr.warning(document.getElementById('toastr-warning').value);
    }
    if (document.getElementById('toastr-error').value) {
        toastr.error(document.getElementById('toastr-error').value);
    }
})();