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

})
