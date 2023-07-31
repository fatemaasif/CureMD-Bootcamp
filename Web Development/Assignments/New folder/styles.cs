body {
  font-family: 'Montserrat', sans-serif;
  margin: 0;
  padding: 0;
  background-color: #f5f5f5;
}

header {
  background-image: url("header-background.jpg"); /* Replace with your own image */
  background-size: cover;
  background-position: center;
  color: #fff;
  text-align: center;
  padding: 100px 0;
}

.navbar {
  list-style-type: none;
  margin: 0;
  padding: 0;
  display: inline-block /* Make the navbar horizontal */
  justify-content: center;
  background-color: rgba(0, 0, 0, 0.8);
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
}

.navbar li {
  margin-right: 20px;
}

.navbar li:last-child {
  margin-right: 0;
}

.navbar a {
  color: #fff;
  text-decoration: none;
  padding: 10px;
  font-size: 18px;
  transition: 0.3s ease-in-out;
}

.navbar a:hover {
  color: #aaf7f7;
}

.header-content h1 {
  font-size: 48px;
  margin-bottom: 20px;
}

.header-content p {
  font-size: 20px;
  color: #f7f7f7;
  margin-bottom: 40px;
}

.blog-container {
  max-width: 800px;
  margin: 20px auto;
  padding: 20px;
  background-color: #fff;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
}

.blog {
  border-bottom: 1px solid #ccc;
  padding: 20px;
}

.blog:last-child {
  border-bottom: none;
}

footer {
  text-align: center;
  padding: 20px;
  background-color: #333;
  color: #fff;
  bottom:0px;
}
