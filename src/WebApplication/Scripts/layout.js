$(document).ready(function () {
    layout.init();
});

var layout = (function () {
    return {
        init: function () {
            layout.configMenu();
        },

        configMenu: function () {

            var isAdmin = $('#isAdmin').val();

            if (isAdmin === 'true') {
                $('.menu-site').addClass('hide');
                $('.menu-admin').removeClass('hide');
            } else {
                $('.menu-site').removeClass('hide');
                $('.menu-admin').addClass('hide');
            }
        }
    };
}());