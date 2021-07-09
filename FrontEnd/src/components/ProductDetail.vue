<template>
    <v-container>
        <v-card class="mx-auto" max-width="600" tile>
            <v-img v-bind:src="product.image" height="300px" width="600px"></v-img>
            <v-card-title>{{product.productName}}</v-card-title>
            <v-card-subtitle>Price: ${{product.price}}</v-card-subtitle>
            <v-card-subtitle>Category: {{product.category}}</v-card-subtitle>
            <v-card-text>{{product.description}}</v-card-text>
        </v-card>
    </v-container>
  
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