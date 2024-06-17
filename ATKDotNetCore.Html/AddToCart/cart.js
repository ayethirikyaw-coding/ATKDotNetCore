getProductsCard();

function getCards() {
    const carts = localStorage.getItem("carts");
    let lst = [];

    if (carts !== null) {
        lst = JSON.parse(carts);
    }

    return lst;
}

function getProductsCard() {
    let cards = getCards();

    if (cards.length == 0) {
        const message = `<h5>No product in cart</h5>`;
        $('.row').html(message);
        return;
    }

    let htmlCards = '';
    let totalAmount = 0;
    cards.forEach(card => {
        const totalPrice = card.price * card.quantity;
        totalAmount += totalPrice;
        const htmlCard = `
            <div class="col-sm-3 mb-3">
                <div class="card" style="width: 15rem;position:relative;">
                    <div class="card-body">
                        <p>Product Name : ${card.name}</p>
                        <p>Description : ${card.description}</p>
                        <p>Price : ${card.price}</p>
                        <div>Quantity : 
                            <button type="button" class="btn btn-outline-primary btn-sm" id="btnPlus" onclick="qtyIncrease('${card.cardId}')">+</button>
                            <span>${card.quantity}</span>
                            <button type="button" class="btn btn-outline-primary btn-sm" id="btnMinus" onclick="qtyDecrease('${card.cardId}')">-</button>
                        </div>   
                        <br/>
                        <p>Total Price : ${totalPrice}</p>
                        <button type="button" class="btn btn-outline btn-sm" style="position:absolute;top:0;right:0;" onclick="remove('${card.cardId}')">X</button>
                    </div>
                </div>
                
            </div>
        `;
        htmlCards += htmlCard;
    });
    totalAmountResult(totalAmount);
    $('.row').html(htmlCards);
}

function totalAmountResult(totalAmount) {
    $('#total').html("Total Amount in Cart : " + totalAmount);
}

function qtyIncrease(id) {
    let lst = getCards();

    const cards = lst.filter(x => x.cardId === id);

    increase(cards);
    getProductsCard();
}

function qtyDecrease(id) {
    let lst = getCards();

    const cards = lst.filter(x => x.cardId === id);

    const card = cards[0];

    if (card.quantity === 1) return;
    card.quantity -= 1;

    const index = lst.findIndex(x => x.cardId === id);
    lst[index] = card;

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem("carts", jsonStr);

    getProductsCard();
}

function remove(cardId) {
    confirmMessage("Are you sure to delete?").then(
        function (value) {
            let lst = getCards();

            const cards = lst.filter(x => x.cardId !== cardId);

            const jsonStr = JSON.stringify(cards);
            localStorage.setItem("carts", jsonStr);

            getProductsCard();
        }
    );
}