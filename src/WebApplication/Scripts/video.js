$(document).ready(function () {
    video.init();
});

var video = (function () {
    return {

        init: function () {

        },

        alterar: function (link) {
            $('.videoCompleta').addClass('hide');
            $('.video-' + link).removeClass('hide');
        }

    };
}());