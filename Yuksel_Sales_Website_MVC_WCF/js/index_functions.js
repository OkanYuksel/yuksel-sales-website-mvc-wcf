var app = angular.module("myApp", ["angularUtils.directives.dirPagination"]);

$(document).on("click", ".open-homeEvents", function (event) {
    var eventId = event.target.getAttribute('attr.data-id');
    document.getElementById("txtProductCode").value = eventId;
    document.getElementById("txtProductCode").readOnly = true;
});

//Product Sale, service checks the stocks. If it is enough, it performs sales.
function SalesCompleteFunction() {
    var product_code = document.getElementById("txtProductCode").value;
    var sales_count = document.getElementById("inputSalesCount").value;
    if (product_code == null || product_code == "", sales_count == null || sales_count == "") {
        alert('error');
    } else {
        $.ajax({
            type: 'POST',
            url: "/Data/BuyProduct",
            data: '{"product_code":"' + product_code + '","sales_count":"' + sales_count + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                $(function () {
                    alert(JSON.parse(msg).buyProductResult);
                    $("[data-dismiss=modal]").trigger({ type: "click" });
                    document.location.reload(true);
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('error');
            }
        })
    }
}
