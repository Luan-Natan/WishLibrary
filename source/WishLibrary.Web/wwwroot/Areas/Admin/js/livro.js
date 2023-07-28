
//Método GET para listar Livros
$(document).ready(function () {
    getDatatable('#tabela');

    $.ajax({
        type: 'GET',
        url: '/Livro/Listar',
        success: function (result) {
            $("#listarLivros").html(result);
        }
    });
})