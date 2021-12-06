const blogDescs = Array.from(document.querySelectorAll('.blog-main-box .blog-desc')) 
let blogDescResult;

blogDescs.forEach(blogDesc =>{
    if(blogDesc.innerText.length>300){
        blogDescResult = blogDesc.innerText.substring(0,334) + "...";
        blogDesc.innerText = blogDescResult;
    }
})