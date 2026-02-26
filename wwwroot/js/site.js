// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Toast auto-show and auto-hide functionality
document.addEventListener('DOMContentLoaded', function () {
    // Initialize all toasts
    var toastElList = [].slice.call(document.querySelectorAll('.toast'));
    var toastList = toastElList.map(function (toastEl) {
        var toast = new bootstrap.Toast(toastEl, {
            autohide: true,
            delay: 2000 // 2 seconds
        });
        toast.show();
        return toast;
    });

    // Optional: Auto-remove toast container after all toasts are hidden
    toastElList.forEach(function (toastEl) {
        toastEl.addEventListener('hidden.bs.toast', function () {
            // Check if all toasts are hidden
            var visibleToasts = document.querySelectorAll('.toast.show');
            if (visibleToasts.length === 0) {
                var container = toastEl.closest('.toast-container');
                if (container && container.children.length === 1) {
                    container.remove();
                }
            }
        });
    });
});

