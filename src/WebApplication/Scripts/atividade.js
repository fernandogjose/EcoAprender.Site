$(document).ready(function () {
    atividade.init();
});

var atividade = (function () {
    return {

        init: function () {
            $('.ico-facebook').click(atividade.CompartilharFacebook);
            $('#form').submit(atividade.Login);
        },

        CompartilharFacebook: function () {
            FB.ui(
            {
                method: 'feed',
                name: $('#facebookName').val(),
                link: $('#facebookLink').val(),
                picture: $('#facebookPicture').val(),
                caption: $('#facebookCaption').val(),
                description: $('#facebookDescription').val(),
                message: $('#facebookMessage').val(),
            });
        },

        Login: function (event) {
            $('#mensagemDeErro').addClass('hide');

            event.preventDefault();
            if (!$("#form").valid()) {
                return;
            }

            $('#entrar').html('Aguarde...');
            $('#entrar').prop('disabled', true);

            var login = $('#login').val();
            var senha = $('#senha').val();
            var url = $("#form").attr('action') + '/' + login + '/' + senha;

            $.ajax({
                type: 'GET',
                url: url,
                success: function (data, status) {
                    $('#entrar').html('Entrar');
                    $('#entrar').prop('disabled', false);

                    if (data !== "sucesso") {
                        $('#mensagemDeErro').removeClass('hide');

                        setTimeout(function () {
                            $('#mensagemDeErro').addClass('hide');
                        }, 300000);

                        return;
                    }

                    location.reload();
                },
                error: function (xmlHttpRequest, status, err) {
                    $('#entrar').html('Entrar');
                    $('#entrar').prop('disabled', false);
                }
            });
        }
    };
}());