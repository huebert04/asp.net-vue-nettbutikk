//let products = [];
const db = require("../config/database");

exports.getProducts = async (req, res) => {
    const response = await db.query('SELECT * FROM products');
    res.status(200).send(response.rows);
};
