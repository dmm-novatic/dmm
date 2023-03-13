import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';
class OrderRepository {
    async orderItem(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.post(
                `${baseUrl}/orders/api/add`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async addTransaction(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.post(
                `${baseUrl}/transactions/api/add`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getOrderHistory(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.get(
                `${baseUrl}/orders/api/SearchOrderByAcount?orderStatusId=${payload}`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getOrderDetail(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.get(
                `${baseUrl}/orderItem/api/GetListByOrderId?OrderID=${payload}`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async cancelOrderDetail(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.post(
                `${baseUrl}/orders/api/CancelOrder`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getPaymentMomoLink(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.post(
                `${baseUrl}/MomoPayment/api/PaymentWithMOMO`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async addNoti(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.post(
                `${baseUrl}/MomoPayment/api/NotifiURL`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
}
export default new OrderRepository();
