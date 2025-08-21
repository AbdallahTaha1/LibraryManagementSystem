$(document).ready(function () {
    $(".js-delete").on("click", function () {
        var btn = $(this);
        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-2",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });

        swal.fire({
            title: "Are you sure you want to delete this user?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `users/delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            "Deleted!",
                            "The user has been deleted.",
                            "success"
                        );
                        btn.parents('tr').fadeOut('slow', function () {
                            $(this).remove();
                        });
                    },
                    error: function () {
                        swal.fire(
                            "Oops...",
                            "Something went wrong.",
                            "error"
                        );
                    }
                });
            }
        });
    });
});
