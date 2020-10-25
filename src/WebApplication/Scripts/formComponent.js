$(document).ready(function () {
    formComponent.init();
});

var formComponent = (function () {
    return {
        init: function () {
            $('.datepicker').datepicker({
                dateFormat: 'dd/mm/yy'
            });
        }
    };
}());