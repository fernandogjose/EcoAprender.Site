$(document).ready(function () {
    comunicado.init();
});

var comunicado = (function () {
    return {
        init: function () {
            $('.exibir-comunicado').click(comunicado.exibirComunicado)
        },

        exibirComunicado: function () {
            bootbox.dialog({
                message: $(this).attr('data-descricao'),
                title: $(this).attr('data-titulo'),
                buttons: {
                    main: {
                        label: "OK",
                        className: "btn-success"
                    }
                }
            });
        }
    };
}());