//This method, verifies that the user can use the control panel.
function UserValidate() {
    var username = document.getElementById("txtUsername").value;
    var password = document.getElementById("txtPassword").value;
    if (username == null || username == "", password == null || password == "") {
        alert('error');
    } else {
        $.ajax({
            type: 'POST',
            url: "/Data/UserValidation",
            data: '{"username":"' + username + '","password":"' + password + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (user_id) {
                if (user_id > 0) {
                    window.location.href = "../Home/ControlPanel";
                } else {
                    alert("User Validation Unsuccesful!")
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('error');
            }
        })
    }
}