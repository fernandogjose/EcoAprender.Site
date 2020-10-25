$(document).ready(function () {
    usuario.init();
});

var usuario = (function () {
    return {
        init: function () {
            usuario.ConfiguraTableList();
        },

        ConfiguraTableList: function () {
            $('#usuarios').dataTable({
                "pageLength": 10,
                "paging": true,
                "ordering": false,
                "info": false,
                "searching": true,
                "dom": '<"toolbar">frtip'
            });
        },

        Excluir: function (id) {
            var request = {
                Id: id,
            };

            bootbox.dialog({
                message: "Deseja realmente excluir?",
                title: "Excluir",
                buttons: {
                    success: {
                        label: "Sim",
                        className: "btn-success",
                        callback: function () {
                            $.ajax({
                                url: "/Portal-Do-Aluno/Usuario-Excluir",
                                type: "POST",
                                data: request,
                                success: usuario.ExcluirSuccess,
                            });
                        }
                    },
                    danger: {
                        label: "Nao",
                        className: "btn-danger",
                        callback: function () {

                        }
                    }
                }
            });
        },

        ExcluirSuccess: function () {
            location.reload();
        }

    };
}());