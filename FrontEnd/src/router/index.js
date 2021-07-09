import Vue from 'vue'
import VueRouter from 'vue-router'
import Products from '../views/Products.vue'
import ProductDetail from '../components/ProductDetail.vue'
import AddProduct from '../components/AddProduct.vue';
import UpdateProduct from '../components/UpdateProduct';
import DeleteProduct from '../components/DeleteProduct';

Vue.use(VueRouter)

const routes = [
  {
    path: '/products',
    name: 'Products',
    component: Products
  },
  {
    path:'/products/:productID',
    name: 'ProductDetail',
    component: ProductDetail
  },
  {
    path: '/addProducts',
    name: 'Add Products',
    component: AddProduct
  },
  {
    path: '/updateProducts',
    name: 'Update Products',
    component: UpdateProduct
  },
  {
    path: '/deleteProducts',
    name: 'Delete Products',
    component: DeleteProduct
  }

]

const router = new VueRouter({
  mode: 'history',
  routes
})

export default router
