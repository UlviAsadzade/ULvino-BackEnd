const minus = document.querySelector(".minus")
const plus = document.querySelector(".plus")

minus.onclick = function(e){
    e.preventDefault();
    sum = minus.nextElementSibling.innerHTML;
    if (sum == 1) {
        minus.nextElementSibling.innerHTML = 1;
    }
    else {
        sum--;
        minus.nextElementSibling.innerHTML = sum;
    }
}

plus.onclick = function(e){
    e.preventDefault();
    sum = plus.previousElementSibling.innerHTML;
    sum++;
    plus.previousElementSibling.innerHTML = sum;
}


