const tblProduct = "products";
let blogId = 0;
let carts = [];

getProductsTable();

function createProduct(name, desc, price) {
    let lst = getProducts();

    const requestModel = {
        id: uuidv4(),
        name: name,
        description: desc,
        price: price
    }

    lst.push(requestModel);
    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblProduct, jsonStr);
}

function editProduct(id) {
    let lst = getProducts();

    const products = lst.filter(x => x.id === id);

    if (products.Length == 0) {
        errorMessage("No data found");
        return;
    }

    const product = products[0];
    blogId = product.id;
    $('#txtName').val(product.name);
    $('#txtDesc').val(product.description);
    $('#txtPrice').val(product.price);
}

function updateProduct(id, productName, desc, price) {
    let lst = getProducts();
    const products = lst.filter(x => x.id === id);

    if (products.Length == 0) {
        errorMessage("No data found");
        return;
    }

    const product = products[0];
    product.name = productName;
    product.description = desc;
    product.price = price;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = product;

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblProduct, jsonStr);
    blogId = 0;
}

function deleteProduct(id) {
    confirmMessage("Are you sure to delete?").then(
        function (value) {
            let lst = getProducts();

            let product = lst.filter(x => x.id === id);

            if (product.length == 0) {
                errorMessage("No data found.");
            }

            lst = lst.filter(x => x.id !== id);

            const jsonStr = JSON.stringify(lst);
            localStorage.setItem(tblProduct, jsonStr);

            successMessage("Deleting successful.");
            getProductsTable();
        }
    );
}

$('#btnSave').click(function () {
    const productName = $('#txtName').val();
    const desc = $('#txtDesc').val();
    const price = $('#txtPrice').val();

    if (blogId === 0) {
        createProduct(productName, desc, price);
    } else {
        updateProduct(blogId, productName, desc, price);
    }

    successMessage("Successful");
    clearControls();
    getProductsTable();
})

function getProducts() {
    const products = localStorage.getItem(tblProduct);

    let lst = [];

    if (products !== null) {
        lst = JSON.parse(products);
    }

    return lst;
}

function getProductsTable() {
    let lst = getProducts();
    let count = 0;
    let htmlRows = '';

    lst.forEach(product => {
        const htmlRow = `
            <tr>
                <td>
                    <button type="button" class="btn btn-warning btn-sm" id="btnEdit" onclick="editProduct('${product.id}')">Edit</button>
                    <button type="button" class="btn btn-danger btn-sm" id="btnDelete" onclick="deleteProduct('${product.id}')">Delete</button>
                </td>
                <td>${++count}</td>
                <td>${product.name}</td>
                <td>${product.description}</td>
                <td>${product.price}</td>
                <td><button type="button" class="btn btn-primary btn-sm" id="btnAddToCart" onclick="addToCart('${product.id}')">Add To Cart</button></td>
            </tr>
        `;

        htmlRows += htmlRow;
    });
    $('#tbody').html(htmlRows);
}

function clearControls() {
    $('#txtName').val('');
    $('#txtDesc').val('');
    $('#txtPrice').val('');
    $('#txtName').focus();
}

$('#btnCancel').click(function () {
    clearControls();
    blogId = 0;
})

function addToCart(productId) {
    let lstCard = getCards();

    let lst = getProducts();
    const products = lst.filter(x => x.id === productId);

    const cards = lstCard.filter(x => x.productId === productId);
    if (cards.length > 0) {
        increase(cards);
        successMessage("record is inserted.");
        return;
    }

    let qty = 1;
    let product = products[0];
    const requestModel = {
        cardId: uuidv4(),
        productId: productId,
        name: product.name,
        description: product.description,
        price: product.price,
        quantity: qty
    };

    lstCard.push(requestModel);

    const jsonStr = JSON.stringify(lstCard);
    localStorage.setItem("carts", jsonStr);

    successMessage("Added to Cart.");
}

function increase(cards) {
    let lst = getCards();
    let card = cards[0];

    card.quantity += 1;

    const index = lst.findIndex(x => x.cardId == card.cardId);
    lst[index] = card;

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem("carts", jsonStr);
}

