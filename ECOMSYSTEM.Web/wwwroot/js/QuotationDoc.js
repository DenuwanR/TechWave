function QuotationListClick() {

    $.ajax({
        type: 'Get',
        url: '/SupplierQuote/UserView',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: null,
        success: function (result) {
            if (result.success == true) {
                location.replace("https://localhost:7092/SupplierQuote/UserView")
            } else {
                location.replace("https://localhost:7092/SupplierQuote/UserView")
            }
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
}
