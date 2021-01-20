<script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
function successalert() {
    Swal.fire({
        title: 'Congratulation',
        text: "You have been successfully Login",
        icon: 'success',
        showCancelButton: false,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'OK'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                window.location.href = "dashboard.aspx"
            )
        }
    })
}
