var productsPaged = new DevExpress.data.CustomStore({
    load: function (loadOptions) {
        var def = $.Deferred();

        var oProduct = {
            ProductName: '',
            SupplierID: 0,
            CategoryID: 0
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
        paging: true
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
        hidingPriority: 0
    },
    {
        dataField: 'UnitPrice',
        caption: 'Precio',
        format: {
            type: 'fixedPoint',
            precision: 2
        },
        width: 100
    },
    {
        dataField: 'UnitsInStock',
        caption: 'En Stock',
        width: 100,
        hidingPriority: 2
    },
    {
        dataField: 'UnitsOnOrder',
        caption: 'En Orden',
        width: 100,
        hidingPriority: 1
    },
    {
        caption: '',
        alignment: 'center',
        width: 80,
        cellTemplate: function (container, options) {
            $('<div class="row">').appendTo(container);
            $('<div class="col-md-6">').appendTo(container.find('.row'));
            $('<a href="#" data-toggle="modal" data-target="#modal-container" onclick="getModal(' + options.data.ProductID + ')" > <span class="glyphicon glyphicon-edit">').appendTo(container.find('.col-md-6'));

            //$('<span id="e_' + options.data.ProductID + '" class="glyphicon glyphicon-edit" >').appendTo(container.find('.col-md-6'))
            //    .on('click', function (e) {
            //        var param = {
            //            Id: $(this).attr('id').replace('e_', '')
            //        };
            //        $.get('/Product/Edit', param, function (data) {
            //            $('.modal-body').html(data);
            //            $('.modal-title').html('Editar Producto');                        
            //        });
            //    });

            //$('<div class="col-md-6">').appendTo(container.find('.row'));
            //$('<span id="d_' + options.data.ProductID + '" class="glyphicon glyphicon-trash">').appendTo(container.find('.col-md-6:last-child'))
            //    .on('click', function (e) {

            //    });
        }
    }
    ]
}).dxDataGrid('instance');

function getModal(ProductId) {
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
            selectButtonText: "Seleccione Imagen",
            uploadUrl: "/Product/UploadFile",
            onUploaded: function (value) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    byteImg = e.target.result;
                    $('#imgProduct').attr('src', `data:image/png;base64,${btoa(e.target.result)}`);
                };
                reader.readAsBinaryString(value.file);
            }
        });
    });
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

//var byteImg;
//function loadIamge(file) {
//    if (file.files && file.files[0]) {
//        var reader = new FileReader();
//        reader.onload = function (e) {
//            byteImg = e.target.result;
//            $('#imgProduct').attr('src', `data:image/png;base64,${btoa(e.target.result)}`);
//        };

//        reader.readAsBinaryString(file.files[0]);
//    }
//}

//$('.btn-primary').click(function () {

//    var param = {
//        entity: {
//            ProductID: $('#ProductID').val(),
//            ProductName: $('#ProductName').val(),
//            SupplierID: $('#SupplierID').val(),
//            CategoryID: $('#CategoryID').val(),
//            QuantityPerUnit: $('#QuantityPerUnit').val(),
//            UnitPrice: $('#UnitPrice').val(),
//            UnitsInStock: $('#UnitsInStock').val(),
//            UnitsOnOrder: $('#UnitsOnOrder').val(),
//            ReorderLevel: $('#ReorderLevel').val(),
//            Discontinued: $('#Discontinued').val()
//            //Picture: byteImg
//        },
//        picture: byteImg
//    };

//    $.post('/Product/Edit', param, function (data) {

//        success(data);
//    });
//});