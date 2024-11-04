function AddtoCartBtn_Click() {

    let itemDescription = "Processor :" + document.getElementById("Processor").value + "," + "Motherboard :" + document.getElementById("Motherboard").value + "," + "RAM :" + document.getElementById("RAM").value + "," + "VGA :" + document.getElementById("VGA").value + "," + "HDD :" + document.getElementById("HDD").value;

    var loginObj = {
        ProductId: document.getElementById("ProductId").innerHTML,
        ItemPrice: document.getElementById("totalPrice").innerHTML,
        ItemName: document.getElementById("Productname").innerHTML,
        ItemQty: document.getElementById("QTY").value,
        ItemDescription: itemDescription,
        IsActive: true,
        IsInCart: true
    };

    $.ajax({
        type: 'POST',
        url: '/Order/AddItemCart',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: loginObj,
        success: function (result) {
            if (result.success == true) {
                Swal.fire(
                    'Success!',
                    'Item Added Successfully!',
                    'success'
                )
            } else {
                Swal.fire(
                    'Error!',
                    'Item not Added',
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

function ItemCartClick() {

    $.ajax({
        type: 'Get',
        url: '/Order/ItemCart',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: null,
        success: function (result) {
            if (result.success == true) {
                location.replace("https://localhost:7092/order/ItemCart")

                var columnIndex = 1;

                var table = document.getElementById('cartTbl');
                var cells = table.querySelectorAll('tbody tr td:nth-child(' + (columnIndex + 5) + ')');

                // Iterate over the selected cells and retrieve their values
                for (var i = 0; i < cells.length; i++) {
                    var cellValue = cells[i].textContent /*|| cells[i].innerText*/;
                    cellValue =+ cellValue ;
                }
            } else {
                location.replace("https://localhost:7092/order/ItemCart")
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
}

function ItemRemove_Click(itemId) {
    var DeleteItem = {
        ItemId: itemId,
    };

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, remove it!'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: 'POST',
                url: '/Order/RemoveItem',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: DeleteItem,

                success: function (result) {
                    if (result.success) {
                        Swal.fire(
                            'Deleted!',
                            'Your Item has been deleted.',
                            'success'
                        )
                        refresh();
                    }
                    else if (result.update) {
                        Swal.fire(
                            'Error!',
                            'Item Deleted Failed..!',
                            'error'
                        )
                    }
                },
                error: function () {
                    alert('Failed to receive the Data');
                    console.log('Failed ');
                    alert(result);
                },
            })
        }
    })
}

function SendMyInbox_click(itemCount) {
    const ordersaveModal = new bootstrap.Modal(document.querySelector('#verifyModalContent'));
    clear();
    if (itemCount > 1) {
        Swal.fire(
            'Warning!',
            'Please add one item for a order.',
            'warning'
        )
        return;
    } else if (itemCount < 1) {
        Swal.fire(
            'Warning!',
            'Please add a order.',
            'warning'
        )
        return;
    }
    ordersaveModal.show();
}

//function SendMailbtn_click(itemId) {
//    var loginObj = {
//        ProductId: document.getElementById("ProductId").innerHTML,
//        ItemPrice: document.getElementById("totalPrice").innerHTML,
//        ItemName: document.getElementById("Productname").innerHTML,
//        ItemQty: document.getElementById("QTY").value,
//        IsActive: true,
//        IsInCart: true
//    };

//    $.ajax({
//        type: 'POST',
//        url: '/Order/SaveOrderDetails',
//        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
//        data: loginObj,
//        success: function (result) {
//            if (result.success == true) {
//                Swal.fire(
//                    'Success!',
//                    'Item Added Successfully!',
//                    'success'
//                )
//            } else {
//                Swal.fire(
//                    'Error!',
//                    'Item not Added',
//                    'error'
//                )
//            }
//        },
//        error: function () {
//            alert('Failed to receive the Data');
//            console.log('Failed ');
//        }
//    })
//}

function refresh() {
    setTimeout(function () {
        location.reload()
    }, 1000);
}


function clear() {
    document.getElementById("name").value = "";
    document.getElementById("mobile").value = "";
    document.getElementById("email").value = "";
    document.getElementById("address").value = "";
}