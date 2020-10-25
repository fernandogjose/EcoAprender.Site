$(document).ready(function () {
    uploadFiles.init();
});

var uploadFiles = (function () {
    return {
        linhaSelecionada: "",
        init: function () {

            //$('.upload-fotos').hide();

            //var id = $('#Id').val();
            //if (id > 0) {
            //    $('.upload-fotos').show();
            //}

            $('#fileupload').fileupload({
                url: '/portal-do-aluno/admin/atividade/upload-file',
                dataType: 'json',
                done: function (e, data) {
                    $('#fotos tbody tr:last').after(
                        '<tr>' +
                        '   <td class="td-foto-anuncio"><img class="img-responsive img-thumbnail" style="max-width: 200px" src="' + data.result.CaminhoDoArquivo + '" /></td>' +
                        '   <td class="td-foto-anuncio capa">não</td>' +
                        '   <td class="td-foto-anuncio resumo">não</td>' +
                        '   <td class="td-foto-anuncio"><button class="btn btn-danger" type="button" onclick="uploadFiles.removerFoto(this)" rel="' + data.result.NomeDoArquivo + '" data-id="' + data.result.Id + '">Remover</button>' +
                        '                               <button class="btn btn-warning" type="button" onclick="uploadFiles.selecionarFotoCapa(this)" rel="' + data.result.NomeDoArquivo + '" data-id="' + data.result.Id + '">Selecionar Foto Capa</button>' +
                        '                               <button class="btn btn-success" type="button" onclick="uploadFiles.selecionarFotoResumo(this)" rel="' + data.result.NomeDoArquivo + '" data-id="' + data.result.Id + '">Selecionar Foto Resumo</button></td>' +
                        '</tr>');
                },
            }).prop('disabled', !$.support.fileInput)
                .parent().addClass($.support.fileInput ? undefined : 'disabled');
        },

        removerFoto: function (linha) {
            uploadFiles.linhaSelecionada = linha;

            var tr = $(uploadFiles.linhaSelecionada).closest("tr");
            var capa = tr.find('.capa').html().trim();
            var resumo = tr.find('.resumo').html().trim();

            if (capa === 'sim' || resumo === 'sim') {
                alert("A foto não pode ser removida por que ela esta sendo usada como foto capa ou foto resumo");
                return;
            }

            var atividade = {
                Id: $(linha).attr("data-id"),
                Arquivo: $(linha).attr("rel")
            };

            $.ajax({
                type: "POST",
                url: "/portal-do-aluno/admin/atividade/excluir-foto/",
                data: atividade,
                success: function (data, status) {
                    var tr = $(uploadFiles.linhaSelecionada).closest("tr");
                    tr.fadeOut(400, function () {
                        tr.remove();
                    });
                    return false;
                },
                error: function (xmlHttpRequest, status, err) { }
            });
        },

        selecionarFotoCapa: function (linha) {
            uploadFiles.linhaSelecionada = linha;
            var atividade = {
                Id: $(linha).attr("data-id"),
                FotoCapa: $(linha).attr("rel")
            };

            $.ajax({
                type: "POST",
                url: "/portal-do-aluno/admin/atividade/selecionar-foto-capa/",
                data: atividade,
                success: function (data, status) {

                    $('.capa').html('não');

                    var tr = $(uploadFiles.linhaSelecionada).closest("tr");
                    tr.find('.capa').html('sim');
                    return false;
                },
                error: function (xmlHttpRequest, status, err) { }
            });
        },

        selecionarFotoResumo: function (linha) {
            uploadFiles.linhaSelecionada = linha;
            var atividade = {
                Id: $(linha).attr("data-id"),
                FotoResumo: $(linha).attr("rel")
            };

            $.ajax({
                type: "POST",
                url: "/portal-do-aluno/admin/atividade/selecionar-foto-resumo/",
                data: atividade,
                success: function (data, status) {

                    $('.resumo').html('não');

                    var tr = $(uploadFiles.linhaSelecionada).closest("tr");
                    tr.find('.resumo').html('sim');
                    return false;
                },
                error: function (xmlHttpRequest, status, err) { }
            });
        }

    };
}());