<template>
  <v-form class="submit-form">
      <div v-if="!submitted">
          <div class="form-group">
              <v-text-field
                label="Product Name"
                class="form-control"
                id="productName"
                required
                v-model="product.productName"
                name="productName"
              />
          </div>

          <div class="form-group">
              <v-text-field
                type="number"
                class="form-control"
                id="price"
                required
                v-model="product.price"
                name="price"
                label="Price"
              />
          </div>

          <div class="form-group">
              <v-text-field
                label="Description"
                type="text"
                class="form-control"
                id="description"
                required
                v-model="product.description"
                name="description"
              />
          </div>

          <div class="form-group">
              <v-text-field
                label="Category"
                type="text"
                class="form-control"
                id="category"
                required
                v-model="product.category"
                name="category"
              />
          </div>

          <div class="form-group">
              <v-text-field
                label="Image URL"
                type="text"
                class="form-control"
                id="image"
                required
                v-model="product.image"
                name="image"
              />
          </div>

          <v-btn @click="addProduct" class="mr-4" color="success">Submit</v-btn>
      </div>

      <div v-else class="success">
        <h4>Product successfully added.</h4>
        <v-btn class="ma-2" outlined color="indigo" @click="newProduct">Add Another Product</v-btn>
      </div>
  </v-form>
</template>

<script>
import ProductService from '../services/ProductService';

export default {
  name: 'Add-Product',
  data: () => ({
    product: {
      productID: null,
        productName: "",
        price: 0,
        description: "",
        category: "",
        image: ""
    },
    submitted: false
  }),
  methods: {
    addProduct() {
      var data = {
        ProductName: this.product.productName,
        Price: this.product.price,
        Description: this.product.description,
        Category: this.product.category,
        Image: this.product.image
      }

      ProductService.createProduct(data).then(result => { 
        console.log(result.data);
        this.submitted = true;
        }).catch(error => {
          console.log(error);
        })
    },
    newProduct() {
      this.submitted = false;
      this.product = {};
    }
  }
}
</script>

<style>
.submit-form, .success {
  max-width: 500px;
  margin: auto;
}
</style>