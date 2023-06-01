const showSuccessOrErrorMessage = () => {
    if (successMessage) {
        showToasterMessage(successMessage, "info");
    }
    if (errorMessage) {
        showToasterMessage(errorMessage, "danger");
    }
}

const showToasterMessage = (message, className) => {
    Toastify({
        text: message,
        className: className,
        style: {
            background: "linear-gradient(to right, #00b09b, #96c93d)",
        }
    }).showToast();
}



$(document).ready(function () {

    showSuccessOrErrorMessage();

    $('.social_data_table').DataTable(
        {
            language: {
                paginate: {
                    next: '<i class="fa fa-fw fa-long-arrow-right">',
                    previous: '<i class="fa fa-fw fa-long-arrow-left">'
                }
            }
        }
    );
})