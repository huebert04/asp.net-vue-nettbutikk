<template>
  <section>
      <ul v-if="product">
          <li>
              <img v-bind:src="product.image" height="200px" width="200px"/>
          </li>
      </ul>
  </section>
</template>

<script>
import axios from 'axios'

export default {
    name: 'ProductDetail',
    created() {
        this.getProductDetail(this.$route.params.id)
    },
    data: () => ({
        product: {}
    }),
    methods: {
        getProductDetail(id) {
            axios.get(`https://fakestoreapi.com/products/${id}`)
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