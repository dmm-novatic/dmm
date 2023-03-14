import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';
class AccountRepository {
    async registAccount(payload) {
        try {
            const response = await Repository.post(
                `${baseUrl}/Account/api/Add`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async updateAccount(payload) {
        try {
            const response = await Repository.post(
                `${baseUrl}/account/api/update`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async updatePassword(payload) {
        try {
            const response = await Repository.post(
                `${baseUrl}/Account/api/ChangePassword`,
                payload
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getAccount(userNames, passWords) {
        var slug = {};
        slug.username = userNames;
        slug.password = passWords;
        slug.accountTypeID = 1;
        slug.active = 1;
        slug.description = '';
        slug.email = '';
        slug.id = 1;
        slug.info = '';
        slug.name = '';
        slug.photo = '';
        try {
            const response = await Repository.post(
                `${baseUrl}/Account/api/Login`,
                slug
            );
            const data = Utils.handleResponse(response);
            return data[0];
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
}
export default new AccountRepository();
