import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';
class AccountRepository {
    async addToCart(payload) {
        try {
            const response = await Repository.post(
                `${baseUrl}/cart/api/add`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getCart() {
        try {
            const response = await Repository.get(
                `${baseUrl}/cart/api/ListbyAccountID`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getListCart() {
        try {
            const response = await Repository.get(
                `${baseUrl}/cart/api/ListbyAccountID`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async updateCart(payload) {
        try {
            const response = await Repository.post(
                `${baseUrl}/cart/api/update`,
                payload
            );

            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async deleteCart(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.post(
                `${baseUrl}/cart/api/delete`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async deleteListCart(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.post(
                `${baseUrl}/cart/api/DeleteListCart`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async countCartItem() {
        try {
            const response = await Repository.get(
                `${baseUrl}/cart/api/CountCart`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
}
export default new AccountRepository();
