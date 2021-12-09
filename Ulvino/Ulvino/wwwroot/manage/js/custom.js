$(document).ready(function () {
    $(document).on("click", ".btn-item-delete", function (e) {
        e.preventDefault();

        var url = $(this).attr("href");

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
                fetch(url)
                    .then(response => response.json())
                    .then(data => {
                        if (data.status == 200) {
                            window.location.reload(true)
                        }
                        else {
                            Swal.fire(
                                'Error!',
                                'Your file has not been deleted!',
                                'error'
                            )
                        }
                    })

            }
        })

    })

    $(document).on("click", ".remove-img-box", function () {
        $(this).parent().remove()
    })


})