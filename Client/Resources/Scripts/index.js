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
            " <button onclick = \"editPost(" + post.id + ")\">Edit</button></li>";
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
    const postText = document.getElementById("text").value;

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

function editPost(id)
{
    const editPostApiUrl = "https://localhost:5001/API/Posts/" + id;
    const postText = document.getElementById("").value;

    fetch(editPostApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            text: postText
        })
    }).then(function(json){
        document.getElementById("Edit").innerHTML;
    }).then((response)=>{
        console.log(response);
        getPosts();
    })
}
