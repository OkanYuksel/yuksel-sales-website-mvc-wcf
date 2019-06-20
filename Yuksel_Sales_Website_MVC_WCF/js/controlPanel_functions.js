var dataList = [];
var count = -1;

var app = angular.module("myApp", []);

app.controller("myCtrl", function ($scope, $http) {

    //Calls products with a quantity greater than 0
    $http({
        method: "GET",
        url: "http://localhost:38456/Service.svc/json/getProducts",
    }).then(function mySucces(response) {
        var jsonData = JSON.parse(response.data.substring(response.data.lastIndexOf("["), response.data.lastIndexOf("]") + 1));
        $scope.records = jsonData;
    }, function myError(error) {
        alert(error);
    });


    //The update method can be used when updating products.
    $scope.updateProduct = function (item) {
        alert($scope.records[item].product_code);
        alert(tableProducts.rows[item].cells[4].children[0].value);
    }


});


//Singular product add -> Products table
function AddNewProductFunction() {
    var prod_name = document.getElementById("txtAddProductName").value
    var prod_price = document.getElementById("txtAddProductPrice").value
    var prod_stock = document.getElementById("txtAddProductStock").value
    var prod_description = document.getElementById("txtAddProductDescription").value

    if (prod_name == null || prod_name == "", prod_price == null || prod_price == "", prod_stock == null || prod_stock == "", prod_description == null || prod_description == "") {
        alert("Values are invalid.");
    }
    else {
        var product = { product_name: prod_name, product_price: prod_price, product_stock_count: prod_stock, product_description: prod_description };
        $.ajax({
            type: 'POST',
            url: "/Data/AddNewProduct",
            data: JSON.stringify(product),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                $(function () {
                    alert("Success");
                    document.location.reload(true);
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('error');
            }
        })
    }
}

function AddNewProductFormCleaner() {
    document.getElementById("txtAddProductName").value = "";
    document.getElementById("txtAddProductPrice").value = 1;
    document.getElementById("txtAddProductStock").value = 1;
    document.getElementById("txtAddProductDescription").value = "";
}

function updateModalLoaderFunc(event) {
    var product_code = event.currentTarget.getAttribute('attr.data-id');
    var product_stock_count = event.currentTarget.getAttribute('attr.data-count')
    document.getElementById("txtProductCode").value = product_code;
    document.getElementById("txtProductCode").readOnly = true;
    document.getElementById("inputStockCount").value = product_stock_count;
}

function UpdateCompleteFunction() {
    var product_code = document.getElementById("txtProductCode").value;
    var product_new_stock_count = document.getElementById("inputStockCount").value;
    var product = { product_code: product_code, product_stock_count: product_new_stock_count};
    $.ajax({
        type: 'POST',
        url: "/Data/UpdateProductStock",
        data: JSON.stringify(product),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $(function () {
                alert("Success");
                document.location.reload(true);
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('error');
        }
    })
}

function ProductDeleteFunction() {
    var product_code = document.getElementById("txtProductCode").value;
    var product = { product_code: product_code};
    $.ajax({
        type: 'POST',
        url: "/Data/DeleteProduct",
        data: JSON.stringify(product),
        contentType: "application/json; charset=utf-8",
        success: function (msg) {
            $(function () {
                alert("Success");
                document.location.reload(true);
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('error');
        }
    })
}
