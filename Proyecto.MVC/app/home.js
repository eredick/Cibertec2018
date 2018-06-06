var itemNum = 9
function init() {

    var oProduct = {
        ProductName: "",
        CategoryName: ""
    };
    var param = {
        product: oProduct,
        itemNum: itemNum
    };
    
    $.get('/Home/Count', param, function (data) {
        var paginas = data;
        $(".pagination").bootpag({
            total: paginas,
            page: 1,
            maxVisible: 5
        }).on('page', function (event, num) {
            getCustomers(num, oProduct);
        });
        getCustomers(1, oProduct);
    });
}

function getCustomers(page, product) {
    var param = {
        product: product,
        page: page,
        itemNum: itemNum
    };
    var url = "/Home/GetList";
    $.get(url, param, function (data) {
        $(".productList").html(data);
    });
}