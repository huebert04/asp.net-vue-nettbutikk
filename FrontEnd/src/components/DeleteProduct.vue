<template>
  <v-container fluid>
    <v-card class="mx-auto" max-width="500" tile>
        <v-list rounded>
            <v-subheader>Products</v-subheader>
            <v-list-item-group color="primary" v-model="selectedItem" >
                <v-list-item v-for="product in products" :value="product.productID" :key="product.productID">
                    <v-list-item-content>
                        <v-list-item-title v-text="product.productName"></v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list-item-group>
        </v-list>
        <v-btn class="ma-4" @click="deleteProduct" color="error">Delete</v-btn>
    </v-card>
  </v-container>
</template>

<script>
import ProductService from '../services/ProductService'
export default {  
    created() {
        this.getProducts();
    },
    data: () => ({
        products: [],
        selectedItem: 0
    }),
    methods: {
        getProducts() {
            ProductService.getProducts().then(result => {
                this.products = result.data;
            }).catch(error => {
                console.log(error);
            })
        },
        deleteProduct() {
            if(confirm("Do you really want to delete this product?")){
                var index = this.products.map(function(x) {return x.productID}).indexOf(this.selectedItem);
                this.products.splice(index, 1);
                ProductService.deleteProduct(this.selectedItem).then(result => {
                    console.log(result.data);
                }).catch(error => {
                    console.log(error);
                })
            }
        }
    }
}
</script>

<style>
.container {
    display: flex;
    margin: 0 auto;
}
</style>