<template>
  <div>
    <b-container>
      <b-card-group deck v-for="(product, index) in products" :key="product + index">
        <b-card :title="product.title">
        </b-card>
        </b-card-group>
    </b-container>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'ProductsList',
  created() {
    this.getProducts()
  },
  data: () => ({
    products: []
  }),
  methods: {
    getProducts() {
      axios.get('https://fakestoreapi.com/products')
        // eslint-disable-next-line no-irregular-whitespace
        .then(result => {
          this.products = result.data
        }).catch(error => {
          console.log(error);
        })
    }
  }
}
</script>

<style>

</style>