// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

let dataSourceAlbums = new kendo.data.DataSource({
    batch: false,
    pageSize: 0,
    serverPaging: false,
    serverSorting: false,
    serverFiltering: false,
    error: function (e) {
        Swal.fire({
            title: 'Error!',
            text: e,
            icon: 'error',
            confirmButtonText: 'Ok'
        });
    },
    schema: {
        total: function (response) {
            return response.length;
        },
        model: {
            id: "Id",
            fields: {
                albumId: { type: "number", nullable: false, editable: false },
                title: { type: "string", nullable: false, editable: false }
            }
        }
    },
    transport: {
        read: {
            type: "GET",
            dataType: "json",
            accepts: "application/json",
            contentType: "application/json; charset=utf-8",
            url: "/api/Albums/ObtenerTodos",
            cache: false
        },
        parameterMap: function (options, operation) {
            if (operation === "read") {
                return kendo.stringify(options);
            }
        }
    },
    requestStart: function (e) {
        $("html, body").css("cursor", "wait");
        kendo.ui.progress($("#homeIndex"), true);
        return;
    },
    requestEnd: function (e) {
        $("html, body").css("cursor", "auto");
        kendo.ui.progress($("#homeIndex"), false);
        return;
    }
});
let viewModel = kendo.observable({
    dsAlbums: dataSourceAlbums,
    clickBtnBoton1: function (e) {
        Swal.fire({
            title: 'Error!',
            text: 'Alerta de error ...',
            icon: 'error',
            confirmButtonText: 'Ok'
        });
    },
    clickBtnAlbum: function (e) {
        let id = e.data.albumId;

        Swal.fire({
            title: '',
            text: 'Id del album: ' + id,
            icon: 'info',
            confirmButtonText: 'Ok'
        });
    }
});
kendo.bind($("#homeIndex"), viewModel);
