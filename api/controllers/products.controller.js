//let products = [];
const db = require("../config/database");

//get all products in db
exports.getProducts = async (req, res) => {
    const response = await db.query('select * from products');
    res.status(200).send(response.rows);
};

//create a product
exports.createProduct = async (req, res) => {
    const { productname, price, category, description, image} = req.body;
    const { rows } = await db.query('insert into products (productname, price, category, description, image) values ($1, $2, $3, $4, $5)',
    [productname, price, category, description, image ]);

    console.log(rows);
    res.status(201).send({
        message: "Product added!",
        body: {
            product: {productname, price, category, description, image}
        }
    })
};

exports.deleteProduct = async (req, res) => {
    const productId = parseInt(req.params.id);
    await db.query('delete from products where productId = $1', [productId]);

    res.status(200).send({message: "Product deleted."});
};

exports.getProduct = async (req, res) => {
    const productId = parseInt(req.params.id);
    const product = await db.query('select * from products where productId = $1', [productId]);

    res.status(200).send(product.rows);
}
