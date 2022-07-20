


█████████████████████████████████████████████████████████████████████
█▄─▄▄▀█▄─▄▄─█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄█─▄─▄─█─▄▄─█▄─▄▄─█▄─▄█─▄▄─█▄─▀█▄─▄█
██─██─██─▄█▀█▄▄▄▄─█─███▀██─▄─▄██─████─███─██─██─▄▄▄██─██─██─██─█▄▀─██
▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▀▀▄▄▄▀▀▄▄▄▄▀▄▄▄▀▀▀▄▄▄▀▄▄▄▄▀▄▄▄▀▀▄▄▀

An online shopping cart solution known as an ecommerce platform allows you to manage your product inventory and sell goods directly from your website. A CMS is a feature of many e-commerce systems. In other words, it's a user-friendly architecture that manages all of an online shop's backend store operations. In our project, an e-commerce content management system (CMS) that is simple, clean, and easy to use while yet being extremely functional is being developed. This system is primarily targeted at small businesses. Our system will have all the required features, including an intuitive user interface (UI) that is well-designed and responsive, a simple system for managing the inventory of products (with the option to add, update, and remove items), and a lot more.



██████████████████████████████████████████████████
█▄─▄▄─█▄─▄▄─██▀▄─██─▄─▄─█▄─██─▄█▄─▄▄▀█▄─▄▄─█─▄▄▄▄█
██─▄████─▄█▀██─▀─████─████─██─███─▄─▄██─▄█▀█▄▄▄▄─█
▀▄▄▄▀▀▀▄▄▄▄▄▀▄▄▀▄▄▀▀▄▄▄▀▀▀▄▄▄▄▀▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀
```
Database Tables: Users, Products, Orders, Reviews 
Table Model   
-> Create a table model for each of the tables including their rows, primary keys and foreign keys
Login page 
-> Uses Users Table
-> Takes user’s login.
Users Page
-> Table of Users
-> Hyperlink on Primary Key to page with full DB data
-> Update Users 
-> Delete Users 
-> Create Users 
Products Page
-> Table of Products
-> Hyperlink on Primary Key to page with full DB data
-> Update Products
-> Delete Products
-> Create Products
Orders Page 
-> Foreign Keys from Users and Products
-> Table of Orders 
-> Hyperlink on Primary Key to page with full DB data
-> Update Orders 
-> Delete Orders 
-> Create Orders 
Reviews Page 
-> Foreign Keys from Products and Users
-> Table of Reviews 
-> Hyperlink on Primary Key to page with full DB data
-> Update Reviews 
-> Delete Reviews 
-> Create Reviews 
Styling and Layout w/ Image Logo 
-> Figure out the layouts, styling and other design aspects of the web application
Master Pages
-> Master page to direct user to the rest of the application
Displaying all Products
-> On the frontend show a grid view of all the products available to the user to purchase
-> Include price and Add to Cart Button
Cart Functionality  
User presses add to cart 
-> User presses button, which triggers function below 
READ product ID 
-> READ crud function to fetch the product ID of the product whose button was clicked
Store in Cookie 
-> Get the fetched product ID and store it in a cookie for later use
When an order is placed, format and push the order to the table 
-> When the Order is placed, get all the productID from the cookie and format and CREATE an order on the table.
Error Handling
Comments 
Responsiveness 
Table Design
```
