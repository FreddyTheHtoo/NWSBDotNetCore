const tblBlog = "blogs";
getBlogTable();

//createBlog();
getBlog();
// updateBlog('632d08fb-b792-4f37-9c99-511f7ca0c57f','axxxxxxxxxd','dxxxxxxxlf','dfxxxxxxxxl');
//deleteBlog('6520f333-523a-4a45-b629-1f2acd91a6e3');
function getBlog() {
    let lst = getBlogs();
    console.log(lst);

}
function createBlog(title, author, content) {

    let lst = getBlogs();
    const requestModel = {
        id: uuidv4(),
        title: title.trim(),
        author: author.trim(),
        content: content.trim()
    }

    lst.push(requestModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    successMessage("Saving Successful.");
    clear();
}

function updateBlog(id, title, author, content) {
    let lst = getBlogs();

    // const items = lst.filter(x=> x.id === id);
    // console.log(items);
    // console.log(items.length);
    // if(items.length == 0){
    //     console.log("No data found");
    //     return;
    // }

    // const item = items[0];
    // item.title=title;
    // item.author=author;
    // item.content=content;

    const index = lst.findIndex(x => x.id === id);
    if (index === null) {
        console.log("No data found");
        return;
    }

    lst[index].title = title.trim();
    lst[index].author = author.trim();
    lst[index].content = content.trim();
    //lst[index]= item;
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

}

function deleteBlog(id) {
    let lst = getBlogs();

    const items = lst.filter(x => x.id === id);
    console.log(items);
    console.log(items.length);
    if (items.length == 0) {
        console.log("No data found");
        return;
    }

    lst = lst.filter(x => x.id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

//console.log(uuidv4());

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}

function successMessage(message) {
    alert(message);
}

function errorMessage(message) {
    alert(message);
}

$('#btnSave').click(function () {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();
    createBlog(title, author, content);

});

function clear() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
    <tr>
        <td>Edit/Delete</td>
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