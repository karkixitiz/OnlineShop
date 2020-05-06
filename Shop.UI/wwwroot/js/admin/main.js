var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        productModel: {
            name: "abc",
            description: "efg",
            value:12.2
        },
        products: []
    },
    methods:{
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
        }
    },
    computed: {

    }
})