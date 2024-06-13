const tblBlog = "blogs";
let blogId = null;

getBlogsTable();
//testConfirmMessage();

function testConfirmMessage2() {
    let confirmMessage = new Promise(function (success, error) {
        // "Producing Code" (May take some time)
        const result = confirm("Are you sure to delete?");
        if (result) {
            success();
        } else {
            error();
        }
    });

    // "Consuming Code" (Must wait for a fulfilled Promise)
    confirmMessage.then(
        function (value) {
            successMessage("Success");
        },
        function (error) {
            errorMessage("Error");
        }
    );
}

//readBlogs();
//createBlog();
//updateBlog("11f6df1f-6b12-4a4d-9f55-1cc24ea17eb2", "author", "title", "content");
//deleteBlog("085d0c5f-a861-4cbc-9aff-eabe8e745e2b");

function readBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function editBlog(id) {
    let lst = getBlogs();

    var items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.length);

    if (items.length == 0) {
        console.log("No data found");
        errorMessage("No data found");
        return;
    }

    let item = items[0];

    blogId = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
    $('#txtTitle').focus();
}

function createBlog(author, title, content) {
    // 1 == '1' value
    // 1 === '1' value and data type

    let lst = getBlogs();

    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    lst.push(requestModel);
    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);
    successMessage("Saving successful.");
    clearControls();
}

function updateBlog(id, author, title, content) {
    let lst = getBlogs();

    var items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.length);

    if (items.length == 0) {
        console.log("No data found");
        errorMessage("No data found");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);

    successMessage("Updating successful.");
}

function deleteBlog2(id) {
    let result = confirm("Are you sure to delete?");
    if (!result) return;

    let lst = getBlogs();

    var items = lst.filter(x => x.id === id);
    if (items.length == 0) {
        console.log("No data found");
        return;
    }

    lst = lst.filter(x => x.id !== id);
    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);

    successMessage("Deleting successful.");

    getBlogsTable();
}

function deleteBlog3(id) {
    //let result = confirm("Are you sure to delete?");
    //if (!result) return;

    Swal.fire({
        title: "Confirm",
        text: "Are you sure to delete?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes"
    }).then((result) => {
        if (!result.isConfirmed) return;

        let lst = getBlogs();

        var items = lst.filter(x => x.id === id);
        if (items.length == 0) {
            console.log("No data found");
            return;
        }

        lst = lst.filter(x => x.id !== id);
        const jsonStr = JSON.stringify(lst);
        localStorage.setItem(tblBlog, jsonStr);
        successMessage("Deleting successful.");

        getBlogsTable();
    });
}

function deleteBlog(id) {
    confirmMessage("Are you sure to delete?").then(
        function (value) {
            let lst = getBlogs();

            var items = lst.filter(x => x.id === id);
            if (items.length == 0) {
                console.log("No data found");
                return;
            }

            lst = lst.filter(x => x.id !== id);
            const jsonStr = JSON.stringify(lst);
            localStorage.setItem(tblBlog, jsonStr);
            successMessage("Deleting successful.");

            getBlogsTable();
        }
    );
}

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}

$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (blogId === null) {
        createBlog(title, author, content);
    }
    else {
        updateBlog(blogId, title, author, content);
        blogId = null;
    }

    getBlogsTable();
})

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogsTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-warning" id="btnEdit" onclick="editBlog('${item.id}')">Edit</button>
                <button type="button" class="btn btn-danger" id="btnDelete" onclick="deleteBlog('${item.id}')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
        </tr>
      `;
        htmlRows += htmlRow;
    });
    $('#tbody').html(htmlRows);
}
