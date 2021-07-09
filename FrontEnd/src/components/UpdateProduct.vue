<template>
    <v-container>
        <v-card class="mx-auto" max-width="600" tile>
            <v-list>
                <v-subheader>Products</v-subheader>
                <v-list-item-group color="primary" v-model="selectedItem"  >
                    <v-list-item v-for="product in products" :value="product.productID" :key="product.productID">
                        <v-list-item-content>
                            <v-list-item-title v-text="product.productName"></v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </v-list-item-group>
            </v-list>
            <v-dialog v-model="dialog" width="auto " :fullscreen="$vuetify.breakpoint.xsOnly">
                            <template v-slot:activator="{ on, attrs }">
                                <v-btn color="indigo" dark v-bind="attrs" v-on="on" @click="getByID"> Edit</v-btn>
                            </template>
                            <v-card>
                                <v-card-title>
                                    <span class="text-h5">Edit Product</span>
                                </v-card-title>
                                <v-card-text>
                                    <v-container>
                                        <v-row>
                                            <v-col cols="12" sm="6" md="4">
                                                <v-text-field
                                                label="Product Name"
                                                class="form-control"
                                                id="productName"
                                                required
                                                v-model="product.productName"
                                                name="productName"
                                            />
                                            </v-col>
                                            <v-col cols="12" sm="6" md="4">
                                                <v-text-field
                                                type="number"
                                                class="form-control"
                                                id="price"
                                                required
                                                v-model="product.price"
                                                name="price"
                                                label="Price"
                                            />
                                            </v-col>
                                            <v-col cols="12" sm="6" md="4">
                                                <v-text-field
                                                label="Category"
                                                type="text"
                                                class="form-control"
                                                id="category"
                                                required
                                                v-model="product.category"
                                                name="category"
                                            />
                                                
                                            </v-col>
                                            <v-col cols="12">
                                                
                                            <v-text-field
                                                label="Description"
                                                type="text"
                                                class="form-control"
                                                id="description"
                                                required
                                                v-model="product.description"
                                                name="description"
                                            />
                                            </v-col>
                                            <v-col cols="12">
                                                <v-text-field
                                                label="Image URL"
                                                type="text"
                                                class="form-control"
                                                id="image"
                                                required
                                                v-model="product.image"
                                                name="image"
                                            />
                                            </v-col>
                                        </v-row>
                                    </v-container>
                                </v-card-text>
        
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="blue darken-1" text @click="dialog = false"> Close </v-btn>
                                    <v-btn color="blue darken-1" text @click="updateProduct"> Save </v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
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
        product: {
            productID: null,
            productName: "",
            price: 0,
            description: "",
            category: "",
            image: ""
        },
        dialog: false,
        selectedItem: undefined
    }),
    methods: {
        getProducts() {
            ProductService.getProducts().then(result => {
                this.products = result.data;
            }).catch(error => {
                console.log(error);
            })
        },
        getByID() {
            if(this.selectedItem == undefined){
                alert("Please select a product to edit.")
            } else {
                var index = this.products.map(function(x) {return x.productID}).indexOf(this.selectedItem);
                this.product = this.products[index];
            }
            
        },
        updateProduct() {
            ProductService.updateProduct(this.selectedItem, this.product).then(result => {
                console.log(result.data);
                alert("Product update successful!")
                }).catch(error => {
                    console.log(error);
                })
        }
    }
}
</script>

<style>

</style>