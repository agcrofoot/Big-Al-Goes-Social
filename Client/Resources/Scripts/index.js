function getPosts()
{
    const allPostsApiUrl = "https://localhost:5001/API/Posts";

    fetch(allPostsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<ul>";
        json.forEach((post)=>{
            html += "<li> <div class=\"avatar\"></div><span>" + post.text + "</span>" + 
            " <button onclick = \"deletePost(" + post.id + ")\">Delete</button>" + 
            " <button onclick = \"ShowAndHide(" + post.id + ")\">Edit</button></li>";
        });
        html += "</ul>";
        document.getElementById("Posts").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

function postPost()
{
    const postPostApiUrl = "https://localhost:5001/API/Posts";
    const postText = document.getElementById("post").value;

    fetch(postPostApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            text: postText
        })
    }).then((response)=>{
        console.log(response);
        getPosts();
    })
}

function deletePost(id)
{
    const deletePostApiUrl = "https://localhost:5001/API/Posts/" + id;

    fetch(deletePostApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        }
    }).then((response)=>{
        console.log(response);
        getPosts();
    })
}


function ShowAndHide(id)
{
    console.log(id + "show and hide");
    var x = document.getElementById('edit');
    if (x.style.display == 'none')
    {
        x.style.display = 'block';
    }
    else
    {
        x.style.display = 'none';
    }

    var html = "<form onsubmit= \"ShowAndHide(" + id + ")\">" +
    " <input type= \"text\" name = \"text\" id = \"editing\"/>" +
    " <input type=\"submit\" value = \"Save\" onclick = \"editPost(" + id + ")\"/>" +
    " </form>";
    document.getElementById("edit").innerHTML = html;
}

function editPost(id)
{
    const editPostApiUrl = "https://localhost:5001/API/Posts/" + id;
    const editText = document.getElementById("editing").value;
    console.log(id);
    fetch(editPostApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            text: editText
        })
    }).then((response)=>{
        console.log(response);
        getPosts();
    })
}
