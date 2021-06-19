//let products = [];
const db = require("../config/database");

//get all products in db
exports.getProducts = async (req, res) => {
    const response = await db.query('SELECT * FROM products');
    res.status(200).send(response.rows);
};

//create a product
exports.createProduct = async (req, res) => {
    const { productname, price, category, description, image} = req.body;
    const { rows } = await db.query('INSERT INTO products (productname, price, category, description, image) VALUES ($1, $2, $3, $4, $5)',
    [productname, price, category, description, image ]);

    console.log(rows);
    res.status(201).send({
        message: "Product added!",
        body: {
            product: {productname, price, category, description, image}
        }
    })
}
