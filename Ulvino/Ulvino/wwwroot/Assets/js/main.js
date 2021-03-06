// Header section start
const accountIcon = document.querySelector('.header-fixed .fa-user')
const accountBox = document.querySelector('.account-box-main')
const cartIcon = document.querySelector('.header-fixed .fa-shopping-cart')
const cartBox = document.querySelector('.cart-box')

accountIcon.onmouseover=function(){
    accountBox.classList.add('active')

}
accountIcon.onmouseout=function(){
    accountBox.classList.remove('active')

}
accountBox.onmouseover=function(){
    accountBox.classList.add('active')

}
accountBox.onmouseout=function(){
    accountBox.classList.remove('active')

}

cartIcon.onmouseover=function(){
    cartBox.classList.add('active')

}
cartIcon.onmouseout=function(){
    cartBox.classList.remove('active')

}
cartBox.onmouseover=function(){
    cartBox.classList.add('active')

}
cartBox.onmouseout=function(){
    cartBox.classList.remove('active')

}



// Header section finish

///////////////////////////////////////

// Scroll button start

const scrollTop = document.querySelector('.scroll-top');

scrollTop.onclick = function(e){
    e.preventDefault();
    window.scrollTo({
        top: 0,
        left: 0,
        behavior: 'smooth'
      });
}

window.addEventListener("scroll", () => {
    if (window.pageYOffset > 200) {
        scrollTop.classList.add("active");
    } else {
        scrollTop.classList.remove("active");
    }
  })

// Scroll button finish



///////////////////////////////////////

// Wishlist button start

const wishlistButtons = Array.from(document.querySelectorAll('.wishlist-button'))
const heart = document.querySelector('.wishlist-button .far.fa-heart')

for (let i = 0; i < wishlistButtons.length; i++) {
    wishlistButtons[i].onclick=function(e){
        e.preventDefault();
        if(wishlistButtons[i].firstElementChild.className=="far fa-heart"){
            wishlistButtons[i].firstElementChild.className="fas fa-heart"
        }
        else{
            wishlistButtons[i].firstElementChild.className="far fa-heart"
        }

    }
}

// Wishlist button finish

/////////////////////////////////////////////////////

$(document).ready(function () {

    $(document).on("click", ".show-product-modal", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        fetch('https://localhost:44363/home/getproduct/' + id)
            .then(response => response.text())
            .then(data => {
                $("#product-modal-detail").html(data)
                
            });

    });

    ///////////////////////////////////////////////////////////////


    $(document).on("click", ".show-register-modal", function (e) {
        e.preventDefault();

        fetch('https://localhost:44363/account/register')
            .then(response => response.text())
            .then(data => {
                $("#register-modal-detail").html(data)
               
                })
    });

    ///////////////////////////////////////////////////////////////


    $(document).on("click", ".show-login-modal", function (e) {
        e.preventDefault();

        fetch('https://localhost:44363/account/login')
            .then(response => response.text())
            .then(data => {
                $("#login-modal-detail").html(data)

            })
    });

    ///////////////////////////////////////////////////////////////


    $(document).on("click", ".show-forgot-modal", function (e) {
        e.preventDefault();

        fetch('https://localhost:44363/account/ForgotPassword')
            .then(response => response.text())
            .then(data => {
                $("#forgot-modal-detail").html(data)

            })
    });

    ///////////////////////////////////////////////////////////////


    $(document).on("click", ".add-basket-btn", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        fetch('https://localhost:44363/product/addtobasket/' + id)
            .then(response => response.text())
            .then(data => {
                $('.show-basket-box').html(data);
                var hiddenCount = $('.hidden-total-count').attr("data-id");
                var basketTotalCount = $('.basket-total-count');
                basketTotalCount.html(hiddenCount);

            })

    });

    ///////////////////////////////////////////////////////////////

    var hiddenWishlistCount = parseInt($('.hidden-wishlist-count').val());
    var wishlistTotalCount = $('.wishlist-total-count');

    $(document).on("click", ".add-wishlist-btn", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");
        
        hiddenWishlistCount = hiddenWishlistCount + 1;
        wishlistTotalCount.html(hiddenWishlistCount);

        fetch('https://localhost:44363/product/AddToWishlist/' + id)
            .then(response => response.text())
        
    });


    ///////////////////////////////////////////////////////////////


    $(document).on("click", "#remove-button", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");
        var content = $(this).attr("data-content");
        if (content > 1)
        {
            fetch('https://localhost:44363/product/deletebasketitem/' + id)
                .then(response => response.text())
                .then(data => {
                    $('.show-basket-box').html(data);
                    var hiddenCount = $('.hidden-total-count').attr("data-id");;
                    var basketTotalCount = $('.basket-total-count');
                    basketTotalCount.html(hiddenCount);
                })
        }
        else
        {
            fetch('https://localhost:44363/product/removebasketitem/' + id)
                .then(response => response.text())
                .then(data => {
                    $('.show-basket-box').html(data);
                    var hiddenCount = $('.hidden-total-count').attr("data-id");;
                    var basketTotalCount = $('.basket-total-count');
                    basketTotalCount.html(hiddenCount);
                })
        }
    });

    ///////////////////////////////////////////////////////////////

    $(document).on("click", "#delete-button", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");
        var content = $(this).attr("data-content");
        if (content > 1) {
            fetch('https://localhost:44363/product/deletebasketitem/' + id)
                .then(response => response.text())
                .then(data => {
                    $('.show-basket-box').html(data);
                    var hiddenCount = $('.hidden-total-count').attr("data-id");;
                    var basketTotalCount = $('.basket-total-count');
                    basketTotalCount.html(hiddenCount);
                })
        }
        
    });

    ///////////////////////////////////////////////////////////////


    $(document).on("click", ".remove-cart-item", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        fetch('https://localhost:44363/product/removebasketitem/' + id)
            .then(response => response.text())
            .then(data => {
                $('.show-basket-box').html(data);
                var hiddenCount = $('.hidden-total-count').attr("data-id");;
                var basketTotalCount = $('.basket-total-count');
                basketTotalCount.html(hiddenCount);
            })
    });

    ///////////////////////////////////////////////////////////////


    $(document).on("click", ".delete-wishlist-item", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");
        hiddenWishlistCount = hiddenWishlistCount - 1;
        wishlistTotalCount.html(hiddenWishlistCount);

        fetch('https://localhost:44363/product/deletewishlistitem/' + id)
            .then(response => response.text())
            

    });


    ///////////////////////////////////////////////////////////////


    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "500",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    ///////////////////////////////////////////////////////////////

    let ranks = document.querySelectorAll('.comment-rank');

    ranks.forEach(function (elem, index) {
        elem.addEventListener('click', function () {
            document.querySelector('#rate').value = index + 1;
            for (let i = 0; i <= index; i++) {
                ranks[i].style.color = '#f9bf00';
            }
        })
    })


    ///////////////////////////////////////////////////////////////


    $('#search').keyup(function () {
        let search = $(this).val();
        $.ajax({
            url: 'https://localhost:44363/home/search?search=' + search,
            method: 'get',
            success: function (resp) {
                $('.search-list').html(resp);
            }
        })
    })
   
})
