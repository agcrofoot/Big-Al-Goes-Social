var tweets = ["Hey there from Big Al", "Hey again", "It's still me!"];

setGreets = function()
{
    var html = "<ul>";
    tweets.forEach((tweet)=>
    {
        html +="<li> <div class=\"avatar\"></div><span>" + tweet + "</span></li>";
    });
    html += "</ul>";
    document.getElementById("greets").innerHTML = html;
}

addPost = function()
{
    let postText = document.getElementById("post").value;
    tweets.push(postText);
    setGreets();
}