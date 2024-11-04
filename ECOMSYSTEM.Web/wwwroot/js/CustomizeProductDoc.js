function CustomizationBtn_Click(ProductId) {
    Clear();
    GetProductDetails(ProductId);
}

function GetProductDetails(ProductId) {
    const custormizeModal = new bootstrap.Modal(document.querySelector('#exampleModalCenter'));

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
                document.getElementById("ProductId").innerHTML = result.response.productId;
                document.getElementById("Productname").innerHTML = result.response.productName;
                document.getElementById("Description").innerHTML = result.response.description;
                document.getElementById("Price").innerHTML = result.response.price + ".00";
                document.getElementById("Image").src = "https://localhost:7092/Image/" + result.response.imageName;
                document.getElementById("totalPrice").innerHTML = result.response.price;
                custormizeModal.show();
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

function Price() {

    let amount = document.getElementById("Price").textContent;
    var processorValue = document.getElementById("Processor").value;
    var motherboardValue = document.getElementById("Motherboard").value;
    var ramValue = document.getElementById("RAM").value;
    var vgaValue = document.getElementById("VGA").value;
    var hddValue = document.getElementById("HDD").value;

    document.getElementById("totalPrice").innerHTML = parseInt(amount) + parseInt(processorValue) + parseInt(motherboardValue) + parseInt(ramValue) + parseInt(vgaValue) + parseInt(hddValue);
}

function Clear() {
    document.getElementById("Processor").selectedIndex = 0;
    document.getElementById("Motherboard").selectedIndex = 0;
    document.getElementById("RAM").selectedIndex = 0;
    document.getElementById("VGA").selectedIndex = 0;
    document.getElementById("HDD").selectedIndex = 0;
}

