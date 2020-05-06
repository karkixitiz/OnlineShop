var app = new Vue({
    el: '#app',
    data: {
        price: 0,
        showPrice:false
    },
    computed: function(){
        formatPrice: function () {
            return "$" + this.price
        }
    },
    methods:{
        togglePrice: function () {
            this.showPrice = !this.showPrice
        }
    }

})