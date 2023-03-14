import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';
class NotificationRepository {
    async getNotificationByAccountId(pageIndex, pageSize) {
        try {
            const response = await Repository.get(
                `${baseUrl}/Notification/api/list/ShowNotificationPaging?pageIndex=${pageIndex}&pageSize=${pageSize}`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getNotificationByAccount() {
        try {
            const response = await Repository.get(
                `${baseUrl}/Notification/api/list/account`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getNotificationNonReadByAccount() {
        try {
            const response = await Repository.get(
                `${baseUrl}/Notification/api/CountByNonReaded`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async markAsReadNotification(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const response = await Repository.post(
                `${baseUrl}/Notification/api/checkingReaded`,
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
export default new NotificationRepository();
