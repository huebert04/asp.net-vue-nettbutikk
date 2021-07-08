<template>
  <div>
    <v-container fluid>
      <v-row dense>
        <v-col v-for="(product, index) in products" :key="product + index" cols="12">
          <v-card class="mx-auto" height="250">
            <div class="d-flex flex-no-wrap justify-space-between">
              <v-card-title>{{product.productName}} - ${{product.price}}</v-card-title>
              <v-avatar
                class="ma-4"
                size="225"
                tile
              >
                <router-link :to="`/products/${product.productID}`"><v-img :src="product.image" height="200" width="225"></v-img></router-link> 
              </v-avatar>
            </div>
          </v-card>
        </v-col> 
      </v-row>
  </v-container>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'ProductsList',
  created() {
    this.getProducts();
  },
  data: () => ({
    products: []
  }),
  methods: {
    getProducts() {
      axios.get('https://localhost:5001/api/product')
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