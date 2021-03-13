// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ExpandText(element)
{
    let parent = element.parentNode;
    let next = parent.nextElementSibling;
    parent.classList.toggle('d-none');
    next.classList.toggle('d-none');
}
function postOnMouseOver(element)
{
    let post_add_like_elem = element.lastElementChild.firstElementChild.firstElementChild.firstElementChild;
    let request = new XMLHttpRequest();
    let data = { id: post_add_like_elem.id };
    function reqReadyStateChanche() {
        if (request.readyState == 4 && request.status == 200)
        {
            let response = JSON.parse(request.responseText);
            let views_counter = post_add_like_elem.parentNode
                .parentNode
                .nextElementSibling
                .nextElementSibling
                .nextElementSibling
                .firstElementChild
                .firstElementChild;
            views_counter.nextSibling.data = response.count;
        }
    }
    var body = "id=" + data.id;
    request.open("POST", "/Home/ViewAdd");
    request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    request.onreadystatechange = reqReadyStateChanche;
    request.send(body);
}
const hubConnection = new signalR.HubConnectionBuilder().withUrl("/chat").build();
hubConnection.start();
/*hubConnection.on("MessageSend", function (response) {
    if (flag) { }
    else
    {
        alert("Hello");
    }
});*/