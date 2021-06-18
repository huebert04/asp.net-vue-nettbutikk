const { getProducts } = require('../controllers/products.controller');

const router = require('express-promise-router')();

router.get('/products', getProducts);

module.exports = router;
