function AddProductBtn_Click() {

    let success = ValidationProductForm();

    if (success == true) {
        var productObj = {
            ProductId: $('#ProductId').val(),
            ProductName: $('#Productname').val(),
            ProductCategoryId: $('#Category').val(),
            Description: $('#Description').val(),
            Price: $('#Price').val(),
            ImageName: $('#Img').val(),
            IsActive: true
        };

        $.ajax({
            type: 'POST',
            url: '/Admin/AddProduct',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: productObj,
            success: function (result) {
                if (result.success == true) {
                    Swal.fire(
                        'Good job!',
                        'Product Saved Successfull Completed!',
                        'success'
                    )
                    refresh();
                    Clear();
                } else {
                    Swal.fire(
                        'Error!',
                        'Product Saved Failed!',
                        'error'
                    )
                    Clear();
                }
            },
            error: function () {
                alert('Failed to receive the Data');
                console.log('Failed ');
            }
        })
    }
}

function ValidationProductForm() {


    let Productname = document.getElementById("Productname").value;
    if (Productname == "") {
        Swal.fire(
            'Error!',
            'Productname must be filled out!',
            'error'
        )
        return false;
    }

    //let Category = document.getElementById("Category").value;
    //if (Category == "") {
    //    Swal.fire(
    //        'Error!',
    //        'Category must be filled out!',
    //        'error'
    //    )
    //    return false;
    //}

    let Description = document.getElementById("Description").value;
    if (Description == "") {
        Swal.fire(
            'Error!',
            'Description must be filled out!',
            'error'
        )
        return false;
    }

    let Price = document.getElementById("Price").value;
    if (Price == "") {
        Swal.fire(
            'Error!',
            'Price must be filled out!',
            'error'
        )
        return false;
    }

    return true;
}

function Clear() {
    document.getElementById('Productname').value = "";
    document.getElementById('Category').value = "";
    document.getElementById('Description').value = "";
    document.getElementById('Price').value = "";
    document.getElementById('Img').value = "";
}

function EditProductsBtn_Click(ProductId, ProductName) {
    document.getElementById("ProductId").value = ProductId;
    document.getElementById("Productname").value = ProductName;
}

function DeleteProductBtn_Click(ProductId) {

    var DeleteProduct = {
        ProductId: ProductId,
    };

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: 'POST',
                url: '/Admin/DeleteProduct',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: DeleteProduct,

                success: function (result) {
                    if (result.success) {
                        Swal.fire(
                            'Deleted!',
                            'Your product has been deleted.',
                            'success'
                        )
                        refresh();
                    }
                    else if (result.update) {
                        Swal.fire(
                            'Error!',
                            'Product Deleted Failed..!',
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

function EditProductsBtn_Click(ProductId) {
    GetProductDetails(ProductId);
}

function GetProductDetails(ProductId) {
    const editProductModal = new bootstrap.Modal(document.querySelector('#EditproductModal'));
    var GetProduct = {
        ProductId: ProductId,
    };

        $.ajax({
            type: 'Post',
            url: '/Admin/GetProductById',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: GetProduct,
            success: function (result) {
                if (result.success == true) {
                    document.getElementById("ProductId").value = result.response.productId;
                    document.getElementById("Productname").value = result.response.productName;
                    document.mdddgetElementById("Category").value = result.response.productCategoryId;
                    document.getElementById("Description").value = result.response.description;
                    document.getElementById("Price").value = result.response.price;
                    editProductModal.show();
                } else {
                    Swal.fire(
                        'Error!',
                        'Product not loaded',
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

function refresh() {
    setTimeout(function () {
        location.reload()
    }, 1000);
}


