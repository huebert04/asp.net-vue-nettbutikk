const { getProducts, createProduct } = require('../controllers/products.controller');

const router = require('express-promise-router')();

router.get('/products', getProducts);
router.post('/products', createProduct);

module.exports = router;
