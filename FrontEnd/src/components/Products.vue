<template>
  <div>
    <!--<v-menu top offset-y>
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          color="primary"
          dark
          v-bind="attrs"
          v-on="on"
        >
          Select Category
        </v-btn>
      </template>

      <v-list>
        <v-list-item v-for="(category, index) in categories" :key="category + index" @click="getProductsByCategory(category.id)">
          <v-list-item-title>{{ category.title }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>-->

    <v-container fluid>
      <v-row dense>
        <v-col v-for="(product, index) in products" :key="product + index" cols="12">
          <v-card class="mx-auto" height="250">
            <div class="d-flex flex-no-wrap justify-space-between">
              <v-card-title>{{product.title}} - ${{product.price}}</v-card-title>
              <v-avatar
                class="ma-4"
                size="225"
                tile
              >
                <router-link :to="`/products/${product.id}`"><v-img :src="product.image" height="200" width="225"></v-img></router-link> 
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
    //this.getProductsByCategory(1);
  },
  data: () => ({
    products: [],
    categories: [
      {id: 1, title: 'Electronics'},
      {id: 2, title: 'Mens Clothing'},
      {id: 3, title: 'Womens Clothing'},
      {id: 4, title: 'Jewelery'}
    ],
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
    },
    getProductsByCategory(id) {
      console.log("clicked")

      if(id == 1) {
        let string = "electronics";
        let array = this.products.filter(item => item.category === string);
        this.products = array;
      } else if(id == 2) {
        let string = "men%27s%20clothing";
        this.products = this.products.filter(item => item.category === string);
      } else if(id == 3) {
        let string = "women%27s%20clothing";
        this.products = this.products.filter(item => item.category === string);
      } else if(id == 4) {
        let string = "jewelery";
        this.products = this.products.filter(item => item.category === string);
      }

      
    }
  }
}
</script>

<style>

</style>