$(document).ready(function () {
    adminComunicadoCadastrar.init();
});

var adminComunicadoCadastrar = (function () {
    return {
        init: function () {
            adminComunicadoCadastrar.ConfiguraFormValidate();
            adminComunicadoCadastrar.ConfiguraEventos();
        },

        ConfiguraEventos: function () {
            $('#form').submit(adminComunicadoCadastrar.Salvar);
        },

        ConfiguraFormValidate: function () {
            $("#form").validate({
                rules: {
                    Data: {
                        required: true,
                    },
                    Titulo: {
                        required: true,
                    },
                    Descricao: {
                        required: true,
                    }
                },
                messages: {
                    Data: {
                        required: "campo obrigatório"
                    },
                    Titulo: {
                        required: "campo obrigatório"
                    },
                    Descricao: {
                        required: "campo obrigatório"
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

            request['Confirmar'] = $('#Confirmar').is(":checked");
            
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
            var request = adminComunicadoCadastrar.GetFields();
            request.Descricao = tinyMCE.get('Descricao').getContent()

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
                    
                    window.location.href = "/portal-do-aluno/admin/comunicado";
                },
                error: function (xmlHttpRequest, status, err) {
                    $('#salvar').html('Enviar');
                    $('#salvar').prop('disabled', false);
                }
            });
        }

    };
}());