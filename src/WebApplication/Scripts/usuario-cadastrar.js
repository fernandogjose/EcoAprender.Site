$(document).ready(function () {
    usuarioCadastrar.init();
});

var usuarioCadastrar = (function () {
    return {
        init: function () {
            usuarioCadastrar.ConfiguraFormValidate();
            usuarioCadastrar.ConfiguraEventos();
        },

        ConfiguraEventos: function () {
            $('#form').submit(usuarioCadastrar.Salvar);
        },

        ConfiguraFormValidate: function () {
            $("#form").validate({
                rules: {
                    Nome: {
                        required: true,
                        minlength: 2,
                    },
                    NomeNoBoleto: {
                        required: true,
                        minlength: 2,
                    },
                    Login: {
                        required: true,
                        minlength: 2
                    },
                    Email: {
                        required: true,
                        minlength: 2,
                        email: true
                    }
                },
                messages: {
                    Nome: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    },
                    NomeNoBoleto: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    },
                    Login: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    },
                    Email: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório",
                        email: "e-mail inválido"
                    }
                }
            });
        },

        GetFields: function(){
            var $inputs = $('#form :input');
            var request = {};
            $inputs.each(function () {
                request[this.name] = $(this).val();
            });

            return request;
        },

        Salvar: function (event) {
            $('#mensagemDeErro').addClass('hide');

            event.preventDefault();
            if (!$("#form").valid()) {
                return;
            }

            $('#salvar').html('Aguarde...');
            $('#salvar').prop('disabled', true);

            var url = $("#form").attr('action');
            var request = usuarioCadastrar.GetFields();

            $.ajax({
                type: 'POST',
                url: url,
                data: request,
                success: function (data, status) {
                    $('#salvar').html('Enviar');
                    $('#salvar').prop('disabled', false);

                    if (data !== "sucesso") {
                        $('#mensagemDeErro').removeClass('hide');
                        $('#mensagemDeErro').html(data.Mensagem);

                        setTimeout(function () {
                            $('#mensagemDeErro').addClass('hide');
                        }, 300000);

                        return;
                    }
                    
                    // similar behavior as clicking on a link
                    window.location.href = "/Portal-Do-Aluno/Usuario";
                },
                error: function (xmlHttpRequest, status, err) {
                    $('#salvar').html('Enviar');
                    $('#salvar').prop('disabled', false);
                }
            });
        }

    };
}());