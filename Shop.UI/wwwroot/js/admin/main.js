﻿var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        productModel: {
            id: 0,
            objectIndex: 0, 
            name: "abc",
            description: "efg",
            value:12.2
        },
        products: []
    },
    methods: {
        getProduct(id) {
            this.loading = true
            axios.get('/Admin/products/'+id)
                .then(res => {
                    console.log(res);
                    var product = res.data;
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        value: product.value
                    }
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false
                });
        },
        getProducts(){
            this.loading=true
            axios.get('/Admin/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false
                });
        },
        createProduct() {
            this.loading = true;
            axios.post('/Admin/products', this.productModel)
                .then(res => {
                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false
                });
        },
        editProduct(id, index) {
            this.objectIndex = index;
            this.getProduct(id);
        },
        updateProduct() {
            this.loading = true;
            axios.put('/Admin/products', this.productModel)
                .then(res => {
                    this.products.splice(this.objectIndex, 1, res.data);
                    this.productModel=''
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false
                });
        },
        deleteProduct(id,index) {
            this.loading = true;
            axios.delete('/Admin/products/'+id)
                .then(res => {
                    this.products.splice(index, 1);
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false
                });
        },
    },
    computed: {

    },
    mounted() {
        this.getProducts();
    }
})