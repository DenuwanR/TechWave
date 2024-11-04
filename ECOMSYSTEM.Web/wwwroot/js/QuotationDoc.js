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
