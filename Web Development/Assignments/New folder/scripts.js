$(document).ready(function() {
    loadBlogs(); // Load blogs on page load
  
    function loadBlogs() {
      // Simulating fetching blogs from the server
      const blogs = [
        {
          title: "Blog Title 1",
          content: "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        },
        {
          title: "Blog Title 2",
          content: "Suspendisse nec libero vitae metus rhoncus volutpat.",
        },
        {
          title: "Blog Title 3",
          content: "Pellentesque eget purus nec felis tristique commodo.",
        },
      ];
  
      // Render blogs on the page
      const blogContainer = $("#blogContainer");
      blogContainer.empty();
      blogs.forEach(blog => {
        const blogHTML = `<div class="blog">
                            <h2>${blog.title}</h2>
                            <p>${blog.content}</p>
                          </div>`;
        blogContainer.append(blogHTML);
      });
    }
  });