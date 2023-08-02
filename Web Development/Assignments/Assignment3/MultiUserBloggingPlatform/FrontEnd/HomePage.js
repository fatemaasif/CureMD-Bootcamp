
    function createPost() {
        const postTitle = $('#PostTitle').val();
        const postText = $('#PostText').val();

        const postData = {
            PostTitle: postTitle,
            PostText: postText,
            
            CategoryID: 1,
            UserID: 1
        };
        //create post
        $.ajax({
            url: '/api/posts',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(postData),
            success: function (data) {
                console.log('Post created successfully:', data);
                getAllPosts();
            },
            error: function (error) {
                console.error('Error creating post:', error);
            }
        });
    }

    //get all posts
    function getAllPosts() {
        $.ajax({
            url: '/api/posts',
            type: 'GET',
            success: function (data) {
                console.log('Posts retrieved successfully:', data);
                displayPosts(data);
            },
            error: function (error) {
                console.error('Error getting posts:', error);
            }
        });
    }

    //display posts
    function displayPosts(posts) {
        const blogContainer = $('.blog-container');
        blogContainer.empty();

        for (const post of posts) {
            const postElement = $('<div>').addClass('post');
            $('<h3>').text(post.PostTitle).appendTo(postElement);
            $('<p>').text(post.PostText).appendTo(postElement);
            blogContainer.append(postElement);
        }
    }

    
    $(document).ready(function () {
        // Call the getAllPosts function when the page loads
        getAllPosts();

        $('#createPostButton').on('click', function (event) {
            event.preventDefault();
            createPost();
        });
    });
