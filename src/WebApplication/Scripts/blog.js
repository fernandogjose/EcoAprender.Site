$(document).ready(function () {
    blog.init();
});

var blog = (function () {
    return {

        init: function () {

        },

        alterarMateria: function (link) {
            $('.materiaCompleta').addClass('hide');
            $('.' + link).removeClass('hide');
        }

    };
}());