$(document).ready(function () {
    adminComunicado.init();
});

var adminComunicado = (function () {
    return {
        init: function () {
            adminComunicado.ConfiguraTableList();
        },

        ConfiguraTableList: function () {
            $('#comunicados').dataTable({
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
                                url: "/portal-do-aluno/admin/comunicado/excluir",
                                type: "POST",
                                data: request,
                                success: adminComunicado.ExcluirSuccess,
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