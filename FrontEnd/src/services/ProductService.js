import http from '../http-common';

class ProductService {
    getProducts() {
      return http.get("/product");
    }
  
    getByID(id) {
      return http.get(`/product/${id}`);
    }
  
    createProduct(data) {
      return http.post("/product", data);
    }
  
    updateProduct(id, data) {
      return http.put(`/product/${id}`, data);
    }
  
    deleteProduct(id) {
      return http.delete(`/product/${id}`);
    }
}

export default new ProductService();