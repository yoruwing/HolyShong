let menuCheck = document.querySelector('#menu-check');
let bg = document.querySelector('.bg');
let body = document.querySelector('body');

//購物車結帳頁面使用
//優惠model 選取優惠
let inputDiscounts = document.querySelectorAll('.discount-item input');
let spanDiscounts = document.querySelectorAll('.discount-item label span');
inputDiscounts.forEach((input, index) => {
    input.addEventListener('change', function () {
        spanDiscounts.forEach((span, num) => {
            if (index == num) {
                span.innerText = "已選取";
            }
            else {
                span.innerText = "可選取";
            }
        })
    })
});

//加入menu背景
menuCheck.addEventListener('click', function () {
    //若漢堡按下，加入背景
    if (menuCheck.checked) {
        bg.classList.add('bg-style');
        body.setAttribute('style', 'overflow:hidden;');
        bg.addEventListener('click', function () {
            menuCheck.click();
            event.stopImmediatePropagation();
        });
    }
    //漢堡關起，移除背景
    else {
        bg.classList.remove('bg-style');
        body.removeAttribute('style', 'overflow:hidden;');
    }
});


// 序號modal 關閉新增優惠modal
let discountAdd = document.querySelector('#discountAdd');
let discountModal = document.querySelector('#discountModal');
discountAdd.addEventListener('click', function () {
    discountModal = document.querySelector('#discountModal');
    discountModal.classList.add('d-none');
});

let ONdiscount = document.querySelectorAll('#ONdiscountModal button');
ONdiscount.forEach(button => {
    button.addEventListener('click', function () {
        discountModal.classList.remove('d-none');
    })
});


//新增優惠卷
function AcquireDiscount() {
    let addDiscount = document.querySelector('.ONdiscount-body input');
    $.ajax({
        type: 'POST',
        url: '/Discount/AcquireDiscount',
        data: addDiscount.innerText,
        success: function (request) {
            console.log("成功傳遞")
        }
    });
}

//時間地點Modal on Modal
let changeDest = document.querySelector("#deliverModal .modal-body div:first-of-type button");
changeDest.addEventListener('click', function () {
    changeDest.parentNode.parentElement.offsetParent.classList.add('opacity-0');
});
let destModalBtn = document.querySelectorAll('#destModal button');
destModalBtn.forEach(button => {
    button.addEventListener('click', function () {
        changeDest.parentNode.parentElement.offsetParent.classList.remove('opacity-0');
    });
});

//cartList 按鈕點擊關閉購物車
let cartBtn = document.querySelector('.cartList .modal-header button');
cartBtn.addEventListener('click', function () {
    let cartInput = document.querySelector('#cart-check');
    cartInput.click();
});

// 下拉選單
$('.circleIcon').on('click', function () {

    if ($(".checkboxDiv").hasClass('d-flex')) {
        $('.checkboxDiv').removeClass('d-flex');
        $('.checkboxDiv').addClass('d-none')

        $('.circleIcon').removeClass('fa-chevron-circle-down');
        $('.circleIcon').addClass('fa-chevron-circle-up');

    } else {
        $('.checkboxDiv').addClass('d-flex');
        $('.checkboxDiv').removeClass('d-none');

        $('.circleIcon').removeClass('fa-chevron-circle-up');
        $('.circleIcon').addClass('fa-chevron-circle-down');
    }
});

//開啟購物車
let cartInput = document.querySelector('#cart-check');
cartInput.addEventListener('click', function () {
    $.ajax({
        type: 'POST',
        url: '/api/Cart/ShowCart',
        success: function (res) {
            cart.product = res;
        }
    });
});