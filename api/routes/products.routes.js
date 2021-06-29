const { getProducts, createProduct, deleteProduct, getProduct } = require('../controllers/products.controller');

const router = require('express-promise-router')();

router.get('/products', getProducts);
router.get('/product/:id', getProduct);
router.post('/products', createProduct);
router.delete('/products/:id', deleteProduct);

module.exports = router;
