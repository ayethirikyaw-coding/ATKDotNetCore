const tblBlog = "blogs";

//readBlog();
//createBlog();
//updateBlog("11f6df1f-6b12-4a4d-9f55-1cc24ea17eb2", "author", "title", "content");
//deleteBlog("085d0c5f-a861-4cbc-9aff-eabe8e745e2b");

function readBlog() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function createBlog() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    // 1 == '1' value
    // 1 === '1' value and data type

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    const requestModel = {
        Id: uuidv4(),
        title: "test title",
        author: "test author",
        content: "test content"
    }

    lst.push(requestModel);
    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);
}

function updateBlog(id, author, title, content) {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    var items = lst.filter(x => x.Id === id);
    console.log(items);

    console.log(items.length);

    if (items.length == 0) {
        console.log("No data found");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.Id === id);
    lst[index] = item;

    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);
}

function deleteBlog(id) {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    var items = lst.filter(x => x.Id === id);
    if (items.length == 0) {
        console.log("No data found");
        return;
    }

    lst = lst.filter(x => x.Id !== id);
    const jsonStr = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonStr);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}
console.log();