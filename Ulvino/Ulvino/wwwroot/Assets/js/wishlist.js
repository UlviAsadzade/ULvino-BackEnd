const removeButtons = Array.from(document.querySelectorAll(".remove-product-icon"))
const wishlistBoxes = Array.from(document.querySelectorAll(".wishlist-page-box-item"))
const wishlistBoxBottom = document.querySelector(".wishlist-page-box-bottom")
const wishlistEmptyBox = document.querySelector(".wishlist-empty-box")
if (wishlistBoxes.length == 0) {
    wishlistBoxBottom.remove();
    wishlistEmptyBox.classList.add("active")
}

removeButtons.forEach(removeButton => {
    removeButton.onclick = function (e) {
        e.preventDefault();
        const targetId = removeButton.getAttribute('data-target')
        const targetContent = document.getElementById(targetId);
        targetContent.remove();
        const wishlistBoxes = Array.from(document.querySelectorAll(".wishlist-page-box-item"))
        if (wishlistBoxes.length==0) {
            wishlistBoxBottom.remove();
            wishlistEmptyBox.classList.add("active")
        }

    }
});