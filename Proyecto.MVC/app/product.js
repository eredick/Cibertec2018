﻿var productsPaged = new DevExpress.data.CustomStore({
    load: function (loadOptions) {
        var def = $.Deferred();
        var prodName = '', catName = '';
        if (loadOptions.filter) {
            if (Array.isArray(loadOptions.filter[0])) {
                $.each(loadOptions.filter, function (index, value) {
                    if (value.length > 0) {
                        switch (value[0]) {
                            case 'ProductName':
                                prodName = value[2];
                                break;
                            case 'CategoryName':
                                catName = value[2];
                                break;
                        }
                    }
                });
            } else {
                var value = loadOptions.filter;
                switch (value[0]) {
                    case 'ProductName':
                        prodName = value[2];
                        break;
                    case 'CategoryName':
                        catName = value[2];
                        break;
                }
            }
        }
        var oProduct = {
            ProductName: prodName,
            CategoryName: catName
        };
        var start = loadOptions.skip;
        var end = loadOptions.take;
        var param = {
            entity: oProduct,
            start: start,
            end: end
        };

        $.post('/Product/GetProductsPaged', param, function (data) {
            def.resolve(data.lProducts, { totalCount: data.count });
        }, 'json');
        return def.promise();
    }
});

$('#dgProducts').dxDataGrid({
    dataSource: {
        store: productsPaged
    },
    remoteOperations: {
        paging: true,
        filtering: true
    },
    filterRow: {
        visible: true,
        applyFilter: "auto",
        showOperationChooser: false
    },
    paging: {
        pageSize: 20
    },
    columns: [{
        dataField: 'ProductName',
        caption: 'Producto'
    },
    {
        dataField: 'CategoryName',
        caption: 'Categoría',
        width: 150,
        hidingPriority: 3
    },
    {
        dataField: 'QuantityPerUnit',
        caption: 'CantidadxUnidad',
        width: 150,
        hidingPriority: 0,
        allowFiltering: false
    },
    {
        dataField: 'UnitPrice',
        caption: 'Precio',
        format: {
            type: 'fixedPoint',
            precision: 2
        },
        allowFiltering: false,
        width: 100
    },
    {
        dataField: 'UnitsInStock',
        caption: 'En Stock',
        width: 100,
        hidingPriority: 2,
        allowFiltering: false
    },
    {
        dataField: 'UnitsOnOrder',
        caption: 'En Orden',
        width: 100,
        hidingPriority: 1,
        allowFiltering: false
    },
    {
        caption: '',
        alignment: 'center',
        width: 80,
        cellTemplate: function (container, options) {
            $('<div class="row">').appendTo(container);
            $('<div class="col-md-6">').appendTo(container.find('.row'));
            $('<a href="#" data-toggle="modal" data-target="#modal-container" onclick="getModal(' + options.data.ProductID + ')" > <span class="glyphicon glyphicon-edit">').appendTo(container.find('.col-md-6'));

            //$('<div class="col-md-6">').appendTo(container.find('.row'));
            //$('<span id="d_' + options.data.ProductID + '" class="glyphicon glyphicon-trash">').appendTo(container.find('.col-md-6:last-child'))
            //    .on('click', function (e) {

            //    });
        }
    }
    ]
}).dxDataGrid('instance');

function getModal(ProductId) {

    if (ProductId) {
        var param = {
            Id: ProductId
        };

        $.get('/Product/Edit', param, function (data) {
            $('.modal-body').html(data);
            $('.modal-title').html('Editar Producto');
            $('#fUpload').dxFileUploader({
                accept: "image/*",
                labelText: "",
                name: "imgFile",
                selectButtonText: "Cambiar Imagen",
                icon: "update",
                uploadUrl: "/Product/UploadFile",
                onUploaded: function (value) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#imgProduct').attr('src', `data:image/png;base64,${btoa(e.target.result)}`);
                    };
                    reader.readAsBinaryString(value.file);
                }
            });
        });
    }
    else {
        $.get('/Product/Create', param, function (data) {
            $('.modal-body').html(data);
            $('.modal-title').html('Registrar Producto');
            $('#fUpload').dxFileUploader({
                accept: "image/*",
                labelText: "",
                name: "imgFile",
                selectButtonText: "Cambiar Imagen",
                icon: "update",
                uploadUrl: "/Product/UploadFile",
                onUploaded: function (value) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#imgProduct').attr('src', `data:image/png;base64,${btoa(e.target.result)}`);
                    };
                    reader.readAsBinaryString(value.file);
                }
            });
        });
    }

}

function success(data) {
    closeModal(data.option);
}

function closeModal(option) {
    $("button[data-dismiss='modal']").click();
    $(".modal-body").html("");
    $(".modal-title").html("");
    $('#dgProducts').dxDataGrid('instance').refresh();
}
