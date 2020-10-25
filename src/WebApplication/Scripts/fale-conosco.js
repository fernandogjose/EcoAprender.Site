$(document).ready(function () {
    FaleConosco.Init();
});

var FaleConosco = (function () {
    return {
        Init: function () {
            FaleConosco.ConfiguraFormValidate();
            FaleConosco.ConfiguraEventos();
        },

        ConfiguraEventos: function () {
            $('#form').submit(FaleConosco.Enviar);
        },

        ConfiguraFormValidate: function () {
            $("#form").validate({
                rules: {
                    nome: {
                        required: true,
                        minlength: 2,
                    },
                    assunto: {
                        required: true,
                        minlength: 2
                    },
                    telefone: {
                        required: true,
                        minlength: 2
                    },
                    email: {
                        required: true,
                        minlength: 2,
                        email: true
                    },
                    mensagem: {
                        required: true,
                        minlength: 2
                    }
                },
                messages: {
                    nome: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    },
                    assunto: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    },
                    telefone: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    },
                    email: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório",
                        email: "e-mail inválido"
                    },
                    mensagem: {
                        required: "campo obrigatório",
                        minLength: "campo obrigatório"
                    }
                }
            });
        },

        LimparCampos: function(){
           $('#nome').val('');
           $('#assunto').val('');
           $('#telefone').val('');
           $('#email').val('');
           $('#mensagem').val('');
        },

        Enviar: function (event) {
            $('.alerta-login').addClass('hide');

            event.preventDefault();
            if (!$("#form").valid()) {
                return;
            }

            $('#enviar').html('Aguarde...');
            $('#enviar').prop('disabled', true);

            var nome = $('#nome').val();
            var assunto = $('#assunto').val();
            var telefone = $('#telefone').val();
            var email = $('#email').val();
            var mensagem = $('#mensagem').val();
            var url = $("#form").attr('action');
            var request = {
                Nome: nome,
                Assunto: assunto,
                Telefone: telefone,
                Email: email,
                Mensagem: mensagem
            };

            $.ajax({
                type: 'POST',
                url: url,
                data: request,
                success: function (data, status) {
                    $('#enviar').html('Enviar');
                    $('#enviar').prop('disabled', false);

                    if (data !== "sucesso") {
                        $('.alerta-login').html('Falha ao enviar seu e-mail, favor tentar novamente mais tarde.');

                        setTimeout(function () {
                            $('.alerta-login').addClass('hide');
                        }, 300000);
                    }

                    $('.alerta-login').removeClass('hide');
                    $('.alerta-login').html('e-mail enviado com sucesso!');

                    FaleConosco.LimparCampos();
                },
                error: function (xmlHttpRequest, status, err) {
                    $('#enviar').html('Enviar');
                    $('#enviar').prop('disabled', false);
                }
            });
        }
    };
}());