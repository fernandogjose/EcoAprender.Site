$(document).ready(function () {
    adminAtividade.init();
});

var adminAtividade = (function () {
    return {
        init: function () {
            adminAtividade.ConfiguraTableList();
        },

        ConfiguraTableList: function () {
            $('#atividades').dataTable({
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
                                url: "/portal-do-aluno/admin/atividade/excluir",
                                type: "POST",
                                data: request,
                                success: adminAtividade.ExcluirSuccess,
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