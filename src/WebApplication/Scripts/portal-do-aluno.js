$(document).ready(function () {
    PortalDoAluno.Init();
});

var PortalDoAluno = (function () {
    return {
        Init: function () {
            PortalDoAluno.ConfiguraFormValidate();
            PortalDoAluno.ConfiguraEventos();
        },

        ConfiguraEventos: function () {
            $('#form').submit(PortalDoAluno.Login);
        },

        ConfiguraFormValidate: function () {
            $("#form").validate({
                rules: {
                    login: {
                        required: true,
                        minlength: 2,
                    },
                    senha: {
                        required: true,
                        minlength: 2
                    }
                },
                messages: {
                    login: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    },
                    senha: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    }
                }
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

                    window.location = $('#actionPainel').val();
                },
                error: function (xmlHttpRequest, status, err) {
                    $('#entrar').html('Entrar');
                    $('#entrar').prop('disabled', false);
                }
            });
        }
    };
}());