(function ($) {
    $.fn.inputblur = function () {
        $(this).focus(function () {
            $(this).blur();
        });
    }
})(jQuery)