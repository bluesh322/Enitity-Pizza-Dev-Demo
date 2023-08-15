import axios from "axios";
const BASE_URL = "http://localhost:44472";

class ApiRequestHandler {

    static async request(endpoint, data = {}, method = "get") {
        console.debug("API Call:", endpoint, data, method);

        const url = `${BASE_URL}/${endpoint}`;
        const params = method === "get" ? data : {};

        try {
            return (await axios({ url, method, data, params })).data;
        } catch (err) {
            console.error("API Error:", err.response);
            let message = err.response.data.error.message;
            throw Array.isArray(message) ? message : [message];
        }
    }

    static async addCustomer(customerData) {
        const { name, address, phone } = customerData;
        let res = await this.request(`api/Customers`, { name, address, phone }, "post");
        const customer = res;

        console.log(customer);
        return customer;
    }
}

export default ApiRequestHandler;