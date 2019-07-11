(function (app) {
    app.factory("PageService", function ($http) {
        var ProductPaging = function (pageno, pagesize) {
            var model = {
                Page: pageno,
                PageSize: pagesize
            };

            return $http({
                method: "POST",
                url: '/Home/ProductPageAjax',
                headers: { 'Content-Type': 'application/json;charset=utf-8' },
                data: model
            }).then(function success(response) {
                console.log(response.data);
                return response.data;
                }, function error(response) {
                console.log("hata:" + response);
            })
        }

        var CategoryPaging = function (pageno, pagesize) {
            var model = {
                Page: pageno,
                PageSize: pagesize
            };

            return $http({
                method: "POST",
                url: '/Home/CategoryPageAjax',
                headers: { 'Content-Type': 'application/json;charset=utf-8' },
                data: model
            }).then(function success(response) {
                return response.data;
            }, function error(response) {
                console.log("hata:" + response);
            })
        }

        return {
            ProductPaging: ProductPaging,
            CategoryPaging: CategoryPaging
        };
    })
}(angular.module("myApp")))