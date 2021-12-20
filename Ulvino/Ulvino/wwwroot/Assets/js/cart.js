const removeButtons = Array.from(document.querySelectorAll(".remove-product-icon"))
const cartBoxes = Array.from(document.querySelectorAll(".cart-page-box-item"))
const cartBoxBottom = document.querySelector(".cart-page-box-bottom")
const cartEmptyBox = document.querySelector(".cart-empty-box")
const minus = Array.from(document.querySelectorAll(".minus"))
const plus = Array.from(document.querySelectorAll(".plus"))
const subtotals = Array.from(document.querySelectorAll(".subtotal"))
const totalAmount = document.querySelector(".total-amount");
var prdtotal = 0;
let total = 0;
let sum = 0;

function sumOfSubtotals(arr) {
    for (let i = 0; i < arr.length; i++) {
        prdtotal += +arr[i].lastElementChild.innerText;
    }
}
sumOfSubtotals(subtotals);
totalAmount.lastElementChild.innerHTML = prdtotal.toFixed(2);
prdtotal = 0

removeButtons.forEach(removeButton => {
    removeButton.onclick = function (e) {
        e.preventDefault();
        const targetId = removeButton.getAttribute('data-target')
        const targetContent = document.getElementById(targetId);
        targetContent.remove();
        const subtotals = Array.from(document.querySelectorAll(".subtotal"))
        sumOfSubtotals(subtotals);
        totalAmount.lastElementChild.innerHTML = prdtotal.toFixed(2);
        prdtotal = 0;
        if (totalAmount.lastElementChild.innerHTML == 0) {
            cartBoxBottom.remove();
            cartEmptyBox.classList.add("active")
        }

    }
});

minus.forEach(x => {
    x.onclick = function (e) {
        e.preventDefault();
        prdPrice = x.parentElement.parentElement.previousElementSibling.firstElementChild.lastElementChild.innerHTML;
        prdSubtotal = x.parentElement.parentElement.nextElementSibling.firstElementChild.lastElementChild.innerHTML;
        sum = x.nextElementSibling.innerHTML;
        if (sum == 1) {
            x.nextElementSibling.innerHTML = 1;
        }
        else {
            sum--;
            x.nextElementSibling.innerHTML = sum;
        }

        prdSubtotal = (sum * prdPrice).toFixed(2);
        x.parentElement.parentElement.nextElementSibling.firstElementChild.lastElementChild.innerHTML = prdSubtotal;
        sumOfSubtotals(subtotals);
        totalAmount.lastElementChild.innerHTML = prdtotal.toFixed(2);
        prdtotal = 0
    }
})

plus.forEach(x => {
    x.onclick = function (e) {
        e.preventDefault();
        prdPrice = x.parentElement.parentElement.previousElementSibling.firstElementChild.lastElementChild.innerHTML;
        prdSubtotal = x.parentElement.parentElement.nextElementSibling.firstElementChild.lastElementChild.innerHTML;
        sum = x.previousElementSibling.innerHTML;
        sum++;
        x.previousElementSibling.innerHTML = sum;
        prdSubtotal = (sum * prdPrice).toFixed(2);
        x.parentElement.parentElement.nextElementSibling.firstElementChild.lastElementChild.innerHTML = prdSubtotal;
        sumOfSubtotals(subtotals);
        totalAmount.lastElementChild.innerHTML = prdtotal.toFixed(2);
        prdtotal = 0

    }
})


