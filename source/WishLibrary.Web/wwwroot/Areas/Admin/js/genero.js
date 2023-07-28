
//Método GET para listar Generos
$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '/Genero/Listar',
        success: function (result) {
            $("#listarGeneros").html(result);
        }
    });
})