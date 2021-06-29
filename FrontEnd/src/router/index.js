import Vue from 'vue'
import VueRouter from 'vue-router'
import Products from '../views/Products.vue'
import ProductDetail from '../components/ProductDetail.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/products',
    name: 'Products',
    component: Products
  },
  {
    path:'/products/:id',
    name: 'ProductDetail',
    component: ProductDetail
  }

]

const router = new VueRouter({
  mode: 'history',
  routes
})

export default router
