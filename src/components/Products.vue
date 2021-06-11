<template>
  <section>
      <b-card-group v-for="(product, index) in products" :key="product + index" class="col-md-5" >
        <b-card
          :title="product.title" 
          :img-src="product.image" img-top
          img-height="400"
          img-width="500">
          
          <b-card-text>
            {{product.description}}
          </b-card-text>
          <div slot="footer">
            <b-btn variant="primary" block>Add to Cart</b-btn>
          </div>
        </b-card>
      </b-card-group>
  </section>
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