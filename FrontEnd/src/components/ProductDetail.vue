<template>
  <section>
      <ul v-if="product">
          <li>
              <img v-bind:src="product.image" height="200px" width="200px"/>
              <p>{{product.productName}}</p>
              <p>{{product.description}}</p>
              <p>{{product.category}}</p>
              <p>{{product.price}}</p>
          </li>
      </ul>
  </section>
</template>

<script>

import ProductService from '../services/ProductService'

export default {
    name: 'ProductDetail',
    created() {
        this.getProductDetail(this.$route.params.productID)
    },
    data: () => ({
        product: {}
    }),
    methods: {
        getProductDetail(id) {
            ProductService.getByID(id)
                .then(result => {
                    this.product = result.data
                }).catch((error) => {
                    console.log(error);
                })
        }
    }
}
</script>

<style>

</style>