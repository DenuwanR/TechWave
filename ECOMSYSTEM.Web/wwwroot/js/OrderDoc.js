var OrderId;
var UserId;
var SupplierId;


function GetOrderBtn_Click(orderId, userId) {

    var GetOrderBtn = document.getElementById("getorderbtn");

    var OrderObj = {
        OrderId: orderId,
        UserId: userId
    }
    $.ajax({
        type: 'POST',
        url: '/Supplier/UpdateOrder',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: OrderObj,
        success: function (result) {
            if (result.success == true) {
                Swal.fire(
                    'Good job!',
                    'Order Accepted Successfull Completed!',
                    'success'
                )
                refresh();

            } else {
                Swal.fire(
                    'Error!',
                    'Order Accept Failed!',
                    'error'
                )
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
}

function ChangeStatus_Click(orderId, userId, supplierId) {
    const statusModal = new bootstrap.Modal(document.querySelector('#ChangeStatusModalContent'));
    OrderId = orderId;
    UserId = userId;
    SupplierId = supplierId;

    statusModal.show();
}

function SaveStatus_click() {

    let status = document.getElementById("status").value
    var OrderObj = {
        OrderId: OrderId,
        UserId: UserId,
        SupplierId: SupplierId,
        OrderStatus: status
    }
    $.ajax({
        type: 'POST',
        url: '/Supplier/UpdateOrderStatus',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: OrderObj,
        success: function (result) {
            if (result.success == true) {
                Swal.fire(
                    'Good job!',
                    'Order Accepted Successfull Completed!',
                    'success'
                )
                refresh();

            } else {
                Swal.fire(
                    'Error!',
                    'Order Accept Failed!',
                    'error'
                )
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
}

function SendMailbtn_click(itemId)
{
    let success = ValidationMailForm();

    if (success == true) {

        let name = document.getElementById("name").value
        let mobile = document.getElementById("mobile").value
        let email = document.getElementById("email").value
        let address = document.getElementById("address").value

        var OrderObj = {
            ItemId: itemId,
            Name: name,
            Mobile: mobile,
            Email: email,
            Address: address
        }
        $.ajax({
            type: 'POST',
            url: '/Order/SaveOrderDetails',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: OrderObj,
            success: function (result) {
                if (result.success == true) {
                    Swal.fire(
                        'Good job!',
                        'Order Details Saved Successfull Completed. Check your email..',
                        'success'
                    )
                    refresh();

                } else {
                    Swal.fire(
                        'Error!',
                        'Something went wrong!',
                        'error'
                    )
                }
            },
            error: function () {
                alert('Failed to receive the Data');
                console.log('Failed ');
            }
        })
    } 
}

function ValidationMailForm() {

    let Name = document.getElementById("name").value;
    if (Name == "") {
        Swal.fire(
            'Error!',
            'Name must be filled out!',
            'error'
        )
        return false;
    }

    let Email = document.getElementById("email").value;
    if (Email == "") {
        Swal.fire(
            'Error!',
            'Email must be filled out!',
            'error'
        )
        return false;
    }

    let Mobile = document.getElementById("mobile").value;
    if (Mobile == "") {
        Swal.fire(
            'Error!',
            'Mobile must be filled out!',
            'error'
        )
        return false;
    }

    let Address = document.getElementById("address").value;
    if (Address == "") {
        Swal.fire(
            'Error!',
            'Address must be filled out!',
            'error'
        )
        return false;
    }

    return true;
}

function CancelBtn_Click(orderId, userId, supplierId) {

    var OrderObj = {
        OrderId: orderId,
        UserId: userId,
        SupplierId: supplierId,
    }
    $.ajax({
        type: 'POST',
        url: '/Supplier/CancelOrder',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: OrderObj,
        success: function (result) {
            if (result.success == true) {
                Swal.fire(
                    'Good job!',
                    'Order Cancel Successfull Completed...',
                    'success'
                )
                refresh();

            } else {
                Swal.fire(
                    'Error!',
                    'Something went wrong!',
                    'error'
                )
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
}

//function OrderListClick() {

//    $.ajax({
//        type: 'Get',
//        url: '/Order/OrderList',
//        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
//        data: null,
//        success: function (result) {
//            if (result.success == true) {
//                location.replace("https://localhost:7092/Order/OrderList")
//            } else {
//                location.replace("https://localhost:7092/Order/OrderList")
//            }
//        },
//        error: function () {
//            alert('Failed to receive the Data');
//            console.log('Failed ');
//        }
//    })
//}

function OrderListClick() {

    $.ajax({
        type: 'Get',
        url: '/Quotation/ViewQuotations',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: null,
        success: function (result) {
            if (result.success == true) {
                location.replace("https://localhost:7092/Quotation/ViewQuotations")
            } else {
                location.replace("https://localhost:7092/Quotation/ViewQuotations")
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
}

function refresh() {
    setTimeout(function () {
        location.reload()
    }, 1000);
}

